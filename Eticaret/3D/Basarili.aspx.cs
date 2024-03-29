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

namespace Eticaret._3D
{
    public partial class Basarili : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        string UyeId, KargoId, SiparisId;
        double Tutar;
        string smtpadres, gidenmail, mailsifre;
        int mailport;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UyeId"] == null)
            {
                Response.Redirect("/Uyelik/Giris.aspx");
            }
            else
            {

                try
                {
                    UyeId = Session["UyeId"].ToString();
                    Tutar = Convert.ToDouble(Session["tutar"].ToString());
                    KargoId = Session["KargoId"].ToString();
                }
                catch (Exception)
                {


                }

                if (Request.Form.ToString() != "")
                {
                    lblResult.Text = "Siparişiniz tamamlanmıştır. En kısa sürede kargoya verilecektir.";
                    //string test = Request.Form["mdstatus"];
                    //lblResult.Text = test;

                    // veri tabanına kaydet ve ürünü stoktan düş.
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
                    cmd.Parameters.AddWithValue("@KargoId", KargoId);
                    cmd.Parameters.AddWithValue("@ReferansNo", "");
                    cmd.Parameters.AddWithValue("@GroupId", "");
                    cmd.Parameters.AddWithValue("@TransId", "");
                    cmd.Parameters.AddWithValue("@Pcode", "");
                    cmd.Parameters.AddWithValue("@Kartisim", "");

                    try
                    {
                        cmd.ExecuteNonQuery();
                        //sepet sayfasındaki id güncelle sepetten düşsün
                        SiparisId = veri.GetDataCell("Select Top 1 SiparisId From Siparisler Where UyeId=" + UyeId + " Order By SiparisId Desc");

                        if (SiparisId != null)
                        {
                            veri.cmd("Update Sepet Set SatildiMi =1,SiparisId=" + SiparisId + " where SiparisId=0 and UyeId=" + UyeId + "");

                            //sipariş adresini kaydet
                            SiparisAdresiAl();

                            //// siparişi stoktan düş. panelde ürün teslim edildiğinde düşüyor o yüzden burdan kaldırdım ilerde değişiklik yapabileceğimden kodları silmedim.

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
                    catch (Exception ex)
                    {
                        Msg.Show(ex.Message);

                    }


                    // ve sipariş bilgisini mail olarak gönder.

                    MailGonder();

                    // tekrar ödeme sayfasına gidilmesin diye tüm sessionları sil
                    try
                    {
                        Session.Remove("KdvDahil");
                        Session.Remove("ProvUserId");
                        Session.Remove("TidUserId");
                        Session.Remove("Mid");
                        Session.Remove("Tid");
                        Session.Remove("strkey");
                        Session.Remove("strpw");
                        Session.Remove("hosturl");
                        Session.Remove("taksit");
                        Session.Remove("tutar");
                        Session.Remove("KargoId");

                    }
                    catch (Exception)
                    {

                    }
                }
                else
                {
                    Response.Redirect("/Default.aspx");
                }
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