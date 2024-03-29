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
    public partial class Varyantlar : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        public static string VaryantAdi;
        string islem, AnaVaryantId, AltVaryantId;

        protected void Page_Load(object sender, EventArgs e)
        {
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Varyant Yönetimi";

            if (Page.IsPostBack == false)
            {

                VaryantGetir();

            }

            try
            {
                islem = Request.QueryString["islem"];
                AnaVaryantId = Kontrol.SayiKontrol(Request.QueryString["v"]);
                AltVaryantId = Kontrol.SayiKontrol(Request.QueryString["Alt"]);

            }
            catch (Exception)
            {
                Response.Redirect("Varyantlar.aspx");
            }

            if (islem == "duzenle" && AnaVaryantId != null)
            {
                tbVaryantEkle.Visible = true;
                if (Page.IsPostBack == false)
                {


                    DataRow drKategori = veri.GetDataRow("Select * From AnaVaryant Where AnaVaryantId=" + AnaVaryantId + "");

                    btnAnaGit.Visible = true;
                    btnKategoriEkle.Visible = false;
                    btnDuzenle.Visible = true;
                    if (drKategori != null)
                    {
                        txtKategoriAdi.Text = drKategori["VaryantAdi"].ToString().Trim();

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
            else if (islem == "sil" && AnaVaryantId != null)
            {

                veri.cmd("Update AnaVaryant Set Sil='1' Where AnaVaryantId=" + AnaVaryantId + "");
                Response.Redirect("Varyantlar.aspx");
            }

            else if (islem == "Alt" && AnaVaryantId != null)
            {
                // ana kategoriye ait alt kategoriler
                btnAnaGit.Visible = true;
                btnGeri.Visible = true;
                PanelAnaKategori.Visible = false;
                PanelAltKategori.Visible = true;

                VaryantAdi = veri.GetDataCell("Select VaryantAdi From AnaVaryant Where AnaVaryantId=" + AnaVaryantId + "");
                lblAna.Text = VaryantAdi;
                lblAltBilgi.Text = VaryantAdi + " Kategorisine ait Alt Varyantlar";
                ddAltKategori.SelectedValue = AnaVaryantId;
                AltKategoriGetir();
            }
            else if (islem == "ad" && AltVaryantId != null && AnaVaryantId != null)
            {
                // alt kategori düzenle

                btnGeri.Visible = true;
                btnAnaGit.Visible = true;
                lblAna.Text = VaryantAdi;
                btnAltEkle.Visible = false;
                btnAltDuzenle.Visible = true;
                PanelAnaKategori.Visible = false;
                PanelAltKategori.Visible = true;
                ddAltKategori.Visible = true;
                KategoriDoldur();
                AltKategoriGetir();
                if (Page.IsPostBack == false)
                {

                    DataRow drKategori = veri.GetDataRow("Select * From AltVaryantlar Where AltVaryantId=" + AltVaryantId + "");

                    if (drKategori != null)
                    {
                        txtAltKat.Text = drKategori["AltVaryantAdi"].ToString().Trim();

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
            else if (islem == "as" && AltVaryantId != null && AnaVaryantId != null)
            {
                veri.cmd("Update AltVaryantlar Set Sil='1' Where AltVaryantId=" + AltVaryantId + "");
                Response.Redirect("Varyantlar.aspx?islem=Alt&v=" + AnaVaryantId + "");
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
            cmd.CommandText = "sp_VaryantEkle";
            cmd.Parameters.AddWithValue("@VaryantAdi", txtKategoriAdi.Text.Trim());
            cmd.Parameters.AddWithValue("Aktif", aktif);


            try
            {
                cmd.ExecuteNonQuery();

                Response.Redirect("Varyantlar.aspx");
            }
            catch (Exception)
            {
                Msg.Show("Bir hata meydana geldi");
            }
        }

        void VaryantGetir()
        {
            try
            {
                DataTable DtKayitlar = veri.GetDataTable("Select AnaVaryantId,VaryantAdi, case Aktif when 1 then 'Aktif' when 0 then 'Pasif' end as Durumadi From AnaVaryant Where Sil=0 ");

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
            cmd.CommandText = "sp_VaryantDuzenle";
            cmd.Parameters.AddWithValue("@VaryantAdi", txtKategoriAdi.Text.Trim());
            cmd.Parameters.AddWithValue("@Aktif", aktif);
            cmd.Parameters.AddWithValue("@AnaVaryantId", AnaVaryantId);

            try
            {
                cmd.ExecuteNonQuery();

                Response.Redirect("Varyantlar.aspx");
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

                ddAltKategori.Items.Add("Ana Varyant Değiştir");
                ddAltKategori.Items[0].Value = "0";
                DataTable dtArac = veri.GetDataTable("Select * From AnaVaryant ");

                int sira = 1;
                for (int i = 0; i < dtArac.Rows.Count; i++)
                {
                    DataRow DrAracTipi = dtArac.Rows[i];
                    ddAltKategori.Items.Add(DrAracTipi["VaryantAdi"].ToString());
                    ddAltKategori.Items[sira].Value = DrAracTipi["AnaVaryantId"].ToString();
                    sira++;
                }
            }
            catch (Exception)
            {

            }
        }

        protected void btnAltGit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Varyantlar.aspx?islem=Alt");
        }

        protected void btnAnaGit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Varyantlar.aspx");
        }

        void AltKategoriGetir()
        {
            try
            {

                DataTable DtAltKayitlar = veri.GetDataTable("Select AltVaryantId,AltVaryantAdi,AnaVaryantId, case Aktif when 1 then 'Aktif' when 0 then 'Pasif' end as Durumadi From AltVaryantlar Where AnaVaryantId=" + AnaVaryantId + " and Sil=0 ");
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

            string katvarmi = veri.GetDataCell("Select top 1 AnaVaryantId from AnaVaryant where AnaVaryantId=" + AnaVaryantId + " and Sil=0");
            if (katvarmi == null || katvarmi == "")
            {
                Response.Redirect("Varyantlar.aspx");
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
                cmd.CommandText = "sp_AltVaryantEkle";
                cmd.Parameters.AddWithValue("@AltVaryantAdi", txtAltKat.Text.Trim());
                cmd.Parameters.AddWithValue("@AnaVaryantId", AnaVaryantId);
                cmd.Parameters.AddWithValue("@Aktif", aktif);


                try
                {
                    cmd.ExecuteNonQuery();

                    Response.Redirect("Varyantlar.aspx?islem=Alt&v=" + AnaVaryantId + "");
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
            cmd.CommandText = "sp_AltVaryantDuzenle";
            cmd.Parameters.AddWithValue("@AltVaryantAdi", txtAltKat.Text.Trim());
            if (ddAltKategori.SelectedValue != "0")
            {
                cmd.Parameters.AddWithValue("@AnaVaryantId", ddAltKategori.SelectedValue);
            }
            else
            {
                cmd.Parameters.AddWithValue("@AnaVaryantId", AnaVaryantId);
            }

            cmd.Parameters.AddWithValue("Aktif", aktif);
            cmd.Parameters.AddWithValue("@AltVaryantId", AltVaryantId);


            try
            {
                cmd.ExecuteNonQuery();

                Response.Redirect("Varyantlar.aspx?islem=Alt&v=" + AnaVaryantId + "");
            }
            catch (Exception ex)
            {
                Msg.Show("Bir hata meydana geldi" + ex.Message);
            }
        }

        protected void btnGeri_Click(object sender, EventArgs e)
        {
            Response.Redirect("Varyantlar.aspx");
        }



    }
}