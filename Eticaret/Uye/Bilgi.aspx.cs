using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eticaret.Uye
{
    public partial class Bilgi : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        string UyeId = "", ilId;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Üyelik Bilgilerim";
            lblBilgi.Text = "Üyelik Bilgilerim";

            try
            {
                UyeId = Session["UyeId"].ToString();
            }
            catch (Exception)
            {
                Response.Redirect("/Uyelik/Giris.aspx");
            }

            if (UyeId != null)
            {
                if (Page.IsPostBack == false)
                {
                    try
                    {
                        ilGetir();

                        DataRow drUye = veri.GetDataRow("Select * From Uyeler Where UyeId=" + UyeId + "");
                        if (drUye != null)
                        {
                            if (drUye["UyeTip"].ToString() == "0") // 1 bayi 0 üye 
                            {
                                PanelBayi.Visible = false;
                            }

                            ilId = drUye["ilId"].ToString().Trim();

                            ilcegetir();

                            txtFirmaAdi.Text = drUye["FirmaAdi"].ToString().Trim();
                            txtVergiDaire.Text = drUye["VergiDairesi"].ToString().Trim();
                            txtVergiNo.Text = drUye["VergiDairesi"].ToString().Trim();
                            txtMail.Text = drUye["Email"].ToString().Trim();
                            txtAd.Text = drUye["Ad"].ToString().Trim();
                            txtSoyad.Text = drUye["Soyad"].ToString().Trim();
                            txtGsm.Text = drUye["Tel1"].ToString().Trim();
                            txtTel.Text = drUye["Tel2"].ToString().Trim();
                            txtDogumTarihi.Text = drUye["DogumTarihi"].ToString().Trim();
                            ddil.SelectedValue = drUye["ilId"].ToString().Trim();
                            ddilce.SelectedValue = drUye["ilceId"].ToString().Trim();

                            if (drUye["HaberVer"].ToString() == "True")
                            {
                                cbKampanya.Checked = true;
                            }
                            if (drUye["Cinsiyet"].ToString() == "Erkek")
                            {
                                RadioBay.Checked = true;
                            }
                            else
                            {
                                RadioBayan.Checked = true;
                            }


                        }

                    }
                    catch (Exception)
                    {

                    }

                }
            }
            else
            {
                Response.Redirect("/Default.aspx");
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

        // üye düzenle ilçe getir
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

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            string ipadres = HttpContext.Current.Request.UserHostAddress;

            int haberver = 0; string cinsiyet = "Erkek";
            if (cbKampanya.Checked)
            {
                haberver = 1;
            }
            if (RadioBayan.Checked)
            {
                cinsiyet = "Kadın";
            }

            SqlConnection baglanti = veri.baglan();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_UyeProfilDuzenle";

            cmd.Parameters.AddWithValue("@FirmaAdi", txtFirmaAdi.Text);
            cmd.Parameters.AddWithValue("@VergiDairesi", txtVergiDaire.Text);
            cmd.Parameters.AddWithValue("@VergiNo", txtVergiNo.Text);
            cmd.Parameters.AddWithValue("@Ad", txtAd.Text.Trim());
            cmd.Parameters.AddWithValue("@Soyad", txtSoyad.Text.Trim());
            cmd.Parameters.AddWithValue("@Email", txtMail.Text.Trim());
            cmd.Parameters.AddWithValue("@Cinsiyet", cinsiyet);
            cmd.Parameters.AddWithValue("@Tel1", txtGsm.Text.Replace("_", "").Replace("(", "").Replace(")", ""));
            cmd.Parameters.AddWithValue("@Tel2", txtTel.Text.Replace("_", "").Replace("(", "").Replace(")", ""));

            cmd.Parameters.AddWithValue("@DogumTarihi", txtDogumTarihi.Text.Trim());
            cmd.Parameters.AddWithValue("@HaberVer", haberver);
            cmd.Parameters.AddWithValue("@UyeIp", ipadres);
            cmd.Parameters.AddWithValue("@ilId", ddil.SelectedValue);
            cmd.Parameters.AddWithValue("@ilceId", ddilce.SelectedValue);
            cmd.Parameters.AddWithValue("@UyeId", UyeId);

            try
            {
                cmd.ExecuteNonQuery();

                Msg.Show("Üye Bilgileri Güncellenmiştir.");
                //  Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Üye Bilgileri Güncellendi'); window.location.href ='UyeDuzenle.aspx?UyeId=" + UyeId + "&islem=duzenle';</script>");
                
            }
            catch (Exception ex)
            {
                Msg.Show("Bir Hata Oluştu, Lütfen Tekrar Deneyin." + ex.Message);
            }
        }
    }
}