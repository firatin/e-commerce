using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace Eticaret
{
    public partial class rss1 : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        public string UrlAdres;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Rss";
            UrlAdres = Request.Url.GetLeftPart(UriPartial.Authority).ToString();


            try
            {
                if (UrlAdres != "")
                {
                    RssUrunGetir();

                }

            }
            catch (Exception)
            {

            }

        }

        void RssUrunGetir()
        {
            //ürün bilgilerini getir

            DataTable dt = veri.GetDataTable("Select UrunId,UrunAdi,AnaResim150,AnaResim800,Tarih,Detay From Urunler Where AktifMi=1 and Sil=0 Order By UrunId desc");

            DataRow drbilgi = veri.GetDataRow("Select Title,Descript From MetaTag");

            string baslik = drbilgi["Title"].ToString();
            string link = UrlAdres;
            string aciklama = drbilgi["Descript"].ToString();

            //string resim_url = "RSS sayfasında gözükmesini istediğiniz";
            //string resim_baslik = "Logo başlığı";

            Response.Clear();
            Response.ContentType = "text/xml";
            XmlTextWriter xml = new XmlTextWriter(Response.OutputStream, Encoding.UTF8);
            xml.WriteStartDocument();
            xml.WriteStartElement("rss");
            xml.WriteAttributeString("version", "2.0");
            xml.WriteStartElement("channel");
            xml.WriteElementString("title", baslik);
            xml.WriteElementString("link", link);
            xml.WriteElementString("description", aciklama);
            xml.WriteElementString("language", "tr");
            //  xml.WriteStartElement("image"); //resimler görünmesin gerek yok
            //  xml.WriteElementString("url", "");
            //xml.WriteElementString("title", resim_baslik);
            xml.WriteEndElement();

            foreach (DataRow dr in dt.Rows)
            {
                string UrunLink = link + "/detay-" + Kontrol.UrlSeo(dr["UrunId"].ToString()) + "-" + Kontrol.UrlSeo(dr["UrunAdi"].ToString()) + ".html";
                string UrunAdi = Kontrol.UrlSeo(dr["UrunAdi"].ToString());
                xml.WriteStartElement("item");
                xml.WriteElementString("title", dr["UrunAdi"].ToString());
                xml.WriteElementString("description", dr["Detay"].ToString());
                xml.WriteElementString("pubDate", dr["Tarih"].ToString());
                xml.WriteElementString("link", UrunLink);
                xml.WriteStartElement("image");
                xml.WriteElementString("url", link + "/Resimler/Urun/800/" + dr["AnaResim800"].ToString());
                xml.WriteEndElement();
            }
            xml.WriteEndElement();
            xml.WriteEndDocument();
            xml.Flush();
            xml.Close();
            Response.End();
        }
    }
}