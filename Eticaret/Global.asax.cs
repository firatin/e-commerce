using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
namespace Eticaret
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteSet(RouteTable.Routes);
        }
        void RouteSet(RouteCollection routes)
        {
            routes.MapPageRoute("arama", "{aranacakdeger}-{ara}.aspx", "~/Arama.aspx");
            routes.MapPageRoute("urundetay", "detay-{UrunId}-{UrunAdi}.html", "~/UrunDetay.aspx");
            routes.MapPageRoute("kategoridetay", "{AltKategoriId}-{AltKategoriAdi}.html", "~/KategoriDetay.aspx");
            routes.MapPageRoute("sayfadetay", "{SayfaAdi}-{SayfaId}", "~/SayfaDetay.aspx");
            routes.MapPageRoute("rss", "rss", "~/rss.aspx");
            routes.MapPageRoute("xml", "xml", "~/Sitemap.aspx");

        }
        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}