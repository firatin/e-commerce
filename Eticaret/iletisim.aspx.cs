using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;

namespace Eticaret
{
    public partial class iletisim : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "İletişim";
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "İletişim";

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

            if (Page.IsPostBack == false)
            {
                try
                {
                    DataRow DrBilgi = veri.GetDataRow("Select * From MetaTag,Firma");
                    lblFirma.Text = DrBilgi["FirmaAdi"].ToString();
                    lblMail.Text = DrBilgi["Mail"].ToString();
                    lblTel.Text = DrBilgi["Tel1"].ToString();
                    lblGsm.Text = DrBilgi["Tel2"].ToString();
                    lblFax.Text = DrBilgi["Fax"].ToString();
                    lblAdres.Text = DrBilgi["FirmaAdresi"].ToString();

                    // harita
                    ltrlHarita.Text = DrBilgi["GoogleHarita"].ToString();
                }
                catch (Exception)
                {


                }
            }
        }

        protected void btnGonder_Click(object sender, EventArgs e)
        {
            string ipadres = HttpContext.Current.Request.UserHostAddress;

            SqlConnection baglanti = veri.baglan();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_Mesajlar";
            cmd.Parameters.AddWithValue("@AdSoyad", txtAdSoyad.Text);
            cmd.Parameters.AddWithValue("@Konu", txtKonu.Text);
            cmd.Parameters.AddWithValue("@Email", txtMail.Text);
            cmd.Parameters.AddWithValue("@Tel", txtTel.Text);
            cmd.Parameters.AddWithValue("@Mesaj", txtMesaj.Text);
            cmd.Parameters.AddWithValue("@Ip", ipadres);

            try
            {
                cmd.ExecuteNonQuery();
                Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Mesajınız gönderildi. En kısa sürede geri dönüş yapılacaktır.'); window.location.href ='iletisim.aspx';</script>");

            }
            catch (Exception)
            {
                Msg.Show("Mesajınız gönderilemedi. Lütfen tekrar deneyin.");
            }

        }


    }
}