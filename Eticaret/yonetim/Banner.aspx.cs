using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Threading;

namespace Eticaret.yonetim
{
    public partial class Banner : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        Label lbl1;
        string islem = "", BannerId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Banner Yönetimi";
            Page.Title = "Banner Yönetimi";


            try
            {
                islem = Request.QueryString["islem"];
                BannerId = Kontrol.SayiKontrol(Request.QueryString["BannerId"]);

            }
            catch (Exception)
            {
                Response.Redirect("Banner.aspx");
            }

            if (islem == "duzenle" && BannerId != null)
            {
                if (Page.IsPostBack == false)
                {

                    DataRow DrBanner = veri.GetDataRow("Select * From BannerYonetimi Where BannerId=" + BannerId + "");

                    btnEkle.Visible = false;
                    btnDuzenle.Visible = true;
                    btnGeri.Visible = true;
                    FuResim.Visible = false;
                    if (DrBanner != null)
                    {

                        txtBaslik.Text = DrBanner["Baslik"].ToString().Trim();
                        txturlAdres.Text = DrBanner["UrlAdres"].ToString().Trim();
                        imgResim.ImageUrl = "../Resimler/Banner/" + DrBanner["Resim"].ToString().Trim();
                        imgResim.Visible = true;
                        if (DrBanner["YeniSayfada"].ToString() == "_self")
                        {
                            cbYeniSayfa.Checked = false;
                        }
                        else if (DrBanner["YeniSayfada"].ToString() == "_blank")
                        {
                            cbYeniSayfa.Checked = true;
                        }
                        if (DrBanner["Aktif"].ToString() == "True")
                        {
                            cbAktif.Checked = true;
                        }
                        else
                        {
                            cbAktif.Checked = false;
                        }
                    }
                }

            }
            else if (islem == "sil")
            {
                try
                {
                    string resimadi = veri.GetDataCell("Select Resim From BannerYonetimi Where BannerId=" + BannerId + ""); 
                    FileInfo fi150sil = new FileInfo(Server.MapPath("../Resimler/Banner/") + resimadi.ToString());
                    fi150sil.Delete();
                    veri.cmd("Delete From BannerYonetimi Where BannerId=" + BannerId + "");

                    Response.Redirect("Banner.aspx");
                }
                catch (Exception)
                {

                }
            }

            try
            {
                BannerGetir();
            }
            catch (Exception)
            {
            }
        }
        void BannerGetir()
        {
            DataTable DtKayitlar = veri.GetDataTable("Select *, Case Aktif when 1 then 'Aktif' when 0 then 'Pasif' end as Durumadi from BannerYonetimi Order By BannerId Desc ");
            CollectionPager1.DataSource = DtKayitlar.DefaultView;
            CollectionPager1.BindToControl = RpKayit;
            RpKayit.DataSource = CollectionPager1.DataSourcePaged;
            RpKayit.DataBind();

        }
        protected void btnEkle_Click(object sender, EventArgs e)
        {

            string resimadi = "";
            string uzanti = "";
            string resimtip = "";
            if (FuResim.HasFile)
            {
                resimtip = FuResim.PostedFile.ContentType;

                if (resimtip == "image/jpeg" || resimtip == "image/jpg" || resimtip == "image/png" || resimtip == "image/bmp" || resimtip == "image/gif")
                {


                    //rasgale sayı
                    Random numara = new Random();
                    Random numara2 = new Random();

                    int resimadisayi = numara.Next(1, 10000);
                    int resimSayi = numara2.Next(1, 7);
                    uzanti = Path.GetExtension(FuResim.PostedFile.FileName);
                    string[] resimDizi = { "r", "re", "res", "resi", "resim", "bannerres", "bnr" };
                    resimadi = resimDizi[resimSayi] + resimadisayi + uzanti;


                    FuResim.SaveAs(Server.MapPath("../Resimler/Banner/" + resimadi));

                    try
                    {
                        string yenisayfa = "_self"; int aktif = 0;
                        if (cbAktif.Checked)
                        {
                            aktif = 1;
                        }
                        if (cbYeniSayfa.Checked)
                        {
                            yenisayfa = "_blank";
                        }

                        SqlConnection baglanti = veri.baglan();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = baglanti;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_BannerEkle";
                        cmd.Parameters.AddWithValue("@Baslik", txtBaslik.Text.Trim());
                        cmd.Parameters.AddWithValue("@UrlAdres", txturlAdres.Text.Trim());
                        cmd.Parameters.AddWithValue("@YeniSayfada", yenisayfa);
                        cmd.Parameters.AddWithValue("@Aktif", aktif);
                        cmd.Parameters.AddWithValue("@Resim", resimadi);

                        cmd.ExecuteNonQuery();
                        Response.Redirect("Banner.aspx");
                    }
                    catch (Exception ex)
                    {
                        Msg.Show(ex.Message);

                    }


                }
                else
                {
                    Msg.Show("Resmin uzantısı sadece, JPG,PNG,BMP ve GİF olmalıdır.");
                }

            }
            else
            {
                Msg.Show("Resim Seçmediniz");
            }
        }

        protected void btnGeri_Click(object sender, EventArgs e)
        {
            Response.Redirect("Banner.aspx");
        }

        protected void btnDuzenle_Click(object sender, EventArgs e)
        {
            try
            {
                string yenisayfa = "_self"; int aktif = 0;
                if (cbAktif.Checked)
                {
                    aktif = 1;
                }
                if (cbYeniSayfa.Checked)
                {
                    yenisayfa = "_blank";
                }

                SqlConnection baglanti = veri.baglan();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_BannerDuzenle";
                cmd.Parameters.AddWithValue("@Baslik", txtBaslik.Text.Trim());
                cmd.Parameters.AddWithValue("@UrlAdres", txturlAdres.Text.Trim());
                cmd.Parameters.AddWithValue("@YeniSayfada", yenisayfa);
                cmd.Parameters.AddWithValue("@Aktif", aktif);
                cmd.Parameters.AddWithValue("@BannerId", BannerId);

                cmd.ExecuteNonQuery();
                Response.Redirect("Banner.aspx");
            }
            catch (Exception ex)
            {
                Msg.Show(ex.Message);

            }
        }
    }
}