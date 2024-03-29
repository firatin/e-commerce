using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace Eticaret.yonetim
{
    public partial class Seo : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "SEO Ayarları";
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "SEO Ayarları";

            if (Page.IsPostBack == false)
            {

                DataRow drSeo = veri.GetDataRow("Select * From MetaTag");
                if (drSeo != null)
                {
                    try
                    {

                    txtTitle.Text = drSeo["Title"].ToString().Trim();
                    txtDesc.Text = drSeo["Descript"].ToString().Trim();
                    txtKeyw.Text = drSeo["Keywords"].ToString().Trim();
                    txtGdogrulama.Text = drSeo["GoogleDogrulama"].ToString().Trim();
                    txtGanalytics.Text = drSeo["GoogelAnaliz"].ToString().Trim();
                    txtTwitter.Text = drSeo["Twitter"].ToString().Trim();
                    txtFacebook.Text = drSeo["Facebook"].ToString().Trim();
                    txtHarita.Text = drSeo["GoogleHarita"].ToString().Trim();
                    if (drSeo["SiteLogo"].ToString() !="")
                    {
                        Image1.ImageUrl = "../images/" + drSeo["SiteLogo"].ToString();
                    }
                    else
                    {
                        PanelSil.Visible = false;
                    }
               

                    }
                    catch (Exception)
                    {

                    }

                }
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = veri.baglan();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_MetaTag";
            cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
            cmd.Parameters.AddWithValue("@Descript", txtDesc.Text.Trim());
            cmd.Parameters.AddWithValue("@Keywords", txtKeyw.Text.Trim());
            cmd.Parameters.AddWithValue("@GoogleDogrulama", txtGdogrulama.Text.Trim());
            cmd.Parameters.AddWithValue("@GoogelAnaliz", txtGanalytics.Text.Trim());
            cmd.Parameters.AddWithValue("@Twitter", txtTwitter.Text.Trim());
            cmd.Parameters.AddWithValue("@Facebook", txtFacebook.Text.Trim());
            cmd.Parameters.AddWithValue("@GoogleHarita", txtHarita.Text.Trim());
            cmd.Parameters.AddWithValue("@Footer", txtFooter.Text.Trim());
           
            try
            {
                cmd.ExecuteNonQuery();
                Msg.Show("Bilgiler Güncellendi");
            }
            catch (Exception)
            {
                Msg.Show("Bir hata meydana geldi");
            }
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
           
            string resimadi = veri.GetDataCell("select SiteLogo from MetaTag");

            try
            {

                FileInfo logosil = new FileInfo(Server.MapPath("../images/" + resimadi));
                logosil.Delete();

            }

            catch (Exception)
            {

            }
            veri.cmd("Update MetaTag Set SiteLogo=''");
            Response.Redirect("Seo.aspx");
        }

        protected void btnResimYukle_Click(object sender, EventArgs e)
        {
          
            string resimadi = "";
            string uzanti = "";
            string resimtip = "";
            if (FuResim.HasFile)
            {
                resimtip = FuResim.PostedFile.ContentType;

                if (resimtip == "image/jpeg" || resimtip == "image/jpg" || resimtip == "image/png" || resimtip == "image/bmp")
                {

                    uzanti = Path.GetExtension(FuResim.PostedFile.FileName);

                    resimadi = "sitelogo" + uzanti;

                    FuResim.SaveAs(Server.MapPath("../images/" + resimadi));

                    try
                    {
                        SqlConnection baglanti = veri.baglan();
                        SqlCommand cmd = new SqlCommand("Update MetaTag Set SiteLogo=@SiteLogo", baglanti);
                        cmd.Parameters.AddWithValue("SiteLogo", resimadi.ToString());
                        cmd.ExecuteNonQuery();
                        Response.Redirect("Seo.aspx");
                    }
                    catch (Exception)
                    {


                    }

                 
                }
                else
                {
                  Msg.Show("Resmin uzantısı sadece, JPG,PNG ve BMP olmalıdır.");
                }

            }
            else
            {
              Msg.Show("Resim Seçmediniz");
            }
        }

        protected void txtHarita_TextChanged(object sender, EventArgs e)
        {

        }
    }
}