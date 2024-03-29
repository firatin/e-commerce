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
    public partial class Urunler : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        Label lbl1; string Urun, UyeId, UyeTip;
        DataTable dtUrunler;
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Ürünler";
            Page.Title = "Ürünler";

            try
            {
                if (Session["UyeId"] != null)
                {
                    UyeId = Session["UyeId"].ToString();
                }
                Urun = Kontrol.SayiKontrol(Request.QueryString["Urun"]);
            }
            catch (Exception)
            {
                Response.Redirect("Default.aspx");
            }
            try
            {
                if (Session["RowUrl"] != null)
                {
                    Eticaret.Msg.Mesaj(this, eStatusType.Bilgi, "<br/>Siparişiniz sepete eklendi.");
                    Session.Remove("RowUrl");

                }

                if (Page.IsPostBack == false)
                {
                    if (UyeId != null)
                    {
                        UyeTip = veri.GetDataCell("Select UyeTip From Uyeler Where UyeId=" + UyeId + "");
                    }

                    if (Urun == "1")
                    {
                        YeniUrunler();
                    }
                    else if (Urun == "2")
                    {
                        indirimdekiUrunler();
                    }
                    else if (Urun == "3")
                    {
                        HaftaninUrunleri();
                    }
                    else if (Urun == "4")
                    {
                        OzelUrunler();
                    }
                    else
                    {
                        Response.Redirect("Default.aspx");
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        void YeniUrunler()
        {
            lbl1.Text = "Yeni Ürünler";
            Page.Title = "Yeni Ürünler";
            if (UyeId == null || UyeTip == "0") // ziyaretçi veya normal üye ise 
            {
                dtUrunler = veri.GetDataTable("Select UrunId,UrunAdi,StokKodu,SatisFiyati,((SatisFiyati - indirim) * Kdv/100+SatisFiyati-indirim) as SatisFiyatiKdvli,AnaResim800,AnaResim150 From Urunler Where Sil=0 and AktifMi=1 and YeniUrun=1 Order By UrunId Desc");

            }

            else if (UyeTip == "1") // bayi ise
            {
                dtUrunler = veri.GetDataTable("Select UrunId,UrunAdi,StokKodu,BayiFiyati,((BayiFiyati - BayiIndirim) * Kdv/100+BayiFiyati-BayiIndirim) as SatisFiyatiKdvli,AnaResim800,AnaResim150 From Urunler Where Sil=0 and AktifMi=1 and YeniUrun=1 Order By UrunId Desc");

            }

            CollectionPager1.DataSource = dtUrunler.DefaultView;
            CollectionPager1.BindToControl = RpUrunler;
            RpUrunler.DataSource = CollectionPager1.DataSourcePaged;
            RpUrunler.DataBind();
        }

        void indirimdekiUrunler()
        {
            lbl1.Text = "İndirimdeki Ürünler";
            Page.Title = "İndirimdeki Ürünler";

            if (UyeId == null || UyeTip == "0") // ziyaretçi veya normal üye ise 
            {
                dtUrunler = veri.GetDataTable("Select UrunId,UrunAdi,StokKodu,SatisFiyati,((SatisFiyati - indirim) * Kdv/100+SatisFiyati-indirim) as SatisFiyatiKdvli,AnaResim800,AnaResim150 From Urunler Where Sil=0 and AktifMi=1 and FiyatiDusen=1 Order By UrunId Desc");

            }

            else if (UyeTip == "1") // bayi ise
            {
                dtUrunler = veri.GetDataTable("Select UrunId,UrunAdi,StokKodu,BayiFiyati,((BayiFiyati - BayiIndirim) * Kdv/100+BayiFiyati-BayiIndirim) as SatisFiyatiKdvli,AnaResim800,AnaResim150 From Urunler Where Sil=0 and AktifMi=1 and FiyatiDusen=1 Order By UrunId Desc");

            }

            CollectionPager1.DataSource = dtUrunler.DefaultView;
            CollectionPager1.BindToControl = RpUrunler;
            RpUrunler.DataSource = CollectionPager1.DataSourcePaged;
            RpUrunler.DataBind();


        }

        void HaftaninUrunleri()
        {
            lbl1.Text = "Haftanın Ürünleri";
            Page.Title = "Haftanın Ürünleri";



            if (UyeId == null || UyeTip == "0") // ziyaretçi veya normal üye ise 
            {
                dtUrunler = veri.GetDataTable("Select UrunId,UrunAdi,StokKodu,SatisFiyati,((SatisFiyati - indirim) * Kdv/100+SatisFiyati-indirim) as SatisFiyatiKdvli,AnaResim800,AnaResim150 From Urunler Where Sil=0 and AktifMi=1 and HaftaninUrunu=1 Order By UrunId Desc");

            }

            else if (UyeTip == "1") // bayi ise
            {
                dtUrunler = veri.GetDataTable("Select UrunId,UrunAdi,StokKodu,BayiFiyati,((BayiFiyati - BayiIndirim) * Kdv/100+BayiFiyati-BayiIndirim) as SatisFiyatiKdvli,AnaResim800,AnaResim150 From Urunler Where Sil=0 and AktifMi=1 and HaftaninUrunu=1 Order By UrunId Desc");

            }

            CollectionPager1.DataSource = dtUrunler.DefaultView;
            CollectionPager1.BindToControl = RpUrunler;
            RpUrunler.DataSource = CollectionPager1.DataSourcePaged;
            RpUrunler.DataBind();


        }

        void OzelUrunler()
        {

            lbl1.Text = "Özel Ürünler";
            Page.Title = "Özel Ürünler";

            if (UyeId == null || UyeTip == "0") // ziyaretçi veya normal üye ise 
            {
                dtUrunler = veri.GetDataTable("Select UrunId,UrunAdi,StokKodu,SatisFiyati,((SatisFiyati - indirim) * Kdv/100+SatisFiyati-indirim) as SatisFiyatiKdvli,AnaResim800,AnaResim150 From Urunler Where Sil=0 and AktifMi=1 and OzelUrun=1 Order By UrunId Desc");

            }

            else if (UyeTip == "1") // bayi ise
            {
                dtUrunler = veri.GetDataTable("Select UrunId,UrunAdi,StokKodu,BayiFiyati,((BayiFiyati - BayiIndirim) * Kdv/100+BayiFiyati-BayiIndirim) as SatisFiyatiKdvli,AnaResim800,AnaResim150 From Urunler Where Sil=0 and AktifMi=1 and OzelUrun=1 Order By UrunId Desc");

            }

            CollectionPager1.DataSource = dtUrunler.DefaultView;
            CollectionPager1.BindToControl = RpUrunler;
            RpUrunler.DataSource = CollectionPager1.DataSourcePaged;
            RpUrunler.DataBind();

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
                            //  Eticaret.Msg.Mesaj(this, eStatusType.Bilgi, "<br/>Siparişiniz sepete eklendi.");
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