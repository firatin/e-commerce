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
    public partial class Yorumlar : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        string islem = "", YorumId; string UyeId;
        string YorumQuery;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Ürün Yorumları";
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Ürün Yorumları";

            try
            {
                YorumQuery = Request.QueryString["Yorum"];

                if (Page.IsPostBack == false)
                {
                    if ( YorumQuery == "Onayli"|| YorumQuery==null)
                    {
                        AktifYorumGetir();
                    }
                   
                    else
                    {
                        PasifYorumGetir();
                    }
                   
                   
                }

            }
            catch (Exception)
            {
            }
            try
            {
                islem = Request.QueryString["islem"];
                Kontrol.SayiKontrol(YorumId = Request.QueryString["YorumId"]);
            }
            catch (Exception)
            {

            }

            if (islem == "sil" && YorumId != null)
            {
                veri.cmd("Delete From Yorumlar Where YorumId=" + YorumId + "");
                Response.Redirect("Yorumlar.aspx");
            }
            else if (islem == "detay" && YorumId != null)
            {
                PanelAna.Visible = false;
                PanelDetay.Visible = true;
                try
                {


                    if (Page.IsPostBack == false)
                    {
                    

                        DataRow DrBilgi = veri.GetDataRow("SELECT  dbo.Yorumlar.*,dbo.Urunler.UrunAdi, dbo.Uyeler.Ad, dbo.Uyeler.Soyad,Uyeler.Email FROM dbo.Yorumlar INNER JOIN dbo.Urunler ON dbo.Yorumlar.UrunId = dbo.Urunler.UrunId INNER JOIN dbo.Uyeler ON dbo.Yorumlar.UyeId = dbo.Uyeler.UyeId WHERE     (dbo.Yorumlar.YorumId =" + YorumId + ") ");

                        UyeId = DrBilgi["UyeId"].ToString();
                            UyeYeAitYorumlar();

                        if (DrBilgi["AktifMi"].ToString()=="True")
                        {
                            cbAktif.Checked = true;
                        }
                        else
                        {
                            cbAktif.Checked = false;
                        }

                        lblAdSoyad.Text = DrBilgi["Ad"].ToString() + " " + DrBilgi["Soyad"].ToString();
                        lblMail.Text = DrBilgi["Email"].ToString();
                        lblUrunAdi.Text = DrBilgi["UrunAdi"].ToString();
                        lblip.Text = DrBilgi["Ip"].ToString();
                        txtYorum.Text = DrBilgi["Yorum"].ToString().Trim();

                    }
                }
                catch (Exception)
                {
                }
            }

        }
        void AktifYorumGetir()
        {
            try
            {
                DataTable DtKayitlar = veri.GetDataTable("SELECT CASE dbo.Yorumlar.AktifMi WHEN '0' THEN 'Yorumu Aktif Yap' WHEN 1 THEN 'Yorumu Pasif Yap' END AS islemyap,CASE dbo.Yorumlar.AktifMi WHEN '0' THEN 'images/yorumonay.png' WHEN 1 THEN 'images/yorumiptal.png' END AS yorumresim, dbo.Yorumlar.*,dbo.Urunler.UrunAdi, dbo.Uyeler.Ad, dbo.Uyeler.Soyad,Uyeler.Email FROM dbo.Yorumlar INNER JOIN dbo.Urunler ON dbo.Yorumlar.UrunId = dbo.Urunler.UrunId INNER JOIN dbo.Uyeler ON dbo.Yorumlar.UyeId = dbo.Uyeler.UyeId WHERE     (dbo.Yorumlar.AktifMi=1) Order By Yorumlar.YorumId Desc");

                  if (DtKayitlar.Rows.Count >=1)
                {
                CollectionPager1.DataSource = DtKayitlar.DefaultView;
                CollectionPager1.BindToControl = RpKayit;

                RpKayit.DataSource = CollectionPager1.DataSourcePaged;
                RpKayit.DataBind();
                lblBilgi.Text = "Onaylı (" + DtKayitlar.Rows.Count + ") Yorum Listeleniyor.";
                }
                  else
                  {
                      lblBilgi.Text = "Henüz yorum yok.";
                  }
              
            }
            catch (Exception)
            {

            }
        }
        void PasifYorumGetir()
        {
            try
            {
                DataTable DtKayitlar = veri.GetDataTable("SELECT CASE dbo.Yorumlar.AktifMi WHEN '0' THEN 'Yorumu Aktif Yap' WHEN 1 THEN 'Yorumu Pasif Yap' END AS islemyap,CASE dbo.Yorumlar.AktifMi WHEN '0' THEN 'images/yorumonay.png' WHEN 1 THEN 'images/yorumiptal.png' END AS yorumresim, dbo.Yorumlar.*,dbo.Urunler.UrunAdi, dbo.Uyeler.Ad, dbo.Uyeler.Soyad,Uyeler.Email FROM dbo.Yorumlar INNER JOIN dbo.Urunler ON dbo.Yorumlar.UrunId = dbo.Urunler.UrunId INNER JOIN dbo.Uyeler ON dbo.Yorumlar.UyeId = dbo.Uyeler.UyeId WHERE     (dbo.Yorumlar.AktifMi=0) Order By Yorumlar.YorumId Desc");

                if (DtKayitlar.Rows.Count >=1)
                {
                    CollectionPager1.DataSource = DtKayitlar.DefaultView;
                    CollectionPager1.BindToControl = RpKayit;

                    RpKayit.DataSource = CollectionPager1.DataSourcePaged;
                    RpKayit.DataBind();
                    lblBilgi.Text = "Onay Bekleyen (" + DtKayitlar.Rows.Count + ") Yorum Listeleniyor.";  
                }
                else
                {
                    lblBilgi.Text = "Henüz onay bekleyen yorum yok.";
                }
               
                
            }
            catch (Exception)
            {

            }
        }
        void UyeYeAitYorumlar()
        {

            try
            {
                DataTable DtKayitlar = veri.GetDataTable("SELECT  dbo.Yorumlar.*,dbo.Urunler.UrunAdi, dbo.Uyeler.Ad, dbo.Uyeler.Soyad,Uyeler.Email,case Yorumlar.AktifMi when 0 then 'Pasif' when 1 then 'Aktif' end as DurumAdi FROM dbo.Yorumlar INNER JOIN dbo.Urunler ON dbo.Yorumlar.UrunId = dbo.Urunler.UrunId INNER JOIN dbo.Uyeler ON dbo.Yorumlar.UyeId = dbo.Uyeler.UyeId WHERE (dbo.Yorumlar.UyeId=" + UyeId + ") Order By Yorumlar.YorumId Desc");
                CollectionPager2.DataSource = DtKayitlar.DefaultView;
                CollectionPager2.BindToControl = RpUyeyeAitYorumlar;

                RpUyeyeAitYorumlar.DataSource = CollectionPager2.DataSourcePaged;
                RpUyeyeAitYorumlar.DataBind();
              
            }
            catch (Exception)
            {

            }
        }

        protected void btnOnayli_Click(object sender, EventArgs e)
        {
            Response.Redirect("Yorumlar.aspx?Yorum=Onayli");
        }

        protected void btnOnayBekleyen_Click(object sender, EventArgs e)
        {
            Response.Redirect("Yorumlar.aspx?Yorum=Onaysiz");
        }

        protected void btnAra_Click(object sender, EventArgs e)
        {
            if (txtAra.Text != "")
            {

                string deger = txtAra.Text.Trim();

                DataTable dtverigetir = veri.GetDataTable("SELECT CASE dbo.Yorumlar.AktifMi WHEN '0' THEN 'Yorumu Aktif Yap' WHEN 1 THEN 'Yorumu Pasif Yap' END AS islemyap,CASE dbo.Yorumlar.AktifMi WHEN '0' THEN 'images/yorumonay.png' WHEN 1 THEN 'images/yorumiptal.png' END AS yorumresim, dbo.Yorumlar.*,dbo.Urunler.UrunAdi, dbo.Uyeler.Ad, dbo.Uyeler.Soyad,Uyeler.Email FROM dbo.Yorumlar  INNER JOIN dbo.Urunler ON dbo.Yorumlar.UrunId = dbo.Urunler.UrunId INNER JOIN dbo.Uyeler ON dbo.Yorumlar.UyeId = dbo.Uyeler.UyeId Where Uyeler.Ad like '%" + deger + "%' OR Uyeler.Soyad like '%" + deger + "%' OR Yorumlar.YorumId like '%" + deger + "%' OR Uyeler.Email like '%" + deger + "%'  OR Urunler.UrunAdi like '%" + deger + "%' Order By Yorumlar.YorumId Desc ");

                RpKayit.DataSource = dtverigetir;

                RpKayit.DataBind();

                if (dtverigetir.Rows.Count > 0)
                {
                    lblBilgi.Text = "Arama Sonuçlandı, (" + dtverigetir.Rows.Count + ") Kayıt Listeleniyor";
                }
                else
                {
                    lblBilgi.Text = "Arama Kriterine Uygun Kayıt Bulunamadı";
                }

            }

            else
            {

                lblBilgi.Text = "Kayıt Yok";

            }
          
        }

        protected void btnVazgec_Click(object sender, EventArgs e)
        {
            Response.Redirect("Yorumlar.aspx");
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            int aktifmi = 0;

            if (cbAktif.Checked==true)
            {
                aktifmi = 1;
            }

            SqlConnection baglanti = veri.baglan();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_YorumDuzenle";

            cmd.Parameters.AddWithValue("Yorum",Kontrol.Yonlendirme(txtYorum.Text.Trim()));
            cmd.Parameters.AddWithValue("AktifMi",aktifmi);
            cmd.Parameters.AddWithValue("YorumId", YorumId);

            try
            {
                cmd.ExecuteNonQuery();
                Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Yorum Güncellendi'); window.location.href ='Yorumlar.aspx';</script>");
            }
            catch (Exception)
            {
                Msg.Show("Bir hata meydana geldi");
            
            }
        

        }

        protected void RpKayit_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "YorumOnay" && e.CommandArgument != null)
            {
                string Aktif = veri.GetDataCell("Select AktifMi From Yorumlar Where YorumId="+e.CommandArgument+"");



                if (Aktif == "True") // yorum aktifse pasif yap
                {
                   
                    veri.cmd("Update Yorumlar Set AktifMi=0 Where YorumId=" + e.CommandArgument + "");
                    Response.Redirect("Yorumlar.aspx?Yorum=Onayli");
                  
                }
                else // pasif ise aktif yap
                {
                   
                    veri.cmd("Update Yorumlar Set AktifMi=1 Where YorumId=" + e.CommandArgument + "");
                    Response.Redirect("Yorumlar.aspx?Yorum=Onaysiz");
                  
                }
               
             
            }
            else
            {
             
            }
        }
    }
}