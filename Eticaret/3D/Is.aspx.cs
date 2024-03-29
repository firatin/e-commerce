using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Eticaret._3D
{
    public partial class Is : System.Web.UI.Page
    {
        public string UyeId, CliendId, strKey, hosturl, taksit;
        public string ffirmaadi, fismi, Fadres, Fil, Filce, FPostaKodu, ttel, tismi, tadres, til, tilce, tpostakodu;
        double tutar;

        baglanti veri = new baglanti();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UyeId"] == null)
            {
                Response.Redirect("/Uyelik/Giris.aspx");
            }
            else
            {


                try
                {
                    UyeId = Session["UyeId"].ToString();

                    CliendId = Session["CliendId"].ToString();
                    strKey = Session["strkey"].ToString();
                    hosturl = Session["hosturl"].ToString();
                    tutar = Convert.ToDouble(Session["tutar"].ToString());
                    taksit = Session["taksit"].ToString();


                }
                catch (Exception)
                {

                }


                if (UyeId != "" && CliendId != "" && strKey != "" && hosturl != "" && tutar.ToString() != "") // bilgiler boş değilse bankaya git.
                {
                    lblTutar.Text = tutar.ToString("C");

                    if (!IsPostBack)
                    {
                        DataRow drTAdres = veri.GetDataRow("SELECT  UyeId,TFirmaAd,TAd,TSoyad,TAdres,TPostaKodu,TTel1,TTel2, iller.ilAdi as ilAdi, ilceler.ilceAdi as ilceAdi FROM AdresFatura INNER JOIN dbo.iller ON dbo.AdresFatura.TilId = dbo.iller.ilId INNER JOIN dbo.ilceler ON dbo.AdresFatura.TilceId = dbo.ilceler.ilceId WHERE (dbo.AdresFatura.UyeId =" + UyeId + ")");

                        DataRow drFAdres = veri.GetDataRow("SELECT  UyeId,FFirmaAd,FAd,FSoyad,FAdres,FPostaKodu,FTel1,FTel2,FVergiTcNo, iller.ilAdi as ilAdi, ilceler.ilceAdi as ilceAdi FROM AdresFatura INNER JOIN dbo.iller ON dbo.AdresFatura.FilId = dbo.iller.ilId INNER JOIN dbo.ilceler ON dbo.AdresFatura.FilceId = dbo.ilceler.ilceId WHERE (dbo.AdresFatura.UyeId = " + UyeId + ")");

                        // fatura adresi
                        ffirmaadi = drFAdres["FFirmaAd"].ToString();
                        fismi = drFAdres["FAd"].ToString() + " " + drFAdres["FSoyad"].ToString();
                        ffirmaadi = drFAdres["FFirmaAd"].ToString();
                        Fadres = drFAdres["FAdres"].ToString();
                        Fil = drFAdres["ilAdi"].ToString();
                        Filce = drFAdres["ilceAdi"].ToString();
                        FPostaKodu = drFAdres["FPostaKodu"].ToString();

                        // teslimat adresi
                        ttel = drTAdres["TTel1"].ToString();
                        tismi = drTAdres["TAd"].ToString() + " " + drTAdres["TSoyad"].ToString();
                        tadres = drTAdres["TAdres"].ToString();
                        til = drTAdres["ilAdi"].ToString();
                        tilce = drTAdres["ilceAdi"].ToString();
                        tpostakodu = drTAdres["TPostaKodu"].ToString();


                    }

                }
                else
                {
                    Response.Redirect("/Siparis.aspx");
                }
            }
        }



        //protected void btnOnay_Click(object sender, EventArgs e)
        //{

        //    btnOnay.PostBackUrl = hosturl;
        //}
    }
}