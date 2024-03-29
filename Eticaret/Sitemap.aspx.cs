using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Xml;

namespace Eticaret
{
    public partial class Sitemap : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        public static string UrlAdres;
        protected void Page_Load(object sender, EventArgs e)
        {
            // sadece alt kategorileri çektim.
            UrlAdres = Request.Url.GetLeftPart(UriPartial.Authority).ToString();
            Page.Title = "SiteMap";

            if (UrlAdres!="")
            {
                SiteHaritasiniDondur(); 
            }
           
        }

        private void SiteHaritasiniDondur()
        {

            Response.Clear(); //sitemap xml formatlı olduğundan sayfamızın içeriğini temizliyoruz.
            Response.ContentType = "text/xml";

            XmlTextWriter xr = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);
            xr.WriteStartDocument();
            xr.WriteStartElement("urlset"); // sitemap standartı gereği urlset düğümü oluşturuyoruz.

            // aşağıdaki kodlar ile sitemap`in hangi standartlara uygun olduğunuz belirliyoruz.
            xr.WriteAttributeString("xmlns", "http://www.sitemaps.org/schemas/sitemap/0.9");
            xr.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xr.WriteAttributeString("xsi:schemaLocation", "http://www.sitemaps.org/schemas/sitemap/0.9 http://www.sitemaps.org/schemas/sitemap/0.9/siteindex.xsd");

            // Aşağıdaki 6 satır ile de herhangi bir sayfayı sitemap`e ekliyoruz.
            xr.WriteStartElement("url"); // sitemap standartına göre url düğümü oluşturuluyor.
            xr.WriteElementString("loc", UrlAdres);
            xr.WriteElementString("lastmod", DateTime.Now.ToString("yyyy-MM-dd")); //son değiştirme tarihi
            xr.WriteElementString("changefreq", "daily"); // sayfa içeriğini değişme frekansı
            xr.WriteElementString("priority", "1"); // sayfanın değişme frekansına göre öncelik sırası
            xr.WriteEndElement();

            // Aşağıda ise dinamik olarak yani veritabanındaki bilgilere göre sitemap`imizi hazırlıyoruz.
            DataTable dt = veri.GetDataTable("Select UrunId,UrunAdi,AnaResim150,AnaResim800,Tarih,Detay From Urunler Where AktifMi=1 and Sil=0 Order By UrunId desc");

            foreach (DataRow dr in dt.Rows)
            {
                string UrunLink = UrlAdres + "/detay-" + Kontrol.UrlSeo(dr["UrunId"].ToString()) + "-" + Kontrol.UrlSeo(dr["UrunAdi"].ToString()) + ".html";
                xr.WriteStartElement("url");
                xr.WriteElementString("loc", UrunLink.ToString());
                // xr.WriteElementString("lastmod","";
                xr.WriteElementString("priority", "0.1");
                xr.WriteElementString("changefreq", "daily");
                xr.WriteEndElement();
            }


            xr.WriteEndDocument();
            xr.Flush();
            xr.Close();
            Response.End();

            // rss yerine xml çektim oluşturdum

            
           
            //StringBuilder strBuilder = new StringBuilder();
            //strBuilder.AppendLine("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            //strBuilder.AppendLine("<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\">");

            //#region AnaSayfa
            ////AnaSayfamizi manuel olarak  Ekliyoruz.
            ////veritabanindan çekerek olusturamayacaginiz degisken olmayan linkleri bu seklide ekleyin.
            //strBuilder.AppendLine("<url>");

            //strBuilder.AppendLine("<loc>");
            //string makaleLink = String.Format(UrlAdres);
            //strBuilder.AppendLine(makaleLink);
            //strBuilder.AppendLine("</loc>");

            //strBuilder.AppendLine("<changefreq>");
            //strBuilder.AppendLine("always");
            //strBuilder.AppendLine("</changefreq>");

            //strBuilder.AppendLine("<priority>");
            //strBuilder.AppendLine("1");
            //strBuilder.AppendLine("</priority>");

            //strBuilder.AppendLine("</url>");
            //#endregion

            ////kategorilere gore sayfalari ekle
            //#region Kategoriler


            //DataTable dt = veri.GetDataTable("Select * From AltKategoriler Where Aktif=1 and Sil=0");


            //foreach (DataRow row in dt.Rows)
            //{
            //    strBuilder.AppendLine("<url>");
            //    strBuilder.AppendLine("<loc>");
            //    string kAd = Kontrol.UrlSeo(row["AltKategoriAdi"].ToString());
            //    string kID = row["AltKategoriId"].ToString();
            //    if (kAd.Contains('('))
            //    {
            //        kAd = kAd.Substring(0, kAd.IndexOf('('));
            //    }

            //    //linki olusturuken & yerine &amp; kullaniyoruz. aksi takdirde hata verir.
            //    makaleLink = String.Format(""+UrlAdres+"/{0}-{1}.html", kID, kAd);

            //    strBuilder.AppendLine(makaleLink);
            //    strBuilder.AppendLine("</loc>");

            //    strBuilder.AppendLine("<changefreq>");
            //    strBuilder.AppendLine("weekly");
            //    strBuilder.AppendLine("</changefreq>");

            //    strBuilder.AppendLine("<priority>");
            //    strBuilder.AppendLine("0.5");
            //    strBuilder.AppendLine("</priority>");

            //    strBuilder.AppendLine("</url>");
            //}
            //#endregion

            //strBuilder.AppendLine("</urlset>");

            //Response.ContentType = "text/xml";
            //Response.Write(strBuilder.ToString());
            //Response.End();
        }
    }
}