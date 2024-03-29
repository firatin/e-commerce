using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;


namespace Eticaret.Uyelik
{
    public partial class Giris1 : System.Web.UI.Page
    {
        baglanti veri = new baglanti();

        protected void Page_Load(object sender, EventArgs e)
        {

            Page.Title = "Üye Girişi";
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Üye Girişi";
            Page.Form.DefaultButton = btnGiris.UniqueID;
            try
            {
                if (!IsPostBack)
                {
                    ViewState["RefUrl"] = Request.UrlReferrer.ToString();
                }
            }
            catch (Exception)
            {
            }


            if (Session["UyeId"] != null)
            {
                Response.Redirect("../Default.aspx");
            }
        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            string Sifre = "";
            SqlConnection baglanti = veri.baglan();
            SqlCommand cmd = new SqlCommand("Select * From Uyeler Where Email=@Email and Sifre=@Sifre and AktifMi=1", baglanti);
            cmd.Parameters.AddWithValue("Email", txtMail.Text);
            Sifre = txtSifre.Text;

            cmd.Parameters.AddWithValue("Sifre", Kontrol.Md5Sifrele(Sifre));

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Session["UyeId"] = dr["UyeId"];
                Session["Ad"] = dr["Ad"];
                Session["Soyad"] = dr["Soyad"];
                Session["Yetki"] = dr["UyeYetki"];

                object refUrl = ViewState["RefUrl"];
                if (refUrl != null)
                {
                    Response.Redirect((string)refUrl);
                }
                else
                {
                    Response.Redirect("../Default.aspx");
                }

            }
            else
            {
                lblBilgi.Text = "E-Mail adresinizi veya şifrenizi hatalı girdiniz. Lütfen bilgilerinizi kontrol ederek tekrar deneyiniz.";

            }
        }
    }
}