using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using aSanalPos;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Text;
using System.IO;
using System.Web.Script.Serialization;
using System.Security.Cryptography;

namespace Eticaret
{
    public partial class Siparis : System.Web.UI.Page
    {
        protected string token;

        baglanti veri = new baglanti();
        string smtpadres, gidenmail, mailsifre;
        int mailport;
        string UyeId, SiparisId;
        string KdvTutari, KdvSizFiyat, KdvDahil, Havaleindirim, TekCekimindirim, HavaleTutar, Tutar, KapidaOdemeTutar;
        int KacTaksit;
        string KrediKartiOdeme, BankahavaleOdeme, KapidaOdeme, OrtakOdeme3D;
        double KargoFiyati, KapidaOdemeKargoFiyat;
        string Host3d, Name3d, Password3d, CliendId3d, Mid3D, StrKey3D, StrPassword3D, ProvUserId3D, TidUserId3D, Tid3D;
        

        protected void Page_Load(object sender, EventArgs e)
        {

            Page.Title = "Sipariş";
            if (Session["UyeId"] == null)
            {
                Response.Redirect("/Uyelik/Giris.aspx");
            }
            else if (Session["KdvDahil"] == null)
            {
                Response.Redirect("/Uye/Sepet.aspx");
            }
            else
            {

                DataRow DrOdemeSecenek = veri.GetDataRow("Select * From OdemeSecenek");
                KrediKartiOdeme = DrOdemeSecenek["KrediKarti"].ToString();
                BankahavaleOdeme = DrOdemeSecenek["BankaHavale"].ToString();
                KapidaOdeme = DrOdemeSecenek["KapidaOdeme"].ToString();
                OrtakOdeme3D = DrOdemeSecenek["Odeme3D"].ToString();

                if (KrediKartiOdeme == "False") // kredi kartı ile ödeme devre dışı bırakıldıysa
                {
                    TabPanel1.Visible = false;
                }

                if (BankahavaleOdeme == "False")
                {
                    TabPanel2.Visible = false;
                }
                if (KapidaOdeme == "False")
                {

                    Tabs3.Visible = false;
                }
                if (OrtakOdeme3D == "False")
                {
                    Tab3DOdeme.Visible = false;
                }

                UyeId = Session["UyeId"].ToString();


                // sepetten gelen fiyatlar
                try
                {
                    if (Session["KdvTutari"] != null)
                    {
                        KdvTutari = Session["KdvTutari"].ToString();
                    }
                    else
                    {
                        KdvTutari = "0";
                    }
                    if (Session["KdvSizFiyat"] != null)
                    {
                        KdvSizFiyat = Session["KdvSizFiyat"].ToString();
                    }
                    else
                    {
                        KdvSizFiyat = "0";
                    }

                    if (Session["KdvDahil"] != null)
                    {
                        KdvDahil = Session["KdvDahil"].ToString();
                    }
                    else
                    {
                        KdvDahil = "0";
                    }

                    if (Session["Havaleindirim"] != null)
                    {
                        Havaleindirim = Session["Havaleindirim"].ToString();
                    }
                    else
                    {
                        Havaleindirim = "0";
                    }

                    if (Session["TekCekimindirim"] != null)
                    {
                        TekCekimindirim = Session["TekCekimindirim"].ToString();
                    }
                    else
                    {
                        TekCekimindirim = "0";
                    }


                }
                catch (Exception)
                {
                }


                AdresGetir();
                KargoGetir();
                BankaGetir();
                // kredi kartı ile ödeme dropdown taksit seçeneği
                BankaTaksitGetir();

                // tek çekim seçilirse tek çekim dropdownu doldur

                RadyokTekCekimDoldur();
                RadyokTekCekimDoldur3D();

                // kargo seçenekleri 
                if (HiddenKargoSec.Value != "")
                {
                    DataRow DrKargo = veri.GetDataRow("Select * From Kargolar Where KargoId=" + HiddenKargoSec.Value + "");

                    double KargoAltLimit = Convert.ToDouble(DrKargo["AltLimit"]);
                    if (Convert.ToDouble(KdvDahil) >= (KargoAltLimit))
                    {
                        KargoFiyati = 0;
                    }
                    else
                    {
                        KargoFiyati = Convert.ToDouble(DrKargo["SabitUcret"]);
                    }

                    // kapıda ödeme fiyatı

                    KapidaOdemeKargoFiyat = Convert.ToDouble(DrKargo["KapidaOdeme"]);
                }

                // havale


                if (Havaleindirim == "" || Havaleindirim == "0")
                {
                    lblHavaleAraToplam.Text = KdvSizFiyat + " TL";
                    lblHavaleKdv.Text = KdvTutari + " TL";
                    lblHavaleKargo.Text = KargoFiyati.ToString("c");
                    double KargoHavale = Convert.ToDouble(KargoFiyati) + Convert.ToDouble(KdvDahil);
                    lblHavaleKdvDahil.Text = KargoHavale.ToString("c");
                    trHavale.Visible = false;
                    HavaleTutar = KdvDahil;

                }
                else
                {
                    trHavaleKDV.Visible = false;

                    lblHavaleAraToplam.Text = KdvSizFiyat + " TL";
                    lblHavaleKdv.Text = KdvTutari + " TL";
                    lblHavaleKargo.Text = KargoFiyati.ToString("c");
                    double KargoHavaleindirim = Convert.ToDouble(KargoFiyati) + Convert.ToDouble(Havaleindirim);
                    lblHavaleFiyat.Text = KargoHavaleindirim.ToString("c");
                    HavaleTutar = Havaleindirim;

                }

                // kapıda ödeme

                lblKapidaAraToplam.Text = KdvSizFiyat + " TL";
                lblKapidaKdv.Text = KdvTutari + " TL";
                lblKapidaKargo.Text = KapidaOdemeKargoFiyat.ToString("c");
                double KargoKapida = Convert.ToDouble(KdvDahil);
                KargoKapida = KargoKapida + KapidaOdemeKargoFiyat;
                lblKapidaKdvDahil.Text = KargoKapida.ToString("c");
                KapidaOdemeTutar = KargoKapida.ToString();


                // Kredi Kartı ile ödeme
                lblKartAraToplam.Text = KdvSizFiyat + " TL";
                lblKartKdv.Text = KdvTutari + " TL";
                lblKartKargo.Text = KargoFiyati.ToString("c");
                double KrediKartiFiyat = Convert.ToDouble(KdvDahil);
                KrediKartiFiyat = KrediKartiFiyat + KargoFiyati;
                lblKartKdvDahil.Text = KrediKartiFiyat.ToString("c");
                Tutar = KrediKartiFiyat.ToString();

                //kerdi kartı 3d ortak ödeme yukardakilerin aynısı

                lblKartAraToplam3D.Text = KdvSizFiyat + " TL";
                lblKartKdv3D.Text = KdvTutari + " TL";
                lblKartKargo3D.Text = KargoFiyati.ToString("c");
                lblKartKdvDahil3D.Text = KrediKartiFiyat.ToString("c");

            }


        }

        void AdresGetir()
        {
            if (Page.IsPostBack == false)
            {

                DataRow drTAdres = veri.GetDataRow("SELECT  UyeId,TFirmaAd,TAd,TSoyad,TAdres,TPostaKodu,TTel1,TTel2, iller.ilAdi as ilAdi, ilceler.ilceAdi as ilceAdi FROM AdresFatura INNER JOIN dbo.iller ON dbo.AdresFatura.TilId = dbo.iller.ilId INNER JOIN dbo.ilceler ON dbo.AdresFatura.TilceId = dbo.ilceler.ilceId WHERE (dbo.AdresFatura.UyeId =" + UyeId + ")");

                DataRow drFAdres = veri.GetDataRow("SELECT  UyeId,FFirmaAd,FAd,FSoyad,FAdres,FPostaKodu,FTel1,FTel2,FVergiTcNo, iller.ilAdi as ilAdi, ilceler.ilceAdi as ilceAdi FROM AdresFatura INNER JOIN dbo.iller ON dbo.AdresFatura.FilId = dbo.iller.ilId INNER JOIN dbo.ilceler ON dbo.AdresFatura.FilceId = dbo.ilceler.ilceId WHERE (dbo.AdresFatura.UyeId = 1)");
                if (drTAdres != null)
                {
                    if (drTAdres["TAdres"].ToString() == "" || drFAdres["FAdres"].ToString() == "")
                    {
                        Response.Redirect("/Uye/Adresim.aspx?U=/Siparis.aspx");
                    }
                    else
                    {

                        // Teslimat Adresi
                        lblAdSoyad.Text = drTAdres["TAd"].ToString() + " " + drTAdres["TSoyad"].ToString();
                        lblAdres.Text = drTAdres["Tadres"].ToString();
                        lblTel.Text = drTAdres["TTel1"].ToString() + " - " + drTAdres["TTel2"].ToString();
                        lblilIlce.Text = drTAdres["TPostaKodu"].ToString() + " - " + drTAdres["ilAdi"].ToString() + "/" + drTAdres["ilceAdi"].ToString();

                        //Fatura Adresi

                        lblFaturaAdSoyad.Text = drFAdres["FAd"].ToString() + " " + drFAdres["FSoyad"].ToString();
                        lblFaturaAdres.Text = drFAdres["Fadres"].ToString();
                        lblFaturaTel.Text = drFAdres["FTel1"].ToString() + " - " + drFAdres["FTel2"].ToString();
                        lblFaturailIlce.Text = drFAdres["FPostaKodu"].ToString() + " - " + drFAdres["ilAdi"].ToString() + "/" + drFAdres["ilceAdi"].ToString();
                    }
                }
            }
        }


        void KargoGetir()
        {
            if (Page.IsPostBack == false)
            {
                DataTable dtKargo = veri.GetDataTable("Select * from Kargolar Where Sil=0 and Aktif=1");
                RpKargo.DataSource = dtKargo;
                RpKargo.DataBind();
            }

        }
        void BankaGetir()
        {
            if (Page.IsPostBack == false)
            {
                DataTable dtKargo = veri.GetDataTable("Select * from Bankalar Where Aktif=1");
                RpBankaHavale.DataSource = dtKargo;
                RpBankaHavale.DataBind();
            }

        }

        protected void btnileri_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTabIndex = TabContainer1.ActiveTabIndex + 1;
        }

        protected void btnGeri_Click(object sender, EventArgs e)
        {
            TabContainer1.ActiveTabIndex = TabContainer1.ActiveTabIndex - 1;
        }


        protected void btnHavaleTamamla_Click(object sender, EventArgs e)
        {
            // havale siparişi tamamala
            if (HiddenKargoSec.Value == "")
            {
                Msg.Show("Lütfen kargo seçiminizi yapınız.");
                TabContainer1.ActiveTabIndex = 1;
            }
            else if (HiddenBankaId.Value == "")
            {
                Msg.Show("Lütfen ödeme yapacağınız bankayı seçiniz.");
            }
            else
            {


                SqlConnection baglanti = veri.baglan();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_HavaleSiparis";
                cmd.Parameters.AddWithValue("@UyeId", UyeId);
                cmd.Parameters.AddWithValue("@Tutar", Convert.ToDouble(HavaleTutar));
                cmd.Parameters.AddWithValue("@DurumId", 5);
                cmd.Parameters.AddWithValue("@OdemeTipi", 1);//0 kredi kartı 1 banka 2 kapıda ödeme
                cmd.Parameters.AddWithValue("@BankaId", HiddenBankaId.Value);// seçili bankaId
                cmd.Parameters.AddWithValue("@KargoId", HiddenKargoSec.Value);//kargo


                try
                {
                    cmd.ExecuteNonQuery();
                    //sepet sayfasındaki id güncelle sepetten düşsün
                    SiparisId = veri.GetDataCell("Select Top 1 SiparisId From Siparisler Where UyeId=" + UyeId + " Order By SiparisId Desc");

                    if (SiparisId != null)
                    {
                        veri.cmd("Update Sepet Set SiparisId=" + SiparisId + " where SiparisId=0 and UyeId=" + UyeId + "");
                        //sipariş adresini kaydet
                        SiparisAdresiAl();
                    }
                    // session sil
                    Session.Remove("KdvDahil");

                    //işlem başarılysa mail gonder
                    MailGonder();

                    Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Siparişiniz Tamamlandı'); window.location.href ='/Uye/Siparislerim.aspx';</script>");
                }
                catch (Exception)
                {
                    Msg.Show("Sipariş sırasında bir hata meydana geldi. Lütfen tekrar deneyin.");
                }
            }


        }

        protected void btnKapidaOdeme_Click(object sender, EventArgs e)
        {
            if (HiddenKargoSec.Value == "")
            {
                Msg.Show("Lütfen kargo seçiminizi yapınız.");
                TabContainer1.ActiveTabIndex = 1;
            }
            else
            {

                SqlConnection baglanti = veri.baglan();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_HavaleSiparis";
                cmd.Parameters.AddWithValue("@UyeId", UyeId);
                cmd.Parameters.AddWithValue("@Tutar", Convert.ToDouble(KapidaOdemeTutar));
                cmd.Parameters.AddWithValue("@DurumId", 2);
                cmd.Parameters.AddWithValue("@OdemeTipi", 2);//0 kredi kartı 1 banka 2 kapıda ödeme
                cmd.Parameters.AddWithValue("@BankaId", DBNull.Value);// kapıda ödeme bankaId gerek yok.
                cmd.Parameters.AddWithValue("@KargoId", HiddenKargoSec.Value);//kargo

                try
                {
                    cmd.ExecuteNonQuery();

                    string SiparisId = veri.GetDataCell("Select Top 1 SiparisId From Siparisler Where UyeId=" + UyeId + " Order By SiparisId Desc");

                    if (SiparisId != null)
                    {
                        veri.cmd("Update Sepet Set SiparisId=" + SiparisId + " where SiparisId=0 and UyeId=" + UyeId + "");
                        //sipariş adresini kaydet
                        SiparisAdresiAl();
                    }

                    // session sil
                    Session.Remove("KdvDahil");

                    //işlem başarılysa mail gonder
                    MailGonder();

                    Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Siparişiniz Tamamlandı'); window.location.href ='/Uye/Siparislerim.aspx';</script>");
                }
                catch (Exception)
                {
                    Msg.Show("Sipariş sırasında bir hata meydana geldi. Lütfen tekrar deneyin.");

                }
            }
        }


        protected void RpBankaHavale_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            RadioButton rd = (RadioButton)e.Item.FindControl("RadioKargo");
            string script = "SetSingleRadioButton('" + rd.Text + "',this)";
            rd.Attributes.Add("onclick", script);
        }

        protected void RpKargo_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
                return;
            RadioButton rd = (RadioButton)e.Item.FindControl("RadioKargoId");
            string script = "RadioButonSec('" + rd.Text + "',this)";
            rd.Attributes.Add("onclick", script);


        }

        public void iyzicoCekim()
        {
            if (ddTaksit.SelectedValue != "0")
            {

                Tutar = Kontrol.SiparisTutar(ddTaksit.SelectedItem.ToString());
                lblKartKdvDahil.Text = Tutar.ToString() + " TL";

            }

            if (Convert.ToInt32(ddBanka.SelectedValue) >= 1 && Convert.ToInt32(ddTaksit.SelectedValue) >= 1)
            {

                lblKartKdvDahil.Text = Tutar;

            }

            if (ddTaksit.SelectedValue != "0" && ddTaksit.SelectedValue != "1")
            {
                KacTaksit = Convert.ToInt32(ddTaksit.SelectedValue);

            }
            else
            {
                KacTaksit = 0;
            }

            WebRequest request = WebRequest.Create("https://ctpe.net/frontend/GenerateToken");
            request.Method = "POST";

            string postData = "SECURITY.SENDER=IYZICO_SENDER" +
                    "&TRANSACTION.CHANNEL=IYZICO_CHANNEL" +
                    "&TRANSACTION.MODE=LIVE" +
                    "&USER.LOGIN=IYZICO_LOGIN" +
                    "&USER.PWD=IYZICO_PWD" +
                    "&PAYMENT.TYPE=DB" +
                    "&IDENTIFICATION.TRANSACTIONID=MERCHANT_TRANSACTIONID" +
                    "&PRESENTATION.USAGE=MERCHANT_DESCRIPTION" +
                    "&PRESENTATION.AMOUNT=50.00" +
                    "&PRESENTATION.CURRENCY=TRY" +
                    "&NAME.GIVEN=CUSTOMER_FISTNAME" +
                    "&NAME.FAMILY=CUSTOMER_LASTNAME" +
                    "&NAME.COMPANY=COMPANY_NAME" +
                    "&ADDRESS.STREET=CUSTOMER_ADDRESS" +
                    "&ADDRESS.ZIP=CUSTOMER_ZIP" +
                    "&ADDRESS.CITY=CUSTOMER_CITY" +
                    "&ADDRESS.STATE=CUSTOMER_CITY" +
                    "&ADDRESS.COUNTRY=CUSTOMER_COUNTRY_CODE" +
                    "&CONTACT.PHONE=CUSTOMER_PHONE" +
                    "&CONTACT.MOBILE=CUSTOMER_MOBILE" +
                    "&CONTACT.EMAIL=CUSTOMER_EMAIL" +
                    "&CONTACT.IP=CUSTOMER_IP";

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();


            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();


            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();


            reader.Close();
            dataStream.Close();
            response.Close();

            var jss = new JavaScriptSerializer();
            dynamic data = jss.Deserialize<dynamic>(responseFromServer);

            token = data["transaction"]["token"];

        }
        public void iyzicoTestCekim()
        {
            if (ddTaksit.SelectedValue != "0")
            {

                Tutar = Kontrol.SiparisTutar(ddTaksit.SelectedItem.ToString());
                lblKartKdvDahil.Text = Tutar.ToString() + " TL";

            }


            if (Convert.ToInt32(ddBanka.SelectedValue) >= 1 && Convert.ToInt32(ddTaksit.SelectedValue) >= 1)
            {


                lblKartKdvDahil.Text = Tutar;

            }

            if (ddTaksit.SelectedValue != "0" && ddTaksit.SelectedValue != "1")
            {
                KacTaksit = Convert.ToInt32(ddTaksit.SelectedValue);

            }
            else
            {
                KacTaksit = 0;
            }

            WebRequest request = WebRequest.Create("https://test.ctpe.net/frontend/GenerateToken");
            request.Method = "POST";

            string postData = "SECURITY.SENDER=IYZICO_SENDER" +
                        "&TRANSACTION.CHANNEL=IYZICO_CHANNEL" +
                        "&TRANSACTION.MODE=INTEGRATOR_TEST" +
                        "&USER.LOGIN=IYZICO_LOGIN" +
                        "&USER.PWD=IYZICO_PWD" +
                        "&PAYMENT.TYPE=DB" +
                        "&IDENTIFICATION.TRANSACTIONID=MERCHANT_TRANSACTIONID" +
                        "&PRESENTATION.USAGE=MERCHANT_DESCRIPTION" +
                        "&PRESENTATION.AMOUNT=50.00" +
                        "&PRESENTATION.CURRENCY=TRY" +
                        "&NAME.GIVEN=CUSTOMER_FIRSTNAME" +
                        "&NAME.FAMILY=CUSTOMER_LASTNAME" +
                        "&NAME.COMPANY=COMPANY_NAME" +
                        "&ADDRESS.STREET=CUSTOMER_ADDRESS" +
                        "&ADDRESS.ZIP=CUSTOMER_ZIP" +
                        "&ADDRESS.CITY=CUSTOMER_CITY" +
                        "&ADDRESS.STATE=CUSTOMER_STATE" +
                        "&ADDRESS.COUNTRY=CUSTOMER_COUNTRY_CODE" +
                        "&CONTACT.PHONE=CUSTOMER_PHONE" +
                        "&CONTACT.MOBILE=CUSTOMER_MOBILE" +
                        "&CONTACT.EMAIL=CUSTOMER_EMAIL" +
                        "&CONTACT.IP=CUSTOMER_IP";

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();


            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();


            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();


            reader.Close();
            dataStream.Close();
            response.Close();


            var jss = new JavaScriptSerializer();
            dynamic data = jss.Deserialize<dynamic>(responseFromServer);

            token = data["transaction"]["token"];

        }
        public void Cekim()
        {
            if (ddTaksit.SelectedValue != "0")
            {

                Tutar = Kontrol.SiparisTutar(ddTaksit.SelectedItem.ToString());
                lblKartKdvDahil.Text = Tutar.ToString() + " TL";

            }


            if (Convert.ToInt32(ddBanka.SelectedValue) >= 1 && Convert.ToInt32(ddTaksit.SelectedValue) >= 1)
            {


                lblKartKdvDahil.Text = Tutar;

            }

            if (ddTaksit.SelectedValue != "0" && ddTaksit.SelectedValue != "1")
            {
                KacTaksit = Convert.ToInt32(ddTaksit.SelectedValue);

            }
            else
            {
                KacTaksit = 0;
            }


            PosForm pf = new PosForm
            {

                ay = Convert.ToInt32(ddAy.SelectedValue),
                yil = Convert.ToInt32(ddYil.SelectedValue),
                guvenlikKodu = Convert.ToInt32(txtCvc.Text),
                kartNumarasi = long.Parse(txtKartNo1.Text + txtKartNo2.Text + txtKartNo3.Text + txtKartNo4.Text),
                kartSahibi = txtKartSahibi.Text,

                taksit = KacTaksit,
                tutar = Convert.ToDouble(Tutar)
            };

            // Poslarımıza yukarıdaki bilgileri gönderiyoruz.
            Pos p = new Pos();

            // Garanti Bankası: 1, Yapı Kredi: 2, Vakıf Bank: 3, Ak Bank: 4, İş Bankası: 5, Finans Bank: 6

            if (RadioTaksitli.Checked == true) // eğer tek seçim seçildiyse 
            {
                // seçili bankanın bilgilerini getir ve işlem yap

                string PosId = ddTekCekBanka.SelectedValue;
                DataRow DrPos = veri.GetDataRow("Select * From Pos Where PosId=" + PosId + "");

                Pos.Host = DrPos["HostUrl"].ToString();
                Pos.Name = DrPos["Name"].ToString();
                Pos.Password = DrPos["Sifre"].ToString();
                Pos.ClientId = Convert.ToInt32(DrPos["CliendId"]).ToString();
                Pos.Posno = DrPos["PosNo"].ToString();
                Pos.Xcip = DrPos["Xcip"].ToString();
                Pos.Mid = DrPos["Mid"].ToString();
                Pos.Tid = DrPos["Tid"].ToString();

                if (PosId == "1") // garanti bankası
                {
                    p.GarantiBankasi(pf);
                }
                else if (PosId == "2") // yapı kredi bankası
                {
                    p.YapiKredi(pf);

                }
                else if (PosId == "3") // Vakıf bank
                {
                    p.VakifBank(pf);
                }
                else if (PosId == "4") // Ak bankası
                {
                    p.Akbank(pf);
                }
                else if (PosId == "5") // iş bankası
                {
                    p.IsBankasi(pf);
                }
                else if (PosId == "6") // finans bank
                {
                    p.FinansBank(pf);
                }
            }
            else if (RadioTaksit.Checked == true) // taksitli seçildiyse
            {
                DataRow DrPos = veri.GetDataRow("Select Top 1 * From Pos Where Aktif=1");
                string PosId = DrPos["PosId"].ToString();

                Pos.Host = DrPos["HostUrl"].ToString();
                Pos.Name = DrPos["Name"].ToString();
                Pos.Password = DrPos["Sifre"].ToString();
                Pos.ClientId = Convert.ToInt32(DrPos["CliendId"]).ToString();
                Pos.Posno = DrPos["PosNo"].ToString();
                Pos.Xcip = DrPos["Xcip"].ToString();
                Pos.Mid = DrPos["Mid"].ToString();
                Pos.Tid = DrPos["Tid"].ToString();

                if (PosId == "1") // garanti bankası
                {
                    p.GarantiBankasi(pf);
                }
                else if (PosId == "2") // yapı kredi bankası
                {
                    p.YapiKredi(pf);

                }
                else if (PosId == "3") // Vakıf bank
                {
                    p.VakifBank(pf);
                }
                else if (PosId == "4") // Ak bankası
                {
                    p.Akbank(pf);
                }
                else if (PosId == "5") // iş bankası
                {
                    p.IsBankasi(pf);
                }
                else if (PosId == "6") // finans bank
                {
                    p.FinansBank(pf);
                }

            }


            // Örnek gönderim;
            //p.Akbank(pf);


            // Poslardan geriye dönen bilgileri alıyoruz.

            if (p.sonuc)
            {
                // Çekim işlemi başarılı ise, geri dönen bilgileri alıyoruz. 
                // Bankadan bankaya değişiklik göstereceği için, alanlardan bazıları boş gelebilir.
                SqlConnection baglanti = veri.baglan();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_KrediKartiSiparis";

                cmd.Parameters.AddWithValue("@UyeId", UyeId);
                cmd.Parameters.AddWithValue("@Tutar", Tutar);
                cmd.Parameters.AddWithValue("@DurumId", 2);
                cmd.Parameters.AddWithValue("@OdemeTipi", 0);//0 kredi kartı 1 banka 2 kapıda ödeme
                cmd.Parameters.AddWithValue("@SiparisTarihi", System.DateTime.Now.ToString());
                cmd.Parameters.AddWithValue("@KargoId", HiddenKargoSec.Value);
                cmd.Parameters.AddWithValue("@ReferansNo", p.referansNo);
                cmd.Parameters.AddWithValue("@GroupId", p.groupId);
                cmd.Parameters.AddWithValue("@TransId", p.transId);
                cmd.Parameters.AddWithValue("@Pcode", p.code);
                cmd.Parameters.AddWithValue("@Kartisim", txtKartSahibi.Text);

                try
                {
                    cmd.ExecuteNonQuery();

                    string SiparisId = veri.GetDataCell("Select Top 1 SiparisId From Siparisler Where UyeId=" + UyeId + " Order By SiparisId Desc");

                    if (SiparisId != null)
                    {
                        veri.cmd("Update Sepet Set SatildiMi =1,SiparisId=" + SiparisId + " where SiparisId=0 and UyeId=" + UyeId + "");

                        //sipariş adresini kaydet
                        SiparisAdresiAl();

                        //// siparişi stoktan düş. - panelde teslim edildiğinde stoktan düşüyor şimdilik kaldırdım buradan


                        //DataTable dt = veri.GetDataTable("Select UrunId,Miktar From Sepet Where SiparisId=" + SiparisId + "");

                        //// ürünleri stoktan düş
                        //#region

                        //foreach (DataRow sepettekiurun in dt.Rows)
                        //{
                        //    double Miktar = Convert.ToDouble(sepettekiurun["Miktar"].ToString());
                        //    string UrunId = sepettekiurun["UrunId"].ToString();

                        //    double kalanmiktar = Convert.ToDouble(veri.GetDataCell("Select StokMiktari From Urunler Where UrunId=" + UrunId + ""));
                        //    // ürün miktarını al ve düşür
                        //    kalanmiktar = kalanmiktar - Miktar;
                        //    veri.cmd("Update Urunler Set StokMiktari=" + kalanmiktar + " Where UrunId=" + UrunId + "");
                        //}
                        //#endregion
                        //// ürünleri stoktan düş
                    }

                    // session sil
                    Session.Remove("KdvDahil");

                    Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Siparişiniz Tamamlandı'); window.location.href ='/Uye/Siparislerim.aspx';</script>");
                }
                catch (Exception)
                {
                    Msg.Show("Sipariş sırasında bir hata meydana geldi. Lütfen tekrar deneyin.");
                }

                //Response.Write(p.referansNo);
                //Response.Write(p.groupId);
                //Response.Write(p.transId);
                //Response.Write(p.code);


                //çekim başarılı ise mail gonder.

                MailGonder();

            }
            else
            {
                // Çekim işlemi herhangi bir sebepden dolayı olumsuz sonuçlanmışsa, bankadan dönen hatayı alıyoruz.
                // Hata kodlarının açıklamaları ilgili banka dökümantasyonunda belirtilmiştir.
                // Response.Write(p.sonuc);
                lblBilgi.Text = p.hataMesaji.ToString();
                //Response.Write(p.hataKodu);
            }
        }

        protected void btnKrediKartiOde_Click(object sender, EventArgs e)
        {
            if (HiddenKargoSec.Value == "")
            {
                Msg.Show("Lütfen kargo seçiminizi yapınız.");
                TabContainer1.ActiveTabIndex = 1;
            }
            else if (RadioTaksit.Checked == false && RadioTaksitli.Checked == false)
            {
                Msg.Show("Lütfen taksit seçiminizi yapınız.");
            }
            else
            {
                DataRow drbilgi = veri.GetDataRow("Select * From OdemeSecenek");
                if (drbilgi["KrediKarti"].ToString() == "True") //kredi kartı ile ödeme varsa
                {
                    int AktifPos = Convert.ToInt32(drbilgi["AktifPos"]);

                    if (AktifPos == 1) // 1 sanal pos çekim 
                    {
                        Cekim();
                    }
                    else if (AktifPos == 2) // 2 iyzicocekim
                    {
                        iyzicoCekim();
                    }
                    else if (AktifPos == 3) // 3 iyzico test çekimi
                    {
                        iyzicoTestCekim();

                    }
                }

            }

        }

        void BankaTaksitGetir()
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    ddBanka.Items.Add("Banka Seçiniz:");
                    ddBanka.Items[0].Value = "0";

                    ddTaksit.Items.Add("Önce Banka Seçiniz");
                    ddTaksit.Items[0].Value = "0";
                    DataTable DtVeriler = veri.GetDataTable("Select TaksitId,BankaAdi From TaksitSecenekleri Where Aktif=1 ");

                    int sira = 1;
                    for (int i = 0; i < DtVeriler.Rows.Count; i++)
                    {
                        DataRow DrKayit = DtVeriler.Rows[i];
                        ddBanka.Items.Add(DrKayit["BankaAdi"].ToString());
                        ddBanka.Items[sira].Value = DrKayit["TaksitId"].ToString();
                        sira++;
                    }

                    // 3d için
                    ddBanka3D.Items.Add("Banka Seçiniz:");
                    ddBanka3D.Items[0].Value = "0";

                    ddTaksit3D.Items.Add("Önce Banka Seçiniz");
                    ddTaksit3D.Items[0].Value = "0";

                    sira = 1;
                    for (int i = 0; i < DtVeriler.Rows.Count; i++)
                    {
                        DataRow DrKayit = DtVeriler.Rows[i];
                        ddBanka3D.Items.Add(DrKayit["BankaAdi"].ToString());
                        ddBanka3D.Items[sira].Value = DrKayit["TaksitId"].ToString();
                        sira++;
                    }
                }

            }
            catch (Exception)
            {

            }
        }

        protected void ddBanka_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                ddTaksit.Items.Clear();
                ddTaksit.Items.Add("Taksit Seçenekleri");
                ddTaksit.Items[0].Value = "0";
                DataRow DrVeriler = veri.GetDataRow("Select * From TaksitSecenekleri Where TaksitId=" + ddBanka.SelectedValue + " ");

                double ToplamTutar = Convert.ToDouble(Tutar);

                ddTaksit.Items.Add("Tek Çekim: " + ToplamTutar.ToString("c"));
                ddTaksit.Items[1].Value = "1";

                if (DrVeriler["Taksit2"].ToString() != "9999,0000")
                {
                    double Taksit2 = ToplamTutar / 100 * Convert.ToDouble(DrVeriler["Taksit2"]) + ToplamTutar;

                    ddTaksit.Items.Add(new ListItem("2 Taksit: " + Taksit2.ToString("c"), "2"));
                }

                if (DrVeriler["Taksit3"].ToString() != "9999,0000")
                {
                    double Taksit3 = ToplamTutar / 100 * Convert.ToDouble(DrVeriler["Taksit3"]) + ToplamTutar;
                    ddTaksit.Items.Add(new ListItem("3 Taksit: " + Taksit3.ToString("c"), "3"));
                }

                if (DrVeriler["Taksit4"].ToString() != "9999,0000")
                {
                    double Taksit4 = ToplamTutar / 100 * Convert.ToDouble(DrVeriler["Taksit4"]) + ToplamTutar;
                    ddTaksit.Items.Add(new ListItem("4 Taksit: " + Taksit4.ToString("c"), "4"));
                }

                if (DrVeriler["Taksit5"].ToString() != "9999,0000")
                {
                    double Taksit5 = ToplamTutar / 100 * Convert.ToDouble(DrVeriler["Taksit5"]) + ToplamTutar;
                    ddTaksit.Items.Add(new ListItem("5 Taksit: " + Taksit5.ToString("c"), "5"));
                }
                if (DrVeriler["Taksit6"].ToString() != "9999,0000")
                {
                    double Taksit6 = ToplamTutar / 100 * Convert.ToDouble(DrVeriler["Taksit6"]) + ToplamTutar;
                    ddTaksit.Items.Add(new ListItem("6 Taksit: " + Taksit6.ToString("c"), "6"));
                }

                if (DrVeriler["Taksit7"].ToString() != "9999,0000")
                {
                    double Taksit7 = ToplamTutar / 100 * Convert.ToDouble(DrVeriler["Taksit7"]) + ToplamTutar;
                    ddTaksit.Items.Add(new ListItem("7 Taksit: " + Taksit7.ToString("c"), "7"));
                }

                if (DrVeriler["Taksit8"].ToString() != "9999,0000")
                {
                    double Taksit8 = ToplamTutar / 100 * Convert.ToDouble(DrVeriler["Taksit8"]) + ToplamTutar;
                    ddTaksit.Items.Add(new ListItem("8 Taksit: " + Taksit8.ToString("c"), "8"));
                }

                if (DrVeriler["Taksit9"].ToString() != "9999,0000")
                {
                    double Taksit9 = ToplamTutar / 100 * Convert.ToDouble(DrVeriler["Taksit9"]) + ToplamTutar;
                    ddTaksit.Items.Add(new ListItem("9 Taksit: " + Taksit9.ToString("c"), "9"));


                }

                if (DrVeriler["Taksit10"].ToString() != "9999,0000")
                {
                    double Taksit10 = ToplamTutar / 100 * Convert.ToDouble(DrVeriler["Taksit10"]) + ToplamTutar;
                    ddTaksit.Items.Add(new ListItem("10 Taksit: " + Taksit10.ToString("c"), "10"));
                }

                if (DrVeriler["Taksit11"].ToString() != "9999,0000")
                {
                    double Taksit11 = ToplamTutar / 100 * Convert.ToDouble(DrVeriler["Taksit11"]) + ToplamTutar;
                    ddTaksit.Items.Add(new ListItem("11 Taksit: " + Taksit11.ToString("c"), "11"));
                }

                if (DrVeriler["Taksit12"].ToString() != "9999,0000")
                {
                    double Taksit12 = ToplamTutar / 100 * Convert.ToDouble(DrVeriler["Taksit12"]) + ToplamTutar;
                    ddTaksit.Items.Add(new ListItem("12 Taksit: " + Taksit12.ToString("c"), "12"));
                }

            }


            catch (Exception)
            {

            }

        }

        protected void RadioTaksit_CheckedChanged(object sender, EventArgs e)
        {
            trTaksit.Visible = true;
            lblBilgi.Text = "";
            trTekCekimOdeme.Visible = false;
        }

        void RadyokTekCekimDoldur()
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    ddTekCekBanka.Items.Add("Banka Seçiniz:");
                    ddTekCekBanka.Items[0].Value = "0";


                    DataTable DtVeriler = veri.GetDataTable("SELECT dbo.Pos3D.BankaId, dbo.Pos3D.PosId, dbo.TaksitSecenekleri.BankaAdi FROM dbo.Pos3D CROSS JOIN dbo.TaksitSecenekleri WHERE (dbo.Pos3D.BankaId = dbo.TaksitSecenekleri.TaksitId) and dbo.Pos3D.Aktif=1 ");

                    int sira = 1;
                    for (int i = 0; i < DtVeriler.Rows.Count; i++)
                    {
                        DataRow DrKayit = DtVeriler.Rows[i];
                        ddTekCekBanka.Items.Add(DrKayit["BankaAdi"].ToString());
                        ddTekCekBanka.Items[sira].Value = DrKayit["PosId"].ToString();
                        sira++;
                    }
                }

            }
            catch (Exception)
            {

            }

        }
        void RadyokTekCekimDoldur3D()
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    ddTekCekBanka3D.Items.Add("Banka Seçiniz:");
                    ddTekCekBanka3D.Items[0].Value = "0";


                    DataTable DtVeriler = veri.GetDataTable("SELECT dbo.Pos3D.BankaId, dbo.Pos3D.PosId, dbo.TaksitSecenekleri.BankaAdi FROM dbo.Pos3D CROSS JOIN dbo.TaksitSecenekleri WHERE (dbo.Pos3D.BankaId = dbo.TaksitSecenekleri.TaksitId) and dbo.Pos3D.Aktif=1");

                    int sira = 1;
                    for (int i = 0; i < DtVeriler.Rows.Count; i++)
                    {
                        DataRow DrKayit = DtVeriler.Rows[i];
                        ddTekCekBanka3D.Items.Add(DrKayit["BankaAdi"].ToString());
                        ddTekCekBanka3D.Items[sira].Value = DrKayit["PosId"].ToString();
                        sira++;
                    }
                }

            }
            catch (Exception)
            {

            }

        }
        protected void RadioTaksitli_CheckedChanged(object sender, EventArgs e)
        {
            lblBilgi.Text = "";
            trTaksit.Visible = false;
            ddBanka.SelectedValue = "0";
            ddTaksit.SelectedValue = "0";

            // tek çekim seçilirse bankalar gelsin

            trTekCekimOdeme.Visible = true;

        }

        protected void ddTaksit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddTaksit.SelectedValue != "0")
            {

                Tutar = Kontrol.SiparisTutar(ddTaksit.SelectedItem.ToString());
                lblKartKdvDahil.Text = Tutar.ToString() + " TL";


            }

        }


        void MailGonder()
        {

            try
            {
                string MailGitsinMi = veri.GetDataCell("Select SiparisAktif From MailForm");

                if (MailGitsinMi == "True")
                {
                    string UyeMail = veri.GetDataCell("Select Email From Uyeler Where UyeId=" + UyeId + "");

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

                        string SiparisIcerik = veri.GetDataCell("Select Siparis From MailForm");
                        if (SiparisIcerik == "")
                        {
                            SiparisIcerik = "Siparişiniz Alınmıştır, En Kısa Sürede İşlem Yapılacaktır";
                        }
                        SmtpClient mailClient = new SmtpClient(smtpadres, mailport);
                        mailClient.EnableSsl = true;
                        NetworkCredential cred = new NetworkCredential(gidenmail, mailsifre);
                        mailClient.Credentials = cred;
                        MailMessage contact = new MailMessage();
                        contact.From = new MailAddress(gidenmail);
                        contact.Subject = "Sipariş";
                        contact.IsBodyHtml = true;
                        contact.Body = SiparisIcerik;


                        contact.Bcc.Add(UyeMail);
                        mailClient.Send(contact);
                    }
                }
                else
                {
                    // eğer mail gönder seçeneği aktif değilse
                    return;
                }
            }
            catch (Exception)
            {

            }

        }

        protected void RadioTekCek3D_CheckedChanged(object sender, EventArgs e)
        {

            trTaksit3d.Visible = false;
            ddBanka3D.SelectedValue = "0";
            ddTaksit3D.SelectedValue = "0";

            // tek çekim seçilirse bankalar gelsin

            trTekCekimOdeme3D.Visible = true;
        }

        protected void RadioTaksitli3D_CheckedChanged(object sender, EventArgs e)
        {
            trTaksit3d.Visible = true;
            trTekCekimOdeme3D.Visible = false;
        }

        protected void ddBanka3D_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                ddTaksit3D.Items.Clear();
                ddTaksit3D.Items.Add("Taksit Seçenekleri");
                ddTaksit3D.Items[0].Value = "0";
                DataRow DrVeriler = veri.GetDataRow("Select * From TaksitSecenekleri Where TaksitId=" + ddBanka3D.SelectedValue + " ");

                double ToplamTutar = Convert.ToDouble(Tutar);

                ddTaksit3D.Items.Add("Tek Çekim: " + ToplamTutar.ToString("c"));
                ddTaksit3D.Items[1].Value = "1";

                if (DrVeriler["Taksit2"].ToString() != "9999,0000")
                {
                    double Taksit2 = ToplamTutar / 100 * Convert.ToDouble(DrVeriler["Taksit2"]) + ToplamTutar;

                    ddTaksit3D.Items.Add(new ListItem("2 Taksit: " + Taksit2.ToString("c"), "2"));
                }

                if (DrVeriler["Taksit3"].ToString() != "9999,0000")
                {
                    double Taksit3 = ToplamTutar / 100 * Convert.ToDouble(DrVeriler["Taksit3"]) + ToplamTutar;
                    ddTaksit3D.Items.Add(new ListItem("3 Taksit: " + Taksit3.ToString("c"), "3"));
                }

                if (DrVeriler["Taksit4"].ToString() != "9999,0000")
                {
                    double Taksit4 = ToplamTutar / 100 * Convert.ToDouble(DrVeriler["Taksit4"]) + ToplamTutar;
                    ddTaksit3D.Items.Add(new ListItem("4 Taksit: " + Taksit4.ToString("c"), "4"));
                }

                if (DrVeriler["Taksit5"].ToString() != "9999,0000")
                {
                    double Taksit5 = ToplamTutar / 100 * Convert.ToDouble(DrVeriler["Taksit5"]) + ToplamTutar;
                    ddTaksit3D.Items.Add(new ListItem("5 Taksit: " + Taksit5.ToString("c"), "5"));
                }
                if (DrVeriler["Taksit6"].ToString() != "9999,0000")
                {
                    double Taksit6 = ToplamTutar / 100 * Convert.ToDouble(DrVeriler["Taksit6"]) + ToplamTutar;
                    ddTaksit3D.Items.Add(new ListItem("6 Taksit: " + Taksit6.ToString("c"), "6"));
                }

                if (DrVeriler["Taksit7"].ToString() != "9999,0000")
                {
                    double Taksit7 = ToplamTutar / 100 * Convert.ToDouble(DrVeriler["Taksit7"]) + ToplamTutar;
                    ddTaksit3D.Items.Add(new ListItem("7 Taksit: " + Taksit7.ToString("c"), "7"));
                }

                if (DrVeriler["Taksit8"].ToString() != "9999,0000")
                {
                    double Taksit8 = ToplamTutar / 100 * Convert.ToDouble(DrVeriler["Taksit8"]) + ToplamTutar;
                    ddTaksit3D.Items.Add(new ListItem("8 Taksit: " + Taksit8.ToString("c"), "8"));
                }

                if (DrVeriler["Taksit9"].ToString() != "9999,0000")
                {
                    double Taksit9 = ToplamTutar / 100 * Convert.ToDouble(DrVeriler["Taksit9"]) + ToplamTutar;
                    ddTaksit3D.Items.Add(new ListItem("9 Taksit: " + Taksit9.ToString("c"), "9"));


                }

                if (DrVeriler["Taksit10"].ToString() != "9999,0000")
                {
                    double Taksit10 = ToplamTutar / 100 * Convert.ToDouble(DrVeriler["Taksit10"]) + ToplamTutar;
                    ddTaksit3D.Items.Add(new ListItem("10 Taksit: " + Taksit10.ToString("c"), "10"));
                }

                if (DrVeriler["Taksit11"].ToString() != "9999,0000")
                {
                    double Taksit11 = ToplamTutar / 100 * Convert.ToDouble(DrVeriler["Taksit11"]) + ToplamTutar;
                    ddTaksit3D.Items.Add(new ListItem("11 Taksit: " + Taksit11.ToString("c"), "11"));
                }

                if (DrVeriler["Taksit12"].ToString() != "9999,0000")
                {
                    double Taksit12 = ToplamTutar / 100 * Convert.ToDouble(DrVeriler["Taksit12"]) + ToplamTutar;
                    ddTaksit3D.Items.Add(new ListItem("12 Taksit: " + Taksit12.ToString("c"), "12"));
                }

            }


            catch (Exception)
            {

            }
        }

        protected void ddTaksit3D_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddTaksit3D.SelectedValue != "0")
            {
                Tutar = Kontrol.SiparisTutar(ddTaksit3D.SelectedItem.ToString());
                lblKartKdvDahil3D.Text = Tutar.ToString() + " TL";

            }


        }

        protected void ddTekCekBanka3D_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btn3dOdeme_Click(object sender, EventArgs e)
        {
            if (HiddenKargoSec.Value == "")
            {
                Msg.Show("Lütfen kargo seçiminizi yapınız.");
                TabContainer1.ActiveTabIndex = 1;
            }
            else if (RadioTekCek3D.Checked == false && RadioTaksitli3D.Checked == false)
            {
                Msg.Show("Lütfen taksit seçiminizi yapınız.");
            }
            else
            {
                if (ddTaksit3D.SelectedValue != "0") // taksit seçildiyse fiyatı değiştir
                {

                    Tutar = Kontrol.SiparisTutar(ddTaksit3D.SelectedItem.ToString());
                    lblKartKdvDahil3D.Text = Tutar.ToString() + " TL";

                }

                if (ddTaksit3D.SelectedValue != "0" && ddTaksit3D.SelectedValue != "1")
                {
                    // taksit sayısını değiştir
                    KacTaksit = Convert.ToInt32(ddTaksit3D.SelectedValue);

                }
                else
                {
                    KacTaksit = 0;
                }

                if (Convert.ToInt32(ddBanka3D.SelectedValue) >= 1 && Convert.ToInt32(ddTaksit3D.SelectedValue) >= 1)
                {

                    lblKartKdvDahil3D.Text = Tutar;

                }

                string aktifmi = veri.GetDataCell("Select Odeme3D From OdemeSecenek");
                if (aktifmi.ToString() == "True") //3d kredi kartı ile ödeme varsa
                {


                    if (RadioTekCek3D.Checked == true) // eğer tek seçim seçildiyse 
                    {
                        try
                        {

                            string PosId = ddTekCekBanka3D.SelectedValue;
                            DataRow DrPos = veri.GetDataRow("Select * From Pos3D Where PosId=" + PosId + "");

                            Host3d = DrPos["HostUrl"].ToString();
                            CliendId3d = DrPos["CliendId"].ToString();
                            Name3d = DrPos["Name"].ToString();
                            Password3d = DrPos["Sifre"].ToString();
                            ProvUserId3D = DrPos["ProvUserId"].ToString();
                            TidUserId3D = DrPos["TidUserId"].ToString();
                            Mid3D = DrPos["Mid"].ToString();
                            Tid3D = DrPos["Tid"].ToString();
                            StrKey3D = DrPos["StrKey"].ToString();
                            StrPassword3D = DrPos["StrPassword"].ToString();

                            if (PosId == "1") // garanti bankası
                            {


                                Session["ProvUserId"] = ProvUserId3D;
                                Session["TidUserId"] = TidUserId3D;
                                Session["Mid"] = Mid3D;
                                Session["Tid"] = Tid3D;
                                Session["strkey"] = StrKey3D;
                                Session["strpw"] = StrPassword3D;
                                Session["hosturl"] = Host3d;

                                Session["tutar"] = Tutar;
                                Session["taksit"] = KacTaksit;

                                Session["KargoId"] = HiddenKargoSec.Value; // başarılı ise veritabanına kaydetmek için
                                Server.Transfer("/3D/Garanti.aspx");
                            }

                            if (PosId == "2") // iş bankası
                            {
                                Session["CliendId"] = CliendId3d;
                                Session["strkey"] = StrKey3D;
                                Session["hosturl"] = Host3d;
                                Session["tutar"] = Tutar;
                                Session["taksit"] = KacTaksit;
                                Session["KargoId"] = HiddenKargoSec.Value; // başarılı ise veritabanına kaydetmek için
                                Response.Redirect("/3D/Is.aspx");
                            }

                            if (PosId == "3") // ziraat bankası
                            {
                                Pos3DZiraat();
                            }

                        }
                        catch (Exception)
                        {


                        }
                    }
                    else if (RadioTaksitli3D.Checked == true) // eğer taksitli seçildiyse
                    {
                        try
                        {


                            DataRow DrPos = veri.GetDataRow("Select Top 1 * From Pos3D Where Aktif=1");
                            string PosId = DrPos["PosId"].ToString();

                            Host3d = DrPos["HostUrl"].ToString();
                            CliendId3d = DrPos["CliendId"].ToString();
                            Name3d = DrPos["Name"].ToString();
                            Password3d = DrPos["Sifre"].ToString();
                            ProvUserId3D = DrPos["ProvUserId"].ToString();
                            TidUserId3D = DrPos["TidUserId"].ToString();
                            Mid3D = DrPos["Mid"].ToString();
                            Tid3D = DrPos["Tid"].ToString();
                            StrKey3D = DrPos["StrKey"].ToString();
                            StrPassword3D = DrPos["StrPassword"].ToString();

                            if (PosId == "1") // garanti bankası
                            {
                                Session["ProvUserId"] = ProvUserId3D;
                                Session["TidUserId"] = TidUserId3D;
                                Session["Mid"] = Mid3D;
                                Session["Tid"] = Tid3D;
                                Session["strkey"] = StrKey3D;
                                Session["strpw"] = StrPassword3D;
                                Session["hosturl"] = Host3d;

                                Session["tutar"] = Tutar;
                                Session["taksit"] = KacTaksit;

                                Session["KargoId"] = HiddenKargoSec.Value; // başarılı ise veritabanına kaydetmek için
                                Server.Transfer("/3D/Garanti.aspx");
                            }

                            if (PosId == "2") // iş bankası
                            {
                                Session["CliendId"] = CliendId3d;
                                Session["strkey"] = StrKey3D;
                                Session["hosturl"] = Host3d;
                                Session["tutar"] = Tutar;
                                Session["taksit"] = KacTaksit;
                                Session["KargoId"] = HiddenKargoSec.Value; // başarılı ise veritabanına kaydetmek için
                                Response.Redirect("/3D/Is.aspx");
                            }

                            if (PosId == "3") // ziraat bankası
                            {
                                Pos3DZiraat();
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }


                }
                else
                {
                    Msg.Show("3D Ortak Ödeme devre bışı bırakılmış, lütfen başka bir ödeme yöntemi seçin.");
                }


            }
        }

        void Pos3Garanti()
        {

        }
        void Pos3DisBank()
        {

        }
        void Pos3DZiraat()
        {
            const string ORTAK_ODEME_URL = "https://yonetim-test.ziraatbank.com.tr/IPOSMerchant_UserInterface/SendTransaction.aspx";

            const string REGISTER_HTTP_POST_URL = "https://yonetim-test.ziraatbank.com.tr/IPOSMerchant_UserInterface/save_transaction.aspx";


            try
            {
                //Gönderilecek alanların kontrolü

                WebRequest webRequest = WebRequest.Create(REGISTER_HTTP_POST_URL);
                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.Method = "POST";

                //POST edilecek parametreler
                string parameters = "AmountMerchant=" + double.Parse(Tutar) * 100
                    + "&AmountCode=" + "949"
                    + "&MerchantID=" + CliendId3d
                    + "&UserName=" + HttpUtility.UrlEncode(Name3d)
                    + "&Password=" + HttpUtility.UrlEncode(Password3d)
                    + "&MerchantGUID=" + Guid.NewGuid().ToString()
                    + "&AmountBank=" + "949"
                    + "&InstalmentCount=" + KacTaksit;

                byte[] bytes = Encoding.ASCII.GetBytes(parameters);

                //Request Hazırlama
                Stream wbStream = null;
                try
                {
                    webRequest.ContentLength = bytes.Length;
                    wbStream = webRequest.GetRequestStream();
                    wbStream.Write(bytes, 0, bytes.Length);
                }
                finally
                {
                    if (wbStream != null)
                        wbStream.Close();

                }

                //Request gönderip Cevap alma
                WebResponse webResponse = webRequest.GetResponse();
                if (webResponse != null)
                {
                    StreamReader sr = new StreamReader(webResponse.GetResponseStream());
                    lblTrnxID.Text = sr.ReadToEnd().Trim();
                }


                if (lblTrnxID.Text.Trim() != "")
                {
                    lblTrnxID.Visible = true;

                }

            }
            catch (Exception ex)
            {
                lblError.Text = "Hata : " + ex.ToString();
                return;

            }

            Response.Redirect(ORTAK_ODEME_URL + "?TransactionID=" + lblTrnxID.Text);
        }
        public string GetSHA1(string SHA1Data)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            string HashedPassword = SHA1Data;
            byte[] hashbytes = Encoding.GetEncoding("ISO-8859-9").GetBytes(HashedPassword);
            byte[] inputbytes = sha.ComputeHash(hashbytes);
            return GetHexaDecimal(inputbytes);
        }

        public string GetHexaDecimal(byte[] bytes)
        {
            StringBuilder s = new StringBuilder();
            int length = bytes.Length;
            for (int n = 0; n <= length - 1; n++)
            {
                s.Append(String.Format("{0,2:x}", bytes[n]).Replace(" ", "0"));
            }
            return s.ToString();
        }

        void SiparisAdresiAl()
        {
            DataRow drAdres = veri.GetDataRow("Select Top 1 * From AdresFatura Where UyeId=" + UyeId + "");

            if (drAdres != null)
            {
                SqlConnection baglanti = veri.baglan();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_SiparisAdres";
                // Teslimat Adresi
                SiparisId = veri.GetDataCell("Select Top 1 SiparisId From Siparisler Where UyeId=" + UyeId + " Order By SiparisId Desc");
                cmd.Parameters.AddWithValue("@TFirmaAd", drAdres["TFirmaAd"].ToString());
                cmd.Parameters.AddWithValue("@SiparisId", SiparisId);
                cmd.Parameters.AddWithValue("@UyeId", UyeId);
                cmd.Parameters.AddWithValue("@TAd", drAdres["TAd"].ToString());
                cmd.Parameters.AddWithValue("@TSoyad", drAdres["TSoyad"].ToString());
                cmd.Parameters.AddWithValue("@TAdres", drAdres["TAdres"].ToString());
                cmd.Parameters.AddWithValue("@TPostaKodu", drAdres["TPostaKodu"].ToString());
                cmd.Parameters.AddWithValue("@TilId", drAdres["TilId"].ToString());
                cmd.Parameters.AddWithValue("@TilceId", drAdres["TilceId"].ToString());
                cmd.Parameters.AddWithValue("@TTel1", drAdres["TTel1"].ToString());
                cmd.Parameters.AddWithValue("@TTel2", drAdres["TTel2"].ToString());

                // Firma Adresi
                cmd.Parameters.AddWithValue("@FFirmaAd", drAdres["FFirmaAd"].ToString());
                cmd.Parameters.AddWithValue("@FAd", drAdres["FAd"].ToString());
                cmd.Parameters.AddWithValue("@FSoyad", drAdres["FSoyad"].ToString());
                cmd.Parameters.AddWithValue("@FAdres", drAdres["FAdres"].ToString());
                cmd.Parameters.AddWithValue("@FPostaKodu", drAdres["FPostaKodu"].ToString());
                cmd.Parameters.AddWithValue("@FilId", drAdres["FilId"].ToString());
                cmd.Parameters.AddWithValue("@FilceId", drAdres["FilceId"].ToString());
                cmd.Parameters.AddWithValue("@FTel1", drAdres["FTel1"].ToString());
                cmd.Parameters.AddWithValue("@FTel2", drAdres["FTel2"].ToString());
                cmd.Parameters.AddWithValue("@FVergiTcNo", drAdres["FVergiTcNo"].ToString());


                try
                {
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Msg.Show(ex.Message);

                }
            }
        }
    }

}
