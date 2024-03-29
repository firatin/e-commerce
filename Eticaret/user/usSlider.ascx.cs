using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eticaret.user
{
    public partial class usSlider : System.Web.UI.UserControl
    {
        baglanti veri = new baglanti();
        public DataTable dtBanner;
        public static string Res1, Res2, Res3, Res4, Title1, Title2, Title3, Title4, Acilis1, Acilis2, Acilis3, Acilis4, Adres1, Adres2, Adres3, Adres4;

        protected void Page_Load(object sender, EventArgs e)
        {
            BannerGetir();

        }
        void BannerGetir()
        {
            DataTable dtBanner = veri.GetDataTable("Select Top 4 * From BannerYonetimi Where Aktif=1 Order By BannerId Desc");
            try
            {
                if (dtBanner.Rows.Count == 1)
                {

                    if (dtBanner.Rows[0]["Resim"].ToString() == null)
                    {
                        ress1.Visible = false;
                    }

                    else
                    {

                        ress1.Visible = true;
                        Res1 = dtBanner.Rows[0]["Resim"].ToString();
                        Adres1 = dtBanner.Rows[0]["UrlAdres"].ToString();
                        Title1 = dtBanner.Rows[0]["Baslik"].ToString();
                        Acilis1 = dtBanner.Rows[0]["YeniSayfada"].ToString();


                    }

                }
                else if (dtBanner.Rows.Count == 2)
                {

                    if (dtBanner.Rows[0]["Resim"].ToString() == null)
                    {
                        ress1.Visible = false;
                    }

                    else
                    {
                        ress1.Visible = true;
                        Res1 = dtBanner.Rows[0]["Resim"].ToString();
                        Adres1 = dtBanner.Rows[0]["UrlAdres"].ToString();
                        Title1 = dtBanner.Rows[0]["Baslik"].ToString();
                        Acilis1 = dtBanner.Rows[0]["YeniSayfada"].ToString();

                    }

                    if (dtBanner.Rows[1]["Resim"].ToString() == null)
                    {
                        ress2.Visible = false;
                    }

                    else
                    {
                        ress2.Visible = true;
                        Res2 = dtBanner.Rows[1]["Resim"].ToString();
                        Adres2 = dtBanner.Rows[1]["UrlAdres"].ToString();
                        Title2 = dtBanner.Rows[1]["Baslik"].ToString();
                        Acilis2 = dtBanner.Rows[1]["YeniSayfada"].ToString();

                    }
                }
                else if (dtBanner.Rows.Count == 3)
                {


                    if (dtBanner.Rows[0]["Resim"].ToString() == null)
                    {
                        ress1.Visible = false;

                    }

                    else
                    {
                        ress1.Visible = true;

                        Res1 = dtBanner.Rows[0]["Resim"].ToString();
                        Adres1 = dtBanner.Rows[0]["UrlAdres"].ToString();
                        Title1 = dtBanner.Rows[0]["Baslik"].ToString();
                        Acilis1 = dtBanner.Rows[0]["YeniSayfada"].ToString();

                    }

                    if (dtBanner.Rows[1]["Resim"].ToString() == null)
                    {
                        ress2.Visible = false;
                    }

                    else
                    {
                        ress2.Visible = true;
                        Res2 = dtBanner.Rows[1]["Resim"].ToString();
                        Adres2 = dtBanner.Rows[1]["UrlAdres"].ToString();
                        Title2 = dtBanner.Rows[1]["Baslik"].ToString();
                        Acilis2 = dtBanner.Rows[1]["YeniSayfada"].ToString();

                    }

                    if (dtBanner.Rows[2]["Resim"].ToString() == null)
                    {
                        ress3.Visible = false;
                    }
                    else
                    {
                        ress3.Visible = true;
                        Res3 = dtBanner.Rows[2]["Resim"].ToString();
                        Adres3 = dtBanner.Rows[2]["UrlAdres"].ToString();
                        Title3 = dtBanner.Rows[2]["Baslik"].ToString();
                        Acilis3 = dtBanner.Rows[2]["YeniSayfada"].ToString();

                    }
                }

                else if (dtBanner.Rows.Count == 4)
                {

                    if (dtBanner.Rows[0]["Resim"].ToString() == null)
                    {
                        ress1.Visible = false;
                    }

                    else
                    {
                        ress1.Visible = true;
                        Res1 = dtBanner.Rows[0]["Resim"].ToString();
                        Adres1 = dtBanner.Rows[0]["UrlAdres"].ToString();
                        Title1 = dtBanner.Rows[0]["Baslik"].ToString();
                        Acilis1 = dtBanner.Rows[0]["YeniSayfada"].ToString();

                    }

                    if (dtBanner.Rows[1]["Resim"].ToString() == null)
                    {
                        ress2.Visible = false;
                    }

                    else
                    {
                        ress2.Visible = true;
                        Res2 = dtBanner.Rows[1]["Resim"].ToString();
                        Adres2 = dtBanner.Rows[1]["UrlAdres"].ToString();
                        Title2 = dtBanner.Rows[1]["Baslik"].ToString();
                        Acilis2 = dtBanner.Rows[1]["YeniSayfada"].ToString();

                    }

                    if (dtBanner.Rows[2]["Resim"].ToString() == null)
                    {
                        ress3.Visible = false;
                    }

                    else
                    {
                        ress3.Visible = true;
                        Res3 = dtBanner.Rows[2]["Resim"].ToString();
                        Adres3 = dtBanner.Rows[2]["UrlAdres"].ToString();
                        Title3 = dtBanner.Rows[2]["Baslik"].ToString();
                        Acilis3 = dtBanner.Rows[2]["YeniSayfada"].ToString();

                    }
                    if (dtBanner.Rows[3]["Resim"].ToString() == null)
                    {
                        ress4.Visible = false;
                    }

                    else
                    {
                        ress4.Visible = true;
                        Res4 = dtBanner.Rows[3]["Resim"].ToString();
                        Adres4 = dtBanner.Rows[3]["UrlAdres"].ToString();
                        Title4 = dtBanner.Rows[3]["Baslik"].ToString();
                        Acilis4 = dtBanner.Rows[3]["YeniSayfada"].ToString();
                    }
                }
            }

            catch (Exception)
            {

                // slideri gizle
                divslider.Visible = false;
            }
        }
    }
}
 

    //void BannerGetir()
    //{
    //    dtBanner = veri.GetDataTable("Select top 4 * From BannerYonetimi Where Aktif=1 Order By BannerId Desc");
    //    try
    //    {
    //        if (dtBanner.Rows[0]["Resim"].ToString() != "")
    //        {
    //            RpBanner.DataSource = dtBanner;
    //            RpBanner.DataBind();
    //        }
    //        if (dtBanner.Rows[1]["Resim"].ToString() != "") //banner1
    //        {
    //            RpBanner.DataSource = dtBanner;
    //            RpBanner.DataBind();
    //        }
    //        if (dtBanner.Rows[2]["Resim"].ToString() != "") //banner2
    //        {
    //            RpBanner.DataSource = dtBanner;
    //            RpBanner.DataBind();
    //        }
    //        if (dtBanner.Rows[3]["Resim"].ToString() != "") // banner 3
    //        {
    //            RpBanner.DataSource = dtBanner;
    //            RpBanner.DataBind();

    //        }

    //    }
    //    catch (Exception)
    //    {
    //        divslider.Visible = false;
    //    }