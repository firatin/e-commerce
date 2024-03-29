using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Eticaret
{
    public partial class KategoriDetay : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        string AltKategoriId, UyeId, UyeTip;
        public static string AltKategoriAdi;
        DataTable DtAltKategoriUrunler;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            try
            {
                AltKategoriId = Kontrol.SayiKontrol(Kontrol.UrlSeo(RouteData.Values["AltKategoriId"].ToString()));
            }
            catch (Exception)
            {

                Response.Redirect("Default.aspx");

            }

            if (Session["RowUrl"] != null)
            {
                Eticaret.Msg.Mesaj(this, eStatusType.Bilgi, "<br/>Siparişiniz sepete eklendi.");
                Session.Remove("RowUrl");

            }

            AltKategoriId = Kontrol.SayiKontrol(Kontrol.Temizle(RouteData.Values["AltKategoriId"].ToString()));

            if (AltKategoriId != null)
            {
                // urldeki değerle oynandığı kontrolü eğer altkategori yoksa ana sayfaya gönder
                string KategoriVarmi = veri.GetDataCell("Select AltKategoriId from AltKategoriler where Sil=0 and Aktif=1 and AltKategoriId=" + AltKategoriId + "");
                if (KategoriVarmi != null)
                {
                    if (Page.IsPostBack == false)
                    {
                        if (Session["UyeId"] != null)
                        {
                            UyeId = Session["UyeId"].ToString();
                        }

                        if (UyeId != null)
                        {
                            UyeTip = veri.GetDataCell("Select UyeTip From Uyeler Where UyeId=" + UyeId + "");
                        }

                        if (UyeId == null || UyeTip == "0") // ziyaretçi veya normal üye ise 
                        {
                            DtAltKategoriUrunler = veri.GetDataTable("Select UrunId,UrunAdi,StokKodu,SatisFiyati,((SatisFiyati - indirim) * Kdv/100+SatisFiyati-indirim) as SatisFiyatiKdvli,AnaResim800,AnaResim150 From Urunler Where Sil=0 and AktifMi=1 and AltKategoriId=" + AltKategoriId + " Order By UrunId Desc");

                        }
                        else if (UyeTip == "1") // bayi ise
                        {
                            DtAltKategoriUrunler = veri.GetDataTable("Select UrunId,UrunAdi,StokKodu,BayiFiyati,((BayiFiyati - BayiIndirim) * Kdv/100+BayiFiyati-BayiIndirim) as SatisFiyatiKdvli,AnaResim800,AnaResim150 From Urunler Where Sil=0 and AktifMi=1 and AltKategoriId=" + AltKategoriId + " Order By UrunId Desc");

                        }

                        AltKategoriAdi = veri.GetDataCell("Select AltKategoriAdi from AltKategoriler Where AltKategoriId=" + AltKategoriId + "");

                        if (DtAltKategoriUrunler.Rows.Count >= 1)
                        {
                            RpUrunler.DataSource = DtAltKategoriUrunler;
                            RpUrunler.DataBind();

                            Page.Title = AltKategoriAdi;
                            Page.MetaDescription = AltKategoriAdi;
                            Page.MetaKeywords = AltKategoriAdi;

                            lbl1.Text = AltKategoriAdi + " kategorisine ait " + DtAltKategoriUrunler.Rows.Count + " ürün bulunuyor.";


                        }
                        else
                        {
                            lbl1.Text = AltKategoriAdi + " kategorisine ait ürün yok.";
                            Page.Title = AltKategoriAdi;
                        }
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
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