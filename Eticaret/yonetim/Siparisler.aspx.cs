using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
namespace Eticaret.yonetim
{
    public partial class Siparisler : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        Label lbl1; string UyeId, SiparisId, SepetId, islem = "";
        string smtpadres, gidenmail, mailsifre, DosyaAdi;
        int mailport;
        DataTable dtFiyat; double fiyattoplam;
        GridView GridAktar = new GridView();
        public string BulundugumUrl;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = btnAra.UniqueID;


            lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Siparişler";

            UyeId = Kontrol.SayiKontrol(Request.QueryString["Uye"]);
            SiparisId = Kontrol.SayiKontrol(Request.QueryString["Detay"]);
            SepetId = Kontrol.SayiKontrol(Request.QueryString["v"]);
            islem = Request.QueryString["islem"];



            // butonlara durum sayılarını ekle
            try
            {
                if (Page.IsPostBack == false)
                {
                    BulundugumUrl = HttpContext.Current.Request.RawUrl; // faturadetay dan geri dönmek için.


                    // bekelyen sipariş sayısı
                    string BekleyenSipSayisi = veri.GetDataCell("Select count(SiparisId) as SiparisNo From Siparisler Where DurumId !=7");
                    btnSiparisler.Text = btnSiparisler.Text + " (" + BekleyenSipSayisi + ")";

                    // tamamlanan sipariş sayısı
                    string TamamlananSipSayisi = veri.GetDataCell("Select count(SiparisId) as SiparisNo From Siparisler Where DurumId =7");
                    btnTamamlanan.Text = btnTamamlanan.Text + " (" + TamamlananSipSayisi + ")";

                    // iptal onayı bekleyen spariş sayısı
                    string IptalSipOnayiSayisi = veri.GetDataCell("Select count(SiparisId) as SiparisNo From Siparisler Where IptalMi =1");
                    btniptalEdilen.Text = btniptalEdilen.Text + " (" + IptalSipOnayiSayisi + ")";

                    // iptal onayı bekleyen siparişe ait ürünlerin sayısı
                    string IptalSipUrunSayisi = veri.GetDataCell("SELECT Count(dbo.Siparisler.SiparisId) as Siparis FROM  dbo.Siparisler INNER JOIN dbo.Sepet ON dbo.Siparisler.SiparisId = dbo.Sepet.SiparisId  WHERE (dbo.Sepet.IptalMi=1) ");
                    btniptalEdilenUrun.Text = btniptalEdilenUrun.Text + " (" + IptalSipUrunSayisi + ")";

                }
            }
            catch (Exception)
            {

            }




            if (Page.IsPostBack == false)
            {
                if (islem == "siparisdetay" && SiparisId != null)
                {
                    divIptalEdilenUrunler.Visible = false;
                    diviptalEdilenSiparisler.Visible = false;
                    divSiparisler.Visible = false;
                    divUyeSiparisler.Visible = false;

                    SiparisDetayGetir();
                }
                else if (islem == "uyedetay" && UyeId != null)
                {
                    divIptalEdilenUrunler.Visible = false;
                    diviptalEdilenSiparisler.Visible = false;
                    divSiparisler.Visible = false;
                    divSiparisDetay.Visible = false;

                    UyeSiparisGetir();
                }
                else if (islem == "tsiparisler" && UyeId == null) // tamamlanan siparişler
                {
                    divIptalEdilenUrunler.Visible = false;
                    diviptalEdilenSiparisler.Visible = false;
                    divSiparisDetay.Visible = false;
                    divUyeSiparisler.Visible = false;
                    TamamlananSiparisGetir();
                }
                else if (islem == "isiparisler" && UyeId == null) // iptal edilen sişarişler
                {
                    divIptalEdilenUrunler.Visible = false;
                    divSiparisDetay.Visible = false;
                    divSiparisler.Visible = false;
                    divUyeSiparisler.Visible = false;


                    iptalEdilenSiparisGetir();
                }
                else if (islem == "iurunler" && UyeId == null)// iptal edilen sipariş ürünleri 
                {
                    diviptalEdilenSiparisler.Visible = false;
                    divSiparisDetay.Visible = false;
                    divUyeSiparisler.Visible = false;
                    divSiparisler.Visible = false;

                    İptalEdilenUrunGetir();
                }
                else if (islem == "varyasyon" && SepetId != null)// sepetId e göre ürüne ait varyasyonlar
                {
                    divIptalEdilenUrunler.Visible = false;
                    diviptalEdilenSiparisler.Visible = false;
                    divSiparisler.Visible = false;
                    divUyeSiparisler.Visible = false;
                    divSiparisDetay.Visible = false;

                    divVaryasyon.Visible = true;
                    try
                    {
                        VaryasyonGetir();
                    }
                    catch (Exception)
                    {
                       
                    }
                 
                }
                else
                {
                    divIptalEdilenUrunler.Visible = false;
                    diviptalEdilenSiparisler.Visible = false;
                    divDropDownListele.Visible = true;
                    divSiparisDetay.Visible = false;
                    divUyeSiparisler.Visible = false;

                    SiparisGetir();
                    DropSiparisListele();
                }

            }
        }

        void SiparisGetir()
        {
            DataTable dtSiparisler = veri.GetDataTable("SELECT TOP (100) PERCENT dbo.Siparisler.SiparisId, dbo.Siparisler.UyeId, dbo.Siparisler.Tutar, dbo.Siparisler.DurumId, dbo.Siparisler.OdemeTipi,  dbo.Siparisler.SiparisTarihi, dbo.Siparisler.TeslimTarihi, dbo.Siparisler.BankaId, dbo.Siparisler.KargoId,dbo.Siparisler.Kartisim,  CASE OdemeTipi WHEN 0 THEN 'Kredi Kartı' WHEN 1 THEN 'Havale/EFT' WHEN 2 THEN 'Kapıda Ödeme' END AS OdemeTip, dbo.SiparisDurum.DurumAdi,  dbo.Uyeler.Ad, dbo.Uyeler.Soyad FROM  dbo.Siparisler INNER JOIN dbo.SiparisDurum ON dbo.Siparisler.DurumId = dbo.SiparisDurum.DurumId INNER JOIN dbo.Uyeler ON dbo.Siparisler.UyeId = dbo.Uyeler.UyeId WHERE (dbo.SiparisDurum.DurumId !=7) ORDER BY dbo.Siparisler.SiparisId DESC");

            if (dtSiparisler.Rows.Count >= 1)
            {
                lblBilgi.Text = "Toplam " + dtSiparisler.Rows.Count + " sipariş bulunuyor";
                CollectionPager1.DataSource = dtSiparisler.DefaultView;
                CollectionPager1.BindToControl = RpSiparisler;
                RpSiparisler.DataSource = CollectionPager1.DataSourcePaged;
                RpSiparisler.DataBind();
            }
            else
            {
                lblBilgi.Text = "Henüz sipariş yok.";
            }

        }

        void UyeSiparisGetir()
        {
            DataTable dtSiparisler = veri.GetDataTable("SELECT TOP (100) PERCENT dbo.Siparisler.SiparisId, dbo.Siparisler.UyeId, dbo.Siparisler.Tutar, dbo.Siparisler.DurumId, dbo.Siparisler.OdemeTipi,  dbo.Siparisler.SiparisTarihi, dbo.Siparisler.TeslimTarihi, dbo.Siparisler.BankaId, dbo.Siparisler.KargoId,dbo.Siparisler.Kartisim,  CASE OdemeTipi WHEN 0 THEN 'Kredi Kartı' WHEN 1 THEN 'Havale/EFT' WHEN 2 THEN 'Kapıda Ödeme' END AS OdemeTip, dbo.SiparisDurum.DurumAdi,  dbo.Uyeler.Ad, dbo.Uyeler.Soyad FROM  dbo.Siparisler FULL JOIN dbo.SiparisDurum ON dbo.Siparisler.DurumId = dbo.SiparisDurum.DurumId FULL JOIN dbo.Uyeler ON dbo.Siparisler.UyeId = dbo.Uyeler.UyeId WHERE (dbo.Siparisler.UyeId = " + UyeId + ") ORDER BY dbo.Siparisler.SiparisId DESC");

            if (dtSiparisler.Rows.Count >= 1)
            {
                lblBilgi.Text = dtSiparisler.Rows[0]["Ad"].ToString() + " " + dtSiparisler.Rows[0]["Soyad"].ToString() + " kullanıcısına ait " + dtSiparisler.Rows.Count + " sipariş listeleniyor";
                CollectionPager1.DataSource = dtSiparisler.DefaultView;
                CollectionPager1.BindToControl = RpUyeSiparisleri;
                RpUyeSiparisleri.DataSource = CollectionPager1.DataSourcePaged;
                RpUyeSiparisleri.DataBind();
            }
            else
            {
                lblBilgi.Text = "Henüz sipariş yok.";
            }

        }

        void TamamlananSiparisGetir()
        {
            DataTable dtSiparisler = veri.GetDataTable("SELECT TOP (100) PERCENT dbo.Siparisler.SiparisId, dbo.Siparisler.UyeId, dbo.Siparisler.Tutar, dbo.Siparisler.DurumId, dbo.Siparisler.OdemeTipi,  dbo.Siparisler.SiparisTarihi, dbo.Siparisler.TeslimTarihi, dbo.Siparisler.BankaId, dbo.Siparisler.KargoId,dbo.Siparisler.Kartisim,  CASE OdemeTipi WHEN 0 THEN 'Kredi Kartı' WHEN 1 THEN 'Havale/EFT' WHEN 2 THEN 'Kapıda Ödeme' END AS OdemeTip, dbo.SiparisDurum.DurumAdi,  dbo.Uyeler.Ad, dbo.Uyeler.Soyad FROM  dbo.Siparisler INNER JOIN dbo.SiparisDurum ON dbo.Siparisler.DurumId = dbo.SiparisDurum.DurumId INNER JOIN dbo.Uyeler ON dbo.Siparisler.UyeId = dbo.Uyeler.UyeId WHERE (dbo.SiparisDurum.DurumId =7) ORDER BY dbo.Siparisler.SiparisId DESC");

            if (dtSiparisler.Rows.Count >= 1)
            {
                lblBilgi.Text = "Toplam " + dtSiparisler.Rows.Count + " sipariş bulunuyor";
                CollectionPager1.DataSource = dtSiparisler.DefaultView;
                CollectionPager1.BindToControl = RpSiparisler;
                RpSiparisler.DataSource = CollectionPager1.DataSourcePaged;
                RpSiparisler.DataBind();
            }
            else
            {
                lblBilgi.Text = "Henüz sipariş yok.";
            }

        }
        protected void RpSiparisler_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            DropDownList dropdown = (DropDownList)e.Item.FindControl("ddDurum");

            DataTable DtSiparisDurum = veri.GetDataTable("Select * From SiparisDurum ");

            int sira = 0;
            for (int i = 0; i < DtSiparisDurum.Rows.Count; i++)
            {
                DataRow DrDurum = DtSiparisDurum.Rows[i];
                dropdown.Items.Add(DrDurum["DurumAdi"].ToString());
                dropdown.Items[sira].Value = DrDurum["DurumId"].ToString();
                sira++;
            }

        }

        protected void DropDegerGetir(object sender, EventArgs e) //dropdown seçili değeri alma için olay tutucu
        {
            DropDownList ddl = sender as DropDownList;
            if (ddl != null)
            {
                try
                {

                    veri.cmd("Update Siparisler Set DurumId=" + ddl.SelectedValue + " where SiparisId=" + ddl.DataValueField + "");

                    if (ddl.SelectedValue == "7") // sipariş teslim edildiyse ürünleride teslim edildi yap
                    {
                       

                        
                        // sepet tablosundaki bu siparişe ait ürünleri stoktan düş ama iptal edilmemiş ürünleri

                        DataTable dt = veri.GetDataTable("Select UrunId,Miktar From Sepet Where IptalMi=0 and  SiparisId=" + ddl.DataValueField + "");

                        // ürünleri stoktan düş
                        #region

                        foreach (DataRow sepettekiurun in dt.Rows)
                        {
                            double Miktar = Convert.ToDouble(sepettekiurun["Miktar"].ToString());
                            string UrunId = sepettekiurun["UrunId"].ToString();

                            double kalanmiktar = Convert.ToDouble(veri.GetDataCell("Select StokMiktari From Urunler Where UrunId=" + UrunId + ""));
                            // ürün miktarını al ve düşür
                            kalanmiktar = kalanmiktar - Miktar;
                            veri.cmd("Update Urunler Set StokMiktari=" + kalanmiktar + " Where UrunId=" + UrunId + "");
                        }
                        #endregion
                        // ürünleri stoktan düş

                        //varyant silinmesi
                        #region

                        DataTable dtvar1 = veri.GetDataTable("Select UrunId,Miktar,Var1 From Sepet Where IptalMi=0 and SiparisId=" + ddl.DataValueField + " and Var1 <>0");

                        // ürünleri stoktan düş
                        #region

                        foreach (DataRow sepettekiurun in dtvar1.Rows)
                        {
                            double Miktar = Convert.ToDouble(sepettekiurun["Miktar"].ToString());
                            string UrunId = sepettekiurun["UrunId"].ToString();
                            string AltVarId = sepettekiurun["Var1"].ToString();
                            double kalanmiktar = Convert.ToDouble(veri.GetDataCell("Select StokSayi From Varyantlar Where UrunId=" + UrunId + " and AltVaryantId=" + AltVarId + ""));

                            // ürün miktarını al ve düşür
                            kalanmiktar = kalanmiktar - Miktar;
                            veri.cmd("Update Varyantlar Set StokSayi=" + kalanmiktar + " Where UrunId=" + UrunId + " and AltVaryantId=" + AltVarId + "");
                        }
                        #endregion

                        //var2
                        DataTable dtVar2 = veri.GetDataTable("Select UrunId,Miktar,Var2 From Sepet Where IptalMi=0 and SiparisId=" + ddl.DataValueField + " and Var2 <>0");

                        // ürünleri stoktan düş
                        #region

                        foreach (DataRow sepettekiurun in dtVar2.Rows)
                        {
                            double Miktar = Convert.ToDouble(sepettekiurun["Miktar"].ToString());
                            string UrunId = sepettekiurun["UrunId"].ToString();
                            string AltVarId = sepettekiurun["Var2"].ToString();
                            double kalanmiktar = Convert.ToDouble(veri.GetDataCell("Select StokSayi From Varyantlar Where UrunId=" + UrunId + " and AltVaryantId=" + AltVarId + ""));

                            // ürün miktarını al ve düşür
                            kalanmiktar = kalanmiktar - Miktar;
                            veri.cmd("Update Varyantlar Set StokSayi=" + kalanmiktar + " Where UrunId=" + UrunId + " and AltVaryantId=" + AltVarId + "");
                        }
                        #endregion

                        //var3

                        DataTable dtVar3 = veri.GetDataTable("Select UrunId,Miktar,Var3 From Sepet Where IptalMi=0 and SiparisId=" + ddl.DataValueField + " and Var3 <>0");

                        // ürünleri stoktan düş
                        #region

                        foreach (DataRow sepettekiurun in dtVar3.Rows)
                        {
                            double Miktar = Convert.ToDouble(sepettekiurun["Miktar"].ToString());
                            string UrunId = sepettekiurun["UrunId"].ToString();
                            string AltVarId = sepettekiurun["Var3"].ToString();
                            double kalanmiktar = Convert.ToDouble(veri.GetDataCell("Select StokSayi From Varyantlar Where UrunId=" + UrunId + " and AltVaryantId=" + AltVarId + ""));

                            // ürün miktarını al ve düşür
                            kalanmiktar = kalanmiktar - Miktar;
                            veri.cmd("Update Varyantlar Set StokSayi=" + kalanmiktar + " Where UrunId=" + UrunId + " and AltVaryantId=" + AltVarId + "");
                        }
                        #endregion

                        #endregion
                        // varyant sil bitiş

                        string tarih = veri.GetDataCell("Select TeslimTarihi from Siparisler Where SiparisId=" + ddl.DataValueField + "");

                        // teslim tarihi boşsa tarih ata.Değilse daha önceki teslim tarihi değişmesin.
                        if (tarih == "")
                        {
                            tarih = System.DateTime.Now.ToString();
                            veri.cmd("Update Siparisler Set TeslimTarihi=" + "'" + tarih + "'" + " where SiparisId=" + ddl.DataValueField + "");
                        }


                        veri.cmd("Update Sepet Set UrunDurumId=4 where IptalMi!=2 and SiparisId=" + ddl.DataValueField + "");
                        // ve ürünü sepet tablosunda satıldı yap.
                        veri.cmd("Update Sepet Set SatildiMi=1 where IptalMi!=2 and SiparisId=" + ddl.DataValueField + "");

                        // sipariş alanında iptalmi yi devre dışı bırak
                        veri.cmd("Update Siparisler Set IptalMi=0 where SiparisId=" + ddl.DataValueField + "");
                        // siparişe ait ürünleride iptal ise dever dışı bırak
                        veri.cmd("Update Sepet Set IptalMi=0 where  IptalMi!=2 and SiparisId=" + ddl.DataValueField + "");

                        // siparişi mail olarak gönder

                        // bu siparişi alan üyenin Idsi
                        string Uye = veri.GetDataCell("Select UyeId From Siparisler Where SiparisId=" + ddl.DataValueField + "");
                        // mail gönder
                        #region
                        try
                        {
                            string MailGitsinMi = veri.GetDataCell("Select SiparisTamamAktif From MailForm");

                            if (MailGitsinMi == "True")
                            {

                                DataRow drveri = veri.GetDataRow("Select Mail,MailSifre,MailSmtp,SmtpPort From Firma");


                                smtpadres = drveri["MailSmtp"].ToString();
                                gidenmail = drveri["Mail"].ToString();
                                mailport = Convert.ToInt32(drveri["SmtpPort"]);
                                mailsifre = drveri["MailSifre"].ToString();

                                if (smtpadres == "" || gidenmail == "" || mailport == null || mailsifre == "")
                                {

                                }
                                else
                                {

                                    string SiparisIcerigi = veri.GetDataCell("Select SiparisTamam From MailForm");
                                    if (SiparisIcerigi == "")
                                    {
                                        SiparisIcerigi = SiparisId + " nolu Siparişiniz Teslim Edildi.";
                                    }
                                    SmtpClient mailClient = new SmtpClient(smtpadres, mailport);
                                    mailClient.EnableSsl = true;
                                    NetworkCredential cred = new NetworkCredential(gidenmail, mailsifre);
                                    mailClient.Credentials = cred;
                                    MailMessage contact = new MailMessage();
                                    contact.From = new MailAddress(gidenmail);
                                    contact.Subject = "Sipariş İşlemi";
                                    contact.IsBodyHtml = true;
                                    contact.Body = SiparisIcerigi;

                                    string Mail = veri.GetDataCell("Select Email From Uyeler Where UyeId=" + Uye + "");

                                    contact.Bcc.Add(Mail.ToString());
                                    mailClient.Send(contact);
                                }
                            }
                            else
                            {
                                // eğer mail gönder seçeneği aktif değilse
                               
                            }
                        }
                        catch (Exception)
                        {

                        }
                        #endregion
                        
                     
                    }
                    else if (ddl.SelectedValue == "3") // sipariş iptali. Eğer sipariş iptal edildiyse ürünleride iptal et
                    {
                        veri.cmd("Update Sepet Set UrunDurumId=3 where SiparisId=" + ddl.DataValueField + "");

                        // sepet tablosundaki satıldımı alanını düzenle satılmayan ürün olarak değiştir.

                        veri.cmd("Update Sepet Set SatildiMi=0 where SiparisId=" + ddl.DataValueField + "");

                        // siparişlerdeki iptalmi alanını da iptal et
                        veri.cmd("Update Siparisler Set IptalMi=2 where SiparisId=" + ddl.DataValueField + "");
                        // siparişe ait ürünleride iptal mi alanınıda iptal et
                        veri.cmd("Update Sepet Set IptalMi=2 where SiparisId=" + ddl.DataValueField + "");



                    }
                    else if (ddl.SelectedValue == "4") // sipariş kargoya verildiyse ürünleride değiştir
                    {
                        veri.cmd("Update Sepet Set UrunDurumId=2 where  IptalMi!=2 and SiparisId=" + ddl.DataValueField + "");

                        // ve ürünü sepet tablosunda satıldı yap.
                        veri.cmd("Update Sepet Set SatildiMi=1 where  IptalMi!=2 and SiparisId=" + ddl.DataValueField + "");
                        // sipariş alanında iptalmi yi devre dışı bırak
                        veri.cmd("Update Siparisler Set IptalMi=0 where SiparisId=" + ddl.DataValueField + "");
                        // siparişe ait ürünleride iptal ise dever dışı bırak
                        veri.cmd("Update Sepet Set IptalMi=0 where  IptalMi!=2 and SiparisId=" + ddl.DataValueField + "");
                    }
                    else if (ddl.SelectedValue == "2" || ddl.SelectedValue == "8") // eğer sipariş kısmı teslim veya çıkış yapılıyor seçildi ise. ürünleri  tedarik sürecine al
                    {
                        veri.cmd("Update Sepet Set UrunDurumId=1 where  IptalMi!=2 and SiparisId=" + ddl.DataValueField + "");
                        // ve ürünü sepet tablosunda satıldı yap.
                        veri.cmd("Update Sepet Set SatildiMi=1 where  IptalMi!=2 and SiparisId=" + ddl.DataValueField + "");
                        // sipariş alanında iptalmi yi devre dışı bırak
                        veri.cmd("Update Siparisler Set IptalMi=0 where SiparisId=" + ddl.DataValueField + "");
                        // siparişe ait ürünleride iptal ise dever dışı bırak
                        veri.cmd("Update Sepet Set IptalMi=0 where   IptalMi!=2 and SiparisId=" + ddl.DataValueField + "");
                    }

                    if (UyeId != null)
                    {
                        Response.Redirect("Siparisler.aspx?Uye=" + UyeId + "&islem=uyedetay");
                    }
                    else
                    {
                        Response.Redirect("Siparisler.aspx");
                    }

                }
                catch (Exception ex)
                {
                    Msg.Show("Bir hata meydana geldi, tekrar deneyiniz.");
                    Msg.Show(ex.Message);
                }



            }
        }

        protected void btnAra_Click(object sender, EventArgs e)
        {
            string AranacakDeger = Kontrol.AramaKontrol(txtAra.Text);

            if (AranacakDeger != "")
            {
                divSiparisDetay.Visible = false;
                divUyeSiparisler.Visible = false;
                divSiparisler.Visible = true;

                DataTable dtSiparisler = veri.GetDataTable("SELECT TOP (100) PERCENT dbo.Siparisler.SiparisId,dbo.Siparisler.Kartisim, dbo.Siparisler.UyeId, dbo.Siparisler.Tutar, dbo.Siparisler.DurumId, dbo.Siparisler.OdemeTipi, dbo.Siparisler.SiparisTarihi, dbo.Siparisler.TeslimTarihi, dbo.Siparisler.BankaId, dbo.Siparisler.KargoId,  CASE OdemeTipi WHEN 0 THEN 'Kredi Kartı' WHEN 1 THEN 'Havale/EFT' WHEN 2 THEN 'Kapıda Ödeme' END AS OdemeTip, dbo.SiparisDurum.DurumAdi, dbo.Uyeler.Ad, dbo.Uyeler.Soyad, MIN(dbo.Urunler.UrunAdi) AS UrunAdi FROM  dbo.Siparisler INNER JOIN  dbo.SiparisDurum ON dbo.Siparisler.DurumId = dbo.SiparisDurum.DurumId INNER JOIN dbo.Uyeler ON dbo.Siparisler.UyeId = dbo.Uyeler.UyeId CROSS JOIN dbo.Urunler WHERE (dbo.SiparisDurum.DurumId LIKE '%" + AranacakDeger + "%'" + "  OR dbo.Uyeler.Ad like '%" + AranacakDeger + "%'" + " OR dbo.Uyeler.Soyad like '%" + AranacakDeger + "%'" + " OR dbo.Siparisler.SiparisId like '%" + AranacakDeger + "%'" + " OR dbo.Siparisler.SiparisTarihi like '%" + AranacakDeger + "%'" + " OR dbo.Siparisler.Tutar like '%" + AranacakDeger + "%'" + " OR  dbo.Siparisler.TeslimTarihi like '%" + AranacakDeger + "%'" + " OR dbo.Urunler.UrunAdi like '%" + AranacakDeger + "%'" + " ) GROUP BY dbo.Siparisler.SiparisId, dbo.Siparisler.UyeId, dbo.Siparisler.Tutar, dbo.Siparisler.DurumId, dbo.Siparisler.OdemeTipi, dbo.Siparisler.SiparisTarihi, dbo.Siparisler.TeslimTarihi, dbo.Siparisler.BankaId, dbo.Siparisler.KargoId, dbo.SiparisDurum.DurumAdi, dbo.Uyeler.Ad, dbo.Uyeler.Soyad,dbo.Siparisler.Kartisim ORDER BY dbo.Siparisler.SiparisId DESC");

                if (dtSiparisler.Rows.Count >= 1)
                {
                    lblBilgi.Text = "Arama sonucu " + dtSiparisler.Rows.Count + " sipariş listeleniyor";
                    CollectionPager1.DataSource = dtSiparisler.DefaultView;
                    CollectionPager1.BindToControl = RpSiparisler;
                    RpSiparisler.DataSource = CollectionPager1.DataSourcePaged;
                    RpSiparisler.DataBind();
                }
                else
                {
                    lblBilgi.Text = "Arama değerine göre sipariş bulunamadı.";
                }
            }
        }

        protected void btnSiparisler_Click(object sender, EventArgs e)
        {
            Response.Redirect("Siparisler.aspx");
        }


        void SiparisDetayGetir()
        {
            DataTable DtSipariDetay = veri.GetDataTable("SELECT TOP (100) PERCENT dbo.Siparisler.SiparisId, dbo.Siparisler.UyeId, dbo.Siparisler.SiparisTarihi,dbo.Siparisler.TeslimTarihi,dbo.Sepet.SepetId, dbo.Sepet.Miktar, dbo.Sepet.UrunId,dbo.Sepet.IptalMi,dbo.Sepet.SatildiMi,dbo.Urunler.UrunAdi, dbo.Siparisler.KargoId, dbo.Kargolar.KargoAdi, dbo.UrunDurum.UrunDurumAdi, dbo.UrunDurum.UrunDurumId FROM  dbo.Siparisler INNER JOIN dbo.Sepet ON dbo.Siparisler.SiparisId = dbo.Sepet.SiparisId INNER JOIN dbo.Urunler ON dbo.Sepet.UrunId = dbo.Urunler.UrunId INNER JOIN dbo.Kargolar ON dbo.Siparisler.KargoId = dbo.Kargolar.KargoId INNER JOIN dbo.UrunDurum ON dbo.Sepet.UrunDurumId = dbo.UrunDurum.UrunDurumId WHERE (dbo.Siparisler.SiparisId = " + SiparisId + ") Order By SepetId Desc");

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
                Response.Redirect("/yonetim/Siparisler.aspx");
            }

        }

        protected void RpUyeSiparisleri_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            DropDownList dropdown = (DropDownList)e.Item.FindControl("ddDurum");

            DataTable DtSiparisDurum = veri.GetDataTable("Select * From SiparisDurum ");

            int sira = 0;
            for (int i = 0; i < DtSiparisDurum.Rows.Count; i++)
            {
                DataRow DrDurum = DtSiparisDurum.Rows[i];
                dropdown.Items.Add(DrDurum["DurumAdi"].ToString());
                dropdown.Items[sira].Value = DrDurum["DurumId"].ToString();
                sira++;
            }
        }

        protected void RpSiparisDetay_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
            DropDownList dropdowndurum = (DropDownList)e.Item.FindControl("ddDetayDurum");

            DataTable DtUrunDurum = veri.GetDataTable("Select * From UrunDurum ");

            int sira = 0;
            for (int i = 0; i < DtUrunDurum.Rows.Count; i++)
            {
                DataRow DrUrunDurum = DtUrunDurum.Rows[i];
                dropdowndurum.Items.Add(DrUrunDurum["UrunDurumAdi"].ToString());
                dropdowndurum.Items[sira].Value = DrUrunDurum["UrunDurumId"].ToString();
                sira++;
            }
        }

        protected void DropDetayDurum(object sender, EventArgs e) //dropdown seçili değeri alma için olay tutucu
        {

            DropDownList ddl = sender as DropDownList;
            if (ddl != null)
            {
                try
                {
                    // urun durumıd değerini drowdownda seçili değer yap.
                    veri.cmd("Update Sepet Set UrunDurumId=" + ddl.SelectedValue + " where SepetId=" + ddl.DataValueField + "");

                    SiparisId = veri.GetDataCell("Select SiparisId From Sepet Where SepetId=" + ddl.DataValueField + "");


                    if (ddl.SelectedValue == "3") // eğer iptal et seçildiyse
                    {

                        int urunsayisi = Convert.ToInt32(veri.GetDataCell("select COUNT(SepetId) From Sepet Where SiparisId=" + SiparisId + ""));
                        int iptalsayisi = Convert.ToInt32(veri.GetDataCell("select COUNT(SepetId) From Sepet Where UrunDurumId=3 and SiparisId=" + SiparisId + ""));

                        if (urunsayisi == iptalsayisi) // Açıklama: eğer ürün sayısı ve UrunDurumId  eşitse demek diğer ürünlerde iptal edilmiş sadece bu kalmış veya tek ürün vardır bu nedenle direk siparişi iptal et. - Ama eğer birden fazla ürün varsa siparişe karışma sadece o ürünü iptal et.
                        {
                            // eğer urun durumu iptal olarak seçildiyse sepetteki satildimi alanını false ve iptalmi'yi iptal yap
                            veri.cmd("Update Sepet Set SatildiMi=0, IptalMi=2 where SepetId=" + ddl.DataValueField + "");
                            // ve siparişide iptal et sipariş tablosundaki alanlarıyla birlikte.
                            veri.cmd("Update Siparisler Set DurumId=3,IptalMi=2 where SiparisId=" + SiparisId + " ");
                        }
                        else  // ama eğer birden fazla ürün varsa siparişe karışma sadece o ürünü iptal et.
                        {
                            veri.cmd("Update Sepet Set SatildiMi=0, IptalMi=2 where SepetId=" + ddl.DataValueField + "");



                        }

                    }
                    else if (ddl.SelectedValue == "1") // eğer tedarik sürecinde seçildiyse
                    {

                        veri.cmd("Update Sepet Set SatildiMi=1, IptalMi=0 where SepetId=" + ddl.DataValueField + "");
                        // sipariş durumid 2 yani çıkış yapılıyor yap
                        veri.cmd("Update Siparisler Set DurumId=2,IptalMi=0 where SiparisId=" + SiparisId + " ");
                    }
                    else if (ddl.SelectedValue == "2") // kargoya verildi seçildiyse
                    {
                        veri.cmd("Update Sepet Set SatildiMi=1, IptalMi=0 where SepetId=" + ddl.DataValueField + "");
                        // sipariş durumid 4 yani kargoya verildi yap
                        veri.cmd("Update Siparisler Set DurumId=4,IptalMi=0 where SiparisId=" + SiparisId + " ");
                    }
                    else if (ddl.SelectedValue == "4") // teslim edildi seçildiyse
                    {
                        veri.cmd("Update Sepet Set SatildiMi=1, IptalMi=0 where SepetId=" + ddl.DataValueField + "");
                        // sipariş durumid 4 yani teslim edildi yap
                        veri.cmd("Update Siparisler Set DurumId=7,IptalMi=0 where SiparisId=" + SiparisId + " ");
                    }


                    // ve siparişler tablosundaki tutarı güncelleki gelirdetay sayfasında iptal edilen siparişlerin veya ürünlerin fiyatıda gelmesin. Bunu siparişlerde yapmadım çünkü sipariş iptal edildiyse tüm ürünlerde iptal edilir ve gelirdetay sayfasında zaten olmaz.

                    // önce sipariş Id değerine göre üye tipini getir
                    string UyeTip = veri.GetDataCell("SELECT Top 1 dbo.Uyeler.UyeTip FROM  dbo.Uyeler INNER JOIN dbo.Siparisler ON dbo.Uyeler.UyeId = dbo.Siparisler.UyeId WHERE  (dbo.Siparisler.SiparisId = " + SiparisId + ")");


                    if (UyeTip == "0") // daha sonra üye ise siparişe ait sepetteki ürünlerin kdvli üye fiyatını getir
                    {
                        dtFiyat = veri.GetDataTable("SELECT dbo.Urunler.SatisFiyati, ((dbo.Urunler.SatisFiyati - dbo.Urunler.indirim) * dbo.Urunler.Kdv / 100 + dbo.Urunler.SatisFiyati - dbo.Urunler.indirim)* dbo.Sepet.Miktar  AS SatisFiyatiKdvli FROM  dbo.Sepet INNER JOIN dbo.Urunler ON dbo.Sepet.UrunId = dbo.Urunler.UrunId WHERE (dbo.Sepet.SiparisId = " + SiparisId + ") AND (dbo.Sepet.IptalMi <> 2)");

                        if (dtFiyat != null)
                        {
                            for (int i = 0; i < dtFiyat.Rows.Count; i++)
                            {
                                DataRow DrOku = dtFiyat.Rows[i];

                                fiyattoplam += Convert.ToDouble(DrOku["SatisFiyatiKdvli"]);
                            }

                        }


                    }
                    else if (UyeTip == "1") // bayi ise ürünlerin kdvli bayi fiyatını getir
                    {
                        dtFiyat = veri.GetDataTable("SELECT dbo.Urunler.BayiFiyati, ((dbo.Urunler.BayiFiyati - dbo.Urunler.BayiIndirim) * dbo.Urunler.Kdv / 100 + dbo.Urunler.BayiFiyati - dbo.Urunler.BayiIndirim)* dbo.Sepet.Miktar  AS BayiFiyatiKdvli FROM  dbo.Sepet INNER JOIN  dbo.Urunler ON dbo.Sepet.UrunId = dbo.Urunler.UrunId WHERE (dbo.Sepet.SiparisId = " + SiparisId + ") AND (dbo.Sepet.IptalMi <> 2)");

                        if (dtFiyat != null)
                        {
                            for (int i = 0; i < dtFiyat.Rows.Count; i++)
                            {
                                DataRow DrOku = dtFiyat.Rows[i];

                                fiyattoplam += Convert.ToDouble(DrOku["BayiFiyatiKdvli"]);
                            }

                        }
                    }
                    // ve sipariş fiyatını güncelle fiyat converte hata olmaması için procedure yazdım.

                    SqlConnection baglan = veri.baglan();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = baglan;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_SiparisIptalFiyat";
                    cmd.Parameters.AddWithValue("@Tutar", fiyattoplam);
                    cmd.Parameters.AddWithValue("@SiparisId", SiparisId);
                    cmd.ExecuteNonQuery();

                    Response.Redirect("Siparisler.aspx?Detay=" + SiparisId + "&islem=siparisdetay");

                }
                catch (Exception ex)
                {
                    Msg.Show("Bir hata meydana geldi, tekrar deneyiniz." + ex.Message);
                }

            }
        }

        protected void btnTamamlanan_Click(object sender, EventArgs e)
        {
            Response.Redirect("Siparisler.aspx?islem=tsiparisler");
        }

        void DropSiparisListele() // drop down
        {
            if (Page.IsPostBack == false)
            {
                DataTable DtSiparisDurum = veri.GetDataTable("Select * From SiparisDurum ");

                ddSiparisListele.Items.Add("Seçiniz");
                ddSiparisListele.Items[0].Value = "0";
                int sira = 1;
                for (int i = 0; i < DtSiparisDurum.Rows.Count; i++)
                {
                    DataRow DrDurum = DtSiparisDurum.Rows[i];
                    ddSiparisListele.Items.Add(DrDurum["DurumAdi"].ToString());
                    ddSiparisListele.Items[sira].Value = DrDurum["DurumId"].ToString();
                    sira++;
                }
            }

        }

        protected void ddSiparisListele_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddSiparisListele.SelectedValue == "0")
            {
                SiparisGetir();
            }
            else
            {

                DataTable dtSiparisler = veri.GetDataTable("SELECT TOP (100) PERCENT dbo.Siparisler.SiparisId, dbo.Siparisler.UyeId, dbo.Siparisler.Tutar, dbo.Siparisler.DurumId, dbo.Siparisler.OdemeTipi,  dbo.Siparisler.SiparisTarihi, dbo.Siparisler.TeslimTarihi,dbo.Siparisler.Kartisim, dbo.Siparisler.BankaId, dbo.Siparisler.KargoId,  CASE OdemeTipi WHEN 0 THEN 'Kredi Kartı' WHEN 1 THEN 'Havale/EFT' WHEN 2 THEN 'Kapıda Ödeme' END AS OdemeTip, dbo.SiparisDurum.DurumAdi,  dbo.Uyeler.Ad, dbo.Uyeler.Soyad FROM  dbo.Siparisler INNER JOIN dbo.SiparisDurum ON dbo.Siparisler.DurumId = dbo.SiparisDurum.DurumId INNER JOIN dbo.Uyeler ON dbo.Siparisler.UyeId = dbo.Uyeler.UyeId WHERE (dbo.SiparisDurum.DurumId= " + ddSiparisListele.SelectedValue + ") ORDER BY dbo.Siparisler.SiparisId DESC");


                CollectionPager1.DataSource = dtSiparisler.DefaultView;
                CollectionPager1.BindToControl = RpSiparisler;
                RpSiparisler.DataSource = CollectionPager1.DataSourcePaged;
                RpSiparisler.DataBind();

                if (dtSiparisler.Rows.Count >= 1)
                {
                    lblBilgi.Text = ddSiparisListele.SelectedItem.Text + " durumunda " + dtSiparisler.Rows.Count + " sipariş bulunuyor";

                }
                else
                {
                    lblBilgi.Text = "Bu durumda sipariş yok.";
                }
            }


        }

        // iptal onayı bekleyen siparişler

        void iptalEdilenSiparisGetir()
        {
            DataTable dtSiparisler = veri.GetDataTable("SELECT TOP (100) PERCENT dbo.Siparisler.SiparisId, dbo.Siparisler.UyeId,dbo.Siparisler.IptalMi, dbo.Siparisler.Tutar, dbo.Siparisler.DurumId, dbo.Siparisler.OdemeTipi,  dbo.Siparisler.SiparisTarihi,dbo.Siparisler.TeslimTarihi, dbo.Siparisler.BankaId, dbo.Siparisler.KargoId,dbo.Siparisler.Kartisim, CASE OdemeTipi WHEN 0 THEN 'Kredi Kartı' WHEN 1 THEN 'Havale/EFT' WHEN 2 THEN 'Kapıda Ödeme' END AS OdemeTip, dbo.SiparisDurum.DurumAdi,  dbo.Uyeler.Ad, dbo.Uyeler.Soyad FROM  dbo.Siparisler INNER JOIN dbo.SiparisDurum ON dbo.Siparisler.DurumId = dbo.SiparisDurum.DurumId INNER JOIN dbo.Uyeler ON dbo.Siparisler.UyeId = dbo.Uyeler.UyeId WHERE (dbo.Siparisler.IptalMi=1) ORDER BY dbo.Siparisler.SiparisId DESC");

            if (dtSiparisler.Rows.Count >= 1)
            {
                lblBilgi.Text = "İptal onayı bekleyen " + dtSiparisler.Rows.Count + " sipariş bulunuyor";
                CollectionPager1.DataSource = dtSiparisler.DefaultView;
                CollectionPager1.BindToControl = RpiptalSiparis;
                RpiptalSiparis.DataSource = CollectionPager1.DataSourcePaged;
                RpiptalSiparis.DataBind();
            }
            else
            {
                lblBilgi.Text = "İptal onayı bekleyen sipariş yok.";
            }

        }

        protected void btniptalEdilen_Click(object sender, EventArgs e)
        {
            Response.Redirect("Siparisler.aspx?islem=isiparisler");
        }
        // sipariş iptali dropdown olay yakala.

        protected void DropSiparisIptali(object sender, EventArgs e)
        {
            DropDownList ddliptal = sender as DropDownList;
            if (ddliptal != null)
            {
                try
                {

                    if (ddliptal.SelectedValue == "1") // sipariş iptal onayı seçildiyse.
                    {

                        veri.cmd("Update Siparisler Set IptalMi=2 where SiparisId=" + ddliptal.DataValueField + " ");
                        // sipariş iptal edildiyse siparişler tablosundaki DurumId alanınıda iptal olarak değiştirelim.
                        veri.cmd("Update Siparisler Set DurumId=3 Where SiparisId=" + ddliptal.DataValueField + "");
                        // sipariş iptal ediydiyse sepetteki bu siparişe ait tüm ürünleride iptal et.
                        veri.cmd("Update Sepet Set UrunDurumId=3,IptalMi=2 where SiparisId=" + ddliptal.DataValueField + "");
                        // ve sepetteki satildi olayını değiştir
                        veri.cmd("Update Sepet Set SatildiMi=0 where SiparisId=" + ddliptal.DataValueField + "");
                        Response.Redirect("Siparisler.aspx?islem=isiparisler");
                    }
                    else if (ddliptal.SelectedValue == "2") // siparişi iptal etme onayı seçildiyse.
                    {
                        veri.cmd("Update Siparisler Set IptalMi=0 where SiparisId=" + ddliptal.DataValueField + " ");
                        Response.Redirect("Siparisler.aspx?islem=isiparisler");
                    }

                }
                catch (Exception)
                {
                    Msg.Show("Bir hata meydana geldi, tekrar deneyiniz.");

                }

            }
        }

        // iptal edilen siparişlerdeki ürünler
        void İptalEdilenUrunGetir()
        {
            DataTable DtSipariDetay = veri.GetDataTable("SELECT TOP (100) PERCENT dbo.Siparisler.SiparisId, dbo.Siparisler.UyeId, dbo.Siparisler.SiparisTarihi,dbo.Siparisler.TeslimTarihi,dbo.Sepet.SepetId, dbo.Sepet.Miktar, dbo.Sepet.UrunId,dbo.Sepet.IptalMi,dbo.Sepet.SatildiMi,dbo.Urunler.UrunAdi, dbo.Siparisler.KargoId, dbo.Kargolar.KargoAdi, dbo.UrunDurum.UrunDurumAdi,dbo.UrunDurum.UrunDurumId FROM  dbo.Siparisler INNER JOIN dbo.Sepet ON dbo.Siparisler.SiparisId = dbo.Sepet.SiparisId INNER JOIN dbo.Urunler ON dbo.Sepet.UrunId = dbo.Urunler.UrunId INNER JOIN dbo.Kargolar ON dbo.Siparisler.KargoId = dbo.Kargolar.KargoId INNER JOIN dbo.UrunDurum ON dbo.Sepet.UrunDurumId = dbo.UrunDurum.UrunDurumId WHERE (dbo.Sepet.IptalMi=1) Order By SepetId Desc");

            if (DtSipariDetay.Rows.Count >= 1)
            {
                lblBilgi.Text = "İptal onayı bekleyen " + DtSipariDetay.Rows.Count + " sipariş bulunuyor";

                CollectionPager1.DataSource = DtSipariDetay.DefaultView;
                CollectionPager1.BindToControl = RpiptalEdilenUrunler;
                RpiptalEdilenUrunler.DataSource = CollectionPager1.DataSourcePaged;
                RpiptalEdilenUrunler.DataBind();
            }
            else
            {
                lblBilgi.Text = "İptal onayı bekleyen sipariş yok.";

            }

        }

        protected void DropUrunIptali(object sender, EventArgs e)
        {
            DropDownList ddliptal = sender as DropDownList;
            if (ddliptal != null)
            {
                try
                {
                    SiparisId = ddliptal.DataTextField;

                    if (ddliptal.SelectedValue == "1") // sipariş iptal onayı seçildiyse.
                    {

                        // önce urun durumunu iptal et alttaki sorgu ona göre gelecek
                        veri.cmd("Update Sepet Set UrunDurumId=3 where SepetId=" + ddliptal.DataValueField + "");
                        int urunsayisi = Convert.ToInt32(veri.GetDataCell("select COUNT(SepetId) From Sepet Where SiparisId=" + SiparisId + ""));
                        int iptalsayisi = Convert.ToInt32(veri.GetDataCell("select COUNT(SepetId) From Sepet Where UrunDurumId=3 and SiparisId=" + SiparisId + "")); //siparişe ait iptal edilmek istenen ile siparisteki ürün sayısı eşitse siparişide iptal et değilse tek o ürünü iptal et.


                        if (urunsayisi == iptalsayisi) // Açıklama: DropDetayDurum kısmında açıklama var.
                        {
                            // eğer urun durumu iptal olarak seçildiyse sepetteki satildimi alanını false ve iptalmi'yi iptal yap
                            veri.cmd("Update Sepet Set SatildiMi=0, IptalMi=2 where SepetId=" + ddliptal.DataValueField + "");
                            // ve siparişide iptal et sipariş tablosundaki alanlarıyla birlikte.
                            veri.cmd("Update Siparisler Set DurumId=3,IptalMi=2 where SiparisId=" + SiparisId + " ");
                        }
                        else  // ama eğer birden fazla ürün varsa siparişe karışma sadece o ürünü iptal et.
                        {
                            veri.cmd("Update Sepet Set SatildiMi=0,UrunDurumId=3,IptalMi=2 where SepetId=" + ddliptal.DataValueField + "");
                        }



                    }
                    else if (ddliptal.SelectedValue == "2") // siparişi iptal etme onayı seçildiyse.
                    {
                        // UrunDurumId 1 yani tedarik sürecinde yap.
                        veri.cmd("Update Sepet Set UrunDurumId=1,IptalMi=0,SatildiMi=0 Where SepetId=" + ddliptal.DataValueField + "");

                        // sipariş durumid 2 yani çıkış yapılıyor yap
                        veri.cmd("Update Siparisler Set DurumId=2,IptalMi=0 where SiparisId=" + SiparisId + " ");

                    }

                    Response.Redirect("Siparisler.aspx?islem=iurunler");
                }
                catch (Exception ex)
                {
                    Msg.Show("Bir hata meydana geldi, tekrar deneyiniz." + ex.Message);

                }

            }
        }

        protected void btniptalEdilenUrun_Click(object sender, EventArgs e)
        {
            Response.Redirect("Siparisler.aspx?islem=iurunler");
        }

        protected void ddOdemeTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddOdemeTipi.SelectedValue == "Seçiniz")
            {
                SiparisGetir();
            }
            else
            {

                DataTable dtSiparisler = veri.GetDataTable("SELECT TOP (100) PERCENT dbo.Siparisler.SiparisId, dbo.Siparisler.UyeId, dbo.Siparisler.Tutar, dbo.Siparisler.DurumId, dbo.Siparisler.OdemeTipi,  dbo.Siparisler.SiparisTarihi, dbo.Siparisler.TeslimTarihi,dbo.Siparisler.Kartisim, dbo.Siparisler.BankaId, dbo.Siparisler.KargoId,  CASE OdemeTipi WHEN 0 THEN 'Kredi Kartı' WHEN 1 THEN 'Havale/EFT' WHEN 2 THEN 'Kapıda Ödeme' END AS OdemeTip, dbo.SiparisDurum.DurumAdi,  dbo.Uyeler.Ad, dbo.Uyeler.Soyad FROM  dbo.Siparisler INNER JOIN dbo.SiparisDurum ON dbo.Siparisler.DurumId = dbo.SiparisDurum.DurumId INNER JOIN dbo.Uyeler ON dbo.Siparisler.UyeId = dbo.Uyeler.UyeId WHERE (dbo.Siparisler.OdemeTipi= " + ddOdemeTipi.SelectedValue + ") ORDER BY dbo.Siparisler.SiparisId DESC");


                CollectionPager1.DataSource = dtSiparisler.DefaultView;
                CollectionPager1.BindToControl = RpSiparisler;
                RpSiparisler.DataSource = CollectionPager1.DataSourcePaged;
                RpSiparisler.DataBind();

                if (dtSiparisler.Rows.Count >= 1)
                {
                    lblBilgi.Text = ddOdemeTipi.SelectedItem.Text + " durumunda " + dtSiparisler.Rows.Count + " sipariş bulunuyor";

                }
                else
                {
                    lblBilgi.Text = "Bu ödeme tipinde sipariş yok.";
                }
            }
        }

        protected void btnExcel_Click(object sender, ImageClickEventArgs e)
        {
            if (islem == "siparisdetay" && SiparisId != null) // sipariş detayları
            {
                AktarSiparisdetay();
            }
            else if (islem == "uyedetay" && UyeId != null) // üyenin tüm siparişleri
            {
                AktarUyeSiparisleri();
            }
            else if (islem == "tsiparisler" && UyeId == null) // tamamlanan siparişler
            {
                AktarTamamlananSiparisler();
            }
            else if (islem == "isiparisler" && UyeId == null) // iptal edilen sişarişler
            {
                AktarIptalOnayiBekleyen();
            }
            else if (islem == "iurunler" && UyeId == null)// iptal edilen sipariş ürünleri 
            {
                AktarIptalOnayiBekleyenUrunler();
            }
            else // ana bekleyen siparişleri getir
            {
                AktarSiparisler();
            }

            if (GridAktar.Rows.Count >= 1)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=" + DosyaAdi + ".xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridAktar.RenderControl(hw);
                Response.Output.Write(sw.ToString().Replace("<div>", "").Replace("</div>", ""));
                Response.Flush();
                Response.End();
            }
            else
            {
                Msg.Show("Aktaracak veri yok");
            }


        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        protected void btnWord_Click(object sender, ImageClickEventArgs e)
        {
            if (islem == "siparisdetay" && SiparisId != null) // sipariş detayları
            {
                AktarSiparisdetay();
            }
            else if (islem == "uyedetay" && UyeId != null) // üyenin tüm siparişleri
            {
                AktarUyeSiparisleri();
            }
            else if (islem == "tsiparisler" && UyeId == null) // tamamlanan siparişler
            {
                AktarTamamlananSiparisler();
            }
            else if (islem == "isiparisler" && UyeId == null) // iptal edilen sişarişler
            {
                AktarIptalOnayiBekleyen();
            }
            else if (islem == "iurunler" && UyeId == null)// iptal edilen sipariş ürünleri 
            {
                AktarIptalOnayiBekleyenUrunler();
            }
            else // ana bekleyen siparişleri getir
            {
                AktarSiparisler();
            }

            if (GridAktar.Rows.Count >= 1)
            {
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=" + DosyaAdi + ".doc");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-word";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridAktar.RenderControl(hw);
                Response.Output.Write(sw.ToString().Replace("<div>", "").Replace("</div>", ""));
                Response.Flush();
                Response.End();
            }
            else
            {
                Msg.Show("Aktaracak veri yok");
            }

        }
        protected void btnPdf_Click(object sender, ImageClickEventArgs e)
        {
            if (islem == "siparisdetay" && SiparisId != null) // sipariş detayları
            {
                AktarSiparisdetay();
            }
            else if (islem == "uyedetay" && UyeId != null) // üyenin tüm siparişleri
            {
                AktarUyeSiparisleri();
            }
            else if (islem == "tsiparisler" && UyeId == null) // tamamlanan siparişler
            {
                AktarTamamlananSiparisler();
            }
            else if (islem == "isiparisler" && UyeId == null) // iptal edilen sişarişler
            {
                AktarIptalOnayiBekleyen();
            }
            else if (islem == "iurunler" && UyeId == null)// iptal edilen sipariş ürünleri 
            {
                AktarIptalOnayiBekleyenUrunler();
            }
            else // ana bekleyen siparişleri getir
            {
                AktarSiparisler();
            }

            if (GridAktar.Rows.Count >= 1)
            {
                try
                {

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition",
                        "attachment;filename=" + DosyaAdi + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    StringWriter sw = new StringWriter();
                    HtmlTextWriter hw = new HtmlTextWriter(sw);
                    GridAktar.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    Response.Write(pdfDoc);
                    Response.End();
                }
                catch (Exception)
                {

                }
            }
            else
            {
                Msg.Show("Aktaracak veri yok");
            }
        }
        void AktarSiparisler()//exvel word aktarımı
        {
            DataTable dtSiparisler = veri.GetDataTable("SELECT TOP (100) PERCENT dbo.Siparisler.SiparisId as 'Sipariş Numarası', dbo.Siparisler.Tutar as 'Sipariş Tutarı', dbo.Siparisler.SiparisTarihi as 'Sipariş Tarihi', dbo.Siparisler.TeslimTarihi as 'Teslimat Tarihi',dbo.Siparisler.Kartisim 'Kart Üzerindeki İsim', CASE OdemeTipi WHEN 0 THEN 'Kredi Kartı' WHEN 1 THEN 'Havale/EFT' WHEN 2 THEN 'Kapıda Ödeme' END AS 'Ödeme Tipi', dbo.SiparisDurum.DurumAdi as 'Sipariş Durumu',  dbo.Uyeler.Ad +' '+ dbo.Uyeler.Soyad as 'Üye' FROM  dbo.Siparisler INNER JOIN dbo.SiparisDurum ON dbo.Siparisler.DurumId = dbo.SiparisDurum.DurumId INNER JOIN dbo.Uyeler ON dbo.Siparisler.UyeId = dbo.Uyeler.UyeId WHERE (dbo.SiparisDurum.DurumId !=7) ORDER BY dbo.Siparisler.SiparisId DESC");
            DosyaAdi = System.DateTime.Now.ToShortDateString() + "-Siparisler";

            if (dtSiparisler.Rows.Count >= 1)
            {
                GridAktar.DataSource = dtSiparisler;
                GridAktar.DataBind();
                GridAktar.AllowPaging = false;
            }

        }
        void AktarSiparisdetay()//exvel word aktarımı
        {
            DataTable dtSiparisler = veri.GetDataTable("SELECT     TOP (100) PERCENT dbo.Siparisler.SiparisId AS 'Sipariş No', dbo.Siparisler.SiparisTarihi AS 'Sipariş Tarihi', dbo.Siparisler.TeslimTarihi AS 'Teslimat Tarihi',  dbo.Sepet.Miktar AS 'Sipariş Miktarı', dbo.Urunler.UrunAdi AS 'Ürün Adı', dbo.Kargolar.KargoAdi AS 'Kargo', dbo.UrunDurum.UrunDurumAdi AS 'Ürün Durumu', dbo.Uyeler.Ad +' '+ dbo.Uyeler.Soyad as 'Üye' FROM  dbo.Siparisler FULL JOIN dbo.Sepet ON dbo.Siparisler.SiparisId = dbo.Sepet.SiparisId FULL JOIN dbo.Urunler ON dbo.Sepet.UrunId = dbo.Urunler.UrunId FULL JOIN dbo.Kargolar ON dbo.Siparisler.KargoId = dbo.Kargolar.KargoId FULL JOIN dbo.UrunDurum ON dbo.Sepet.UrunDurumId = dbo.UrunDurum.UrunDurumId FULL JOIN dbo.Uyeler ON dbo.Siparisler.UyeId = dbo.Uyeler.UyeId WHERE (dbo.Siparisler.SiparisId = " + SiparisId + ") ORDER BY dbo.Sepet.SepetId DESC");

            DosyaAdi = System.DateTime.Now.ToShortDateString() + "-" + SiparisId + "-Nolu-Siparisdetayi";

            if (dtSiparisler.Rows.Count >= 1)
            {
                GridAktar.DataSource = dtSiparisler;
                GridAktar.DataBind();
            }

        }
        void AktarUyeSiparisleri()//exvel word aktarımı
        {
            DataTable dtSiparisler = veri.GetDataTable("SELECT TOP (100) PERCENT dbo.Siparisler.SiparisId as 'Sipariş No', dbo.Siparisler.Tutar as 'Tutar', dbo.Siparisler.SiparisTarihi as 'Sipariş Tarihi', dbo.Siparisler.TeslimTarihi as 'Teslimat Tarihi', dbo.Siparisler.Kartisim as 'Kart Üzerindeki İsim',  CASE OdemeTipi WHEN 0 THEN 'Kredi Kartı' WHEN 1 THEN 'Havale/EFT' WHEN 2 THEN 'Kapıda Ödeme' END AS 'Ödeme Tipi', dbo.SiparisDurum.DurumAdi as 'Durum',dbo.Uyeler.Ad +' '+ dbo.Uyeler.Soyad as 'Üye' FROM  dbo.Siparisler FULL JOIN dbo.SiparisDurum ON dbo.Siparisler.DurumId = dbo.SiparisDurum.DurumId FULL JOIN dbo.Uyeler ON dbo.Siparisler.UyeId = dbo.Uyeler.UyeId WHERE (dbo.Siparisler.UyeId = " + UyeId + ") ORDER BY dbo.Siparisler.SiparisId DESC");

            DosyaAdi = System.DateTime.Now.ToShortDateString() + "-" + UyeId + "-Nolu-UyeSiparisleri";

            if (dtSiparisler.Rows.Count >= 1)
            {
                GridAktar.DataSource = dtSiparisler;
                GridAktar.DataBind();
            }

        }
        void AktarTamamlananSiparisler()//exvel word aktarımı
        {
            DataTable dtSiparisler = veri.GetDataTable("SELECT TOP (100) PERCENT dbo.Siparisler.SiparisId as 'Sipariş Numarası', dbo.Siparisler.Tutar as 'Sipariş Tutarı', dbo.Siparisler.SiparisTarihi as 'Sipariş Tarihi', dbo.Siparisler.TeslimTarihi as 'Teslimat Tarihi',dbo.Siparisler.Kartisim 'Kart Üzerindeki İsim', CASE OdemeTipi WHEN 0 THEN 'Kredi Kartı' WHEN 1 THEN 'Havale/EFT' WHEN 2 THEN 'Kapıda Ödeme' END AS 'Ödeme Tipi', dbo.SiparisDurum.DurumAdi as 'Sipariş Durumu',  dbo.Uyeler.Ad +' '+ dbo.Uyeler.Soyad as 'Üye' FROM  dbo.Siparisler INNER JOIN dbo.SiparisDurum ON dbo.Siparisler.DurumId = dbo.SiparisDurum.DurumId INNER JOIN dbo.Uyeler ON dbo.Siparisler.UyeId = dbo.Uyeler.UyeId WHERE (dbo.SiparisDurum.DurumId =7) ORDER BY dbo.Siparisler.SiparisId DESC");

            DosyaAdi = System.DateTime.Now.ToShortDateString() + "-Tamamlanan-Siparisler";

            if (dtSiparisler.Rows.Count >= 1)
            {
                GridAktar.DataSource = dtSiparisler;
                GridAktar.DataBind();
            }

        }
        void AktarIptalOnayiBekleyen()//exvel word aktarımı
        {
            DataTable dtSiparisler = veri.GetDataTable("SELECT TOP (100) PERCENT dbo.Siparisler.SiparisId as 'Sipariş Numarası', dbo.Siparisler.Tutar as 'Sipariş Tutarı', dbo.Siparisler.SiparisTarihi as 'Sipariş Tarihi', dbo.Siparisler.TeslimTarihi as 'Teslimat Tarihi',dbo.Siparisler.Kartisim 'Kart Üzerindeki İsim', CASE OdemeTipi WHEN 0 THEN 'Kredi Kartı' WHEN 1 THEN 'Havale/EFT' WHEN 2 THEN 'Kapıda Ödeme' END AS 'Ödeme Tipi', dbo.SiparisDurum.DurumAdi as 'Sipariş Durumu',  dbo.Uyeler.Ad +' '+ dbo.Uyeler.Soyad as 'Üye' FROM  dbo.Siparisler INNER JOIN dbo.SiparisDurum ON dbo.Siparisler.DurumId = dbo.SiparisDurum.DurumId INNER JOIN dbo.Uyeler ON dbo.Siparisler.UyeId = dbo.Uyeler.UyeId WHERE (dbo.Siparisler.IptalMi=1) ORDER BY dbo.Siparisler.SiparisId DESC");

            DosyaAdi = System.DateTime.Now.ToShortDateString() + "-iptalOnayiBekleyen-Siparisler";

            if (dtSiparisler.Rows.Count >= 1)
            {
                GridAktar.DataSource = dtSiparisler;
                GridAktar.DataBind();
            }



        }
        void AktarIptalOnayiBekleyenUrunler()//exvel word aktarımı
        {
            DataTable dtSiparisler = veri.GetDataTable("SELECT TOP (100) PERCENT dbo.Siparisler.SiparisId as 'Sipariş No', dbo.Siparisler.SiparisTarihi as 'Sipariş Tarihi',dbo.Siparisler.TeslimTarihi as 'Teslimat Tarihi',dbo.Sepet.Miktar as 'Miktar',dbo.Urunler.UrunAdi as 'Ürün',dbo.Kargolar.KargoAdi as 'Kargo',dbo.UrunDurum.UrunDurumAdi as 'Durum' FROM  dbo.Siparisler INNER JOIN dbo.Sepet ON dbo.Siparisler.SiparisId = dbo.Sepet.SiparisId INNER JOIN dbo.Urunler ON dbo.Sepet.UrunId = dbo.Urunler.UrunId INNER JOIN dbo.Kargolar ON dbo.Siparisler.KargoId = dbo.Kargolar.KargoId INNER JOIN dbo.UrunDurum ON dbo.Sepet.UrunDurumId = dbo.UrunDurum.UrunDurumId WHERE (dbo.Sepet.IptalMi=1) Order By SepetId Desc");

            DosyaAdi = System.DateTime.Now.ToShortDateString() + "-iptalOnayiBekleyen-Siparisler-Urunleri";

            if (dtSiparisler.Rows.Count >= 1)
            {
                GridAktar.DataSource = dtSiparisler;
                GridAktar.DataBind();
            }

        }

        void VaryasyonGetir()
        {
            DataRow drSepetVar = veri.GetDataRow("Select Var1,Var2,Var3 From Sepet Where SepetID=" + SepetId + "");
            if (drSepetVar["Var1"].ToString() != "" && drSepetVar["Var1"].ToString() != "0")
            {
                //// önce ana varyantıd öğrenelim
                //string AnaVarId = veri.GetDataCell("Select AnaVaryantId From AltVaryantlar where AltVaryantId=" + drSepetVar["Var1"].ToString() + ""); bunu sonra kaldırdım zaten ana varyantlar 1,2,3 olarak statik gidiyor.

                // ana varyasyon adı
                string AnaVarAdi = veri.GetDataCell("Select VaryantAdi From AnaVaryant where AnaVaryantId=1 ");

                // alt varyasyon adi

                string altVarAdi = veri.GetDataCell("Select AltVaryantAdi From AltVaryantlar where AltVaryantId=" + drSepetVar["Var1"].ToString() + "");

                lblVarAdi1.Text = AnaVarAdi;
                lblVar1.Text = altVarAdi;

            }
            else // varyant seçilmedise yinede labele ana varyant adı gelsin
            {
                lblVarAdi1.Text = veri.GetDataCell("Select VaryantAdi From AnaVaryant where AnaVaryantId=1 ");
                lblVar1.Text = "-";
            }
            // var 2 için

            if (drSepetVar["Var2"].ToString() != "" && drSepetVar["Var2"].ToString() != "0")
            {

                // ana varyasyon adı
                string AnaVarAdi = veri.GetDataCell("Select VaryantAdi From AnaVaryant where AnaVaryantId=2");

                // alt varyasyon adi

                string altVarAdi = veri.GetDataCell("Select AltVaryantAdi From AltVaryantlar where AltVaryantId=" + drSepetVar["Var2"].ToString() + "");

                lblVarAdi2.Text = AnaVarAdi;
                lblVar2.Text = altVarAdi;

            }
            else
            {
                lblVarAdi2.Text = veri.GetDataCell("Select VaryantAdi From AnaVaryant where AnaVaryantId=2 ");
                lblVar2.Text = "-";
            }
            if (drSepetVar["Var3"].ToString() != "" && drSepetVar["Var3"].ToString() != "0")
            {

                // ana varyasyon adı
                string AnaVarAdi = veri.GetDataCell("Select VaryantAdi From AnaVaryant where AnaVaryantId=3");

                // alt varyasyon adi

                string altVarAdi = veri.GetDataCell("Select AltVaryantAdi From AltVaryantlar where AltVaryantId=" + drSepetVar["Var3"].ToString() + "");

                lblVarAdi3.Text = AnaVarAdi;
                lblVar3.Text = altVarAdi;

            }
            else
            {
                lblVarAdi3.Text = veri.GetDataCell("Select VaryantAdi From AnaVaryant where AnaVaryantId=3 ");
                lblVar3.Text = "-";
            }
        }


    }
}