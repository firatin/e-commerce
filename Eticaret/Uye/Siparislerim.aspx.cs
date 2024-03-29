using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Eticaret.Uye
{
    public partial class Siparislerim1 : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        string UyeId, SiparisId, GeldigiSayfa;
        protected void Page_Load(object sender, EventArgs e)
        {

            Page.Title = "Siparişlerim";
            if (Session["UyeId"] == null)
            {
                Response.Redirect("/Uyelik/Giris.aspx");
            }
            else
            {

                UyeId = Session["UyeId"].ToString();
                GeldigiSayfa = Request.QueryString["r"];
                SiparisId = Kontrol.SayiKontrol(Request.QueryString["Detay"]);

                if (SiparisId == null)
                {
                    divSiparisDetay.Visible = false;
                    SiparisGetir();
                }
                else
                {
                    btnGeri.Visible = true;
                    divSiparis.Visible = false;
                    SiparisDetayGetir();

                }

            }
        }

        void SiparisGetir()
        {
            if (Page.IsPostBack == false)
            {

                DataTable DtSiparislerim = veri.GetDataTable("SELECT CASE IptalMi WHEN '0' THEN 'Siparişi İptal Et' WHEN 1 THEN 'Sipariş İptali İçin Onay Bekleniyor' When 2 then 'Sipariş İptal Edildi' END AS iptalonay,CASE IptalMi WHEN '0' THEN '~/images/icon/siparisiptal.png' WHEN 1 THEN '~/images/icon/onaybekliyor.png' When 2 then '~/images/icon/iptaledildi.png' END AS iptalresim,dbo.Siparisler.*,case OdemeTipi When 0 Then 'Kredi Kartı' when 1 then 'Havale/EFT' when 2 then 'Kapıda Ödeme' end as OdemeTip,dbo.SiparisDurum.DurumAdi FROM  dbo.Siparisler INNER JOIN dbo.SiparisDurum ON dbo.Siparisler.DurumId = dbo.SiparisDurum.DurumId  where UyeId=" + UyeId + " Order By SiparisId Desc");
                CollectionPager1.DataSource = DtSiparislerim.DefaultView;
                CollectionPager1.BindToControl = RpSiparislerim;
                RpSiparislerim.DataSource = CollectionPager1.DataSourcePaged;
                RpSiparislerim.DataBind();
            }
        }

        void SiparisDetayGetir()
        {
            if (Page.IsPostBack == false)
            {

                DataTable DtSipariDetay = veri.GetDataTable("SELECT TOP (100) PERCENT CASE dbo.Sepet.IptalMi WHEN '0' THEN 'Siparişi İptal Et' WHEN 1 THEN 'Sipariş İptali İçin Onay Bekleniyor' When 2 then 'Sipariş İptal Edildi' END AS iptalonay,CASE dbo.Sepet.IptalMi WHEN '0' THEN '~/images/icon/siparisiptal.png' WHEN 1 THEN '~/images/icon/onaybekliyor.png' When 2 then '~/images/icon/iptaledildi.png' END AS iptalresim,  dbo.Siparisler.SiparisId,dbo.Siparisler.UyeId, dbo.Siparisler.SiparisTarihi, dbo.Siparisler.TeslimTarihi, dbo.Sepet.Miktar, dbo.Sepet.UrunId,dbo.Sepet.SepetId, dbo.Urunler.UrunAdi, dbo.Siparisler.KargoId, dbo.Kargolar.KargoAdi FROM  dbo.Siparisler INNER JOIN dbo.Sepet ON dbo.Siparisler.SiparisId = dbo.Sepet.SiparisId INNER JOIN dbo.Urunler ON dbo.Sepet.UrunId = dbo.Urunler.UrunId INNER JOIN dbo.Kargolar ON dbo.Siparisler.KargoId = dbo.Kargolar.KargoId WHERE (dbo.Siparisler.SiparisId = " + SiparisId + " and dbo.Siparisler.UyeId=" + UyeId + ")");

                if (DtSipariDetay.Rows.Count >= 1)
                {
                    lblBilgi.Text = "Sipariş Detayları";

                    CollectionPager1.DataSource = DtSipariDetay.DefaultView;
                    CollectionPager1.BindToControl = RpSiparisDetay;
                    RpSiparisDetay.DataSource = CollectionPager1.DataSourcePaged;
                    RpSiparisDetay.DataBind();
                }
                else
                {
                    Response.Redirect("/Uye/Siparislerim.aspx");
                }
            }

        }

        protected void btnGeri_Click(object sender, EventArgs e)
        {
            if (GeldigiSayfa == "Kargo")
            {
                Response.Redirect("Kargom.aspx");
            }
            else
            {
                Response.Redirect("/Uye/Siparislerim.aspx");
            }

        }

        protected void RpSiparislerim_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "iptalEt" && e.CommandArgument != null)
            {

                DataRow DegerGetir = veri.GetDataRow("Select IptalMi,SiparisTarihi From Siparisler Where SiparisId=" + e.CommandArgument + "");

                if (DegerGetir["IptalMi"].ToString() == "0")
                {
                    // eğer 3 saat geçmediyse iptal edilebilsin

                    DateTime SiparisSaati = Convert.ToDateTime(DegerGetir["SiparisTarihi"]);
                    DateTime SimdikiSaat = System.DateTime.Now;
                    TimeSpan SaatFarklari = SimdikiSaat - SiparisSaati;

                    // eğer 1 günden az ve 3 saatten az ise iptal et. yarın aynı saatte iptal edemesin diye gün olayını ekledim.
                    if (SaatFarklari.Days == 0 && SaatFarklari.Hours <= 3)
                    {
                        veri.cmd("Update Siparisler Set IptalMi=1 Where SiparisId=" + e.CommandArgument + "");
                        // siparişi iptal ederse içerisindeki ürünler de iptal olacak.
                        veri.cmd("Update Sepet Set IptalMi=1 Where SiparisId=" + e.CommandArgument + "");
                        Response.Redirect("Siparislerim.aspx");
                    }
                    else
                    {
                        Msg.Show("Başarısız! Bir siparişi satın aldıktan sonraki ilk 3 saat içerisinde iptal edebilirsiniz.");
                    }

                }
                else if (DegerGetir["IptalMi"].ToString() == "1")
                {
                    Msg.Show("Bu siparişi daha önce iptal ettiniz, sipariş iptali için onay bekleniyor.");
                }
                else if (DegerGetir["IptalMi"].ToString() == "2")
                {
                    Msg.Show("İptal ettiğiniz bir ürünü aktif edemezsiniz.");
                }

            }
        }


        protected void RpSiparisDetay_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            // sipariş detaylarındaki ürünler.

            if (e.CommandName == "iptalEt" && e.CommandArgument != null)
            {

                DataRow DegerGetir = veri.GetDataRow("Select IptalMi,Tarih From Sepet Where SepetId=" + e.CommandArgument + "");

                if (DegerGetir["IptalMi"].ToString() == "0")
                {
                    // eğer 3 saat geçmediyse iptal edilebilsin

                    DateTime SiparisSaati = Convert.ToDateTime(DegerGetir["Tarih"]);
                    DateTime SimdikiSaat = System.DateTime.Now;
                    TimeSpan SaatFarklari = SimdikiSaat - SiparisSaati;

                    // eğer 1 günden az ve 3 saatten az ise iptal et. yarın aynı saatte iptal edemesin diye gün olayını ekledim.
                    if (SaatFarklari.Days == 0 && SaatFarklari.Hours <= 3)
                    {
                        veri.cmd("Update Sepet Set IptalMi=1 Where SepetId=" + e.CommandArgument + "");
                        Response.Redirect("Siparislerim.aspx?Detay=" + SiparisId + "");
                    }
                    else
                    {
                        Msg.Show("Başarısız! Bir siparişi satın aldıktan sonraki ilk 3 saat içerisinde iptal edebilirsiniz.");
                    }

                }
                else if (DegerGetir["IptalMi"].ToString() == "1")
                {
                    Msg.Show("Bu siparişi daha önce iptal ettiniz, sipariş iptali için onay bekleniyor.");
                }
                else if (DegerGetir["IptalMi"].ToString() == "2")
                {
                    Msg.Show("İptal ettiğiniz bir ürünü aktif edemezsiniz.");
                }

            }

        }


    }
}