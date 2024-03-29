using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eticaret
{
    public partial class SayfaDetay : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        string SayfaId;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            try
            {
                SayfaId = Kontrol.SayiKontrol(Kontrol.UrlSeo(RouteData.Values["SayfaId"].ToString()));
            }
            catch (Exception)
            {

                Response.Redirect("Default.aspx");

            }

            SayfaId = Kontrol.SayiKontrol(Kontrol.Temizle(RouteData.Values["SayfaId"].ToString()));
            if (SayfaId != null)
            {
                DataRow DrSayfa = veri.GetDataRow("Select * From Sayfalar Where Aktif=1 and SayfaId =" + SayfaId);

                if (DrSayfa != null)
                {

                    Page.Title = DrSayfa["SayfaAdi"].ToString();
                    Page.MetaDescription = DrSayfa["SayfaAdi"].ToString();
                    Page.MetaKeywords = DrSayfa["SayfaAdi"].ToString();

                    lbl1.Text = DrSayfa["SayfaAdi"].ToString();

                    ltrlDetay.Text = DrSayfa["Aciklama"].ToString();


                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }
    }
}