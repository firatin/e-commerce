using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Eticaret
{
    public partial class UrunDetay2 : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        Label lbl1;

        string UrunId, UyeId, KategoriId, AltKategoriId, SayfalamaId, UyeTip, KrediKartiOdeme;
        public static string Anaresim, UrunAdi, titlebilgisi;
        public double kdv;
        double PiyasaFiyati, SatisFiyati, indirimliFiyati, indirimtoplam, Havaleindirim, Tekcekimindirim;
        double BayiFiyati, indirimliBayiFiyati, ToptanBayiFiyati, indirimliToptanBayi, BayiindirimToplam, ToptanBayiindirimToplam, BayiKdv;
        DataRow drUrun;
        public double Taksit2, Taksit3, Taksit4, Taksit5, Taksit6, Taksit7, Taksit8, Taksit9, Taksit10, Taksit11, Taksit12;
        public string BankaAdi;

        int VaryantStok1, VaryantStok2, VaryantStok3;
        string Var1UrunVarmi, Var2UrunVarmi, Var3UrunVarmi;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Ürün Detayı";
            Page.Title = "Ürün Detayı";
            try
            {
                KrediKartiOdeme = veri.GetDataCell("Select KrediKarti From OdemeSecenek");
            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                SayfalamaId = Request.QueryString["Sayfa"];

                UrunId = Kontrol.SayiKontrol(Kontrol.UrlSeo(RouteData.Values["UrunId"].ToString()));
            }
            catch (Exception)
            {

                Response.Redirect("Default.aspx");

            }

            if (Session["RowUrl"] != null && Session["SepeteGit"] == null)
            {
                Eticaret.Msg.Mesaj(this, eStatusType.Bilgi, "<br/>Siparişiniz sepete eklendi.");
                Session.Remove("RowUrl");

            }
            else if (Session["RowUrl"] != null && Session["SepeteGit"] != null)
            {

                Response.Redirect(Session["SepeteGit"].ToString());
                Session.Remove("SepeteGit");
            }

            if (Session["UyeId"] == null)
            {
                // üye yorum için.
                PanelUyeOl.Visible = true;
                divBayi.Visible = false;

            }
            else
            {

                UyeId = Session["UyeId"].ToString();
                PanelYorumYaz.Visible = true;

                // üye girişi yapmışsa tipini al ve kontrol et

                try
                {
                    UyeTip = veri.GetDataCell("Select UyeTip From Uyeler Where UyeId=" + UyeId + "");
                    if (UyeTip == "0")
                    {
                        // normal üye.
                        divBayi.Visible = false;
                    }
                    else if (UyeTip == "1") // bayi
                    {
                        divUye.Visible = false;
                    }

                }
                catch (Exception)
                {


                }

            }
            if (SayfalamaId != null)
            {
                //TabContainer1.ActiveTabIndex = 1;
            }
            UrunId = Kontrol.SayiKontrol(Kontrol.Temizle(RouteData.Values["UrunId"].ToString()));
            if (UrunId != "")
            {
                try
                {


                    drUrun = veri.GetDataRow("SELECT dbo.Urunler.*, dbo.Kategoriler.KategoriAdi, dbo.AltKategoriler.AltKategoriAdi, dbo.Markalar.MarkaAdi FROM  dbo.Urunler INNER JOIN dbo.Kategoriler ON dbo.Urunler.KategoriId = dbo.Kategoriler.KategoriId INNER JOIN dbo.AltKategoriler ON dbo.Urunler.AltKategoriId = dbo.AltKategoriler.AltKategoriId INNER JOIN dbo.Markalar ON dbo.Urunler.MarkaId = dbo.Markalar.MarkaId Where dbo.Urunler.AktifMi=1 and dbo.Urunler.Sil=0 and dbo.Urunler.UrunId =" + UrunId + "");


                    if (drUrun != null)
                    {
                        ResimleriGetir();
                        ilgiliUrunler();
                        YorumGetir();
                        varyantGetir();
                        if (KrediKartiOdeme != "False") // kredi kartı aktif ise
                        {
                            TaksitSecenekleri();
                        }
                        else // aktif değil ise False ise gizle
                        {
                           // TabPanel3.Visible = false;
                        }

                        UrunAdi = drUrun["UrunAdi"].ToString();
                        titlebilgisi = UrunAdi + " - " + drUrun["KategoriAdi"].ToString() + " - " + drUrun["AltKategoriAdi"].ToString() + " - " + drUrun["MarkaAdi"].ToString();

                        //title
                        Page.Title = titlebilgisi;
                        Page.MetaDescription = titlebilgisi;
                        Page.MetaKeywords = titlebilgisi;
                        lbl1.Text = UrunAdi;

                        //detay

                        lblAd.Text = "Stok Kodu: " + drUrun["StokKodu"].ToString();
                        ltrlDetay.Text = drUrun["Detay"].ToString();

                        // indirimleri getir.
                        Havaleindirim = Convert.ToDouble(drUrun["HavaleIndirim"]);
                        Tekcekimindirim = Convert.ToDouble(drUrun["TekCekimIndirim"]);


                        // stokta varsa
                        if (Convert.ToInt32(drUrun["StokMiktari"]) > 0)
                        {
                            if (Page.IsPostBack == false)
                            {
                                for (int i = 1; i <= Convert.ToInt32(drUrun["StokMiktari"]); i++)
                                {
                                    ddStokAdet.Items.Add(i.ToString());
                                    lblStokSayiOlcut.Text = drUrun["StokOlcutu"].ToString();
                                }
                            }

                        }
                        else
                        {
                            trStok.Visible = false;
                            trsiparisSayisi.Visible = false;

                        }
                        // miktar gösterilsin mi
                        if (drUrun["MiktarGosterim"].ToString() == "True")
                        {
                            lblStokAdet.Text = drUrun["StokMiktari"].ToString() + " " + drUrun["StokOlcutu"].ToString();
                        }
                        else
                        {
                            trStok.Visible = false;
                        }

                        // sok durumu
                        lblStokDurum.Text = drUrun["StokDurumu"].ToString();

                        //ürün hit
                        int Hit;
                        Hit = Convert.ToInt32(drUrun["Hit"]);
                        Hit = Hit + 1;

                        veri.cmd("Update Urunler Set Hit=" + Hit + " Where UrunId=" + UrunId + "");

                        if (Convert.ToDouble(drUrun["PiyasaFiyati"]) > 0)
                        {
                            PiyasaFiyati = Convert.ToDouble(drUrun["PiyasaFiyati"]);
                            lblPiyasaFiyat.Text = PiyasaFiyati.ToString("c"); //##,##.00
                        }
                        else
                        {
                            trPiyasa.Visible = false;
                        }
                        if (Convert.ToDouble(drUrun["SatisFiyati"]) > 0)
                        {
                            SatisFiyati = Convert.ToDouble(drUrun["SatisFiyati"]);
                            lblFiyatiFiyat.Text = SatisFiyati.ToString("c") + " + Kdv";
                        }
                        if (Convert.ToDouble(drUrun["indirim"]) > 0)
                        {
                            indirimliFiyati = Convert.ToDouble(drUrun["indirim"]);
                            indirimtoplam = SatisFiyati - indirimliFiyati;
                            lblindirimliFiyat.Text = indirimtoplam.ToString("c");
                        }
                        else
                        {
                            trindirim.Visible = false;
                        }

                        // + kdv.
                        int kdvdegeri = Convert.ToInt32(drUrun["Kdv"]);
                        // eğer fiyat indirimi varsa
                        if (indirimliFiyati > 0)
                        {
                            double indirimkazanci = indirimtoplam * kdvdegeri / 100;
                            if (indirimkazanci > 0)
                            {
                                //lblindirimliFiyat.Text = lblindirimliFiyat.Text + " Kazancınız: " + indirimkazanci + " TL";
                                lblindirimliFiyat.Text = lblindirimliFiyat.Text;
                            }
                            else
                            {
                                lblindirimliFiyat.Text = lblindirimliFiyat.Text;
                            }

                            kdv = indirimtoplam += indirimtoplam * kdvdegeri / 100;
                            lblKdvDahilFiyat.Text = kdv.ToString("c");
                        }
                        else // eğer indirim yoksa indirim girilmediyse
                        {
                            kdv = SatisFiyati += SatisFiyati * kdvdegeri / 100; // eğer kdv değeri yoksa 0 gelir fiyatın kendisini gösterir
                            lblKdvDahilFiyat.Text = kdv.ToString("c");
                        }

                        //havale indirimi
                        if (Convert.ToDouble(drUrun["HavaleIndirim"]) > 0)
                        {

                            double Havalaindirim = kdv / 100 * Havaleindirim;
                            Havalaindirim = kdv - Havalaindirim;
                            lblHavaleFiyat.Text = Havalaindirim.ToString("c");
                        }
                        else
                        {
                            lblHavaleFiyat.Text = "";
                            trHavaleindirim.Visible = false;
                        }
                        //tek çekim indirimi
                        if (Convert.ToDouble(drUrun["TekCekimIndirim"]) > 0)
                        {

                            double TekCekimindirim = kdv / 100 * Tekcekimindirim;
                            TekCekimindirim = kdv - TekCekimindirim;
                            lblTekCekimFiyat.Text = TekCekimindirim.ToString("c");
                        }
                        else
                        {
                            lblTekCekimFiyat.Text = "";
                            trTekCekimindirim.Visible = false;
                        }




                        // Toptan Bayi içeriği


                        //bayi işlemleri
                        // bayi fiyatı
                        BayiFiyati = Convert.ToDouble(drUrun["BayiFiyati"]);
                        lblBayiFiyati.Text = BayiFiyati.ToString("c") + " + Kdv";
                        // indirimli bayi fiyatı
                        if (Convert.ToDouble(drUrun["BayiIndirim"]) > 0)
                        {
                            indirimliBayiFiyati = Convert.ToDouble(drUrun["BayiIndirim"]);
                            BayiindirimToplam = BayiFiyati - indirimliBayiFiyati;
                            lblindirimliBayiFiyat.Text = BayiindirimToplam.ToString("c");
                        }
                        else
                        {
                            trBayiindirim.Visible = false;
                        }

                        // + kdv si.
                        // eğer fiyat indirimi varsa
                        kdvdegeri = Convert.ToInt32(drUrun["Kdv"]);
                        // eğer fiyat indirimi varsa
                        if (indirimliBayiFiyati > 0)
                        {
                            double Bayiindirimkazanci = BayiindirimToplam * kdvdegeri / 100;
                            if (Bayiindirimkazanci > 0)
                            {
                                //lblindirimliBayiFiyat.Text = lblindirimliBayiFiyat.Text + " Kazancınız: " + Bayiindirimkazanci + " TL";
                                lblindirimliBayiFiyat.Text = lblindirimliBayiFiyat.Text;
                            }
                            else
                            {
                                lblindirimliBayiFiyat.Text = lblindirimliBayiFiyat.Text;
                            }

                            BayiKdv = BayiindirimToplam += BayiindirimToplam * kdvdegeri / 100;
                            lblBayiKdvDahil.Text = BayiKdv.ToString("c");
                        }
                        else // eğer indirim yoksa indirim girilmediyse
                        {
                            BayiKdv = BayiFiyati += BayiFiyati * kdvdegeri / 100; // eğer kdv değeri yoksa 0 gelir fiyatın kendisini gösterir
                            lblBayiKdvDahil.Text = BayiKdv.ToString("c");
                        }


                        // kdv bitiş

                        //bayi havale indirimi
                        if (Convert.ToDouble(drUrun["HavaleIndirim"]) > 0)
                        {

                            double Havaleindirimsonuc = kdv / 100 * Havaleindirim;
                            Havaleindirimsonuc = kdv - Havaleindirimsonuc;
                            lblBayiHavale.Text = Havaleindirimsonuc.ToString("c");
                        }
                        else
                        {
                            lblBayiHavale.Text = "";
                            trBayiHavaleindirim.Visible = false;
                        }

                        //bayi tek çekim indirimi
                        if (Convert.ToDouble(drUrun["TekCekimIndirim"]) > 0)
                        {

                            double TekCekimindirimSonuc = kdv / 100 * Tekcekimindirim;
                            TekCekimindirimSonuc = kdv - TekCekimindirimSonuc;
                            lblBayiTekCekim.Text = TekCekimindirimSonuc.ToString("c");
                        }
                        else
                        {
                            lblBayiTekCekim.Text = "";
                            trBayiTekCekimindirim.Visible = false;
                        }

                        // toptan bayi işlemleri

                        // toptan bayi fiyatı
                        ToptanBayiFiyati = Convert.ToDouble(drUrun["ToptanBayiFiyati"]);
                        lblToptanBayiFiyat.Text = ToptanBayiFiyati.ToString("c") + " + Kdv";

                        // indirimli toptan bayi fiyatı
                        if (Convert.ToDouble(drUrun["ToptanBayiIndirim"]) > 0)
                        {
                            indirimliToptanBayi = Convert.ToDouble(drUrun["ToptanBayiIndirim"]);
                            ToptanBayiindirimToplam = ToptanBayiFiyati - indirimliToptanBayi;
                            lblindirimToptanBayi.Text = ToptanBayiindirimToplam.ToString("c");
                        }
                        else
                        {
                            trToptanBayiindirim.Visible = false;
                        }

                        // + toptan bayi kdv si.

                        // eğer fiyat indirimi varsa
                        if (indirimliToptanBayi > 0)
                        {
                            double ToptanBayiindirimkazanci = ToptanBayiindirimToplam * kdvdegeri / 100;
                            if (ToptanBayiindirimkazanci > 0)
                            {
                                // lblindirimToptanBayi.Text = lblindirimToptanBayi.Text + " Kazancınız: " + ToptanBayiindirimkazanci + " TL";
                                lblindirimToptanBayi.Text = lblindirimToptanBayi.Text;
                            }
                            else
                            {
                                lblindirimToptanBayi.Text = lblindirimToptanBayi.Text;
                            }

                            BayiKdv = ToptanBayiindirimToplam += ToptanBayiindirimToplam * kdvdegeri / 100;
                            lblToptanBayiKdvDahil.Text = BayiKdv.ToString("c");
                        }
                        else // eğer indirim yoksa indirim girilmediyse
                        {
                            BayiKdv = ToptanBayiFiyati += ToptanBayiFiyati * kdvdegeri / 100; // eğer kdv değeri yoksa 0 gelir fiyatın kendisini gösterir
                            lblToptanBayiKdvDahil.Text = BayiKdv.ToString("c");
                        }


                        // kdv toptan bayi bitiş


                        //toptan bayi havale indirimi
                        if (Convert.ToDouble(drUrun["HavaleIndirim"]) > 0)
                        {

                            double TBayiHavaleindirimsonuc = kdv / 100 * Havaleindirim;
                            TBayiHavaleindirimsonuc = kdv - TBayiHavaleindirimsonuc;
                            lblToptanBayiHavale.Text = TBayiHavaleindirimsonuc.ToString("c");
                        }
                        else
                        {
                            lblToptanBayiHavale.Text = "";
                            trToptanBayiHavaleindirim.Visible = false;
                        }

                        //toptan bayi tek çekim indirimi
                        if (Convert.ToDouble(drUrun["TekCekimIndirim"]) > 0)
                        {

                            double TBayiTekCekimindirimSonuc = kdv / 100 * Tekcekimindirim;
                            TBayiTekCekimindirimSonuc = kdv - TBayiTekCekimindirimSonuc;
                            lblToptanBayiTekCekindirim.Text = TBayiTekCekimindirimSonuc.ToString("c");
                        }
                        else
                        {
                            lblToptanBayiTekCekindirim.Text = "";
                            trToptanBayiTekCekimindirim.Visible = false;
                        }

                    }

                    else
                    {
                        Response.Redirect("Default.aspx");
                    }
                }
                catch (Exception)
                {

                    //hata mesajı
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnYorumGonder_Click(object sender, EventArgs e)
        {
            string UyeYetki = veri.GetDataCell("Select UyeYetki from uyeler Where UyeId=" + UyeId + "");
            int aktif = 0;
            if (UyeYetki == "1")
            {
                aktif = 1;
            }
            string ipadres = HttpContext.Current.Request.UserHostAddress;
            SqlConnection baglan = veri.baglan();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglan;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_YorumEkle";
            cmd.Parameters.AddWithValue("@UyeId", UyeId);
            cmd.Parameters.AddWithValue("@UrunId", UrunId);
            cmd.Parameters.AddWithValue("@Yorum", Kontrol.Yonlendirme(txtYorum.Text));
            cmd.Parameters.AddWithValue("@AktifMi", aktif);
            cmd.Parameters.AddWithValue("@Ip", ipadres);
            try
            {
                cmd.ExecuteNonQuery();
                if (UyeYetki == "1")
                {
                    Response.Redirect(HttpContext.Current.Request.RawUrl);
                }
                else
                {
                    Msg.Show("Yorumunuz gönderildi. Editörlerimiz tarafından onaylandıktan sonra yayımlanacaktır.");
                }

                txtYorum.Text = "";
            }
            catch (Exception)
            {

            }

        }
        void ilgiliUrunler()
        {
            try
            {
                if (Page.IsPostBack == false)
                {
                    DataRow drKatBilgi = veri.GetDataRow("Select AltKategoriId,KategoriId From Urunler Where UrunId =" + UrunId + "");
                    KategoriId = drKatBilgi["KategoriId"].ToString();
                    AltKategoriId = drKatBilgi["AltKategoriId"].ToString();

                    if (UyeId == null || UyeTip == "0") // ziyaretçi veya normal üye ise 
                    {
                        DataTable dtUrunler = veri.GetDataTable("Select Top 4 UrunId,UrunAdi,StokKodu,SatisFiyati,((SatisFiyati - indirim) * Kdv/100+SatisFiyati-indirim) as SatisFiyatiKdvli,AnaResim800,AnaResim150,AltKategoriId From Urunler Where Sil=0 and AktifMi=1 and AltKategoriId=" + AltKategoriId + " and UrunId!=" + UrunId + " Order By UrunId Desc");
                        RpUrunler.DataSource = dtUrunler;
                        RpUrunler.DataBind();

                        if (dtUrunler.Rows.Count == 0)
                        {
                            DataTable dtBenzerUrunler = veri.GetDataTable("Select Top 4 UrunId,UrunAdi,StokKodu,SatisFiyati,((SatisFiyati - indirim) * Kdv/100+SatisFiyati-indirim) as SatisFiyatiKdvli,AnaResim800,AnaResim150,KategoriId From Urunler Where Sil=0 and AktifMi=1 and KategoriId=" + KategoriId + " and UrunId!=" + UrunId + " Order By UrunId Desc");
                            RpUrunler.DataSource = dtBenzerUrunler;
                            RpUrunler.DataBind();

                        }
                    }
                    else if (UyeTip == "1") // bayi ise
                    {
                        DataTable dtUrunler = veri.GetDataTable("Select Top 4 UrunId,UrunAdi,StokKodu,BayiFiyati,((BayiFiyati - BayiIndirim) * Kdv/100+BayiFiyati-BayiIndirim) as SatisFiyatiKdvli,AnaResim800,AnaResim150,AltKategoriId From Urunler Where Sil=0 and AktifMi=1 and AltKategoriId=" + AltKategoriId + " and UrunId!=" + UrunId + " Order By UrunId Desc");
                        RpUrunler.DataSource = dtUrunler;
                        RpUrunler.DataBind();

                        if (dtUrunler.Rows.Count == 0)
                        {
                            DataTable dtBenzerUrunler = veri.GetDataTable("Select Top 4 UrunId,UrunAdi,StokKodu,BayiFiyati,((BayiFiyati - BayiIndirim) * Kdv/100+BayiFiyati-BayiIndirim) as SatisFiyatiKdvli,AnaResim800,AnaResim150,KategoriId From Urunler Where Sil=0 and AktifMi=1 and KategoriId=" + KategoriId + " and UrunId!=" + UrunId + " Order By UrunId Desc");
                            RpUrunler.DataSource = dtBenzerUrunler;
                            RpUrunler.DataBind();

                        }
                    }



                }
            }
            catch (Exception)
            {

            }

        }

        void YorumGetir()
        {
            DataTable dtYorumlar = veri.GetDataTable("SELECT dbo.Uyeler.Ad, dbo.Uyeler.Soyad, dbo.Yorumlar.* FROM  dbo.Uyeler INNER JOIN dbo.Yorumlar ON dbo.Uyeler.UyeId = dbo.Yorumlar.UyeId Where dbo.Yorumlar.UrunId=" + UrunId + " and dbo.Yorumlar.AktifMi =1 Order By dbo.Yorumlar.YorumId Desc");

            CollectionPager1.DataSource = dtYorumlar.DefaultView;
            CollectionPager1.BindToControl = RpYorumlar;
            RpYorumlar.DataSource = CollectionPager1.DataSourcePaged;
            RpYorumlar.DataBind();

            if (dtYorumlar.Rows.Count == 0)
            {
                lblYorumSayisi.Text = "Bu ürüne henüz yorum yapılmadı.";
            }
            else
            {
                lblYorumSayisi.Text = dtYorumlar.Rows.Count.ToString() + " değerlendirme var";
            }

        }

        void ResimleriGetir()
        {
            Anaresim = veri.GetDataCell("Select AnaResim800 From Urunler Where UrunId=" + UrunId + "");
            if (Anaresim == "")// ana resim yoksa
            {
                Anaresim = "/Resimler/resimyok.jpg";
            }
            else
            {
                Anaresim = "/Resimler/Urun/800/" + Anaresim;
            }

            DataTable dtResimler = veri.GetDataTable("Select * From Resimler Where UrunId=" + UrunId + "");


            if (dtResimler.Rows.Count > 0)
            {

                RpResimler.DataSource = dtResimler;
                RpResimler.DataBind();

                //RpUstResimler.DataSource = dtResimler;
                //RpUstResimler.DataBind();
            }
            else
            {
                PanelResimYok.Visible = true;

            }

        }

        protected void btnSepeteEkle_Click(object sender, EventArgs e)
        {
            if (UyeId == null)
            {
                Response.Redirect("/Uyelik/Giris.aspx");
            }
            else
            {
                Session.Remove("SepeteGit");
                SepeteEkle();
            }
        }

        protected void btnHemenAl_Click(object sender, EventArgs e)
        {
            if (UyeId == null)
            {
                Response.Redirect("/Uyelik/Giris.aspx");
            }
            else
            {
                Session.Add("SepeteGit", "/Uye/Sepet.aspx");

                SepeteEkle();

                // Response.Redirect("/Uye/Sepet.aspx");
            }
        }
        void SepeteEkle()
        {
            string ipadres = HttpContext.Current.Request.UserHostAddress;

            try
            {
                // ürünId 7 ve altvaryant dropdownda seçili olanın stok sayısını getir

                if (Var1UrunVarmi != null)
                {
                    VaryantStok1 = Convert.ToInt32(veri.GetDataCell("Select StokSayi From Varyantlar Where AltVaryantId=" + ddVar1.SelectedValue + " and UrunId=" + UrunId + ""));

                }
                if (Var2UrunVarmi != null)
                {
                    VaryantStok2 = Convert.ToInt32(veri.GetDataCell("Select StokSayi From Varyantlar Where AltVaryantId=" + ddVar2.SelectedValue + " and UrunId=" + UrunId + ""));

                }
                if (Var3UrunVarmi != null)
                {
                    VaryantStok3 = Convert.ToInt32(veri.GetDataCell("Select StokSayi From Varyantlar Where AltVaryantId=" + ddVar3.SelectedValue + " and UrunId=" + UrunId + ""));

                }
            }
            catch (Exception)
            {


            }

            int Miktar;
            if (ddStokAdet.SelectedValue == "")
            {
                Miktar = 1;
            }
            else
            {
                Miktar = Convert.ToInt32(ddStokAdet.SelectedValue);
            }

            int stoksayisi = Convert.ToInt32(drUrun["StokMiktari"]);
            int MaxSparisMiktari = Convert.ToInt32(drUrun["MaxSparisMiktari"]);
            if (MaxSparisMiktari == 0) MaxSparisMiktari = 1; // eğer admin panelinden 0 yapılırsa hiç bir ürün alınamaz.;
            int MinSparisMiktari = Convert.ToInt32(drUrun["MinSparisMiktari"]);
            if (MinSparisMiktari == 0) MinSparisMiktari = 1; // eğer admin panelinden 0 yapılırsa hiç bir ürün alınamaz.;

            //varyanttan sonra eklediklerim
            if (Miktar > stoksayisi)
            {
                Msg.Show("Yetersiz stok miktarı! Kalan ürün sayısı: " + stoksayisi + " Almak istediğiniz ürün sayısı: " + Miktar + "");
            }
            else if (stoksayisi == 0)
            {
                Msg.Show("Malesef bu ürün tükendi. Stokta yok.");
            }
            else if (Miktar > MaxSparisMiktari)
            {
                Msg.Show("Bu üründen en fazla " + MaxSparisMiktari + " adet sipariş verebilirsiniz. ");
            }
            else if (Miktar < MinSparisMiktari)
            {
                Msg.Show("Bu ürünü alabilmeniz için en az " + MinSparisMiktari + " adet sipariş vermelisiniz. ");
            }
            // varyanttan sonra eklediklerim
            else if (Var1UrunVarmi != null && Miktar > VaryantStok1)
            {
                Msg.Show("Yetersiz stok miktarı! " + Var1UrunVarmi + " için kalan ürün sayısı: " + VaryantStok1 + " Almak istediğiniz ürün sayısı: " + Miktar + "");
            }
            else if (Var2UrunVarmi != null && Miktar > VaryantStok2)
            {
                Msg.Show("Yetersiz stok miktarı! " + Var2UrunVarmi + " için kala ürün sayısı: " + VaryantStok2 + " Almak istediğiniz ürün sayısı: " + Miktar + "");
            }
            else if (Var3UrunVarmi != null && Miktar > VaryantStok3)
            {
                Msg.Show("Yetersiz stok miktarı! " + Var3UrunVarmi + " için kala ürün sayısı: " + VaryantStok3 + " Almak istediğiniz ürün sayısı: " + Miktar + "");
            }

                // varyant kontrolünden sonra normal stok kontrolü zaten varyantlar yoksa direk stok kontrolüne geçer.

            else
            {

                SqlConnection baglan = veri.baglan();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglan;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_SepeteEkle";
                cmd.Parameters.AddWithValue("@UrunId", UrunId);
                cmd.Parameters.AddWithValue("@UyeId", UyeId);
                cmd.Parameters.AddWithValue("@UyeIp", ipadres);
                cmd.Parameters.AddWithValue("@SiparisId", 0);

                if (Miktar >= 1)
                {
                    cmd.Parameters.AddWithValue("@Miktar", Miktar);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Miktar", 1);
                }


                try
                {
                    Session.Add("RowUrl", HttpContext.Current.Request.RawUrl);
                    cmd.ExecuteNonQuery();
                    // Sepetteki varyant alanlarını guncelle
                    string SepetId = veri.GetDataCell("Select Top 1 SepetId From Sepet Where UyeId=" + UyeId + " Order By SepetId Desc");

                    veri.cmd("Update Sepet Set Var1='" + ddVar1.SelectedValue + "',Var2='" + ddVar2.SelectedValue + "',Var3='" + ddVar3.SelectedValue + "' Where SepetId=" + SepetId + "");

                    Response.Redirect(Session["RowUrl"].ToString());
                }
                catch (Exception)
                {

                }
            }
        }

        protected void RpUrunler_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "SepeteEkle")
            {
                try
                {


                    if (Session["UyeId"] == null)
                    {
                        Response.Redirect("/Uyelik/Giris.aspx");
                    }
                    else
                    {

                        UyeId = Session["UyeId"].ToString();

                    }

                    Session.Add("RowUrl", HttpContext.Current.Request.RawUrl);

                    DataRow drUrun = veri.GetDataRow("Select StokMiktari,MaxSparisMiktari,MinSparisMiktari From Urunler Where UrunId=" + e.CommandArgument + "");

                    string ipadres = HttpContext.Current.Request.UserHostAddress;

                    int Miktar = 1; // detay sayfası dışındaki yerlerde 1 adet sipariş edilebilir.
                    int stoksayisi = Convert.ToInt32(drUrun["StokMiktari"]);
                    int MaxSparisMiktari = Convert.ToInt32(drUrun["MaxSparisMiktari"]);
                    if (MaxSparisMiktari == 0) MaxSparisMiktari = 1; // eğer admin panelinden 0 yapılırsa hiç bir ürün alınamaz.;
                    int MinSparisMiktari = Convert.ToInt32(drUrun["MinSparisMiktari"]);
                    if (MinSparisMiktari == 0) MinSparisMiktari = 1; // eğer admin panelinden 0 yapılırsa hiç bir ürün alınamaz.;
                    if (Miktar > stoksayisi)
                    {
                        Msg.Show("Yetersiz stok miktarı! Kalan ürün sayısı: " + stoksayisi + " Almak istediğiniz ürün sayısı: " + Miktar + "");
                    }
                    else if (stoksayisi == 0)
                    {
                        Msg.Show("Malesef bu ürün tükendi. Stokta yok.");
                    }
                    else if (Miktar > MaxSparisMiktari)
                    {
                        Msg.Show("Bu üründen en fazla " + MaxSparisMiktari + " adet sipariş verebilirsiniz. ");
                    }
                    else if (Miktar < MinSparisMiktari)
                    {
                        Msg.Show("Bu ürünü alabilmeniz için en az " + MinSparisMiktari + " adet sipariş vermelisiniz. ");
                    }

                    else
                    {

                        SqlConnection baglan = veri.baglan();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = baglan;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_SepeteEkle";
                        cmd.Parameters.AddWithValue("@UrunId", e.CommandArgument);
                        cmd.Parameters.AddWithValue("@UyeId", UyeId);
                        cmd.Parameters.AddWithValue("@UyeIp", ipadres);
                        cmd.Parameters.AddWithValue("@SiparisId", 0);
                        cmd.Parameters.AddWithValue("@Miktar", Miktar);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            //Eticaret.Msg.Mesaj(this, eStatusType.Bilgi, "<br/>Siparişiniz sepete eklendi.");
                            Response.Redirect(Session["RowUrl"].ToString());
                        }
                        catch (Exception)
                        {

                        }

                    }
                }
                catch (Exception)
                {

                }
            }
        
        }
        // taksit seçenekleri

        void TaksitSecenekleri()
        {
            DataRow DrTaksit = veri.GetDataRow("Select SatisFiyati,indirim,Kdv,BayiFiyati,BayiIndirim From Urunler Where UrunId=" + UrunId + "");

            double TaksitFiyat = Convert.ToDouble(DrTaksit["SatisFiyati"].ToString());
            double Taksitindirim = Convert.ToDouble(DrTaksit["indirim"].ToString());
            double Taksitkdvoran = Convert.ToDouble(DrTaksit["Kdv"].ToString());

            SqlConnection baglanti = veri.baglan();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "TaksitHesapla";
            cmd.Parameters.AddWithValue("@Fiyat", TaksitFiyat);
            cmd.Parameters.AddWithValue("@İndirim", Taksitindirim);
            cmd.Parameters.AddWithValue("@Kdv", Taksitkdvoran);


            DlTaksit.DataSource = cmd.ExecuteReader();
            DlTaksit.DataBind();
        }
        // varyant seçenekleri- var1 var2 var3 3 statik ana varyant var alt varyantlar dinamik. Stok sayısı 0 dan büyük olanları getir. 
        void varyantGetir()
        {

            string UrunVaryant = veri.GetDataCell("Select AnaVaryantId From Varyantlar where StokSayi > 0 AND UrunId=" + UrunId + "");// ürüne ait varyant yoksa alt işlemleri hiç yapma
            string AkifVarmi = veri.GetDataCell("Select Top 1 AnaVaryantId From AnaVaryant Where Sil=0 and Aktif=1"); // ve aktif varyant varsa detaydaki html tabloyu göster yoksa hiç gösterme ve işlemleri yapma

            if (UrunVaryant != null && AkifVarmi != null)
            {

                tblVaryant.Visible = true;
                //eğer anavaryantId 1 olan anavaryant aktifse varyantı getir ve ismini labele ve dropdownu doldur
                string Var1AKtifMi = veri.GetDataCell("Select AnaVaryantId From AnaVaryant Where Sil=0 and AnaVaryantId=1 and Aktif=1");

                if (Var1AKtifMi != null)
                {

                    Var1UrunVarmi = veri.GetDataCell("SELECT  TOP (1) dbo.AnaVaryant.VaryantAdi FROM dbo.Varyantlar INNER JOIN dbo.AnaVaryant ON dbo.Varyantlar.AnaVaryantId = dbo.AnaVaryant.AnaVaryantId WHERE (dbo.Varyantlar.AnaVaryantId = 1) AND (dbo.Varyantlar.StokSayi > 0) AND (dbo.Varyantlar.UrunId = " + UrunId + ")");
                    if (Var1UrunVarmi != null) // boş değilse bu varyanta bağlı ürünler vardır.
                    {
                        trVar1.Visible = true;
                        lblVar1Adi.Text = Var1UrunVarmi;

                        // ve dropdown doldur
                        try
                        {
                            if (!IsPostBack)
                            {
                                ddVar1.Items.Add("Seçiniz");
                                ddVar1.Items[0].Value = "0";
                                DataTable dtVeri = veri.GetDataTable("SELECT  dbo.AltVaryantlar.AltVaryantAdi,dbo.AltVaryantlar.AltVaryantId, dbo.Varyantlar.VaryantId FROM  dbo.Varyantlar INNER JOIN dbo.AltVaryantlar ON dbo.Varyantlar.AltVaryantId = dbo.AltVaryantlar.AltVaryantId WHERE (dbo.Varyantlar.AnaVaryantId = 1) AND (dbo.Varyantlar.StokSayi > 0) AND (dbo.Varyantlar.UrunId = " + UrunId + ")");

                                int sira = 1;
                                for (int i = 0; i < dtVeri.Rows.Count; i++)
                                {
                                    DataRow drBilgi = dtVeri.Rows[i];
                                    ddVar1.Items.Add(drBilgi["AltVaryantAdi"].ToString());
                                    ddVar1.Items[sira].Value = drBilgi["AltVaryantId"].ToString();
                                    sira++;
                                }
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }
                }


                // varyant 2
                string Var2AKtifMi = veri.GetDataCell("Select AnaVaryantId From AnaVaryant Where Sil=0 and AnaVaryantId=2 and Aktif=1");
                if (Var2AKtifMi != null)
                {
                    Var2UrunVarmi = veri.GetDataCell("SELECT  TOP (1) dbo.AnaVaryant.VaryantAdi FROM dbo.Varyantlar INNER JOIN dbo.AnaVaryant ON dbo.Varyantlar.AnaVaryantId = dbo.AnaVaryant.AnaVaryantId WHERE (dbo.Varyantlar.AnaVaryantId = 2) AND (dbo.Varyantlar.StokSayi > 0) AND (dbo.Varyantlar.UrunId = " + UrunId + ")");
                    if (Var2UrunVarmi != null) // boş değilse bu varyanta bağlı ürünler vardır.
                    {
                        trVar2.Visible = true;
                        lblVar2Adi.Text = Var2UrunVarmi;
                        // ve dropdown doldur
                        try
                        {
                            if (!IsPostBack)
                            {
                                ddVar2.Items.Add("Seçiniz");
                                ddVar2.Items[0].Value = "0";
                                DataTable dtVeri = veri.GetDataTable("SELECT     dbo.AltVaryantlar.AltVaryantAdi,dbo.AltVaryantlar.AltVaryantId, dbo.Varyantlar.VaryantId FROM  dbo.Varyantlar INNER JOIN dbo.AltVaryantlar ON dbo.Varyantlar.AltVaryantId = dbo.AltVaryantlar.AltVaryantId WHERE (dbo.Varyantlar.AnaVaryantId = 2) AND (dbo.Varyantlar.StokSayi > 0) AND (dbo.Varyantlar.UrunId = " + UrunId + ")");



                                int sira = 1;
                                for (int i = 0; i < dtVeri.Rows.Count; i++)
                                {
                                    DataRow drBilgi = dtVeri.Rows[i];
                                    ddVar2.Items.Add(drBilgi["AltVaryantAdi"].ToString());
                                    ddVar2.Items[sira].Value = drBilgi["AltVaryantId"].ToString();
                                    sira++;
                                }
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
                // varyant 3
                string Var3AKtifMi = veri.GetDataCell("Select AnaVaryantId From AnaVaryant Where Sil=0 and AnaVaryantId=3 and Aktif=1");
                if (Var3AKtifMi != null)
                {
                    Var3UrunVarmi = veri.GetDataCell("SELECT  TOP (1) dbo.AnaVaryant.VaryantAdi FROM dbo.Varyantlar INNER JOIN dbo.AnaVaryant ON dbo.Varyantlar.AnaVaryantId = dbo.AnaVaryant.AnaVaryantId WHERE (dbo.Varyantlar.AnaVaryantId = 3) AND (dbo.Varyantlar.StokSayi > 0) AND (dbo.Varyantlar.UrunId = " + UrunId + ")");
                    if (Var3UrunVarmi != null) // boş değilse bu varyanta bağlı ürünler vardır.
                    {
                        trVar3.Visible = true;
                        lblVar3Adi.Text = Var3UrunVarmi;
                        // ve dropdown doldur
                        try
                        {
                            if (!IsPostBack)
                            {
                                ddVar3.Items.Add("Seçiniz");
                                ddVar3.Items[0].Value = "0";
                                DataTable dtVeri = veri.GetDataTable("SELECT dbo.AltVaryantlar.AltVaryantAdi,dbo.AltVaryantlar.AltVaryantId, dbo.Varyantlar.VaryantId FROM  dbo.Varyantlar INNER JOIN dbo.AltVaryantlar ON dbo.Varyantlar.AltVaryantId = dbo.AltVaryantlar.AltVaryantId WHERE (dbo.Varyantlar.AnaVaryantId = 3) AND (dbo.Varyantlar.StokSayi > 0) AND (dbo.Varyantlar.UrunId = " + UrunId + ")");

                                int sira = 1;
                                for (int i = 0; i < dtVeri.Rows.Count; i++)
                                {
                                    DataRow drBilgi = dtVeri.Rows[i];
                                    ddVar3.Items.Add(drBilgi["AltVaryantAdi"].ToString());
                                    ddVar3.Items[sira].Value = drBilgi["AltVaryantId"].ToString();
                                    sira++;
                                }
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
            }
        }

    }
}