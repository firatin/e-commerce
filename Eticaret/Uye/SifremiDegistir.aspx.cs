using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace Eticaret.Uye
{
    public partial class SifremiDegistir1 : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        string UyeId;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Şifre Değişikliği";
            lblBilgi.Text = "Şifre Değişikliği";

            try
            {
                UyeId = Session["UyeId"].ToString();
            }
            catch (Exception)
            {
                Response.Redirect("/Uyelik/Giris.aspx");
            }
        }


        protected void btnDegistir_Click(object sender, EventArgs e)
        {
            string eskisifre = veri.GetDataCell("Select Sifre From Uyeler Where UyeId=" + UyeId + "");
            if (eskisifre != Kontrol.Md5Sifrele(txtEski.Text))
            {
                Msg.Show("Lütfen Eski Şifrenizi Kontrol Ediniz.");
            }
            else
            {
                try
                {
                    veri.cmd("Update Uyeler Set Sifre='" + Kontrol.Md5Sifrele(txtYeniTekrar.Text) + "' where UyeId=" + UyeId + "");
                    Msg.Show("Şifreniz Başarıyla Değiştirildi.");
                }
                catch (Exception)
                {

                    Msg.Show("Şifre Değiştirilemedi, Tekrar Deneyiniz");
                }

            }
        }
    }
}