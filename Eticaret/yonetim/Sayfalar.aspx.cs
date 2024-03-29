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

    public partial class Sayfalar : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        string islem, SayfaId;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Sayfa Yönetimi";
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Sayfa Yönetimi";

            if (Page.IsPostBack == false)
            {
                SayfaGetir();
            }

            try
            {
               islem = Request.QueryString["islem"];
               SayfaId = Kontrol.SayiKontrol(Request.QueryString["Sayfa"]);

            }
            catch (Exception)
            {
                Response.Redirect("Sayfalar.aspx");
            }

            if (islem=="sil" && SayfaId !=null)
            {
                
                veri.cmd("Delete from Sayfalar Where SayfaId="+SayfaId+"");
                Response.Redirect("Sayfalar.aspx");
            }
        }

        void SayfaGetir()
        {
            try
            {
                DataTable DtKayitlar = veri.GetDataTable("Select SayfaId,SayfaAdi,Aciklama,Tarih,Aktif, case Aktif when 1 then 'Aktif' when  0 then 'Pasif' end as Durumadi from Sayfalar Order By SayfaId Desc ");

                CollectionPager1.DataSource = DtKayitlar.DefaultView;
                CollectionPager1.BindToControl = RpSayfalar;
                RpSayfalar.DataSource = CollectionPager1.DataSourcePaged;
                RpSayfalar.DataBind();

            }
            catch (Exception)
            {


            }
        }
    }
}