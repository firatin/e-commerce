using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace Eticaret.yonetim
{
    public partial class AnaPage : System.Web.UI.MasterPage
    {
        baglanti veri = new baglanti();
        string UyeId, Yetki, MesajSayisi, BildirimSayisi,YorumSayisi;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UyeId"] == null)
            {
                Response.Redirect("/Uyelik/Giris.aspx");
            }
            else
            {
                UyeId = Session["UyeId"].ToString();
                Yetki = veri.GetDataCell("Select UyeYetki From Uyeler Where UyeId=" + UyeId + "");
                if (Yetki == "1")
                {
                    lblAdmin.Text = Session["Ad"].ToString() + " " + Session["Soyad"].ToString();
                }
                else
                {
                    Response.Redirect("/Uyelik/Giris.aspx");
                }

                if (Page.IsPostBack == false)
                {
                    MesajBildirim();
                }
            }

        }

        protected void lnkCikis_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("/Uyelik/Giris.aspx");
        }

        void MesajBildirim()
        {
            BildirimSayisi = veri.GetDataCell("Select COUNT(OdemeId) From OdemeBildirim Where OkunduMu=0");
            lblBildirim.Text = BildirimSayisi;

            MesajSayisi = veri.GetDataCell("Select COUNT(MesajId) From Mesajlar Where OkunduMu=0");
            lblMesaj.Text = MesajSayisi;

            YorumSayisi = veri.GetDataCell("Select COUNT(YorumId) From Yorumlar Where AktifMi=0");
            lblYrm.Text = YorumSayisi;
        }

    }
}