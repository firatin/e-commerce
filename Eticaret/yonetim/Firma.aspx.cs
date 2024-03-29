using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace Eticaret.yonetim
{
    public partial class Firma : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        string ilId;
        string MailSifre;
        DataRow drFirma;
        protected void Page_Load(object sender, EventArgs e)
        {

            Page.Title = "Firma Bilgileri";
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Firma Bilgileri";

            try
            {
                drFirma = veri.GetDataRow("Select * From Firma");
                MailSifre = drFirma["MailSifre"].ToString().Trim();
                if (Page.IsPostBack == false)
                {


                    ilGetir();


                   
                    if (drFirma != null)
                    {
                        ilId = drFirma["ilId"].ToString().Trim();

                        ilcegetir();

                        txtFirmaAdi.Text = drFirma["FirmaAdi"].ToString().Trim();
                        txtYetkili.Text = drFirma["YetkiliKisi"].ToString().Trim();
                        txtMail.Text = drFirma["Mail"].ToString().Trim();
                        txtSmtp.Text = drFirma["MailSmtp"].ToString();
                        txtSifre.Text = drFirma["MailSifre"].ToString();
                        txtPort.Text = drFirma["SmtpPort"].ToString();
                        txtTel1.Text = drFirma["Tel1"].ToString().Trim();
                        txtTel2.Text = drFirma["Tel2"].ToString().Trim();
                        txtFax.Text = drFirma["Fax"].ToString().Trim();
                        txtAdres.Text = drFirma["FirmaAdresi"].ToString().Trim();
                        txtPostaKodu.Text = drFirma["PostaKodu"].ToString().Trim();
                        ddil.SelectedValue = drFirma["ilId"].ToString().Trim();
                        ddilce.SelectedValue = drFirma["ilceId"].ToString().Trim();
                        txtVergiDaire.Text = drFirma["VergiDairesi"].ToString().Trim();
                        txtVergiNo.Text = drFirma["VergiDairesi"].ToString().Trim();
                     


                    }

                }
            }
            catch (Exception)
            {

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

        // firma düzenle ilçe getir
        void ilcegetir()
        {
            try
            {
                ddilce.Items.Clear();
                ddilce.Items.Add("Seçiniz");
                ddilce.Items[0].Value = "0";
                DataTable dtKayit = veri.GetDataTable("Select * From ilceler Where ilId=" + ilId + " ");

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
        protected void bnGuncelle_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = veri.baglan();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_FirmaDuzenle";
            cmd.Parameters.AddWithValue("@FirmaAdi", txtFirmaAdi.Text.Trim());
            cmd.Parameters.AddWithValue("@YetkiliKisi", txtYetkili.Text.Trim());
            cmd.Parameters.AddWithValue("@Mail", txtMail.Text.Trim());
            if (txtSifre.Text != "")
            {
                cmd.Parameters.AddWithValue("@MailSifre", txtSifre.Text);
            }
            else
            {
                cmd.Parameters.AddWithValue("@MailSifre", MailSifre);
            }
            cmd.Parameters.AddWithValue("@MailSmtp", txtSmtp.Text);
            cmd.Parameters.AddWithValue("@SmtpPort", txtPort.Text);
            cmd.Parameters.AddWithValue("@Tel1", txtTel1.Text.Trim());
            cmd.Parameters.AddWithValue("@Tel2", txtTel2.Text.Trim());
            cmd.Parameters.AddWithValue("@Fax", txtFax.Text.Trim());
            cmd.Parameters.AddWithValue("@FirmaAdresi", txtAdres.Text.Trim());
            cmd.Parameters.AddWithValue("@PostaKodu", txtPostaKodu.Text.Trim());
            cmd.Parameters.AddWithValue("@ilId", ddil.SelectedValue);
            cmd.Parameters.AddWithValue("@ilceId", ddilce.SelectedValue);
            cmd.Parameters.AddWithValue("@VergiDairesi", txtVergiDaire.Text.Trim());
            cmd.Parameters.AddWithValue("@VergiNo", txtVergiNo.Text.Trim());

            try
            {
                cmd.ExecuteNonQuery();
                Msg.Show("Bilgiler Güncellendi");
            }
            catch (Exception)
            {
                Msg.Show("Bir hata meydana geldi");
            }

        }
    }
}