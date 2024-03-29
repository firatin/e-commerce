using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eticaret
{
    public partial class Default : System.Web.UI.Page
    {
        baglanti veri = new baglanti();

        protected void Page_Load(object sender, EventArgs e)
        {


            if (Page.IsPostBack == false)
            {
                TitleGetir();
                PopupGetir();
            }
        }

        void TitleGetir()
        {
            try
            {

                DataRow DrTitle = veri.GetDataRow("Select Title, Descript,Keywords From MetaTag");
                Page.Title = Kontrol.Yonlendirme(DrTitle["Title"].ToString());
                Page.MetaDescription = Kontrol.Yonlendirme(DrTitle["Descript"].ToString());
                Page.MetaKeywords = Kontrol.Yonlendirme(DrTitle["Keywords"].ToString());
            }
            catch (Exception)
            {

            }
        }
        void PopupGetir()
        {
            DataRow drBilgi = veri.GetDataRow("Select * From Popup");

            if (drBilgi != null)
            {

                if (drBilgi["Aktif"].ToString() == "True")
                {

                    lblPBaslik.Text = drBilgi["Baslik"].ToString();
                    ltrlPDetay.Text = drBilgi["PopupMesaj"].ToString();
                    divPopup.Visible = true;
                }

            }
        }
    }
}