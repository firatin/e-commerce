using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Eticaret
{
    public partial class Ana : System.Web.UI.MasterPage
    {
        baglanti veri = new baglanti();
        string UyeId, UyeTip;
        public string Logo, Title, Face, Twit, Tel1, Mail;
        double SatisFiyati, Kdv, Toplam, SatisFiyatToplam;
        DataTable dtSepet;
        public DataTable drReklam;
        public string Rurl, Rlogo, Rtitle;
        protected void Page_Load(object sender, EventArgs e)
        {
            // logo
           
            LogoGetir();
            KurGetir();
            // footer reklam

            FooterReklam();//footer orta reklam
            SolReklamAlan();//footer sol reklam
            if (Session["UyeId"] == null)
            {
                PanelZiyaretci.Visible = true;
                divPanelSepetim.Visible = false;
                ulUye.Visible = false;
            }
            else
            {
                //ulziyaretci.Visible = false;
                UyeId = Session["UyeId"].ToString();
                PanelUye.Visible = true;
                PanelZiyaretci.Visible = false;
                lblAdSoyad.Text = Session["Ad"].ToString() + " " + Session["Soyad"].ToString();
                PanelHesap.Visible = true;
                string Yetki = veri.GetDataCell("Select UyeYetki From Uyeler Where UyeId=" + UyeId + "");
                if (Yetki == "1")
                {
                    PanelYonet.Visible = true;
                }
                else
                {
                    PanelYonet.Visible = false;
                }

                // master sepetim
                SepetDoldur();
            }

            try
            {
                if (Page.IsPostBack == false)
                {
                    AnaKategoriGetir();
                    SayfaGetir();
                    YeniUrunGetir();
                    indirimliUrunGetir();
                    BilgiGet();
                }

            }
            catch (Exception)
            {

            }

        }

        void SepetDoldur()
        {
            if (Page.IsPostBack == false)
            {
                dtSepet = veri.GetDataTable(" SELECT dbo.Urunler.UrunAdi, dbo.Urunler.BayiFiyati, dbo.Urunler.Kdv, dbo.Urunler.AnaResim150, dbo.Urunler.SatisFiyati,((SatisFiyati - indirim) * Kdv/100+SatisFiyati-indirim) * Miktar As UyeSatisFiyatiKdvli,((BayiFiyati - BayiIndirim) * Kdv/100+BayiFiyati-BayiIndirim)* Miktar as BayiSatisFiyatiKdvli , SUM(dbo.Urunler.SatisFiyati * dbo.Sepet.Miktar) AS ToplamFiyat,SUM(dbo.Urunler.SatisFiyati*dbo.Sepet.Miktar-dbo.Urunler.indirim*dbo.Sepet.Miktar ) AS indirimliFiyat,SUM(dbo.Urunler.BayiFiyati*dbo.Sepet.Miktar-dbo.Urunler.BayiIndirim*dbo.Sepet.Miktar ) AS indirimliBayiFiyat, dbo.Sepet.SepetId, dbo.Sepet.UrunId, dbo.Sepet.UyeId, dbo.Sepet.Tarih, dbo.Sepet.UyeIp, dbo.Sepet.SiparisId, dbo.Sepet.Miktar, SUM(dbo.Urunler.BayiFiyati * dbo.Sepet.Miktar) AS ToplamBayiFiyati FROM dbo.Sepet INNER JOIN dbo.Urunler ON dbo.Sepet.UrunId = dbo.Urunler.UrunId WHERE (dbo.Sepet.SiparisId = 0) AND (dbo.Sepet.UyeId = " + UyeId + ") GROUP BY dbo.Urunler.UrunAdi, dbo.Urunler.BayiFiyati, dbo.Urunler.Kdv, dbo.Urunler.AnaResim150, dbo.Urunler.SatisFiyati, dbo.Sepet.SepetId, dbo.Sepet.UrunId,  dbo.Sepet.UyeId, dbo.Sepet.Tarih, dbo.Sepet.UyeIp, dbo.Sepet.SiparisId, dbo.Sepet.Miktar,dbo.Urunler.Kdv,dbo.Urunler.indirim,dbo.Urunler.BayiFiyati,BayiIndirim");
                UyeTip = veri.GetDataCell("Select UyeTip From Uyeler Where UyeId=" + UyeId + "");


                if (dtSepet.Rows.Count > 0 && UyeTip == "0")// normal üye
                {
                    RpAnaSepet.DataSource = dtSepet;
                    RpAnaSepet.DataBind();
                    lblSepetSayi.Text = "Sepetinizde " + dtSepet.Rows.Count + " ürün var.";
                    //lblFiyat.Text = dtSepet.Rows.Count + " Ürün ";

                    UyeHesabi();

                  

                }
                else if (dtSepet.Rows.Count > 0 && UyeTip == "1")// bayi
                {
                    RpAnaSepet.DataSource = dtSepet;
                    RpAnaSepet.DataBind();
                    lblSepetSayi.Text = "Sepetinizde " + dtSepet.Rows.Count + " ürün var.";
                    lblFiyat.Text = dtSepet.Rows.Count + " Ürün ";

                    BayiHesabi();

                   
                }
                else // ya üyenin ürün sepeti boştur ya da üyetip ile oynanmıştır 0 veya 1 değildir
                {
                    divPanelSepetim.Visible = false;
                    lblFiyat.Text = "Sepetinizde ürün yok";
                }

            }


        }
        void UyeHesabi()
        {
            // giriş yapan üye ise 
            foreach (DataRow drUrun in dtSepet.Rows)
            {
                // tek tek ürün kdvsini al hesapla tut
                SatisFiyati = Convert.ToDouble(drUrun["indirimliFiyat"]);
                Kdv = Convert.ToDouble(drUrun["Kdv"]);

                Toplam += SatisFiyati * Kdv / 100;
                SatisFiyatToplam += SatisFiyati;

            }
            //düzeltme lbl fiyata kdvli fiyat toplamını ekledim lblFiyat.Text = lblFiyat.Text + SatisFiyatToplam.ToString("c");
           
            // kdv dahil genel toplam.
            Toplam = Toplam + SatisFiyatToplam;
            lblFiyat.Text = lblFiyat.Text + Toplam.ToString("c");
            lblKdvDahil.Text = Toplam.ToString("c");
        }

        protected void RpAnaSepet_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            // üye ve bayi bilgileri tek repeaterda eğer üye girişi yapılmışsa üye fiyatını göster bayi ise bayi fiyatını göster

            if (UyeTip == "0") // normal üye
            {


                e.Item.FindControl("divBayiFiyat").Visible = false;
            }
            else if (UyeTip == "1")// bayi
            {
                e.Item.FindControl("divUyeFiyat").Visible = false;
            }



        }

        void BayiHesabi()
        {
            // eğer giriş yapan bayi ise

            foreach (DataRow drUrun in dtSepet.Rows)
            {

                SatisFiyati = Convert.ToDouble(drUrun["indirimliBayiFiyat"]);
                Kdv = Convert.ToDouble(drUrun["Kdv"]);

                Toplam += SatisFiyati * Kdv / 100;
                SatisFiyatToplam += SatisFiyati;

            }
            lblFiyat.Text = lblFiyat.Text + SatisFiyatToplam.ToString("c");
            //// kdv dahil genel toplam.
            Toplam = Toplam + SatisFiyatToplam;
            lblKdvDahil.Text = Toplam.ToString("c");
        }

        void YeniUrunGetir()
        {
            if (UyeId != null)
            {
                UyeTip = veri.GetDataCell("Select UyeTip From Uyeler Where UyeId=" + UyeId + "");
            }
             if (UyeId == null || UyeTip == "0") // ziyaretçi veya normal üye ise 
            {
            DataTable dtUrunler = veri.GetDataTable("Select Top 6 UrunId,UrunAdi,StokKodu,BayiFiyati,((SatisFiyati - indirim) * Kdv/100+SatisFiyati-indirim) as SatisFiyatiKdvli ,AnaResim800,AnaResim150 From Urunler Where Sil=0 and AktifMi=1 Order By UrunId Desc");
            RpYeniUrun.DataSource = dtUrunler;
            RpYeniUrun.DataBind();
            }
             else if (UyeTip == "1") // bayi ise
             {
                 DataTable dtUrunler = veri.GetDataTable("Select Top 6 UrunId,UrunAdi,StokKodu,BayiFiyati,((BayiFiyati - BayiIndirim) * Kdv/100+BayiFiyati-BayiIndirim) as SatisFiyatiKdvli ,AnaResim800,AnaResim150 From Urunler Where Sil=0 and AktifMi=1 Order By UrunId Desc");
                 RpYeniUrun.DataSource = dtUrunler;
                 RpYeniUrun.DataBind();
             
             }
        } 
        void indirimliUrunGetir()
        {
             if (UyeId != null)
            {
                UyeTip = veri.GetDataCell("Select UyeTip From Uyeler Where UyeId=" + UyeId + "");
            }
             if (UyeId == null || UyeTip == "0") // ziyaretçi veya normal üye ise 
             {
                 DataTable dtUrunler = veri.GetDataTable("Select Top 3 SatisFiyati,indirim,UrunId,UrunAdi,((SatisFiyati - indirim) * Kdv/100+SatisFiyati-indirim) as SatisFiyatiKdvli ,AnaResim150 From Urunler Where Sil=0 and AktifMi=1 and FiyatiDusen=1 Order By UrunId Desc");
                 Rpindirimli.DataSource = dtUrunler;
                 Rpindirimli.DataBind();
             }
             else if (UyeTip == "1") // bayi ise
             {
                 DataTable dtUrunler = veri.GetDataTable("Select Top 3 SatisFiyati,indirim,UrunId,UrunAdi,BayiFiyati,((BayiFiyati - BayiIndirim) * Kdv/100+BayiFiyati-BayiIndirim) as SatisFiyatiKdvli ,AnaResim150 From Urunler Where Sil=0 and AktifMi=1 and FiyatiDusen=1 Order By UrunId Desc");
                 Rpindirimli.DataSource = dtUrunler;
                 Rpindirimli.DataBind();
             }
        }
        void AnaKategoriGetir()
        {
            DataTable DtAnaKategori = veri.GetDataTable("Select * From Kategoriler where Aktif=1 and Sil=0");
            RpAnaKategoriler.DataSource = DtAnaKategori;
            RpAnaKategoriler.DataBind();
        }
        protected void AltKategoriCek(object sender, RepeaterItemEventArgs e)
        {

            // ilk kategoriden kategoriId değerlerine e ile ulaştım.
            Repeater rp = (Repeater)e.Item.FindControl("RpAltKategoriler");
            rp.DataSource = veri.GetDataTable("Select * From AltKategoriler Where Aktif=1 and Sil=0 and KategoriId= " + DataBinder.Eval(e.Item.DataItem, "KategoriId"));
            rp.DataBind();
        }
        void SayfaGetir()
        {
            DataTable DtSayfalar = veri.GetDataTable("Select * From Sayfalar Where Aktif=1 Order By SayfaId Desc");
            RpSayfa.DataSource = DtSayfalar;
            RpSayfa.DataBind();
            DataTable DtAltSayfa = veri.GetDataTable("Select Top 3 * From Sayfalar Where Aktif=1 Order By SayfaId Desc");
            DlSayfalar.DataSource = DtAltSayfa;
            DlSayfalar.DataBind();

        }
        void LogoGetir()
        {
            try
            {

                DataRow drBilgi = veri.GetDataRow("Select Title,SiteLogo,Footer,Twitter,Facebook  From MetaTag");
                Logo = drBilgi["SiteLogo"].ToString();
                Title = drBilgi["Title"].ToString();
                Twit = drBilgi["Twitter"].ToString();
                Face = drBilgi["Facebook"].ToString();              
                //  lblFooter.Text = drBilgi["Footer"].ToString();
                if (drBilgi["SiteLogo"].ToString() == "")
                {
                    // divLogo.Visible = false;
                }
            }

            catch (Exception)
            {

            }
        }

        //protected void btnSepetBosalt_Click(object sender, ImageClickEventArgs e)
        //{
        //    // üyeye ait tüm sepetteki siparişleri silmemesi için sadece siparisId = 0 yani henüz alınmayan ürünleri yani şuan septteki ürünleri sil.

        //    //try
        //    //{
        //    //    veri.cmd("Delete From Sepet Where SiparisId=0 and UyeId=" + UyeId + "");

        //    //    Session.Remove("KdvDahil");
        //    //    Response.Redirect("/Default.aspx");
        //    //}
        //    //catch (Exception)
        //    //{
              
        //    //}
           
        //}
        void SolReklamAlan()
        {
        //    try
        //    {

        //        drReklam = veri.GetDataTable("Select * From Reklam Where Aktif=1");

        //        //if (drReklam.Rows[0]["Logo"].ToString() != "") // footer reklam alanı
        //        //{
        //        //    divFooterReklam.Visible = true;
        //        //} ana master de zaten footer reklamını çektim

        //        if (drReklam.Rows[1]["Logo"].ToString() != "") // sol reklam alanı 2
        //        {
        //            SolAlan1.Visible = true;
        //        }

        //        if (drReklam.Rows[2]["Logo"].ToString() != "") // sol reklam alanı 3
        //        {
        //            SolAlan2.Visible = true;

        //        }



        //    }
        //    catch (Exception)
        //    {

        //    }
        }

        void FooterReklam()
        {

        //    try
        //    {

        //        DataRow drReklam = veri.GetDataRow("Select * From Reklam Where ReklamId=1 and Aktif=1");

        //        if (drReklam["Logo"].ToString() != "") // footer reklam alanı
        //        {
        //            Rtitle = drReklam["Baslik"].ToString();
        //            Rlogo = drReklam["Logo"].ToString();
        //            Rurl = drReklam["UrlAdres"].ToString();
        //            divFooterReklam.Visible = true;

        //        }
        //        else
        //        {

        //        }



        //    }
        //    catch (Exception)
        //    {

        //    }
        }
        void BilgiGet()
        {
            DataRow drBilgi = veri.GetDataRow("Select Mail,Tel2,Fax,FirmaAdresi From Firma");
            lblGsm.Text = drBilgi["Tel2"].ToString();
            lblFax.Text = drBilgi["Fax"].ToString();
            lblMail.Text = drBilgi["Mail"].ToString();
            lblAdres.Text = drBilgi["FirmaAdresi"].ToString();
        }
        void KurGetir()
        {
            if (Page.IsPostBack == false)
            {
                try
                {
                    XmlDocument xmlVerisi = new XmlDocument();
                    xmlVerisi.Load("http://www.tcmb.gov.tr/kurlar/today.xml");
                    decimal dolar = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "USD")).InnerText.Replace('.', ','));

                    decimal Euro = Convert.ToDecimal(xmlVerisi.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/ForexSelling", "EUR")).InnerText.Replace('.', ','));

                    lblDolar.Text += dolar.ToString();
                    lblEuro.Text += Euro.ToString();

                }
                catch (Exception)
                {

                }
            }
        }
        protected void btnCikis_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("/Default.aspx");
        }

        protected void btnCik_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("/Default.aspx");
        }

        protected void btnSepet_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Uye/Sepet.aspx");
        }

        protected void btnAra_Click(object sender, EventArgs e)
        {
            string aranacakdeger = Kontrol.AramaKontrol(txtAra.Text);
            Response.Redirect("/" + aranacakdeger + "-ara.aspx");
        }
    }
}