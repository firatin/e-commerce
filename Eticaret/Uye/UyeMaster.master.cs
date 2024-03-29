using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eticaret.Uye
{
    public partial class UyeMaster1 : System.Web.UI.MasterPage
    {
        string UyeId;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UyeId"] == null)
            {
                Response.Redirect("/Uyelik/Giris.aspx");
            }
            else
            {
                UyeId = Session["UyeId"].ToString();
            }
        }
    }
}