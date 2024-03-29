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
    public partial class iyzicoPos : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
           
            lbl1.Text="İyzico Pos Bilgileri";

            if (Page.IsPostBack==false)
            {
                DataRow DrBilgi = veri.GetDataRow("Select * From iyzicoPos");
                if (DrBilgi!=null)
                {
                    txtAd.Text = DrBilgi["Login"].ToString();
                    txtSifre.Text = DrBilgi["Pw"].ToString();
                }
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = veri.baglan();
            SqlCommand cmd = new SqlCommand("Update iyzicoPos Set Login=@Login,Pw=@Pw",baglanti);
            cmd.Parameters.AddWithValue("@Login",txtAd.Text.Trim());
            cmd.Parameters.AddWithValue("@Pw",txtSifre.Text.Trim());

            try
            {
                cmd.ExecuteNonQuery();
                Msg.Show("Bilgiler Güncellendi");
            }
            catch (Exception ex)
            {
                Msg.Show(ex.Message);
             
            }
        }
    }
}