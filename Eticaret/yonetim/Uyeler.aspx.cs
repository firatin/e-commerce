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
    public partial class Uyeler : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        string islem = "";
        string UyeId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Üyeler";
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Üyeler";

            try
            {
                if (Page.IsPostBack == false)
                {
                    TumUyeler();
                }

            }
            catch (Exception)
            {
            }
            try
            {
                islem = Request.QueryString["islem"];
                UyeId = Kontrol.SayiKontrol(Request.QueryString["UyeId"]);
            }
            catch (Exception)
            {
                
              
            }
          
            if (islem == "sil" && UyeId!=null)
            {
                veri.cmd("Update Uyeler Set Sil=1, AktifMi=0 Where UyeId=" + UyeId + "");
                Response.Redirect("Uyeler.aspx");
            }
        }
        void TumUyeler()
        {
            DataTable DtKayitlar = veri.GetDataTable("Select *,case UyeYetki When 0 Then 'Yetki Yok' when 1 then 'Yönetici' end as YetkiAdi, case UyeTip When 0 Then 'Üye' when 1 then 'Bayi' end as Durumadi From Uyeler Where Sil=0 Order By UyeId Desc ");
            CollectionPager1.DataSource = DtKayitlar.DefaultView;
            CollectionPager1.BindToControl = RpKayit;
            RpKayit.DataSource = CollectionPager1.DataSourcePaged;
            RpKayit.DataBind();
            lblBilgi.Text = "Tüm üyeler listeleniyor.";
        }

        protected void btnUyeler_Click(object sender, EventArgs e)
        {
            TumUyeler();
        }

        protected void btnAra_Click(object sender, EventArgs e)
        {
            if (txtAra.Text != "")
            {

                string deger = txtAra.Text.Trim();

                DataTable dtverigetir = veri.GetDataTable("Select *,case UyeYetki When 0 Then 'Yetki Yok' when 1 then 'Yönetici' end as YetkiAdi, case UyeTip When 0 Then 'Üye' when 1 then 'Bayi' end as Durumadi From Uyeler Where Ad like '%" + deger + "%' OR Soyad like '%" + deger + "%' OR Email like '%" + deger + "%' OR Tel1 like '%" + deger + "%' OR Tel2 like '%" + deger + "%' OR KayitTarihi like '%" + deger + "%' Order By UyeId Desc");

                RpKayit.DataSource = dtverigetir;

                RpKayit.DataBind();

            }

            else
            {

                lblBilgi.Text = "Kayıt Yok";

            }
        }

        protected void btnYetkili_Click(object sender, EventArgs e)
        {
            DataTable DtKayitlar = veri.GetDataTable("Select *,case UyeYetki When 0 Then 'Yetki Yok' when 1 then 'Yönetici' end as YetkiAdi, case UyeTip When 0 Then 'Üye' when 1 then 'Bayi' end as Durumadi From Uyeler Where UyeYetki=1 Order By UyeId Desc ");
            CollectionPager1.DataSource = DtKayitlar.DefaultView;
            CollectionPager1.BindToControl = RpKayit;
            RpKayit.DataSource = CollectionPager1.DataSourcePaged;
            RpKayit.DataBind();
            lblBilgi.Text = "Yetkili üyeler listeleniyor.";
        }
    }
}