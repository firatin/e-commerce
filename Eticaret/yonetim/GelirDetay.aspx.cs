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
    public partial class GelirDetay : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        string islem = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Gelir Dağılımı";


            islem = Request.QueryString["islem"];

            if (islem == "bugun")
            {
                Bugunun();
            }
            else if (islem == "buhafta")
            {
                BuHafta();
            }
            else if (islem == "buay")
            {
                BuAy();
            }
            else
            {
                TumZamanlar();
            }

        }


        protected void btnAra_Click(object sender, EventArgs e)
        {
            string AranacakDeger = Kontrol.AramaKontrol(txtAra.Text);

            if (AranacakDeger != "")
            {
                 try
                {
                    DataTable dtSiparisler = veri.GetDataTable("SELECT dbo.Uyeler.Ad +' '+ dbo.Uyeler.Soyad as AdSoyad, dbo.Siparisler.SiparisId, dbo.Siparisler.UyeId, dbo.Siparisler.OdemeTipi, dbo.Siparisler.SiparisTarihi, dbo.SiparisDurum.DurumAdi,  dbo.Siparisler.DurumId,dbo.Siparisler.Tutar,CASE OdemeTipi WHEN 0 THEN 'Kredi Kartı' WHEN 1 THEN 'Havale/EFT' WHEN 2 THEN 'Kapıda Ödeme' END AS OdemeTip FROM  dbo.Siparisler INNER JOIN dbo.Uyeler ON dbo.Siparisler.UyeId = dbo.Uyeler.UyeId INNER JOIN dbo.SiparisDurum ON dbo.Siparisler.DurumId = dbo.SiparisDurum.DurumId Where IptalMi=0 and CONVERT(varchar(50), SiparisTarihi, 104) like '%" + AranacakDeger + "%' Order By SiparisId desc ");

                    if (dtSiparisler.Rows.Count >= 1)
                    {
                        double GenelToplam = Convert.ToDouble(veri.GetDataCell("SELECT SUM(dbo.Siparisler.Tutar) From Siparisler Where IptalMi=0 and SiparisTarihi like '%" + AranacakDeger + "%'" + ""));
                        lblBilgi.Text = "Tüm Zamanlar - Toplam " + dtSiparisler.Rows.Count + " sipariş bulunuyor. Genel Toplam: " + GenelToplam.ToString("c") + "";

                        lblAltBilgi.Text = lblBilgi.Text;

                        CollectionPager1.DataSource = dtSiparisler.DefaultView;
                        CollectionPager1.BindToControl = RpSiparisler;
                        RpSiparisler.DataSource = CollectionPager1.DataSourcePaged;
                        RpSiparisler.DataBind();
                    }
                    else
                    {
                        lblBilgi.Text = "Arama Sorgusuna Göre Kayıt Bulunamadı.";
                    }

                }
                catch (Exception)
                {

                }
            }
        }

        protected void btnBugun_Click(object sender, EventArgs e)
        {
            Response.Redirect("GelirDetay.aspx?islem=bugun");
        }

        protected void btnHafta_Click(object sender, EventArgs e)
        {
            Response.Redirect("GelirDetay.aspx?islem=buhafta");
        }

        protected void btnAy_Click(object sender, EventArgs e)
        {
            Response.Redirect("GelirDetay.aspx?islem=buay");
        }

        protected void btnTumu_Click(object sender, EventArgs e)
        {
            Response.Redirect("GelirDetay.aspx");
        }

        void Bugunun() // bugünün toplamı
        {
            if (!Page.IsPostBack)
            {
                try
                {

                    DataTable dtSiparisler = veri.GetDataTable("SELECT dbo.Uyeler.Ad +' '+ dbo.Uyeler.Soyad as AdSoyad, dbo.Siparisler.SiparisId, dbo.Siparisler.UyeId, dbo.Siparisler.OdemeTipi, dbo.Siparisler.SiparisTarihi, dbo.SiparisDurum.DurumAdi,  dbo.Siparisler.DurumId,dbo.Siparisler.Tutar,CASE OdemeTipi WHEN 0 THEN 'Kredi Kartı' WHEN 1 THEN 'Havale/EFT' WHEN 2 THEN 'Kapıda Ödeme' END AS OdemeTip FROM  dbo.Siparisler INNER JOIN  dbo.Uyeler ON dbo.Siparisler.UyeId = dbo.Uyeler.UyeId INNER JOIN dbo.SiparisDurum ON dbo.Siparisler.DurumId = dbo.SiparisDurum.DurumId Where IptalMi=0 and CONVERT(varchar(50), SiparisTarihi,  104) = CONVERT(varchar(50), GETDATE(), 104) Order By SiparisId desc");

                    if (dtSiparisler.Rows.Count >= 1)
                    {
                        double GenelToplam = Convert.ToDouble(veri.GetDataCell("SELECT SUM(Tutar) FROM Siparisler Where IptalMi=0 and CONVERT(varchar(50), SiparisTarihi,  104) = CONVERT(varchar(50), GETDATE(), 104)"));
                        lblBilgi.Text = "Bugün - Toplam " + dtSiparisler.Rows.Count + " sipariş bulunuyor. Genel Toplam: " + GenelToplam.ToString("c") + "";

                        lblAltBilgi.Text = lblBilgi.Text;
                        CollectionPager1.DataSource = dtSiparisler.DefaultView;
                        CollectionPager1.BindToControl = RpSiparisler;
                        RpSiparisler.DataSource = CollectionPager1.DataSourcePaged;
                        RpSiparisler.DataBind();
                    }
                    else
                    {
                        lblBilgi.Text = "Henüz kayıt yok.";
                    }

                }
                catch (Exception)
                {

                }
            }

        }
        void BuHafta() // son 7 günün toplamı
        {
            if (!Page.IsPostBack)
            {
                try
                {

                    DataTable dtSiparisler = veri.GetDataTable("SELECT   dbo.Uyeler.Ad +' '+ dbo.Uyeler.Soyad as AdSoyad, dbo.Siparisler.SiparisId, dbo.Siparisler.UyeId, dbo.Siparisler.OdemeTipi, dbo.Siparisler.SiparisTarihi, dbo.SiparisDurum.DurumAdi,  dbo.Siparisler.DurumId,dbo.Siparisler.Tutar,CASE OdemeTipi WHEN 0 THEN 'Kredi Kartı' WHEN 1 THEN 'Havale/EFT' WHEN 2 THEN 'Kapıda Ödeme' END AS OdemeTip FROM  dbo.Siparisler INNER JOIN  dbo.Uyeler ON dbo.Siparisler.UyeId = dbo.Uyeler.UyeId INNER JOIN dbo.SiparisDurum ON dbo.Siparisler.DurumId = dbo.SiparisDurum.DurumId Where IptalMi=0 and DATEDIFF(day, SiparisTarihi, getdate()) BETWEEN 0 AND 7 Order By SiparisId desc");

                    if (dtSiparisler.Rows.Count >= 1)
                    {
                        double GenelToplam = Convert.ToDouble(veri.GetDataCell("SELECT SUM(Tutar) FROM Siparisler Where IptalMi=0 and DATEDIFF(day, SiparisTarihi, getdate()) BETWEEN 0 AND 7 "));
                        lblBilgi.Text = "Bu Hafta - Toplam " + dtSiparisler.Rows.Count + " sipariş bulunuyor. Genel Toplam: " + GenelToplam.ToString("c") + "";

                        lblAltBilgi.Text = lblBilgi.Text;
                        CollectionPager1.DataSource = dtSiparisler.DefaultView;
                        CollectionPager1.BindToControl = RpSiparisler;
                        RpSiparisler.DataSource = CollectionPager1.DataSourcePaged;
                        RpSiparisler.DataBind();
                    }
                    else
                    {
                        lblBilgi.Text = "Henüz kayıt yok.";
                    }

                }
                catch (Exception)
                {

                }
            }

        }
        void BuAy() // bu ayın toplamı
        {
            if (!Page.IsPostBack)
            {
                try
                {

                    DataTable dtSiparisler = veri.GetDataTable("SELECT   dbo.Uyeler.Ad +' '+ dbo.Uyeler.Soyad as AdSoyad, dbo.Siparisler.SiparisId, dbo.Siparisler.UyeId, dbo.Siparisler.OdemeTipi, dbo.Siparisler.SiparisTarihi, dbo.SiparisDurum.DurumAdi, dbo.Siparisler.DurumId,dbo.Siparisler.Tutar,CASE OdemeTipi WHEN 0 THEN 'Kredi Kartı' WHEN 1 THEN 'Havale/EFT' WHEN 2 THEN 'Kapıda Ödeme'END AS OdemeTip FROM dbo.Siparisler INNER JOIN dbo.Uyeler ON dbo.Siparisler.UyeId = dbo.Uyeler.UyeId INNER JOIN  dbo.SiparisDurum ON dbo.Siparisler.DurumId = dbo.SiparisDurum.DurumId Where IptalMi=0 and DATEDIFF(month, SiparisTarihi, getdate()) BETWEEN 0 AND 1  Order By SiparisId desc");

                    if (dtSiparisler.Rows.Count >= 1)
                    {
                        double GenelToplam = Convert.ToDouble(veri.GetDataCell("SELECT SUM(Tutar) FROM Siparisler Where IptalMi=0 and DATEDIFF(month, SiparisTarihi, getdate()) BETWEEN 0 AND 1 "));
                        lblBilgi.Text = "Bu Ay - Toplam " + dtSiparisler.Rows.Count + " sipariş bulunuyor. Genel Toplam: " + GenelToplam.ToString("c") + "";

                        lblAltBilgi.Text = lblBilgi.Text;
                        CollectionPager1.DataSource = dtSiparisler.DefaultView;
                        CollectionPager1.BindToControl = RpSiparisler;
                        RpSiparisler.DataSource = CollectionPager1.DataSourcePaged;
                        RpSiparisler.DataBind();
                    }
                    else
                    {
                        lblBilgi.Text = "Henüz kayıt yok.";
                    }

                }
                catch (Exception)
                {

                }
            }

        }
        void TumZamanlar() // bütün zamanların toplamı
        {
            if (!Page.IsPostBack)
            {


                try
                {


                    DataTable dtSiparisler = veri.GetDataTable("SELECT dbo.Uyeler.Ad +' '+ dbo.Uyeler.Soyad as AdSoyad, dbo.Siparisler.SiparisId, dbo.Siparisler.UyeId, dbo.Siparisler.OdemeTipi, dbo.Siparisler.SiparisTarihi, dbo.SiparisDurum.DurumAdi,  dbo.Siparisler.DurumId,dbo.Siparisler.Tutar,CASE OdemeTipi WHEN 0 THEN 'Kredi Kartı' WHEN 1 THEN 'Havale/EFT' WHEN 2 THEN 'Kapıda Ödeme' END AS OdemeTip FROM  dbo.Siparisler INNER JOIN dbo.Uyeler ON dbo.Siparisler.UyeId = dbo.Uyeler.UyeId INNER JOIN dbo.SiparisDurum ON dbo.Siparisler.DurumId = dbo.SiparisDurum.DurumId Where IptalMi=0 Order By SiparisId desc ");

                    if (dtSiparisler.Rows.Count >= 1)
                    {
                        double GenelToplam = Convert.ToDouble(veri.GetDataCell("SELECT SUM(dbo.Siparisler.Tutar) From Siparisler Where IptalMi=0"));
                        lblBilgi.Text = "Tüm Zamanlar - Toplam " + dtSiparisler.Rows.Count + " sipariş bulunuyor. Genel Toplam: " + GenelToplam.ToString("c") + "";

                        lblAltBilgi.Text = lblBilgi.Text;
                        CollectionPager1.DataSource = dtSiparisler.DefaultView;
                        CollectionPager1.BindToControl = RpSiparisler;
                        RpSiparisler.DataSource = CollectionPager1.DataSourcePaged;
                        RpSiparisler.DataBind();
                    }
                    else
                    {
                        lblBilgi.Text = "Henüz kayıt yok.";
                    }

                }
                catch (Exception)
                {

                }
            }

        }
    }
}