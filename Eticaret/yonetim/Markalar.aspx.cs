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

    public partial class Markalar : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        string islem, MarkaId;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Marka Ayarları";
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Marka Ayarları";

            if (Page.IsPostBack == false)
            {

                MarkaGetir();

            }

            try
            {
                islem = Request.QueryString["islem"];
                MarkaId = Kontrol.SayiKontrol(Request.QueryString["Marka"]);

            }
            catch (Exception)
            {
                Response.Redirect("Markalar.aspx");
            }

            if (islem == "duzenle" && MarkaId != null)
            {
                btnGeri.Visible = true;
                if (Page.IsPostBack == false)
                {


                    DataRow drVeriler = veri.GetDataRow("Select * From Markalar Where MarkaId=" + MarkaId + "");

                    btnMarkaEkle.Visible = false;
                    btnMarkaDuzenle.Visible = true;
                    if (drVeriler != null)
                    {
                        txtMarkaAdi.Text = drVeriler["MarkaAdi"].ToString().Trim();

                        if (drVeriler["Aktif"].ToString() == "True")
                        {
                            cbAktif.Checked = true;
                        }
                        else
                        {
                            cbAktif.Checked = false;
                        }
                    }
                }

            }
            else if (islem == "sil" && MarkaId != null)
            {

                veri.cmd("Update Markalar Set Sil='1' Where MarkaId=" + MarkaId + "");
                Response.Redirect("Markalar.aspx");
            }
        }

        protected void btnMarkaEkle_Click(object sender, EventArgs e)
        {
            int aktif = 0;
            if (cbAktif.Checked)
            {
                aktif = 1;
            }

            SqlConnection baglanti = veri.baglan();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_MarkaEkle";
            cmd.Parameters.AddWithValue("MarkaAdi", txtMarkaAdi.Text.Trim());
            cmd.Parameters.AddWithValue("Aktif", aktif);


            try
            {
                cmd.ExecuteNonQuery();

                Response.Redirect("Markalar.aspx");
            }
            catch (Exception)
            {
                Msg.Show("Bir hata meydana geldi");
            }
        }

        protected void btnMarkaDuzenle_Click(object sender, EventArgs e)
        {
            int aktif = 0;
            if (cbAktif.Checked)
            {
                aktif = 1;
            }

            SqlConnection baglanti = veri.baglan();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_MarkaDuzenle";
            cmd.Parameters.AddWithValue("MarkaAdi", txtMarkaAdi.Text.Trim());
            cmd.Parameters.AddWithValue("Aktif", aktif);
            cmd.Parameters.AddWithValue("MarkaId", MarkaId);


            try
            {
                cmd.ExecuteNonQuery();

                Response.Redirect("Markalar.aspx");
            }
            catch (Exception)
            {
                Msg.Show("Bir hata meydana geldi");
            }
        }

        void MarkaGetir()
        {
            try
            {
                DataTable DtKayitlar = veri.GetDataTable("select MarkaId,MarkaAdi,Aktif,Sil, case Aktif when 1 then 'Aktif' when 0 then 'Pasif' end as Durumadi from Markalar where Sil=0 ");

                CollectionPager1.DataSource = DtKayitlar.DefaultView;
                CollectionPager1.BindToControl = RpMarka;
                RpMarka.DataSource = CollectionPager1.DataSourcePaged;
                RpMarka.DataBind();
            }
            catch (Exception)
            {


            }
        }

        protected void btnGeri_Click(object sender, EventArgs e)
        {
            Response.Redirect("Markalar.aspx");
        }
    }
}