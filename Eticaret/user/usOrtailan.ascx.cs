using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eticaret.user
{
    public partial class usOrtailan1 : System.Web.UI.UserControl
    {
        baglanti veri = new baglanti();
        string UyeId, UyeTip;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsPostBack == false)
                {
                    if (Session["UyeId"] != null)
                    {
                        UyeId = Session["UyeId"].ToString();
                    }

                    AnaUrunGetir();
                }

                if (Session["RowUrl"] != null)
                {
                    Eticaret.Msg.Mesaj(this, eStatusType.Bilgi, "<br/>Siparişiniz sepete eklendi.");
                    Session.Remove("RowUrl");

                }

            }
            catch (Exception ex)
            {

                Msg.Show(ex.Message);
            }
        }

        void AnaUrunGetir()
        {
            if (UyeId != null)
            {
                UyeTip = veri.GetDataCell("Select UyeTip From Uyeler Where UyeId=" + UyeId + "");
            }

            if (UyeId == null || UyeTip == "0") // ziyaretçi veya normal üye ise 
            {
                DataTable dtUrunler = veri.GetDataTable("Select Top 15 UrunId,UrunAdi,StokKodu,SatisFiyati,((SatisFiyati - indirim) * Kdv/100+SatisFiyati-indirim) as SatisFiyatiKdvli ,AnaResim800,AnaResim150 From Urunler Where Sil=0 and AktifMi=1 and VitrinUrunu=1 Order By UrunId Desc");
                RpUrunler.DataSource = dtUrunler;
                RpUrunler.DataBind();
            }
            else if (UyeTip == "1") // bayi ise
            {
                DataTable dtUrunler = veri.GetDataTable("Select Top 15 UrunId,UrunAdi,StokKodu,BayiFiyati,((BayiFiyati - BayiIndirim) * Kdv/100+BayiFiyati-BayiIndirim) as SatisFiyatiKdvli ,AnaResim800,AnaResim150 From Urunler Where Sil=0 and AktifMi=1 and VitrinUrunu=1 Order By UrunId Desc");
                RpUrunler.DataSource = dtUrunler;
                RpUrunler.DataBind();
            }

        }

        protected void RpUrunler_ItemCommand(object source, DataListCommandEventArgs e)
        {

            if (e.CommandName == "SepeteEkle")
            {
                try
                {

                    if (Session["UyeId"] == null)
                    {
                        Response.Redirect("/Uyelik/Giris.aspx");
                    }
                    else
                    {

                        UyeId = Session["UyeId"].ToString();

                    }

                    Session.Add("RowUrl", HttpContext.Current.Request.RawUrl);

                    DataRow drUrun = veri.GetDataRow("Select StokMiktari,MaxSparisMiktari,MinSparisMiktari From Urunler Where UrunId=" + e.CommandArgument + "");

                    string ipadres = HttpContext.Current.Request.UserHostAddress;

                    int Miktar = 1; // detay sayfası dışındaki yerlerde 1 adet sipariş edilebilir.
                    int stoksayisi = Convert.ToInt32(drUrun["StokMiktari"]);
                    int MaxSparisMiktari = Convert.ToInt32(drUrun["MaxSparisMiktari"]);
                    if (MaxSparisMiktari == 0) MaxSparisMiktari = 1; // eğer admin panelinden 0 yapılırsa hiç bir ürün alınamaz.;
                    int MinSparisMiktari = Convert.ToInt32(drUrun["MinSparisMiktari"]);
                    if (MinSparisMiktari == 0) MinSparisMiktari = 1; // eğer admin panelinden 0 yapılırsa hiç bir ürün alınamaz.;
                    if (Miktar > stoksayisi)
                    {
                        Msg.Show("Yetersiz stok miktarı! Kalan ürün sayısı: " + stoksayisi + " Almak istediğiniz ürün sayısı: " + Miktar + "");
                    }
                    else if (stoksayisi == 0)
                    {
                        Msg.Show("Malesef bu ürün tükendi. Stokta yok.");
                    }
                    else if (Miktar > MaxSparisMiktari)
                    {
                        Msg.Show("Bu üründen en fazla " + MaxSparisMiktari + " adet sipariş verebilirsiniz. ");
                    }
                    else if (Miktar < MinSparisMiktari)
                    {
                        Msg.Show("Bu ürünü alabilmeniz için en az " + MinSparisMiktari + " adet sipariş vermelisiniz. ");
                    }

                    else
                    {

                        SqlConnection baglan = veri.baglan();
                        SqlCommand cmd = new SqlCommand();
                        cmd.Connection = baglan;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "sp_SepeteEkle";
                        cmd.Parameters.AddWithValue("@UrunId", e.CommandArgument);
                        cmd.Parameters.AddWithValue("@UyeId", UyeId);
                        cmd.Parameters.AddWithValue("@UyeIp", ipadres);
                        cmd.Parameters.AddWithValue("@SiparisId", 0);
                        cmd.Parameters.AddWithValue("@Miktar", Miktar);

                        try
                        {
                            cmd.ExecuteNonQuery();
                            // Eticaret.Msg.Mesaj(this, eStatusType.Bilgi, "<br/>Siparişiniz sepete eklendi.");
                            Response.Redirect(Session["RowUrl"].ToString());

                        }
                        catch (Exception)
                        {

                        }

                    }
                }
                catch (Exception)
                {

                }
            }


        }


    }
}