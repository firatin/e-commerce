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
    public partial class Adresim1 : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        string UyeId = "", TilId, FilId, Url;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Adres Bilgilerim";
            lblBilgi.Text = "Adres Bilgilerim";

            Url = Request.QueryString["U"];
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
                        FaturailGetir();

                        DataRow drUye = veri.GetDataRow("Select * From AdresFatura Where UyeId=" + UyeId + "");
                        string UyeTip = veri.GetDataCell("Select UyeTip From Uyeler Where UyeId=" + UyeId + "");
                        if (drUye != null)
                        {
                            if (UyeTip.ToString() == "0") // 1 bayi 0 üye 
                            {
                                trTBayi.Visible = false;
                                trFBayi.Visible = false;
                            }

                            TilId = drUye["TilId"].ToString().Trim();
                            FilId = drUye["FilId"].ToString().Trim();

                            ilcegetir();
                            FaturailceGetir();

                            // Teslimat adresi

                            txtFaturaAd.Text = drUye["TFirmaAd"].ToString().Trim();
                            txtAd.Text = drUye["TAd"].ToString().Trim();
                            txtSoyad.Text = drUye["TSoyad"].ToString().Trim();
                            txtAdres.Text = drUye["TAdres"].ToString().Trim();
                            txtPostaKodu.Text = drUye["TPostaKodu"].ToString().Trim();
                            txtTel.Text = drUye["TTel1"].ToString().Trim();
                            txtGsm.Text = drUye["TTel2"].ToString().Trim();
                            ddil.SelectedValue = drUye["TilId"].ToString().Trim();
                            ddilce.SelectedValue = drUye["TilceId"].ToString().Trim();

                            // Fatura adresi

                            txtFaturaFirmaAd.Text = drUye["FFirmaAd"].ToString().Trim();
                            txtFaturaAd.Text = drUye["FAd"].ToString().Trim();
                            txtFaturaSoyad.Text = drUye["FSoyad"].ToString().Trim();
                            txtFaturaAdres.Text = drUye["FAdres"].ToString().Trim();
                            txtFaturaPostaKodu.Text = drUye["FPostaKodu"].ToString().Trim();
                            txtFaturaTel.Text = drUye["FTel1"].ToString().Trim();
                            txtFaturaGsm.Text = drUye["FTel2"].ToString().Trim();
                            ddFaturail.SelectedValue = drUye["FilId"].ToString().Trim();
                            ddFaturailce.SelectedValue = drUye["FilceId"].ToString().Trim();
                            txtTcVergi.Text = drUye["FVergiTcNo"].ToString().Trim();
                        }

                    }
                    catch (Exception ex)
                    {
                        Msg.Show(ex.Message);
                    }

                }
            }
            else
            {
                Response.Redirect("/Default.aspx");
            }
        }
        void ilGetir() // teslimat
        {
            try
            {
                // teslimat Adresi
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
        void FaturailGetir()
        {
            try
            {

                // Fatura Adresi
                ddFaturail.Items.Add("Seçiniz");
                ddFaturail.Items[0].Value = "0";
                DataTable dtKayit = veri.GetDataTable("Select * From iller ");

                int sira = 1;
                for (int i = 0; i < dtKayit.Rows.Count; i++)
                {
                    DataRow DrKayitlar = dtKayit.Rows[i];

                    ddFaturail.Items.Add(DrKayitlar["ilAdi"].ToString());
                    ddFaturail.Items[sira].Value = DrKayitlar["ilId"].ToString();
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

        void ilcegetir() // teslimat
        {
            try
            {
                // teslimat
                ddilce.Items.Clear();
                ddilce.Items.Add("Seçiniz");
                ddilce.Items[0].Value = "0";

                DataTable dtKayit = veri.GetDataTable("Select * From ilceler Where ilId=" + TilId + " ");

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
        void FaturailceGetir() // fatura
        {
            try
            {
                // teslimat
                ddFaturailce.Items.Clear();
                ddFaturailce.Items.Add("Seçiniz");
                ddFaturailce.Items[0].Value = "0";

                DataTable dtKayit = veri.GetDataTable("Select * From ilceler Where ilId=" + FilId + " ");

                int sira = 1;
                for (int i = 0; i < dtKayit.Rows.Count; i++)
                {
                    DataRow DrKayitlar = dtKayit.Rows[i];

                    ddFaturailce.Items.Add(DrKayitlar["ilceAdi"].ToString());
                    ddFaturailce.Items[sira].Value = DrKayitlar["ilceId"].ToString();
                    sira++;
                }
            }
            catch (Exception)
            {

            }
        }

        protected void ddFaturail_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddFaturailce.Items.Clear();
                ddFaturailce.Items.Add("Seçiniz");
                ddFaturailce.Items[0].Value = "0";
                DataTable dtKayit = veri.GetDataTable("Select * From ilceler Where ilId=" + ddFaturail.SelectedValue + " ");

                int sira = 1;
                for (int i = 0; i < dtKayit.Rows.Count; i++)
                {
                    DataRow DrKayitlar = dtKayit.Rows[i];
                    ddFaturailce.Items.Add(DrKayitlar["ilceAdi"].ToString());
                    ddFaturailce.Items[sira].Value = DrKayitlar["ilceId"].ToString();
                    sira++;
                }
            }
            catch (Exception)
            {

            }
        }


        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = veri.baglan();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_AdresBilgileriDuzenle";
            // Teslimat Adresi
            cmd.Parameters.AddWithValue("@TFirmaAd", txtFirmaAd.Text);
            cmd.Parameters.AddWithValue("@TAd", txtAd.Text);
            cmd.Parameters.AddWithValue("@TSoyad", txtSoyad.Text);
            cmd.Parameters.AddWithValue("@TAdres", txtAdres.Text);
            cmd.Parameters.AddWithValue("@TPostaKodu", txtPostaKodu.Text);
            cmd.Parameters.AddWithValue("@TilId", ddil.SelectedValue);
            cmd.Parameters.AddWithValue("@TilceId", ddilce.SelectedValue);
            cmd.Parameters.AddWithValue("@TTel1", txtTel.Text);
            cmd.Parameters.AddWithValue("@TTel2", txtGsm.Text);

            // Firma Adresi
            cmd.Parameters.AddWithValue("@FFirmaAd", txtFaturaFirmaAd.Text);
            cmd.Parameters.AddWithValue("@FAd", txtFaturaAd.Text);
            cmd.Parameters.AddWithValue("@FSoyad", txtFaturaSoyad.Text);
            cmd.Parameters.AddWithValue("@FAdres", txtFaturaAdres.Text);
            cmd.Parameters.AddWithValue("@FPostaKodu", txtFaturaPostaKodu.Text);
            cmd.Parameters.AddWithValue("@FilId", ddFaturail.SelectedValue);
            cmd.Parameters.AddWithValue("@FilceId", ddFaturailce.SelectedValue);
            cmd.Parameters.AddWithValue("@FTel1", txtFaturaTel.Text);
            cmd.Parameters.AddWithValue("@FTel2", txtFaturaGsm.Text);
            cmd.Parameters.AddWithValue("@FVergiTcNo", txtTcVergi.Text);
            cmd.Parameters.AddWithValue("@UyeId", UyeId);

            try
            {
                cmd.ExecuteNonQuery();
                if (Url != "")
                {
                    Response.Redirect(Url);
                }
                else
                {
                    Response.Redirect("/Uye/Adresim.aspx");
                }

            }
            catch (Exception)
            {


            }

        }
    }
}