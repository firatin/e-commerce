using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
namespace Eticaret.Yonet
{
    public partial class Login : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("/Uyelik/Giris.aspx");
        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            
        //    string Sifre = "";
        //    SqlConnection baglanti = veri.baglan();
        //    SqlCommand cmd = new SqlCommand("Select * From Uyeler Where AktifMi=1 and Email=@Email and Sifre=@Sifre", baglanti);
        //    cmd.Parameters.AddWithValue("Email", Kontrol.EmailGirisTemizle(txtMail.Text));
        //    Sifre = Kontrol.Md5Sifrele(txtSifre.Text);

        //    cmd.Parameters.AddWithValue("Sifre", Sifre);

        //    SqlDataReader dr = cmd.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        Session["UyeId"] = dr["UyeId"];
        //        Session["Ad"] = dr["Ad"];
        //        Session["Soyad"] = dr["Soyad"];

        //       Response.Redirect("Default.aspx");
        //    }
        //    else
        //    {
        //        lblBilgi.Text = "Kullanıcı Adı veya Şifre Yanlış";
        //        txtMail.Text = "";
        //        txtSifre.Text = "";
        //    }
        }

    }
}