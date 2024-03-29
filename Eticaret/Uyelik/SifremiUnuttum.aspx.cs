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

namespace Eticaret.Uyelik
{
    public partial class SifremiUnuttum1 : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        string smtpadres, gidenmail, mailsifre;
        int mailport;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Şifremi Unuttum";
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Lütfen E-posta adresinizi yazın.";


            if (Session["UyeId"] != null)
            {
                Response.Redirect("/Default.aspx");
            }
        }

        protected void btnGonder_Click(object sender, EventArgs e)
        {

            SqlConnection baglanti = veri.baglan();
            SqlCommand cmd = new SqlCommand("Select * from Uyeler Where Email=@Email", baglanti);
            cmd.Parameters.AddWithValue("@Email", txtMail.Text);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                try
                {
                    DataRow drveri = veri.GetDataRow("Select Mail,MailSifre,MailSmtp,SmtpPort From Firma");

                    try
                    {
                        smtpadres = drveri["MailSmtp"].ToString();
                        gidenmail = drveri["Mail"].ToString();
                        mailport = Convert.ToInt32(drveri["SmtpPort"]);
                        mailsifre = drveri["MailSifre"].ToString();

                    }
                    catch (Exception)
                    {


                    }

                    SmtpClient smtp = new SmtpClient();
                    smtp.Port = mailport;
                    smtp.Host = smtpadres;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential(gidenmail, mailsifre);
                    MailAddress mSender = new MailAddress(txtMail.Text);
                    MailAddress mTo = new MailAddress(gidenmail);

                    MailMessage mesaj = new MailMessage(mSender, mTo);
                    mesaj.IsBodyHtml = true;
                    mesaj.Subject = HttpContext.Current.Request.Url.Host.ToString() + " Şifreniz";
                    string YeniSifreUret = "";
                    YeniSifreUret = Kontrol.SifreOlustur();
                    mesaj.Body = Request.Url.GetLeftPart(UriPartial.Authority).ToString() + " - Şifremi unuttum talebinde bulundunuz.<br>Yeni Şifreniz: " + YeniSifreUret;

                    smtp.Send(mesaj);
                    Msg.Show("Yeni Şifreniz Mail Hesabınıza Gönderildi.");

                    veri.cmd("Update Uyeler Set Sifre='" + Kontrol.Md5Sifrele(YeniSifreUret) + "'" + " Where Email='" + txtMail.Text + "'");
                    txtMail.Text = "";

                }
                catch
                {
                    Msg.Show("Şifreniz Gönderilemedi, Lütfen Tekrar Deneyiniz.");

                }
            }
            else
            {
                Msg.Show("Bu E-posta adresine bağlı bir kullanıcı bulunamadı.");

            }
        }
    }
}