using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Eticaret.Uye
{
    public partial class Kargom1 : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        string UyeId;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Kargo Takibi";
            try
            {
                UyeId = Session["UyeId"].ToString();
            }
            catch (Exception)
            {

                Response.Redirect("Default.aspx");
            }


            SiparisGetir();
        }

        void SiparisGetir()
        {
            if (Page.IsPostBack == false)
            {

                DataTable DtSiparislerim = veri.GetDataTable("SELECT KargoTakip.*, Kargolar.KargoAdi, Kargolar.SorgulaAdres FROM  KargoTakip INNER JOIN Kargolar ON KargoTakip.KargoId = Kargolar.KargoId Where UyeId=" + UyeId + " order by siparisId desc");
                CollectionPager1.DataSource = DtSiparislerim.DefaultView;
                CollectionPager1.BindToControl = RpSiparislerim;
                RpSiparislerim.DataSource = CollectionPager1.DataSourcePaged;
                RpSiparislerim.DataBind();
            }
        }
    }
}