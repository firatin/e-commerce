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
    public partial class BankaHesap : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        string islem, BankaId;

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Banka Bilgileri";
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Banka Bilgileri";

            try
            {
                islem = Request.QueryString["islem"];
                BankaId = Kontrol.SayiKontrol(Request.QueryString["BankaId"]);

            }
            catch (Exception)
            {
                Response.Redirect("BankaHesap.aspx");
            }

            if (islem == "duzenle" && BankaId != null)
            {
                if (Page.IsPostBack == false)
                {


                    DataRow DrKaro = veri.GetDataRow("Select * From Bankalar Where BankaId=" + BankaId + "");

                    btnEkle.Visible = false;
                    btnDuzenle.Visible = true;
                    btnGeri.Visible = true;
                    if (DrKaro != null)
                    {
                        txtBankaAdi.Text = DrKaro["BankaAdi"].ToString().Trim();
                        txtSubeAdi.Text = DrKaro["SubeAdi"].ToString().Trim();
                        txtSubeKodu.Text = DrKaro["SubeKodu"].ToString().Trim();
                        txtHesapNo.Text = DrKaro["HesapNo"].ToString().Trim();
                        txtHesapSahibi.Text = DrKaro["AliciAdi"].ToString().Trim();
                        txtiban.Text = DrKaro["IBAN"].ToString().Trim();
                        if (DrKaro["Aktif"].ToString() == "True")
                        {
                            cbAktif.Checked = true;
                        }
                    }
                }

            }
            else if (islem == "sil" && BankaId != null)
            {
                veri.cmd("Delete From Bankalar Where BankaId=" + BankaId + "");
                Response.Redirect("BankaHesap.aspx");
            }

            if (Page.IsPostBack == false)
            {
                BankaGetir();
            }

        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            int aktif = 0;
            if (cbAktif.Checked)
            {
                aktif = 1;
            }

            SqlConnection baglanti = veri.baglan();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_BankaEkle";
            cmd.Parameters.AddWithValue("BankaAdi", txtBankaAdi.Text.Trim());
            cmd.Parameters.AddWithValue("SubeAdi", txtSubeAdi.Text.Trim());
            cmd.Parameters.AddWithValue("SubeKodu", txtSubeKodu.Text.Trim());
            cmd.Parameters.AddWithValue("HesapNo", txtHesapNo.Text.Trim());
            cmd.Parameters.AddWithValue("IBAN", txtiban.Text.Trim());
            cmd.Parameters.AddWithValue("AliciAdi", txtHesapSahibi.Text.Trim());
            cmd.Parameters.AddWithValue("Aktif", aktif);


            try
            {
                cmd.ExecuteNonQuery();
               
                Response.Redirect("BankaHesap.aspx");
            }
            catch (Exception)
            {
                Msg.Show("Bir hata meydana geldi");
            }
        }

        void BankaGetir()
        {
            DataTable DtKayitlar = veri.GetDataTable("Select BankaId,BankaAdi,SubeAdi,SubeKodu,HesapNo,IBAN,AliciAdi, case Aktif when 1 then 'Aktif' when 0 then 'Pasif' end as Durumadi from Bankalar");
            RpKayit.DataSource = DtKayitlar;
            RpKayit.DataBind();

        }

        protected void btnDuzenle_Click(object sender, EventArgs e)
        {
            int aktif = 0;
            if (cbAktif.Checked)
            {
                aktif = 1;
            }

            SqlConnection baglanti = veri.baglan();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_BankaDuzenle";
            cmd.Parameters.AddWithValue("BankaAdi", txtBankaAdi.Text.Trim());
            cmd.Parameters.AddWithValue("SubeAdi", txtSubeAdi.Text.Trim());
            cmd.Parameters.AddWithValue("SubeKodu", txtSubeKodu.Text.Trim());
            cmd.Parameters.AddWithValue("HesapNo", txtHesapNo.Text.Trim());
            cmd.Parameters.AddWithValue("IBAN", txtiban.Text.Trim());
            cmd.Parameters.AddWithValue("AliciAdi", txtHesapSahibi.Text.Trim());
            cmd.Parameters.AddWithValue("Aktif", aktif);
            cmd.Parameters.AddWithValue("BankaId", BankaId);


            try
            {
                cmd.ExecuteNonQuery();

                Response.Redirect("BankaHesap.aspx");
            }
            catch (Exception)
            {
                Msg.Show("Bir hata meydana geldi");
            }
        }

        protected void btnGeri_Click(object sender, EventArgs e)
        {
            Response.Redirect("BankaHesap.aspx");
        }
    }
}