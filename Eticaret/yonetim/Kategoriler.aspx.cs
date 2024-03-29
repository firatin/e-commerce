using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Eticaret.yonetim
{
    public partial class Kategoriler : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        public static string kategoriadi;
        string islem, KategoriId, AltKategoriId;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Kategori Ayarları";
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Kategori Ayarları";

            if (Page.IsPostBack == false)
            {

                KategoriGetir();

            }

            try
            {
                islem = Request.QueryString["islem"];
                KategoriId = Kontrol.SayiKontrol(Request.QueryString["Kategori"]);
                AltKategoriId = Kontrol.SayiKontrol(Request.QueryString["AltKat"]);


            }
            catch (Exception)
            {
                Response.Redirect("Kategoriler.aspx");
            }

            if (islem == "duzenle" && KategoriId != null)
            {
                if (Page.IsPostBack == false)
                {


                    DataRow drKategori = veri.GetDataRow("Select * From Kategoriler Where KategoriId=" + KategoriId + "");

                    btnAnaGit.Visible = true;
                    btnKategoriEkle.Visible = false;
                    btnDuzenle.Visible = true;
                    if (drKategori != null)
                    {
                        txtKategoriAdi.Text = drKategori["KategoriAdi"].ToString().Trim();

                        if (drKategori["Aktif"].ToString() == "True")
                        {
                            cbKatAktif.Checked = true;
                        }
                        else
                        {
                            cbKatAktif.Checked = false;
                        }
                    }
                }

            }
            else if (islem == "sil" && KategoriId != null)
            {

                veri.cmd("Update Kategoriler Set Sil='1' Where KategoriId=" + KategoriId + "");
                Response.Redirect("Kategoriler.aspx");
            }

            else if (islem == "Alt" && KategoriId != null)
            {
                // ana kategoriye ait alt kategoriler
                btnAnaGit.Visible = true;
                btnGeri.Visible = true;
                PanelAnaKategori.Visible = false;
                PanelAltKategori.Visible = true;

                kategoriadi = veri.GetDataCell("Select KategoriAdi From Kategoriler Where KategoriId=" + KategoriId + "");
                lblAna.Text = kategoriadi;
                lblAltBilgi.Text = kategoriadi + " Kategorisine ait Alt Kategoriler";
                ddAltKategori.SelectedValue = KategoriId;
                AltKategoriGetir();
            }
            else if (islem == "ad" && AltKategoriId != null && KategoriId != null)
            {
                // alt kategori düzenle

                btnGeri.Visible = true;
                btnAnaGit.Visible = true;
                lblAna.Text = kategoriadi;
                btnAltEkle.Visible = false;
                btnAltDuzenle.Visible = true;
                PanelAnaKategori.Visible = false;
                PanelAltKategori.Visible = true;
                ddAltKategori.Visible = true;
                KategoriDoldur();
                AltKategoriGetir();
                if (Page.IsPostBack == false)
                {

                    DataRow drKategori = veri.GetDataRow("Select * From AltKategoriler Where AltKategoriId=" + AltKategoriId + "");

                    if (drKategori != null)
                    {
                        txtAltKat.Text = drKategori["AltKategoriAdi"].ToString().Trim();

                        if (drKategori["Aktif"].ToString() == "True")
                        {
                            cbAltKat.Checked = true;
                        }
                        else
                        {
                            cbAltKat.Checked = false;
                        }
                    }
                }
            }
            else if (islem == "as" && AltKategoriId != null && KategoriId != null)
            {
                veri.cmd("Update AltKategoriler Set Sil='1' Where AltKategoriId=" + AltKategoriId + "");
                Response.Redirect("Kategoriler.aspx?islem=Alt&Kategori=" + KategoriId + "");
            }

        }

        protected void btnKategoriEkle_Click(object sender, EventArgs e)
        {
            int aktif = 0;
            if (cbKatAktif.Checked)
            {
                aktif = 1;
            }

            SqlConnection baglanti = veri.baglan();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_KategoriEkle";
            cmd.Parameters.AddWithValue("KategoriAdi", txtKategoriAdi.Text.Trim());
            cmd.Parameters.AddWithValue("Aktif", aktif);


            try
            {
                cmd.ExecuteNonQuery();

                Response.Redirect("Kategoriler.aspx");
            }
            catch (Exception)
            {
                Msg.Show("Bir hata meydana geldi");
            }
        }

        void KategoriGetir()
        {
            try
            {
                DataTable DtKayitlar = veri.GetDataTable("Select KategoriId,KategoriAdi, case Aktif when 1 then 'Aktif' when 0 then 'Pasif' end as Durumadi From Kategoriler Where Sil=0 ");

                CollectionPager1.DataSource = DtKayitlar.DefaultView;
                CollectionPager1.BindToControl = RpKayit;
                RpKayit.DataSource = CollectionPager1.DataSourcePaged;
                RpKayit.DataBind();
            }
            catch (Exception)
            {


            }


        }

        protected void btnDuzenle_Click(object sender, EventArgs e)
        {
            int aktif = 0;
            if (cbKatAktif.Checked)
            {
                aktif = 1;
            }

            SqlConnection baglanti = veri.baglan();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_KategoriDuzenle";
            cmd.Parameters.AddWithValue("KategoriAdi", txtKategoriAdi.Text.Trim());
            cmd.Parameters.AddWithValue("Aktif", aktif);
            cmd.Parameters.AddWithValue("KategoriId", KategoriId);

            try
            {
                cmd.ExecuteNonQuery();

                Response.Redirect("Kategoriler.aspx");
            }
            catch (Exception)
            {
                Msg.Show("Bir hata meydana geldi");
            }
        }


        void KategoriDoldur()
        {
            try
            {

                ddAltKategori.Items.Add("Ana Kategoriyi Değiştir");
                ddAltKategori.Items[0].Value = "0";
                DataTable dtArac = veri.GetDataTable("Select * From Kategoriler ");

                int sira = 1;
                for (int i = 0; i < dtArac.Rows.Count; i++)
                {
                    DataRow DrAracTipi = dtArac.Rows[i];
                    ddAltKategori.Items.Add(DrAracTipi["KategoriAdi"].ToString());
                    ddAltKategori.Items[sira].Value = DrAracTipi["KategoriId"].ToString();
                    sira++;
                }
            }
            catch (Exception)
            {

            }
        }

        protected void btnAltGit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Kategoriler.aspx?islem=Alt");
        }

        protected void btnAnaGit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Kategoriler.aspx");
        }

        void AltKategoriGetir()
        {
            try
            {

                DataTable DtAltKayitlar = veri.GetDataTable("Select AltKategoriId,AltKategoriAdi,KategoriId, case Aktif when 1 then 'Aktif' when 0 then 'Pasif' end as Durumadi From AltKategoriler Where KategoriId=" + KategoriId + " and Sil=0 ");
                rpAltKategori.DataSource = DtAltKayitlar;
                rpAltKategori.DataBind();

            }
            catch (Exception)
            {


            }

        }

        protected void btnAltEkle_Click(object sender, EventArgs e)
        {
            // qurystring url kontrl kategori varmı

            string katvarmi = veri.GetDataCell("Select top 1 KategoriId from Kategoriler where KategoriId="+KategoriId+" and Sil=0");
            if (katvarmi == null || katvarmi == "")
            {
                Response.Redirect("Kategoriler.aspx");
            }
            else
            {
                // alt kategori ekle
                int aktif = 0;
                if (cbAltKat.Checked)
                {
                    aktif = 1;
                }

                SqlConnection baglanti = veri.baglan();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_AltKategoriEkle";
                cmd.Parameters.AddWithValue("AltKategoriAdi", txtAltKat.Text.Trim());
                cmd.Parameters.AddWithValue("KategoriId", KategoriId);
                cmd.Parameters.AddWithValue("Aktif", aktif);


                try
                {
                    cmd.ExecuteNonQuery();

                    Response.Redirect("Kategoriler.aspx?islem=Alt&Kategori=" + KategoriId + "");
                }
                catch (Exception ex)
                {
                    Msg.Show("Bir hata meydana geldi" + ex.Message);
                }
            }

        }


        protected void btnAltDuzenle_Click(object sender, EventArgs e)
        {
            // alt kategori düzenle
            int aktif = 0;
            if (cbAltKat.Checked)
            {
                aktif = 1;
            }

            SqlConnection baglanti = veri.baglan();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_AltKategoriDuzenle";
            cmd.Parameters.AddWithValue("AltKategoriAdi", txtAltKat.Text.Trim());
            if (ddAltKategori.SelectedValue != "0")
            {
                cmd.Parameters.AddWithValue("KategoriId", ddAltKategori.SelectedValue);
            }
            else
            {
                cmd.Parameters.AddWithValue("KategoriId", KategoriId);
            }

            cmd.Parameters.AddWithValue("Aktif", aktif);
            cmd.Parameters.AddWithValue("AltKategoriId", AltKategoriId);


            try
            {
                cmd.ExecuteNonQuery();

                Response.Redirect("Kategoriler.aspx?islem=Alt&Kategori=" + KategoriId + "");
            }
            catch (Exception ex)
            {
                Msg.Show("Bir hata meydana geldi" + ex.Message);
            }
        }

        protected void btnGeri_Click(object sender, EventArgs e)
        {
            Response.Redirect("Kategoriler.aspx");
        }

       

    }
}