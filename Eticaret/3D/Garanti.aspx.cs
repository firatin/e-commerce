using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eticaret._3D
{
    public partial class Garanti : System.Web.UI.Page
    {
        string UyeId, provuserId, tiduserId, mid, tid, strKey, strpw, hosturl, taksit;
        double tutar;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UyeId"] == null)
            {
                Response.Redirect("/Uyelik/Giris.aspx");
            }
            else
            {

                try
                {
                    UyeId = Session["UyeId"].ToString();

                    provuserId = Session["ProvUserId"].ToString();
                    tiduserId = Session["TidUserId"].ToString();
                    mid = Session["Mid"].ToString();
                    tid = Session["Tid"].ToString();
                    strKey = Session["strkey"].ToString();
                    strpw = Session["strpw"].ToString();
                    hosturl = Session["hosturl"].ToString();
                    tutar = Convert.ToDouble(Session["tutar"].ToString());
                    taksit = Session["taksit"].ToString();
                }
                catch (Exception)
                {
                    Response.Redirect("/Siparis.aspx");
                }

                if (UyeId != "" && provuserId != "" && tiduserId != "" && mid != "" && tid != "" && strKey != "" && strpw != "" && hosturl != "" && tutar.ToString() != "") // bilgiler boş değilse bankaya git.
                {

                    if (!IsPostBack)
                    {
                        
                       
                        string strSecure3dsecuritylevel = "3D_OOS_PAY";
                        string strMode = "PROD";
                        string strApiVersion = "v0.01";
                        string strTerminalProvUserID = provuserId;
                        string strType = "sales";
                        string strAmount = "500";//(tutar * 100).ToString(); //İşlem Tutarı
                     
                        string strCurrencyCode = "949";
                        string strInstallmentCount = taksit; //Taksit Sayısı. Boş gönderilirse taksit yapılmaz
                        string strTerminalUserID = tiduserId; //"deneme"
                        string strOrderID = tiduserId + new Random().Next(1, 9999); //"Deneme" + new Random().Next(1, 9999);
                        string strCustomeripaddress = Request.UserHostAddress.Contains("::") ? "149.226.254.200" : Request.UserHostAddress;
                        string strcustomerEmailAddress = "eticaret@garanti.com.tr";
                        string strTerminalID = tid; //"30691299"; //8 Haneli TerminalID yazılmalı.
                        string _strTerminalID = "0" + strTerminalID;
                        string strTerminalMerchantID = mid; //"7000679";
                        string strStoreKey = strKey; //"12345678"; //3D Secure şifresi
                        string strProvisionPassword = strpw; //"123qweASD"; //Terminal UserID şifresi
                        string strSuccessURL = string.Format("http://{0}:{1}/{2}/{3}", Request.Url.Host, Request.Url.Port, "3D", "Basarili.aspx");
                        string strErrorURL = string.Format("http://{0}:{1}/{2}/{3}", Request.Url.Host, Request.Url.Port, "3D", "Hata.aspx");
                        string strCompanyName = "TradeSiS";
                        string strlang = "tr";
                        string strRefreshTime = "10";
                        string strMotoInd = "N";
                        string strtimestamp = System.DateTime.Now.ToString(); //Random ve Unique bir değer olmalı
                        string SecurityData = GetSHA1(strProvisionPassword + _strTerminalID).ToUpper();
                        string HashData = GetSHA1(strTerminalID + strOrderID + strAmount + strSuccessURL + strErrorURL + strType + strInstallmentCount + strStoreKey + SecurityData).ToUpper();

                        form1.Controls.Add(new HiddenField() { Value = strSecure3dsecuritylevel, ID = "secure3dsecuritylevel" });
                        form1.Controls.Add(new HiddenField() { Value = strMode, ID = "mode" });
                        form1.Controls.Add(new HiddenField() { Value = strApiVersion, ID = "apiversion" });
                        form1.Controls.Add(new HiddenField() { Value = strTerminalProvUserID, ID = "terminalprovuserid" });
                        form1.Controls.Add(new HiddenField() { Value = strTerminalUserID, ID = "terminaluserid" });
                        form1.Controls.Add(new HiddenField() { Value = strTerminalMerchantID, ID = "terminalmerchantid" });
                        form1.Controls.Add(new HiddenField() { Value = strType, ID = "txntype" });
                        form1.Controls.Add(new HiddenField() { Value = strAmount, ID = "txnamount" });
                        form1.Controls.Add(new HiddenField() { Value = strCurrencyCode, ID = "txncurrencycode" });
                        form1.Controls.Add(new HiddenField() { Value = strInstallmentCount, ID = "txninstallmentcount" });
                        form1.Controls.Add(new HiddenField() { Value = strcustomerEmailAddress, ID = "customeremailaddress" });
                        form1.Controls.Add(new HiddenField() { Value = strCustomeripaddress, ID = "customeripaddress" });
                        form1.Controls.Add(new HiddenField() { Value = strOrderID, ID = "orderid" });
                        form1.Controls.Add(new HiddenField() { Value = strTerminalID, ID = "terminalid" });
                        form1.Controls.Add(new HiddenField() { Value = strSuccessURL, ID = "successurl" });
                        form1.Controls.Add(new HiddenField() { Value = strErrorURL, ID = "errorurl" });
                        form1.Controls.Add(new HiddenField() { Value = strCompanyName, ID = "companyname" });
                        form1.Controls.Add(new HiddenField() { Value = strlang, ID = "lang" });
                        form1.Controls.Add(new HiddenField() { Value = strMotoInd, ID = "motoind" });
                        form1.Controls.Add(new HiddenField() { Value = HashData, ID = "secure3dhash" });
                        form1.Controls.Add(new HiddenField() { Value = strtimestamp, ID = "txntimestamp" });
                        form1.Controls.Add(new HiddenField() { Value = strRefreshTime, ID = "refreshtime" });


                        body.Attributes.Add("onload", string.Format("formSubmit('{0}','{1}');", form1.ClientID, hosturl));

                    }
                }
            }
        }

        public string GetSHA1(string SHA1Data)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            string HashedPassword = SHA1Data;
            byte[] hashbytes = Encoding.GetEncoding("ISO-8859-9").GetBytes(HashedPassword);
            byte[] inputbytes = sha.ComputeHash(hashbytes);
            return GetHexaDecimal(inputbytes);
        }

        public string GetHexaDecimal(byte[] bytes)
        {
            StringBuilder s = new StringBuilder();
            int length = bytes.Length;
            for (int n = 0; n <= length - 1; n++)
            {
                s.Append(String.Format("{0,2:x}", bytes[n]).Replace(" ", "0"));
            }
            return s.ToString();
        }
    }
}