using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

namespace Eticaret.yonetim
{
    public partial class Default : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        string Uyeler, Urunler, Yorumlar;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Hoş Geldiniz. ";

            if (Page.IsPostBack == false)
            {
                BilgiGetir();
                KritikStokGetir();
            }

        }

        void BilgiGetir()
        {
            try
            {

                Uyeler = veri.GetDataCell("Select COUNT(UyeId) From Uyeler where Sil=0");
                pUyeler.InnerText = Uyeler;

                Urunler = veri.GetDataCell("Select COUNT(UrunId) From Urunler where Aktifmi =1 and Sil=0");
                pUrunler.InnerText = Urunler;

                Yorumlar = veri.GetDataCell("Select COUNT(YorumId) From Yorumlar");
                pYorumlar.InnerText = Yorumlar;
                // son üyeler
                DataTable dtUyeler = veri.GetDataTable("Select Top 5 Case UyeTip When 0 then 'Üye' When 1 then 'Bayi' end as BayiMi, UyeId,Ad,Soyad,Email,KayitTarihi From Uyeler where Sil=0 Order By UyeId Desc");

                if (dtUyeler.Rows.Count > 0)
                {
                    RpUyeler.DataSource = dtUyeler;
                    RpUyeler.DataBind();
                }
                else
                {
                    divSonUyeler.InnerText = "Henüz Kayıt Bulunmuyor.";
                }
                // en çok incelenen ürünler

                DataTable dtUrunler = veri.GetDataTable("Select Top 6 UrunId,UrunAdi,Hit From Urunler Order By Hit desc");
                if (dtUrunler.Rows.Count > 0)
                {
                    RpincelenenUrun.DataSource = dtUrunler;
                    RpincelenenUrun.DataBind();
                }
                else
                {
                    divEnCokincelenen.InnerText = "Henüz Kayıt Bulunmuyor.";
                }


                //chart en çok satılan ürünler
                DataSet dsUrunler = veri.GetDataSet("SELECT TOP (5) dbo.Urunler.UrunAdi, COUNT(dbo.Sepet.UrunId) AS UrunId, dbo.Sepet.SatildiMi FROM dbo.Sepet INNER JOIN dbo.Urunler ON dbo.Sepet.UrunId = dbo.Urunler.UrunId GROUP BY dbo.Urunler.UrunAdi,dbo.Sepet.SatildiMi HAVING (dbo.Sepet.SatildiMi = 1)");

                if (dsUrunler.Tables[0].Rows.Count > 0)
                {
                    chCokSatilan.DataSource = dsUrunler;
                    chCokSatilan.DataBind();
                }
                else
                {
                    divEnCokSatilanUrun.InnerText = "Henüz Kayıt Bulunmuyor.";
                }


                // en çok Alışveriş yapan üyeler
                DataSet dtEnckoSatilan = veri.GetDataSet("SELECT TOP (5)  dbo.Uyeler.UyeId, dbo.Uyeler.Ad+ ' '+ dbo.Uyeler.Soyad as 'AdSoyad', COUNT(dbo.Sepet.UrunId) AS UrunId, dbo.Sepet.SatildiMi FROM   dbo.Sepet INNER JOIN  dbo.Uyeler ON dbo.Sepet.UyeId = dbo.Uyeler.UyeId GROUP BY dbo.Uyeler.Ad, dbo.Uyeler.Soyad, dbo.Uyeler.UyeId, dbo.Sepet.SatildiMi HAVING (dbo.Sepet.SatildiMi = 1)");

                if (dtEnckoSatilan.Tables[0].Rows.Count > 0)
                {
                    chEncokUrunAlan.DataSource = dtEnckoSatilan;
                    chEncokUrunAlan.DataBind();
                }
                else
                {
                    divEnCokAlisvarisYapan.InnerText = "Henüz Kayıt Bulunmuyor.";
                }

                // bugünün gelirleri
                DataTable dtgununGelirleri = veri.GetDataTable("SELECT Top 5 dbo.Uyeler.Ad +' '+ dbo.Uyeler.Soyad as AdSoyad, dbo.Siparisler.SiparisId, dbo.Siparisler.UyeId, dbo.Siparisler.SiparisTarihi,dbo.Siparisler.Tutar FROM  dbo.Siparisler INNER JOIN  dbo.Uyeler ON dbo.Siparisler.UyeId = dbo.Uyeler.UyeId INNER JOIN dbo.SiparisDurum ON dbo.Siparisler.DurumId = dbo.SiparisDurum.DurumId Where IptalMi=0 and CONVERT(varchar(50), SiparisTarihi,  104) = CONVERT(varchar(50), GETDATE(), 104) Order By SiparisId desc");

                if (dtgununGelirleri.Rows.Count > 0)
                {
                    double GenelToplam = Convert.ToDouble(veri.GetDataCell("SELECT SUM(Tutar) FROM Siparisler Where IptalMi=0 and CONVERT(varchar(50), SiparisTarihi,  104) = CONVERT(varchar(50), GETDATE(), 104)"));
                    lblBugun.Text = "Bugün - Toplam " + dtgununGelirleri.Rows.Count + " sipariş bulunuyor. Genel Toplam: " + GenelToplam.ToString("c") + "";

                    RpGununSiparisleri.DataSource = dtgununGelirleri;
                    RpGununSiparisleri.DataBind();

                }
                else
                {
                    divGununSiparisleri.InnerText = "Henüz Sipariş Bulunmuyor.";
                }

                // Son 1 ayın en pahalı 5 alışverişi
                DataTable dtBuAy = veri.GetDataTable("SELECT Top 5  dbo.Uyeler.Ad +' '+ dbo.Uyeler.Soyad as AdSoyad, dbo.Siparisler.SiparisId, dbo.Siparisler.UyeId, dbo.Siparisler.SiparisTarihi,dbo.Siparisler.Tutar FROM  dbo.Siparisler INNER JOIN  dbo.Uyeler ON dbo.Siparisler.UyeId = dbo.Uyeler.UyeId INNER JOIN dbo.SiparisDurum ON dbo.Siparisler.DurumId = dbo.SiparisDurum.DurumId Where IptalMi=0 and DATEDIFF(month, SiparisTarihi, getdate()) BETWEEN 0 AND 1  Order By Tutar desc");

                if (dtBuAy.Rows.Count > 0)
                {
                    double GenelToplam = Convert.ToDouble(veri.GetDataCell("SELECT SUM(Tutar) FROM Siparisler Where IptalMi=0 and DATEDIFF(month, SiparisTarihi, getdate()) BETWEEN 0 AND 1"));
                    lblBuay.Text = "Toplam " + dtBuAy.Rows.Count + " sipariş bulunuyor. Genel Toplam: " + GenelToplam.ToString("c") + "";

                    RpBuAy.DataSource = dtBuAy;
                    RpBuAy.DataBind();

                }
                else
                {
                    divSonBirAy.InnerText = "Henüz Sipariş Bulunmuyor.";
                }

            }
            catch (Exception)
            {

            }
        }

        void KritikStokGetir()
        {
            try
            {

                DataTable DtKayitlar = veri.GetDataTable("Select Case Aktifmi when 1 then 'Aktif' when 0 then 'Pasif' end as Durumadi,UrunId,StokKodu,UrunAdi,StokMiktari,SatisFiyati,Hit,AnaResim150 from Urunler Where Sil=0 and StokMiktari<=10 and AktifMi=1 Order By StokMiktari Asc");

                if (DtKayitlar.Rows.Count >= 1)
                {
                    CollectionPager1.DataSource = DtKayitlar.DefaultView;
                    CollectionPager1.BindToControl = RpKayit;
                    RpKayit.DataSource = CollectionPager1.DataSourcePaged;
                    RpKayit.DataBind();
                    lblBilgi.Text = " - " + DtKayitlar.Rows.Count + " Kritik Stoklu Ürün Var.";

                        //Msg.Mesaj(this, eStatusType.Uyari, "<br/> " + DtKayitlar.Rows.Count + " Kritik Stoklu Ürün Var."); 
                  
                }
                else
                {
                    divstok.InnerText = "Henüz Ürün Bulunmuyor. ";
                }

                pStok.InnerText = DtKayitlar.Rows.Count.ToString();
            }
            catch (Exception)
            {


            }

        }
    }
}