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
    public partial class TeslimatBilgi : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        Label lbl1;
       
        string SiparisId,GeriGit;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Teslimat ve Fatura adresi detayları";

          
            try
            {
                SiparisId = Kontrol.SayiKontrol(Request.QueryString["Detay"]);
              
            }
            catch (Exception)
            {

                Response.Redirect("Siparisler.aspx");
            }

            if (SiparisId != "")
            {
                if (Page.IsPostBack == false)
                {
                    try
                    {

                        DataRow drTAdres = veri.GetDataRow("SELECT  UyeId,TFirmaAd,TAd,TSoyad,TAdres,TPostaKodu,TTel1,TTel2, iller.ilAdi as ilAdi, ilceler.ilceAdi as ilceAdi FROM SiparisAdres INNER JOIN dbo.iller ON dbo.SiparisAdres.TilId = dbo.iller.ilId INNER JOIN dbo.ilceler ON dbo.SiparisAdres.TilceId = dbo.ilceler.ilceId WHERE (dbo.SiparisAdres.SiparisId = " + SiparisId + ")");

                        DataRow drFAdres = veri.GetDataRow("SELECT  UyeId,FFirmaAd,FAd,FSoyad,FAdres,FPostaKodu,FTel1,FTel2,FVergiTcNo, iller.ilAdi as ilAdi, ilceler.ilceAdi as ilceAdi FROM SiparisAdres INNER JOIN dbo.iller ON dbo.SiparisAdres.FilId = dbo.iller.ilId INNER JOIN dbo.ilceler ON dbo.SiparisAdres.FilceId = dbo.ilceler.ilceId WHERE (dbo.SiparisAdres.SiparisId = " + SiparisId + ")");

                        // Teslimat adresi

                        txtFaturaAd.Text = drTAdres["TFirmaAd"].ToString().Trim();
                        txtAd.Text = drTAdres["TAd"].ToString().Trim();
                        txtSoyad.Text = drTAdres["TSoyad"].ToString().Trim();
                        txtAdres.Text = drTAdres["TAdres"].ToString().Trim();
                        txtPostaKodu.Text = drTAdres["TPostaKodu"].ToString().Trim();
                        txtTel.Text = drTAdres["TTel1"].ToString().Trim();
                        txtGsm.Text = drTAdres["TTel2"].ToString().Trim();
                        txtTil.Text = drTAdres["ilAdi"].ToString().Trim();
                        txtTilce.Text = drTAdres["ilceadi"].ToString().Trim();

                        // Fatura adresi

                        txtFaturaFirmaAd.Text = drFAdres["FFirmaAd"].ToString().Trim();
                        txtFaturaAd.Text = drFAdres["FAd"].ToString().Trim();
                        txtFaturaSoyad.Text = drFAdres["FSoyad"].ToString().Trim();
                        txtFaturaAdres.Text = drFAdres["FAdres"].ToString().Trim();
                        txtFaturaPostaKodu.Text = drFAdres["FPostaKodu"].ToString().Trim();
                        txtFaturaTel.Text = drFAdres["FTel1"].ToString().Trim();
                        txtFaturaGsm.Text = drFAdres["FTel2"].ToString().Trim();
                        txtFil.Text = drFAdres["ilAdi"].ToString().Trim();
                        txtFilce.Text = drFAdres["ilceAdi"].ToString().Trim();
                        txtTcVergi.Text = drFAdres["FVergiTcNo"].ToString().Trim();
                    }
                    catch (Exception)
                    {

                    }
                }
            }

        }

        protected void btnGeri_Click(object sender, EventArgs e)
        {
            try
            {
                GeriGit = Request.QueryString["Return"];
                if (GeriGit!="")
                {
                    Response.Redirect(GeriGit);
                }
                else
                {
                    Response.Redirect("Siparisler.aspx");
                }
            }
            catch (Exception)
            {
                
            }
        }
    }
}