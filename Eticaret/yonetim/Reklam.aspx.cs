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
    public partial class Reklam : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        string ReklamId, islem;
        string resimadi = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Reklam Alanı";
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Reklam Alanları";
            try
            {
                ReklamId = Kontrol.SayiKontrol(Request.QueryString["Alan"]);
                islem = Request.QueryString["islem"];
            }
            catch (Exception)
            {

                Response.Redirect("Reklam.aspx");

            }

            ReklamAlanDoldur();


            if (islem == "duzenle" && ReklamId != null)
            {

                // seçili olanın bilgilerini getir 
                divReklam.Visible = true;
                if (Page.IsPostBack == false)
                {
                    DataRow drBilgi = veri.GetDataRow("Select * From Reklam Where ReklamId=" + ReklamId + "");
                    if (drBilgi != null)
                    {
                        lblAlan.Text = drBilgi["AlanAdi"].ToString();
                        txtBaslik.Text = drBilgi["Baslik"].ToString();
                        txtUrl.Text = drBilgi["UrlAdres"].ToString();
                        Image1.ImageUrl = "../Resimler/Banner/" + drBilgi["Logo"].ToString();
                        if (drBilgi["Aktif"].ToString() == "True")
                        {
                            cbAktif.Checked = true;
                        }
                    }
                    else
                    {
                        Response.Redirect("Reklam.aspx");
                    }
                }
            }




        }
        void ReklamAlanDoldur()
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    DataTable dtkayit = veri.GetDataTable("Select *,case Aktif when 1 then 'Aktif' when 0 then 'Pasif' end as Durumadi From Reklam ");

                    RpKayit.DataSource = dtkayit;
                    RpKayit.DataBind();
                }
            }
            catch (Exception)
            {

            }
        }

        protected void btnVazgec_Click(object sender, EventArgs e)
        {
            Response.Redirect("Reklam.aspx");
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {

            string uzanti = "";
            string resimtip = "";
            if (FuResim.HasFile)
            {
                // eski resim varsa sil
                EskiResimSil();

                resimtip = FuResim.PostedFile.ContentType;

                if (resimtip == "image/jpeg" || resimtip == "image/jpg" || resimtip == "image/png" || resimtip == "image/bmp" || resimtip == "image/gif")
                {

                    //rasgale sayı
                    Random numara = new Random();
                    Random numara2 = new Random();

                    int resimadisayi = numara.Next(1, 10000);
                    int resimSayi = numara2.Next(1, 7);
                    uzanti = Path.GetExtension(FuResim.PostedFile.FileName);
                    string[] resimDizi = { "r", "re", "res", "resi", "resim", "rklmrsm", "reklam" };
                    resimadi = resimDizi[resimSayi] + resimadisayi + uzanti;



                    FuResim.SaveAs(Server.MapPath("../Resimler/Banner/" + resimadi.ToString()));

                   
                    // resimli kayıt kodları.

                    KayitYap();

                }
                else
                {
                    Msg.Show("Resmin uzantısı sadece, JPG,PNG ve BMP olmalıdır.");
                }

            }
            else
            {
                // resim seçmediyse diğer alanları düzeltmiştir eski resim kalsın.
                resimadi = veri.GetDataCell("Select Logo From Reklam Where ReklamId=" + ReklamId + "");
                KayitYap();
            }
            }
            catch (Exception)
            {

            }
        }


        void KayitYap()
        {
            try
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
                cmd.CommandText = "sp_ReklamDuzenle";
                cmd.Parameters.AddWithValue("@Baslik", txtBaslik.Text.Trim());
                cmd.Parameters.AddWithValue("@UrlAdres", txtUrl.Text.Trim());
                cmd.Parameters.AddWithValue("@Logo", resimadi);
                cmd.Parameters.AddWithValue("@Aktif", aktif);
                cmd.Parameters.AddWithValue("@ReklamId", ReklamId);


                cmd.ExecuteNonQuery();
                Response.Redirect("Reklam.aspx");
            }
            catch (Exception ex)
            {
                Msg.Show(ex.Message);

            }

        }

        void EskiResimSil()
        {
            resimadi = veri.GetDataCell("Select Logo From Reklam Where ReklamId=" + ReklamId + "");

            try
            {

                FileInfo logosil = new FileInfo(Server.MapPath("../Resimler/Banner/" + resimadi));
                logosil.Delete();

            }

            catch (Exception)
            {

            }
            veri.cmd("Update Reklam Set Logo='' Where ReklamId=" + ReklamId + "");

        }
    }
}