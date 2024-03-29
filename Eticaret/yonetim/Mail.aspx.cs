using CKFinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net;
namespace Eticaret.yonetim
{
    public partial class Mail : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        string smtpadres, gidenmail, mailsifre;
        int mailport;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lbl1 = (Label)Master.FindControl("lblBilgi");

            Page.Title = "Mail Gönderin";
            lbl1.Text = "Tek veya Tüm Kullanıcılara Mail Gönderin";

            if (Page.IsPostBack == false)
            {
                FileBrowser f1 = new FileBrowser();
                f1.BasePath = "../ckfinder/";
                f1.SetupCKEditor(CKEditorControl1);
            }


            try
            {
                if (!Page.IsPostBack)
                {


                    ddMail.Items.Add("Tüm Kullanıcılara Gönder");
                    ddMail.Items[0].Value = "0";
                    ddMail.Items.Add("Sadece Bildirim Almak İsteyenlere Gönder");
                    ddMail.Items[1].Value = "1";
                    ddMail.Items.Add("Mail Listesindeki Kullanıcılara Gönder");
                    ddMail.Items[2].Value = "2";
                    DataTable dtMailler = veri.GetDataTable("Select Email,Ad + ' '+ Soyad as Ad From Uyeler ");

                    int sira = 3;
                    for (int i = 0; i < dtMailler.Rows.Count; i++)
                    {
                        DataRow DrMail = dtMailler.Rows[i];
                        ddMail.Items.Add(DrMail["Ad"].ToString() + " (" + DrMail["Email"].ToString() + ")");
                        ddMail.Items[sira].Value = DrMail["Email"].ToString();

                        sira++;
                    }
                }
            }
            catch (Exception)
            {

            }


        }

        protected void btnTemizle_Click(object sender, EventArgs e)
        {
            txtBaslik.Text = "";
            CKEditorControl1.Text = "";
        }

        protected void btnGonder_Click(object sender, EventArgs e)
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

            //string mailmesaj = "";
            //mailmesaj += "<b>İletişim Formundan Bir Mail Aldınız.</b><br/>";

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
                contact.Subject = txtBaslik.Text;
                contact.IsBodyHtml = true;
                contact.Body = CKEditorControl1.Text;

                DataTable dtMailGetir = veri.GetDataTable("Select Email From Uyeler Where HaberVer=1");
                DataTable dtTumMailGetir = veri.GetDataTable("Select Email From Uyeler");
                DataTable dtMailListesi = veri.GetDataTable("Select Mail From MailListesi");

                if (ddMail.SelectedValue == "0")
                {
                    if (dtMailGetir != null) // mailler varsa 
                    {

                        int sira = 0;
                        for (int i = 0; i < dtMailGetir.Rows.Count; i++)
                        {
                            DataRow DrMail = dtMailGetir.Rows[i];

                            contact.Bcc.Add(DrMail["Email"].ToString());
                            sira++;
                        }
                    }
                    else
                    {
                        Msg.Show("Bu listede kayıtlı mail yok.");
                    }

                }
                else if (ddMail.SelectedValue == "1")
                {
                    if (dtTumMailGetir != null) // mailler varsa 
                    {

                        int sira = 0;
                        for (int i = 0; i < dtTumMailGetir.Rows.Count; i++)
                        {
                            DataRow DrMail = dtTumMailGetir.Rows[i];

                            contact.Bcc.Add(DrMail["Email"].ToString());
                            sira++;
                        }
                    }
                    else
                    {
                        Msg.Show("Bu listede kayıtlı mail yok.");
                    }
                }
                else if (ddMail.SelectedValue == "2")
                {
                    if (dtMailListesi != null) // mailler varsa 
                    {
                        int sira = 0;
                        for (int i = 0; i < dtMailListesi.Rows.Count; i++)
                        {
                            DataRow DrMail = dtMailListesi.Rows[i];

                            contact.Bcc.Add(DrMail["Mail"].ToString());
                            sira++;
                        }
                    }
                    else
                    {
                        Msg.Show("Bu listede kayıtlı mail yok.");
                    }
                }

                else
                {

                    foreach (var mailler in lbMail.Items)
                    {
                        contact.Bcc.Add(mailler.ToString());
                    }

                }


                try
                {

                    mailClient.Send(contact);

                    Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Mesajınız Gönderildi'); window.location.href ='Mail.aspx';</script>");
                }
                catch (Exception ex)
                {
                    Msg.Show("Mesajınız gönderilemedi tekrar deneyiniz. - (Bu gruba kayıtlı mail olmayabilir.)");

                }
            }
        }

        protected void ddMail_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddMail.SelectedValue == "0" || ddMail.SelectedValue == "1" || ddMail.SelectedValue == "2")
            {
                lbMail.Items.Clear();
                lbMail.Visible = false;
                btnSil.Visible = false;
            }
            else
            {
                btnSil.Visible = true;
                lbMail.Visible = true;
                lbMail.Items.Add(ddMail.SelectedValue);
            }


        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            if (lbMail.SelectedItem != null)
            {
                lbMail.Items.Remove(lbMail.SelectedItem);
            }

            if (lbMail.Items.Count.ToString() == "0")
            {
                btnSil.Visible = false;
                lbMail.Visible = false;
            }

            //while (lbMail.SelectedItem !=null)
            //{
            //    lbMail.Items.Remove(lbMail.SelectedItem);
            //}

        }
    }
}