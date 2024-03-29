using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.IO;

namespace Eticaret.yonetim
{
    public partial class Urunler : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        string islem = "", UrunId = "";
        string KategoriId, MarkaId, AltKategoriId, aramadeger, sorgu = "";

        protected void Page_Load(object sender, EventArgs e)
        {
           
            Page.Form.DefaultButton = btnAra.UniqueID;
            Page.Title = "Ürünler";
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Ürünler";

            try
            {
                if (Page.IsPostBack == false)
                {
                    TumUrunler();

                    // arama işlemleri
                    KategoriGetir();
                    MarkaGetir();
                    // arama son
                }

            }
            catch (Exception)
            {
            }

            try
            {
                islem = Request.QueryString["islem"];
                UrunId = Kontrol.SayiKontrol(Request.QueryString["UrunId"]);

                // arama

                KategoriId = Kontrol.Temizle(Kontrol.SayiKontrol(Request.QueryString["Kategori"]));
                AltKategoriId = Kontrol.Temizle(Kontrol.SayiKontrol(Request.QueryString["AltKategori"]));
                MarkaId = Kontrol.Temizle(Kontrol.SayiKontrol(Request.QueryString["Marka"]));
                aramadeger = Kontrol.AramaKontrol(Request.QueryString["Ara"]);


            }
            catch (Exception)
            {
            }

            if (islem == "sil" && UrunId != null)
            {
                //SqlConnection bgln = veri.baglan();
                //SqlCommand cmd = new SqlCommand("Select ResimYolu From Resimler Where UrunId=" + UrunId, bgln);
                //SqlDataReader droku = cmd.ExecuteReader();

                //ArrayList alistresimler = new ArrayList();
                //int i = 0;
                //while (droku.Read())
                //{
                //    i = i + 1;
                //    alistresimler.Add(droku[0].ToString());
                //}
                //if (alistresimler != null)
                //{
                //    foreach (object UrunResimleri in alistresimler)
                //    {
                //        FileInfo fi150sil = new FileInfo(Server.MapPath("../Resimler/Urun/150/") + UrunResimleri.ToString());
                //        fi150sil.Delete();

                //        FileInfo fiorjinalresim = new FileInfo(Server.MapPath("../Resimler/Urun/800/") + UrunResimleri.ToString());
                //        fiorjinalresim.Delete();

                //        veri.cmd("Delete From Resimler Where UrunId=" + UrunId);
                //    }
                //}

                veri.cmd("Update Urunler Set Sil=1 Where UrunId=" + UrunId + "");


                Response.Redirect("Urunler.aspx");
            }
            else if (islem == "bul")
            {
                if (KategoriId != "0" && KategoriId != null)
                {
                    sorgu = " and KategoriId=" + KategoriId + "";
                }
                if (AltKategoriId != "0" && AltKategoriId != null)
                {
                    sorgu = sorgu + " and AltKategoriId=" + AltKategoriId + "";
                }
                if (MarkaId != "0" && MarkaId != null)
                {
                    sorgu = sorgu + " and MarkaId=" + MarkaId + "";
                }
                if (aramadeger != "")
                {
                    sorgu = sorgu + "  and UrunAdi Like '%" + aramadeger + "%' ";
                }

                UrunAra();
            }
        }
        void TumUrunler()
        {
            DataTable DtKayitlar = veri.GetDataTable("Select *, Case Aktifmi when 1 then 'Aktif' when 0 then 'Pasif' end as Durumadi from Urunler Where Sil=0 Order By UrunId Desc ");
            CollectionPager1.DataSource = DtKayitlar.DefaultView;
            CollectionPager1.BindToControl = RpKayit;
            RpKayit.DataSource = CollectionPager1.DataSourcePaged;
            RpKayit.DataBind();
            lblBilgi.Text = "Tüm ürünler listeleniyor.";
        }

        protected void btnAra_Click(object sender, EventArgs e)
        {

            Response.Redirect("Urunler.aspx?islem=bul&Kategori=" + ddKategori.SelectedValue + "&AltKategori=" + ddAltKategori.SelectedValue + "&Marka=" + ddMarka.SelectedValue + "&Ara=" + txtAra.Text + "");

        }
        // ürün arama işlemleri 

        void UrunAra()
        {
            btnUrunler.Visible = true;
            try
            {
                DataTable DtKayitlar = veri.GetDataTable("Select *, Case Aktifmi when 1 then 'Aktif' when 0 then 'Pasif' end as Durumadi from Urunler  Where Sil=0 " + sorgu + " Order By UrunId Desc");

                CollectionPager1.DataSource = DtKayitlar.DefaultView;
                CollectionPager1.BindToControl = RpKayit;

                RpKayit.DataSource = CollectionPager1.DataSourcePaged;
                RpKayit.DataBind();

                if (DtKayitlar.Rows.Count > 0)
                {
                    lblBilgi.Text = "Arama Sonuçlandı, Kayıtlar Listeleniyor";
                }
                else
                {
                    lblBilgi.Text = "Arama Kriterine Uygun Kayıt Bulunamadı";
                }

            }
            catch (Exception)
            {

            }
        }
        #region
        void KategoriGetir()
        {
            if (Page.IsPostBack == false)
            {
                try
                {
                    ddKategori.Items.Add("Seçiniz");
                    ddKategori.Items[0].Value = "0";
                    DataTable dtArac = veri.GetDataTable("Select * From Kategoriler Where Aktif=1 and Sil =0 ");

                    int sira = 1;
                    for (int i = 0; i < dtArac.Rows.Count; i++)
                    {
                        DataRow DrAracTipi = dtArac.Rows[i];
                        ddKategori.Items.Add(DrAracTipi["KategoriAdi"].ToString());
                        ddKategori.Items[sira].Value = DrAracTipi["KategoriId"].ToString();
                        sira++;
                    }
                }
                catch (Exception)
                {

                }
            }
        }
        void MarkaGetir()
        {
            if (Page.IsPostBack == false)
            {
                try
                {
                    ddMarka.Items.Add("Seçiniz");
                    ddMarka.Items[0].Value = "0";
                    DataTable dtArac = veri.GetDataTable("Select * From Markalar Where Aktif=1 and Sil=0");

                    int sira = 1;
                    for (int i = 0; i < dtArac.Rows.Count; i++)
                    {
                        DataRow DrAracTipi = dtArac.Rows[i];
                        ddMarka.Items.Add(DrAracTipi["MarkaAdi"].ToString());
                        ddMarka.Items[sira].Value = DrAracTipi["MarkaId"].ToString();
                        sira++;
                    }
                }
                catch (Exception)
                {

                }
            }
        }
        #endregion

        // ürün arama alt kategori getir
        protected void ddKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddAltKategori.Items.Clear();
                ddAltKategori.Items.Add("Seçiniz");
                ddAltKategori.Items[0].Value = "0";
                DataTable dtModel = veri.GetDataTable("Select * From AltKategoriler Where KategoriId =" + ddKategori.SelectedValue + " and Aktif=1 and Sil=0");


                int sira = 1;
                for (int i = 0; i < dtModel.Rows.Count; i++)
                {
                    DataRow DrModel = dtModel.Rows[i];
                    ddAltKategori.Items.Add(DrModel["AltKategoriAdi"].ToString());
                    ddAltKategori.Items[sira].Value = DrModel["AltKategoriId"].ToString();
                    sira++;
                }

            }
            catch (Exception)
            {

            }
        }

        protected void btnUrunler_Click(object sender, EventArgs e)
        {
            TumUrunler();
        }

    }
}