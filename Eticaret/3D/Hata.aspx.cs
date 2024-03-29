using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eticaret._3D
{
    public partial class Hata : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form.ToString() != "")
            {
                lblResult.Text = "Siparişiniz Onaylanmadı.Girdiğiniz bilgilerin doğruluğundan eminseniz lütfen bankanızla görüşüp işlemi tekrar deneyiniz";
                //string test = Request.Form["mdstatus"];
                //lblResult.Text = test;
            }


            else
            {
                Response.Redirect("/Default.aspx");
            }
        }
    }
}