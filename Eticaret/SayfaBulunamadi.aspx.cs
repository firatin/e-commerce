using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eticaret
{
    public partial class SayfaBulunamadi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Sayfa Bulunamadı";
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Aradığınız Sayfa Bulunamadı";
        }
    }
}