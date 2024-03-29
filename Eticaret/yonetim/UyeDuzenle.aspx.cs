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
    public partial class UyeDuzenle : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        string UyeId = "", islem = "",ilId;
        DataRow drUye;
        public static string Sifre; 
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Üye Düzenle";
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Üye Düzenle";

            UyeId = Request.QueryString["UyeId"];
            islem = Request.QueryString["islem"];
            if (UyeId != null & islem == "duzenle")
            {


                drUye = veri.GetDataRow("Select * From Uyeler Where UyeId=" + UyeId);

                if (drUye != null)
                {
            

                    if (Page.IsPostBack == false)
                    {
                        try
                        {
                            ilGetir();

                            if (drUye["UyeTip"].ToString() == "0") // 1 bayi 0 üye 
                            {
                                PanelBayi.Visible = false;
                            }

                            ilId = drUye["ilId"].ToString().Trim();

                            ilcegetir();

                            lbl1.Text = drUye["Ad"].ToString() + " " + drUye["Soyad"].ToString() + " - Üye Bilgileri";
                            txtFirmaAdi.Text = drUye["FirmaAdi"].ToString().Trim();
                            txtVergiDairesi.Text = drUye["VergiDairesi"].ToString().Trim();
                            txtVergiNo.Text = drUye["VergiNo"].ToString().Trim();
                            txtAdiniz.Text = drUye["Ad"].ToString().Trim();
                            txtSoyad.Text = drUye["Soyad"].ToString().Trim();
                            txtMail.Text = drUye["Email"].ToString().Trim();
                            //txtSifre.Text = drUye["Sifre"].ToString();
                            Sifre = drUye["Sifre"].ToString();
                            ddil.SelectedValue = drUye["ilId"].ToString().Trim();
                            ddilce.SelectedValue = drUye["ilceId"].ToString().Trim();

                            if (drUye["Cinsiyet"].ToString() == "Erkek")
                            {
                                RadioErkek.Checked = true;
                            }
                            else
                            {
                                RadioKadin.Checked = true;
                            }
                            if (drUye["UyeTip"].ToString() == "0")
                            {
                                ddUyeTip.SelectedValue = "0";
                            }
                            else if (drUye["UyeTip"].ToString() == "1")
                            {
                                ddUyeTip.SelectedValue = "1";
                            }
                            if (drUye["UyeYetki"].ToString() == "0")
                            {
                                ddYetki.SelectedValue = "0";
                            }
                            else if (drUye["UyeYetki"].ToString() == "1")
                            {
                                ddYetki.SelectedValue = "1";
                            }
                            txtTel.Text = drUye["Tel1"].ToString().Trim();
                            txtTel2.Text = drUye["Tel2"].ToString().Trim();
                            if (drUye["AktifMi"].ToString() == "True")
                            {
                                RadioAktif.Checked = true;
                            }
                            else
                            {
                                RadioPasif.Checked = true;
                            }
                            txtDogum.Text = drUye["DogumTarihi"].ToString().Trim();

                            txtUyePuan.Text = drUye["UyePuan"].ToString().Trim();
                            txtIp.Text = drUye["UyeIp"].ToString().Trim();
                            if (drUye["HaberVer"].ToString() == "True")
                            {
                                cbHaber.Checked = true;
                            }
                            else
                            {
                                cbHaber.Checked = false;
                            }
                        }
                        catch (Exception)
                        {


                        }

                    }

                }
                else
                {

                    Response.Redirect("Uyeler.aspx");
                }
            }

            else
            {
                Response.Redirect("Uyeler.aspx");
            }
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            int haberver = 0, uyedurum = 1; string cinsiyet = "Erkek";
            if (cbHaber.Checked)
            {
                haberver = 1;
            }
            if (RadioKadin.Checked)
            {
                cinsiyet = "Kadın";
            }
            if (RadioPasif.Checked)
            {
                uyedurum = 0;
            }

            SqlConnection baglanti = veri.baglan();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_UyeDuzenle";

            cmd.Parameters.AddWithValue("FirmaAdi", txtFirmaAdi.Text);
            cmd.Parameters.AddWithValue("VergiDairesi", txtVergiDairesi.Text);
            cmd.Parameters.AddWithValue("VergiNo", txtVergiNo.Text);
            cmd.Parameters.AddWithValue("Ad", txtAdiniz.Text.Trim());
            cmd.Parameters.AddWithValue("Soyad", txtSoyad.Text.Trim());
            cmd.Parameters.AddWithValue("Email", txtMail.Text.Trim());
            cmd.Parameters.AddWithValue("Cinsiyet", cinsiyet);
            cmd.Parameters.AddWithValue("Tel1", txtTel.Text.Replace("_", "").Replace("(", "").Replace(")", ""));
            cmd.Parameters.AddWithValue("Tel2", txtTel2.Text.Replace("_", "").Replace("(", "").Replace(")", ""));
            cmd.Parameters.AddWithValue("AktifMi", uyedurum);
            cmd.Parameters.AddWithValue("DogumTarihi", txtDogum.Text.Trim());
            cmd.Parameters.AddWithValue("UyeTip", ddUyeTip.SelectedValue);
            cmd.Parameters.AddWithValue("UyeYetki", ddYetki.SelectedValue);
            cmd.Parameters.AddWithValue("HaberVer", haberver);
            cmd.Parameters.AddWithValue("UyePuan", txtUyePuan.Text);
            if (txtSifre.Text!="")
            {
                cmd.Parameters.AddWithValue("Sifre", Kontrol.Md5Sifrele(txtSifre.Text));
            }
            else
            {
              
                cmd.Parameters.AddWithValue("Sifre", Sifre);
            }

            cmd.Parameters.AddWithValue("UyeIp", txtIp.Text.Trim());
            cmd.Parameters.AddWithValue("ilId", ddil.SelectedValue);
            cmd.Parameters.AddWithValue("ilceId", ddilce.SelectedValue);
            cmd.Parameters.AddWithValue("UyeId", UyeId);

            try
            {
                cmd.ExecuteNonQuery();

               // Msg.Show("Üye Bilgileri Güncellendi");
                Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Üye Bilgileri Güncellendi'); window.location.href ='UyeDuzenle.aspx?UyeId=" + UyeId + "&islem=duzenle';</script>");
            }
            catch (Exception )
            {
                Msg.Show("Bir Hata Oluştu, Lütfen Tekrar Deneyin.");
            }

          
        }

        protected void btnSifre_Click(object sender, EventArgs e)
        {
            Response.Redirect("UyeDuzenle.aspx?UyeId=" + UyeId + "&islem=sifre" + "");
        }

        protected void btnUye_Click(object sender, EventArgs e)
        {

        }

        protected void btnGeri_Click(object sender, EventArgs e)
        {
            Response.Redirect("Uyeler.aspx");
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
    }
}