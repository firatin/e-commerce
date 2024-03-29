using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Eticaret
{
    //toast message
    public enum eStatusType : short
    {
        Onay = 1,
        Bilgi = 2,
        Uyari = 3,
        Hata = 4
    }
    //toast son

    public class Msg
    {
      // toast message

        public static void Mesaj(Control pctrlControl, eStatusType peUyariTuru, string pstrMesaj)
        {
            try
            {
                string strTur = "";
                switch (peUyariTuru)
                {
                    case eStatusType.Onay:
                        strTur = "showSuccessToast";
                        break;
                    case eStatusType.Bilgi:
                        strTur = "showNoticeToast";
                        break;
                    case eStatusType.Uyari:
                        strTur = "showWarningToast";
                        break;
                    case eStatusType.Hata:
                        strTur = "showErrorToast";
                        break;
                    default:
                        break;
                }
                ScriptManager.RegisterStartupScript(pctrlControl, pctrlControl.GetType(), "ShowMessage", "$().toastmessage('" + strTur + "', '" + pstrMesaj + "');", true);
            }
            catch
            {
                throw;
            }
        }
        //toasg message son

        protected static Hashtable handlerPages = new Hashtable();
        private Msg()
        {
        }
        public static void Show(string Message)
        {
            if (!(handlerPages.Contains(HttpContext.Current.Handler)))
            {
                Page currentPage = (Page)HttpContext.Current.Handler;
                if (!((currentPage == null)))
                {
                    Queue messageQueue = new Queue();
                    messageQueue.Enqueue(Message);
                    handlerPages.Add(HttpContext.Current.Handler, messageQueue);
                    currentPage.Unload += new EventHandler(CurrentPageUnload);
                }
            }
            else
            {
                Queue queue = ((Queue)(handlerPages[HttpContext.Current.Handler]));
                queue.Enqueue(Message);
            }
        }
        private static void CurrentPageUnload(object sender, EventArgs e)
        {
            Queue queue = ((Queue)(handlerPages[HttpContext.Current.Handler]));
            if (queue != null)
            {
                StringBuilder builder = new StringBuilder();
                int iMsgCount = queue.Count;
                builder.Append("<script language='javascript'>");
                string sMsg;
                while ((iMsgCount > 0))
                {
                    iMsgCount = iMsgCount - 1;
                    sMsg = System.Convert.ToString(queue.Dequeue());
                    sMsg = sMsg.Replace("\"", "'");
                    builder.Append("alert( \"" + sMsg + "\" );");
                }
                builder.Append("</script>");
                handlerPages.Remove(HttpContext.Current.Handler);
                HttpContext.Current.Response.Write(builder.ToString());
            }
        }
    }

}

