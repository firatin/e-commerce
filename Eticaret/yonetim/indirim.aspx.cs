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
    public partial class indirim : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "İndirim Bilgileri";
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "İndirim Bilgileri";

            if (Page.IsPostBack == false)
            {
                try
                {

                    DataRow drindirim = veri.GetDataRow("Select * From indirimler");
                    if (drindirim != null)
                    {
                        txtHavale.Text = Convert.ToDouble(drindirim["HavaleIndirim"]).ToString();
                        Double tekcekim = Convert.ToDouble(drindirim["TekCekimIndirim"].ToString());
                        txtHTekCekim.Text = tekcekim.ToString();

                    }
                }
                catch (Exception)
                {

                }

            }
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (txtHavale.Text=="")
            {
                txtHavale.Text = "0";
            }
            if (txtHTekCekim.Text == "")
                txtHTekCekim.Text = "0";
            {
                
            }
            SqlConnection baglanti = veri.baglan();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_indirimDuzenle";
            cmd.Parameters.AddWithValue("HavaleIndirim", Convert.ToDouble(txtHavale.Text.Trim().Replace(".",",")));

            cmd.Parameters.AddWithValue("TekCekimIndirim", Convert.ToDouble(txtHTekCekim.Text.Trim().Replace(".", ",")));
         
            try
            {
                cmd.ExecuteNonQuery();
                Msg.Show("Bilgiler Güncellendi");
            }
            catch (Exception ex )
            {
                Msg.Show("Bir hata meydana geldi"+ ex.Message);
            }
        }
    }
}