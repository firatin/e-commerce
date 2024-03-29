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
    public partial class OdemeBildirim : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        string islem = "", OdemeId;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Ödeme Bildirimleri";

            try
            {
                if (Page.IsPostBack == false)
                {
                    BildirimGetir();
                }

            }
            catch (Exception)
            {
            }
            try
            {
                islem = Request.QueryString["islem"];
                Kontrol.SayiKontrol(OdemeId = Request.QueryString["OdemeId"]);
            }
            catch (Exception)
            {

            }

            if (islem == "sil" && OdemeId != null)
            {
                veri.cmd("Delete From OdemeBildirim Where OdemeId=" + OdemeId + "");
                Response.Redirect("OdemeBildirim.aspx");
            }
            else if (islem == "detay")
            {
                PanelAna.Visible = false;
                PanelDetay.Visible = true;

                if (Page.IsPostBack == false)
                {
                    DataRow DrBilgi = veri.GetDataRow("SELECT dbo.OdemeBildirim.*, dbo.Bankalar.BankaAdi FROM  dbo.OdemeBildirim INNER JOIN dbo.Bankalar ON dbo.OdemeBildirim.BankaId = dbo.Bankalar.BankaId Where OdemeId=" + OdemeId + "");
                    try
                    {
                        string OkunduMu = veri.GetDataCell("Select OkunduMu From OdemeBildirim Where OdemeId=" + OdemeId + "");

                        if (OkunduMu == "False")
                        {
                            veri.cmd("Update OdemeBildirim Set OkunduMu='1' Where OdemeId =" + OdemeId + "");
                        }
                    }
                    catch (Exception)
                    {
                    }

                    lblAdSoyad.Text = DrBilgi["AdSoyad"].ToString();
                    lblMail.Text = DrBilgi["Email"].ToString();
                    lblOdenenMiktar.Text = DrBilgi["OdenenTutar"].ToString();
                    lblOdemeYapan.Text = DrBilgi["OdemeYapanAdSoyad"].ToString();
                    lblOdemeYontemi.Text = DrBilgi["OdemeSekli"].ToString().Trim();
                    lblBanka.Text = DrBilgi["BankaAdi"].ToString();
                    lblAdSoyad.Text = DrBilgi["AdSoyad"].ToString();
                    lblTel.Text = DrBilgi["Tel"].ToString();
                    lblAciklama.Text = DrBilgi["Aciklama"].ToString();
                    lblTarih.Text = DrBilgi["Tarih"].ToString();
                    lblip.Text = DrBilgi["Ip"].ToString();
                }

            }
        }
        void BildirimGetir()
        {
            try
            {
                DataTable DtKayitlar = veri.GetDataTable("Select *, case OkunDumu when 1 then 'Okundu' when 0 then 'Okunmadı' end as DurumAdi from OdemeBildirim Order By OkunduMu asc, OdemeId Desc");
                CollectionPager1.DataSource = DtKayitlar.DefaultView;
                CollectionPager1.BindToControl = RpKayit;

                RpKayit.DataSource = CollectionPager1.DataSourcePaged;
                RpKayit.DataBind();
                lblBilgi.Text = "Havale ile alınmış ürünler için gönderilen ödeme bilgirimleri.";
            }
            catch (Exception)
            {

            }
        }

        protected void btnGeri_Click(object sender, EventArgs e)
        {
            Response.Redirect("OdemeBildirim.aspx");
        }

        protected void btnBildirimler_Click(object sender, EventArgs e)
        {
            BildirimGetir();
        }

        protected void btnAra_Click(object sender, EventArgs e)
        {
            if (txtAra.Text != "")
            {

                string deger = txtAra.Text.Trim();

                try
                {
                    DataTable DtKayitlar = veri.GetDataTable("Select *, case OkunDumu when 1 then 'Okundu' when 0 then 'Okunmadı' end as DurumAdi from OdemeBildirim where AdSoyad like '%" + deger + "%' OR Email like '%" + deger + "%' OR OdemeYapanAdSoyad like '%" + deger + "%' OR BankaAdi like'%" + deger + "%' OR Tel like '%" + deger + "%' OR Tarih like '%" + deger + "%' OR OdenenTutar like '%" + deger + "%' OR OdemeSekli like '%" + deger + "%' Order By OkunduMu asc, OdemeId Desc");

                    CollectionPager1.DataSource = DtKayitlar.DefaultView;
                    CollectionPager1.BindToControl = RpKayit;

                    RpKayit.DataSource = CollectionPager1.DataSourcePaged;
                    RpKayit.DataBind();

                    if (DtKayitlar.Rows.Count > 0)
                    {
                        lblBilgi.Text = "Arama Sonuçlandı, Kayıtlar Listeleniyor";
                    }
                    else
                    {
                        lblBilgi.Text = "Arama Kriterine Uygun Kayıt Bulunamadı";
                    }

                }
                catch (Exception)
                {

                }
            }

            else
            {

                lblBilgi.Text = "Kayıt Bulunamadı";

            }
        }
    }
}