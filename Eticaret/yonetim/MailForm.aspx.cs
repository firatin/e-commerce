using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using CKFinder;
namespace Eticaret.yonetim
{
    public partial class MailForm : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Mail Formları";
            Page.Title = "Mail Formları";

            if (Page.IsPostBack == false)
            {
                FileBrowser f1 = new FileBrowser();
                f1.BasePath = "../ckfinder/";
                f1.SetupCKEditor(txtSiparisSonra);

                FileBrowser f2 = new FileBrowser();
                f2.BasePath = "../ckfinder/";
                f2.SetupCKEditor(txtSiparisTamam);

                FileBrowser f3 = new FileBrowser();
                f3.BasePath = "../ckfinder/";
                f3.SetupCKEditor(txtUyeOl);
            }

            try
            {
                if (Page.IsPostBack==false)
                {
                    DataRow drBilgi = veri.GetDataRow("Select * From MailForm");

                    if (drBilgi!=null)
                    {
                        txtSiparisSonra.Text = drBilgi["Siparis"].ToString();
                        txtSiparisTamam.Text = drBilgi["SiparisTamam"].ToString();
                        txtUyeOl.Text = drBilgi["UyeOl"].ToString();

                        if (drBilgi["SiparisAktif"].ToString()=="True")
                        {
                            cbSiparis.Checked = true;
                        }
                        if (drBilgi["SiparisTamamAktif"].ToString() == "True")
                        {
                            cbSiparisTamam.Checked = true;
                        }
                        if (drBilgi["UyeOlAktif"].ToString() == "True")
                        {
                            cbUyeOl.Checked = true;
                        }
                    }
                }
            }
            catch (Exception)
            {
                
                
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            int Siparis=0, SiparisTamam=0, UyeOl=0;

            if (cbSiparis.Checked)
            {
                Siparis = 1;
            }
            if (cbSiparisTamam.Checked)
            {
                SiparisTamam = 1;
            }
            if (cbUyeOl.Checked)
            {
                UyeOl = 1;
            }
            SqlConnection baglanti = veri.baglan();
            SqlCommand cmd = new SqlCommand("Update MailForm Set Siparis=@Siparis,SiparisTamam=@SiparisTamam,UyeOl=@UyeOl,SiparisAktif=@SiparisAktif,SiparisTamamAktif=@SiparisTamamAktif,UyeOlAktif=@UyeOlAktif", baglanti);

            cmd.Parameters.AddWithValue("@Siparis",txtSiparisSonra.Text.Trim());
            cmd.Parameters.AddWithValue("@SiparisTamam", txtSiparisTamam.Text.Trim());
            cmd.Parameters.AddWithValue("@UyeOl", txtUyeOl.Text.Trim());
            cmd.Parameters.AddWithValue("@SiparisAktif", Siparis);
            cmd.Parameters.AddWithValue("@SiparisTamamAktif", SiparisTamam);
            cmd.Parameters.AddWithValue("@UyeOlAktif",UyeOl);

            try
            {
                cmd.ExecuteNonQuery();
                Msg.Show("Bilgiler Güncellendi");
            }
            catch (Exception)
            {
                Msg.Show("Bir Hata Meydana Geldi,Tekrar Deneyin");
            }
        }
    }
}