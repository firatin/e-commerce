using CKFinder;
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
    public partial class Popup : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Ana Sayfa'da gösterilecek popup mesajı.";
            Page.Title = "Popup Mesaj";

            if (Page.IsPostBack == false)
            {
                FileBrowser f1 = new FileBrowser();
                f1.BasePath = "../ckfinder/";
               
            }

            try
            {
                if (Page.IsPostBack == false)
                {
                    DataRow drBilgi = veri.GetDataRow("Select * From Popup");

                    if (drBilgi != null)
                    {
                        CKEditorControl1.Text = drBilgi["PopupMesaj"].ToString();
                        txtBaslik.Text = drBilgi["Baslik"].ToString();

                        if (drBilgi["Aktif"].ToString() == "True")
                        {
                            cBoxAktif.Checked = true;
                        }
                        else
                        {
                            cBoxAktif.Checked = false;
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
            int Aktif = 0;

            if (cBoxAktif.Checked)
            {
                Aktif = 1;
            }
           
            SqlConnection baglanti = veri.baglan();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = baglanti;
            cmd.CommandText = "Sp_Popup";
            cmd.Parameters.AddWithValue("@PopupMesaj", CKEditorControl1.Text.Trim());
            cmd.Parameters.AddWithValue("@Aktif", Aktif);
            cmd.Parameters.AddWithValue("@Baslik",txtBaslik.Text.Trim());
            
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