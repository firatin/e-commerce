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
    public partial class Mesajlar : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        string islem = "", MesajId;

        protected void Page_Load(object sender, EventArgs e)
        {
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Gelen Mesajlar";

            try
            {
                if (Page.IsPostBack == false)
                {
                    MesajGetir();
                }

            }
            catch (Exception)
            {
            }

            try
            {
                islem = Request.QueryString["islem"];
                Kontrol.SayiKontrol(MesajId = Request.QueryString["MesajId"]);
            }
            catch (Exception)
            {

            }

            if (islem == "sil" && MesajId != null)
            {
                veri.cmd("Delete From Mesajlar Where MesajId=" + MesajId + "");
                Response.Redirect("Mesajlar.aspx");
            }
            else if (islem == "detay")
            {
                PanelAna.Visible = false;
                PanelDetay.Visible = true;

                if (Page.IsPostBack == false)
                {
                    DataRow DrBilgi = veri.GetDataRow("Select * From Mesajlar Where MesajId=" + MesajId + "");
                    try
                    {
                        string OkunduMu = veri.GetDataCell("Select OkunduMu From Mesajlar Where MesajId=" + MesajId + "");

                        if (OkunduMu == "False")
                        {
                            veri.cmd("Update Mesajlar Set OkunduMu='1' Where MesajId =" + MesajId + "");
                        }
                    }
                    catch (Exception)
                    {
                    }

                    lblAdSoyad.Text = DrBilgi["AdSoyad"].ToString();
                    lblMail.Text = DrBilgi["Email"].ToString();
                    lblKonu.Text = DrBilgi["Konu"].ToString();
                    lblTel.Text = DrBilgi["Tel"].ToString();
                    lblMesaj.Text = DrBilgi["Mesaj"].ToString();
                    lblTarih.Text = DrBilgi["Tarih"].ToString();
                    lblip.Text = DrBilgi["Ip"].ToString();
                }

            }
        }
        void MesajGetir()
        {
            try
            {
                DataTable DtKayitlar = veri.GetDataTable("Select *, case OkunDumu when 1 then 'Okundu' when 0 then 'Okunmadı' end as DurumAdi from Mesajlar Order By OkunduMu asc, MesajId Desc");
                CollectionPager1.DataSource = DtKayitlar.DefaultView;
                CollectionPager1.BindToControl = RpKayit;

                RpKayit.DataSource = CollectionPager1.DataSourcePaged;
                RpKayit.DataBind();
                lblBilgi.Text = "İletişim Formundan Gelen Mesajlar.";
            }
            catch (Exception)
            {

            }
        }
        protected void btnGeri_Click(object sender, EventArgs e)
        {
            Response.Redirect("Mesajlar.aspx");
        }

        protected void btnAra_Click(object sender, EventArgs e)
        {
            if (txtAra.Text != "")
            {

                string deger = txtAra.Text.Trim();

                try
                {
                    DataTable DtKayitlar = veri.GetDataTable("Select *, case OkunDumu when 1 then 'Okundu' when 0 then 'Okunmadı' end as DurumAdi from Mesajlar Where Email like '%" + deger + "%' OR AdSoyad like '%" + deger + "%' OR Tel like '%" + deger + "%' Or Tarih like '%" + deger + "%' OR MesajId like '%" + deger + "%' Order By  OkunduMu asc, MesajId Desc");

                    CollectionPager1.DataSource = DtKayitlar.DefaultView;
                    CollectionPager1.BindToControl = RpKayit;

                    RpKayit.DataSource = CollectionPager1.DataSourcePaged;
                    RpKayit.DataBind();

                    if (DtKayitlar.Rows.Count >0)
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

        protected void btnMesajlar_Click(object sender, EventArgs e)
        {
            MesajGetir();
        }

    }
}