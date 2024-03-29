using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eticaret
{
    public partial class OdemeBildirim : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Ödeme Bildirim Formu";
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Ödeme Bildirim Formu";

            if (Page.IsPostBack == false)
            {
                BankaGetir();

            }
            if (Session["UyeId"] != null)
            {
                if (Page.IsPostBack == false)
                {
                    try
                    {


                        DataRow drUye = veri.GetDataRow("Select Ad,Soyad,Email,Tel1 From Uyeler Where UyeId=" + Session["UyeId"] + "");
                        if (drUye != null)
                        {
                            txtAdSoyad.Text = drUye["Ad"].ToString() + " " + drUye["Soyad"].ToString();
                            txtMail.Text = drUye["Email"].ToString();
                            txtTel.Text = drUye["Tel1"].ToString();
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }

        }

        void BankaGetir()
        {
            try
            {
                ddBanka.Items.Add("Seçiniz");
                ddBanka.Items[0].Value = "0";
                DataTable dtKayit = veri.GetDataTable("Select * From Bankalar Where Aktif=1 ");

                int sira = 1;
                for (int i = 0; i < dtKayit.Rows.Count; i++)
                {
                    DataRow DrKayitlar = dtKayit.Rows[i];
                    ddBanka.Items.Add(DrKayitlar["BankaAdi"].ToString());
                    ddBanka.Items[sira].Value = DrKayitlar["BankaId"].ToString();
                    sira++;
                }
            }
            catch (Exception)
            {

            }
        }

        protected void btnGonder_Click(object sender, EventArgs e)
        {
            string ipadres = HttpContext.Current.Request.UserHostAddress;

            SqlConnection baglanti = veri.baglan();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_OdemeBildirim";
            cmd.Parameters.AddWithValue("@AdSoyad", txtAdSoyad.Text);
            cmd.Parameters.AddWithValue("@Email", txtMail.Text);
            cmd.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);
            cmd.Parameters.AddWithValue("@OdenenTutar", txtTutar.Text);
            cmd.Parameters.AddWithValue("@OdemeYapanAdSoyad", txtOdemeYapan.Text);
            cmd.Parameters.AddWithValue("@BankaId", ddBanka.SelectedValue);
            cmd.Parameters.AddWithValue("@OdemeSekli", "Banka Havalesi");
            cmd.Parameters.AddWithValue("@Tel", txtTel.Text);
            cmd.Parameters.AddWithValue("@Ip", ipadres);

            try
            {
                cmd.ExecuteNonQuery();
                Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Bildiriminiz gönderildi. En kısa sürede işlem yapılacaktır.'); window.location.href ='OdemeBildirim.aspx';</script>");

            }
            catch (Exception)
            {
                Msg.Show("Bildiriminiz gönderilemedi. Lütfen tekrar deneyin.");

            }
        }
    }
}