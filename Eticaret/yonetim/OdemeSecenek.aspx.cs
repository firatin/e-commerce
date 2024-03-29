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
    public partial class OdemeSecenek : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        int KrediKarti = 0, Havale = 0, KapidaOdeme = 0, AktifPos, Odeme3D = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Ödeme Seçenekleri";
            Page.Title = "Ödeme Seçenekleri";

            try
            {
                if (Page.IsPostBack == false)
                {
                    DataRow drBilgi = veri.GetDataRow("Select * From OdemeSecenek");

                    if (drBilgi != null)
                    {

                        if (drBilgi["KrediKarti"].ToString() == "True")
                        {
                            cbKrediKart.Checked = true;
                            ddPos.Enabled = true;
                        }
                        if (drBilgi["Odeme3D"].ToString() == "True")
                        {
                            cb3D.Checked = true;

                        }
                        if (drBilgi["BankaHavale"].ToString() == "True")
                        {
                            cbHavale.Checked = true;
                        }
                        if (drBilgi["KapidaOdeme"].ToString() == "True")
                        {
                            cbKapidaOdeme.Checked = true;
                        }

                        ddPos.SelectedValue = drBilgi["AktifPos"].ToString();
                    }
                }
            }
            catch (Exception)
            {


            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cbKrediKart.Checked && ddPos.SelectedValue == "0")
            {
                Msg.Show("Lütfen Aktif Kullanılacak Pos'u Seçiniz.");
            }
            else
            {
                AktifPos = Convert.ToInt32(ddPos.SelectedValue);

                if (cbKrediKart.Checked)
                {
                    KrediKarti = 1;
                }
                if (cb3D.Checked)
                {
                    Odeme3D = 1;
                }
                if (cbHavale.Checked)
                {
                    Havale = 1;
                }
                if (cbKapidaOdeme.Checked)
                {
                    KapidaOdeme = 1;
                }


                SqlConnection baglanti = veri.baglan();
                SqlCommand cmd = new SqlCommand("Update OdemeSecenek Set KrediKarti=@KrediKarti,Odeme3D=@Odeme3D,BankaHavale=@BankaHavale,KapidaOdeme=@KapidaOdeme,AktifPos=@AktifPos", baglanti);
                cmd.Parameters.AddWithValue("@KrediKarti", KrediKarti);
                cmd.Parameters.AddWithValue("@Odeme3D", Odeme3D);
                cmd.Parameters.AddWithValue("@BankaHavale", Havale);
                cmd.Parameters.AddWithValue("@KapidaOdeme", KapidaOdeme);
                cmd.Parameters.AddWithValue("@AktifPos", AktifPos);
                try
                {
                    cmd.ExecuteNonQuery();
                    Msg.Show("Ayarlarınız Kaydedildi.");

                }
                catch (Exception)
                {

                }
            }


        }

        protected void cbKrediKart_CheckedChanged(object sender, EventArgs e)
        {
            if (cbKrediKart.Checked)
            {
                ddPos.Enabled = true;
            }
            else
            {
                ddPos.Enabled = false;
            }
        }
    }
}