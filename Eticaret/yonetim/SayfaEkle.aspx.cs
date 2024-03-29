using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CKFinder;
using System.Data.SqlClient;
using System.Data;

namespace Eticaret.yonetim
{
    public partial class SayfaEkle : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        Label lbl1;
        string islem, SayfaId;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Sayfa Ekle";
            lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Sayfa Ekle";

            if (Page.IsPostBack == false)
            {
                FileBrowser f1 = new FileBrowser();
                f1.BasePath = "../ckfinder/";
                f1.SetupCKEditor(CKEditorControl1);
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

            if (islem == "duzenle" && SayfaId != null)
            {
             
                DataRow drSayfa = veri.GetDataRow("Select * From Sayfalar Where SayfaId=" + SayfaId + "");
                lbl1.Text = "Sayfa Düzenle";
                if (Page.IsPostBack==false)
                {
                    btnEkle.Visible = false;
                    btnGuncelle.Visible = true;
        
                if (drSayfa != null)
                {
                    txtSayfaAdi.Text = drSayfa["SayfaAdi"].ToString().Trim();
                    CKEditorControl1.Text = drSayfa["Aciklama"].ToString();

                    if (drSayfa["Aktif"].ToString() == "True")
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

        }

        protected void btnEkle_Click(object sender, EventArgs e)
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
            cmd.CommandText = "sp_SayfaEkle";
            cmd.Parameters.AddWithValue("SayfaAdi", txtSayfaAdi.Text.Trim());
            cmd.Parameters.AddWithValue("Aciklama", CKEditorControl1.Text);
            cmd.Parameters.AddWithValue("Aktif", aktif);


            try
            {
                cmd.ExecuteNonQuery();

                Response.Redirect("Sayfalar.aspx");
            }
            catch (Exception)
            {
                Msg.Show("Bir hata meydana geldi");
            }
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
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
            cmd.CommandText = "sp_SayfaDuzenle";
            cmd.Parameters.AddWithValue("SayfaAdi", txtSayfaAdi.Text.Trim());
            cmd.Parameters.AddWithValue("Aciklama", CKEditorControl1.Text);
            cmd.Parameters.AddWithValue("Aktif", aktif);
            cmd.Parameters.AddWithValue("SayfaId", SayfaId);


            try
            {
                cmd.ExecuteNonQuery();

                Response.Redirect("Sayfalar.aspx");
            }
            catch (Exception)
            {
                Msg.Show("Bir hata meydana geldi");
            }
        }

        protected void btnGeri_Click(object sender, EventArgs e)
        {
            Response.Redirect("Sayfalar.aspx");
        }
    }
}