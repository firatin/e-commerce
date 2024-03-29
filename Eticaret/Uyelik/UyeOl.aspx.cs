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

namespace Eticaret
{
    public partial class UyeOl : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        int haberver = 0;
        string cinsiyet = "Erkek", ipadres;
        string smtpadres, gidenmail, mailsifre;
        int mailport;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Yeni Üyelik";
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Yeni Üyelik";

            if (Session["UyeId"] != null)
            {
                Response.Redirect("/Default.aspx");
            }

            if (Page.IsPostBack == false)
            {
                ilGetir();
            }


        }

        protected void ddUyeTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddUyeTipi.SelectedValue == "1") // 1 bayi 0 üye 
            {
                PanelBayi.Visible = true;
                //  PanelSabitTel.Visible = true;

            }
            else
            {
                PanelBayi.Visible = false;
                // PanelSabitTel.Visible = false;
            }
        }
        void ilGetir()
        {
            try
            {
                ddil.Items.Add("Seçiniz");
                ddil.Items[0].Value = "0";
                DataTable dtKayit = veri.GetDataTable("Select * From iller ");

                int sira = 1;
                for (int i = 0; i < dtKayit.Rows.Count; i++)
                {
                    DataRow DrKayitlar = dtKayit.Rows[i];
                    ddil.Items.Add(DrKayitlar["ilAdi"].ToString());
                    ddil.Items[sira].Value = DrKayitlar["ilId"].ToString();
                    sira++;
                }
            }
            catch (Exception)
            {

            }
        }

        protected void ddil_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddilce.Items.Clear();
                ddilce.Items.Add("Seçiniz");
                ddilce.Items[0].Value = "0";
                DataTable dtKayit = veri.GetDataTable("Select * From ilceler Where ilId=" + ddil.SelectedValue + " ");

                int sira = 1;
                for (int i = 0; i < dtKayit.Rows.Count; i++)
                {
                    DataRow DrKayitlar = dtKayit.Rows[i];
                    ddilce.Items.Add(DrKayitlar["ilceAdi"].ToString());
                    ddilce.Items[sira].Value = DrKayitlar["ilceId"].ToString();
                    sira++;
                }
            }
            catch (Exception)
            {

            }
        }
        protected void btnUyeOl_Click(object sender, EventArgs e)
        {
            ipadres = HttpContext.Current.Request.UserHostAddress;
            if (cbKampanya.Checked)
            {
                haberver = 1;
            }
            if (RadioBayan.Checked)
            {
                cinsiyet = "Kadın";
            }

            SqlConnection baglanti = veri.baglan();
            SqlCommand cmdkontrol = new SqlCommand();
            cmdkontrol = new SqlCommand("Select * from Uyeler Where Email=@Email", baglanti);
            cmdkontrol.Parameters.AddWithValue("@Email", txtMail.Text);


            SqlDataReader dr = cmdkontrol.ExecuteReader();

            if (dr.Read())
            {
                Msg.Show("Bu Mail Adresinde Kayıtlı Bir Kullanıcı Zaten Var");
                // lblBilgi.Text = "Bu Mail Adresine Kayıtlı Bir Kullanıcı Zaten Var , <a href=\"SifremiUnuttum.aspx\">Şifremi Unuttum</a>";

            }

            else
            {
                dr.Dispose(); dr.Close();

                SqlConnection baglan = veri.baglan();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_UyeEkle";
                cmd.Parameters.AddWithValue("@FirmaAdi", txtFirmaAdi.Text.Trim());
                cmd.Parameters.AddWithValue("@VergiDairesi", txtVergiDaire.Text.Trim());
                cmd.Parameters.AddWithValue("@VergiNo", txtVergiNo.Text.Trim());
                cmd.Parameters.AddWithValue("@Ad", txtAd.Text.Trim());
                cmd.Parameters.AddWithValue("@Soyad", txtSoyad.Text.Trim());
                cmd.Parameters.AddWithValue("@Email", txtMail.Text.Trim());
                cmd.Parameters.AddWithValue("@Sifre", Kontrol.Md5Sifrele(txtSifreTekrar.Text));
                cmd.Parameters.AddWithValue("@Cinsiyet", cinsiyet);
                cmd.Parameters.AddWithValue("@Tel1", txtGsm.Text.Replace("_", "").Replace("(", "").Replace(")", ""));
                cmd.Parameters.AddWithValue("@Tel2", txtTel.Text.Replace("_", "").Replace("(", "").Replace(")", ""));
                cmd.Parameters.AddWithValue("@AktifMi", "1");
                cmd.Parameters.AddWithValue("@DogumTarihi", ddGun.SelectedValue + "." + ddAy.SelectedValue + "." + ddYil.SelectedValue);
                cmd.Parameters.AddWithValue("@UyeYetki", "0");
                cmd.Parameters.AddWithValue("@UyeTip", ddUyeTipi.SelectedValue);
                cmd.Parameters.AddWithValue("@UyePuan", "0");
                cmd.Parameters.AddWithValue("@ilId", ddil.SelectedValue);
                cmd.Parameters.AddWithValue("@ilceId", ddilce.SelectedValue);
                cmd.Parameters.AddWithValue("@HaberVer", haberver);
                cmd.Parameters.AddWithValue("@UyeIp", ipadres);

                try
                {
                    cmd.ExecuteNonQuery();

                    // üye teslimat adres ve fatura bilgileri
                    string UyeId = veri.GetDataCell("Select top 1 UyeId from Uyeler Order By UyeId Desc");
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = baglan;
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.CommandText = "sp_AdresBilgileriEkle";
                    cmd2.Parameters.AddWithValue("@TFirmaAd", txtFirmaAdi.Text);
                    cmd2.Parameters.AddWithValue("@UyeId", UyeId);
                    cmd2.Parameters.AddWithValue("@TAd", txtAd.Text);
                    cmd2.Parameters.AddWithValue("@TSoyad", txtSoyad.Text);
                    cmd2.Parameters.AddWithValue("@TilId", ddil.SelectedValue);
                    cmd2.Parameters.AddWithValue("@TilceId", ddilce.SelectedValue);
                    cmd2.Parameters.AddWithValue("@TTel1", txtTel.Text);
                    cmd2.Parameters.AddWithValue("@TTel2", txtGsm.Text);
                    cmd2.Parameters.AddWithValue("@FFirmaAd", txtFirmaAdi.Text);
                    cmd2.Parameters.AddWithValue("@FAd", txtAd.Text);
                    cmd2.Parameters.AddWithValue("@FSoyad", txtSoyad.Text);
                    cmd2.Parameters.AddWithValue("@FilId", ddil.SelectedValue);
                    cmd2.Parameters.AddWithValue("@FilceId", ddilce.SelectedValue);
                    cmd2.Parameters.AddWithValue("@FTel1", txtTel.Text);
                    cmd2.Parameters.AddWithValue("@FTel2", txtGsm.Text);

                    cmd2.ExecuteNonQuery();

                    MailGonder();

                    Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Üyeliğiniz Oluşturuldu - Giriş İçin Tıklayınız.'); window.location.href ='/Uyelik/Giris.aspx';</script>");
                }
                catch (Exception)
                {
                    //  lblBilgi.Text = "Bir Hata Oluştu, Lütfen Tekrar Deneyin.";
                    Msg.Show("Bir Hata Oluştu, Lütfen Tekrar Deneyin.");
                }

            }
        }


        void MailGonder()
        {

            try
            {
                string MailGitsinMi = veri.GetDataCell("Select UyeOlAktif From MailForm");

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

                        string UyelikIcerik = veri.GetDataCell("Select UyeOl From MailForm");
                        if (UyelikIcerik == "")
                        {
                            UyelikIcerik = "Sayın " + txtAd.Text + " " + txtSoyad.Text + " Üyeliğiniz Oluşturuldu, Üye Olduğunuz için Teşekkürler.";
                        }
                        SmtpClient mailClient = new SmtpClient(smtpadres, mailport);
                        mailClient.EnableSsl = true;
                        NetworkCredential cred = new NetworkCredential(gidenmail, mailsifre);
                        mailClient.Credentials = cred;
                        MailMessage contact = new MailMessage();
                        contact.From = new MailAddress(gidenmail);
                        contact.Subject = "Üyelik";
                        contact.IsBodyHtml = true;
                        contact.Body = UyelikIcerik;


                        contact.Bcc.Add(txtMail.Text.Trim());
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

    }
}