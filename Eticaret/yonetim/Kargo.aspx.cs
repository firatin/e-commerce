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
    public partial class Kargo : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        string islem, KargoId;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Kargo Bilgileri";
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Kargo Bilgileri";

            try
            {
                islem = Request.QueryString["islem"];
                KargoId = Kontrol.SayiKontrol(Request.QueryString["KargoId"]);

            }
            catch (Exception)
            {
                Response.Redirect("Kargo.aspx");
            }

            if (islem == "duzenle" && KargoId != null)
            {
                if (Page.IsPostBack == false)
                {


                    DataRow DrKaro = veri.GetDataRow("Select * From Kargolar Where KargoId=" + KargoId + "");

                    btnKargoEkle.Visible = false;
                    btnDuzenle.Visible = true;
                    btnGeri.Visible = true;
                    if (DrKaro != null)
                    {
                        txtKargoAdi.Text = DrKaro["KargoAdi"].ToString().Trim();
                        txtUcretsiz.Text = Convert.ToDouble(DrKaro["AltLimit"]).ToString().Trim();
                        txtSabitUcret.Text = Convert.ToDouble(DrKaro["SabitUcret"]).ToString().Trim();
                        txtOdeme.Text = Convert.ToDouble(DrKaro["KapidaOdeme"]).ToString().Trim();
                        txtAciklama.Text = DrKaro["Aciklama"].ToString().Trim();
                        txtKargoSorgulama.Text = DrKaro["SorgulaAdres"].ToString().Trim();
                        if (DrKaro["Aktif"].ToString() == "True")
                        {
                            cbAktif.Checked = true;
                        }
                    }
                }

            }
            else if (islem=="sil" && KargoId !=null)
            {
                veri.cmd("Update Kargolar Set Sil=1 Where KargoId="+KargoId+"");
                Response.Redirect("Kargo.aspx");
            }

            if (Page.IsPostBack == false)
            {
                KargoGetir();
            }
        }

        protected void btnKargoEkle_Click(object sender, EventArgs e)
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
            cmd.CommandText = "sp_KargoEkle";
            cmd.Parameters.AddWithValue("@KargoAdi", txtKargoAdi.Text.Trim());
            cmd.Parameters.AddWithValue("@AltLimit", txtUcretsiz.Text.Trim());
            cmd.Parameters.AddWithValue("@SabitUcret", txtSabitUcret.Text.Trim());
            cmd.Parameters.AddWithValue("@KapidaOdeme", txtOdeme.Text.Trim());
            cmd.Parameters.AddWithValue("@Aciklama", txtAciklama.Text.Trim());
            cmd.Parameters.AddWithValue("@Aktif", aktif);
            cmd.Parameters.AddWithValue("@SorgulaAdres",txtKargoSorgulama.Text.Trim());


            try
            {
                cmd.ExecuteNonQuery();
                Msg.Show("Kargo Eklendi");
                Response.Redirect("Kargo.aspx");
            }
            catch (Exception)
            {
                Msg.Show("Bir hata meydana geldi");
            }
        }


        void KargoGetir()
        {
            DataTable DtKayitlar = veri.GetDataTable("select KargoId,KargoAdi,AltLimit,SabitUcret,KapidaOdeme,Aciklama, case Aktif when 1 then 'Aktif' when 0 then 'Pasif' end as Durumadi from Kargolar Where Sil=0");
            RpKayit.DataSource = DtKayitlar;
            RpKayit.DataBind();

        }

        protected void btnDuzenle_Click(object sender, EventArgs e)
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
            cmd.CommandText = "sp_KargoDuzenle";
            cmd.Parameters.AddWithValue("@KargoAdi", txtKargoAdi.Text.Trim());
            cmd.Parameters.AddWithValue("@AltLimit", txtUcretsiz.Text.Trim());
            cmd.Parameters.AddWithValue("@SabitUcret", txtSabitUcret.Text.Trim());
            cmd.Parameters.AddWithValue("@KapidaOdeme", txtOdeme.Text.Trim());
            cmd.Parameters.AddWithValue("@Aciklama", txtAciklama.Text.Trim());
            cmd.Parameters.AddWithValue("@Aktif", aktif);
            cmd.Parameters.AddWithValue("@SorgulaAdres", txtKargoSorgulama.Text.Trim());
            cmd.Parameters.AddWithValue("@KargoId", KargoId);

            try
            {
                cmd.ExecuteNonQuery();
                Msg.Show("Kargo Güncellendi");

                Response.Redirect("Kargo.aspx");
            }
            catch (Exception)
            {
                Msg.Show("Bir hata meydana geldi");
            }
        }

        protected void btnGeri_Click(object sender, EventArgs e)
        {
            Response.Redirect("Kargo.aspx");
        }
    }
}