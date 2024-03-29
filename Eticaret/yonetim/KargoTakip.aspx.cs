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

namespace Eticaret.yonetim
{
    public partial class KargoTakip : System.Web.UI.Page
    {
        baglanti veri = new baglanti();

        string smtpadres, gidenmail, mailsifre;
        int mailport;
        string UyeId, SiparisId, KargoId, UyeMail;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Kargo Takip Kodu Gönderimi";
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Kargo Takip Kodu Gönderimi";

            try
            {
                SiparisId = Kontrol.SayiKontrol(Request.QueryString["s"]);
                UyeId = Kontrol.SayiKontrol(Request.QueryString["u"]);
                KargoId = Kontrol.SayiKontrol(Request.QueryString["k"]);


                if (SiparisId != "" && UyeId != "" && KargoId != "")
                {
                    lblSiparisno.Text = SiparisId;
                    string kargoAdi = veri.GetDataCell("Select KargoAdi From Kargolar Where KargoId=" + KargoId + "");
                    lblKargoAdi.Text = kargoAdi;
                }
                else
                {
                    Response.Redirect("Siparisler.aspx");
                }
            }
            catch (Exception)
            {

                Response.Redirect("Siparisler.aspx");
            }

        }

        protected void btnGonder_Click(object sender, EventArgs e)
        {
            if (cbMail.Checked)
            {
                MailGonder();
            }
            else
            {
                SqlConnection baglanti = veri.baglan();
                SqlCommand cmd = new SqlCommand("insert into KargoTakip (TakipNo,SiparisId,UyeId,KargoId) values (@TakipNo,@SiparisId,@UyeId,@KargoId)", baglanti);
                cmd.Parameters.AddWithValue("@TakipNo", txtTakipNo.Text);
                cmd.Parameters.AddWithValue("@SiparisId", SiparisId);
                cmd.Parameters.AddWithValue("@UyeId", UyeId);
                cmd.Parameters.AddWithValue("@KargoId", KargoId);

                try
                {
                    cmd.ExecuteNonQuery();

                    Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Takip Kodu Eklendi'); window.location.href ='Siparisler.aspx';</script>");
                }
                catch (Exception)
                {
                    Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Bir Hata Oluştu'); window.location.href ='Siparisler.aspx';</script>");
                }
               
            }
         
        }

        void MailGonder()
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


            if (smtpadres == "" || gidenmail == "" || mailport == null || mailsifre == "")
            {
                Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Mail göndermek için gerekli mail bilgilerinizi doldurunuz.'); window.location.href ='Firma.aspx';</script>");
            }
            else
            {


                SmtpClient mailClient = new SmtpClient(smtpadres, mailport);
                mailClient.EnableSsl = true;
                NetworkCredential cred = new NetworkCredential(gidenmail, mailsifre);
                mailClient.Credentials = cred;
                MailMessage contact = new MailMessage();
                contact.From = new MailAddress(gidenmail);
                contact.Subject = "Sipariş İşlemi";
                contact.IsBodyHtml = true;
                contact.Body = SiparisId + " nolu Siparişiniz Kargoya Verildi. Sipariş Takip No: " + txtTakipNo.Text + "";

                UyeMail = veri.GetDataCell("Select Email From Uyeler Where UyeId=" + UyeId + "");
                contact.Bcc.Add(UyeMail.ToString());

                try
                {

                    mailClient.Send(contact);

                    SqlConnection baglanti = veri.baglan();
                    SqlCommand cmd = new SqlCommand("insert into KargoTakip (TakipNo,SiparisId,UyeId,KargoId) values (@TakipNo,@SiparisId,@UyeId,@KargoId)", baglanti);
                    cmd.Parameters.AddWithValue("@TakipNo", txtTakipNo.Text);
                    cmd.Parameters.AddWithValue("@SiparisId", SiparisId);
                    cmd.Parameters.AddWithValue("@UyeId", UyeId);
                    cmd.Parameters.AddWithValue("@KargoId", KargoId);

                    cmd.ExecuteNonQuery();

                    Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Mesajınız Gönderildi'); window.location.href ='Siparisler.aspx';</script>");
                }
                catch (Exception ex)
                {
                    Msg.Show("Mesajınız gönderilemedi tekrar deneyiniz. " + ex.Message);

                }
            }

        }
    }
}