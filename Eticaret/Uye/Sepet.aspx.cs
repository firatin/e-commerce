using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Eticaret.Uye
{
    public partial class Sepet1 : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        string UyeId, UyeTip, UrunId;
        DataTable dtSepet;
        TextBox txtadet;

        double indirimliFiyati, Miktar, Haveleindirimi, indirimtoplam, indirimliFiyatiToplami, GenelindirimToplam, KdvSizToplam, TekCekimindirimi;
        double SatisFiyati, Kdv, Toplam, SatisFiyatToplam;
        double UrunPuanlari;
        // tek çekim
        double TekCekimindirimtoplam, TekCekimKdvSizToplam, TekcekimindirimliFiyatiToplam, TekCekimGenelToplam;

        protected void Page_Load(object sender, EventArgs e)
        {

            Page.Title = "Sepetim";
            lblBilgi.Text = "Sepetim";

            Session.Remove("RowUrl"); // hemen al butonundan gelen session

            if (Session["UyeId"] == null)
            {
                Response.Redirect("/Uyelik/Giris.aspx");
            }
            else
            {

                UyeId = Session["UyeId"].ToString();
                if (Page.IsPostBack == false)
                {
                    SepetDoldur();

                }


            }
        }

        void SepetDoldur()
        {
            dtSepet = veri.GetDataTable("SELECT  dbo.Urunler.UrunAdi,dbo.Urunler.UrunPuan,dbo.Urunler.HavaleIndirim,dbo.Urunler.TekCekimIndirim,dbo.Urunler.Kdv, dbo.Urunler.AnaResim150, dbo.Urunler.MinSparisMiktari, dbo.Urunler.MaxSparisMiktari, dbo.Urunler.SatisFiyati,((SatisFiyati - indirim) * Kdv/100+SatisFiyati-indirim) * Miktar As UyeSatisFiyatiKdvli,((BayiFiyati - BayiIndirim) * Kdv/100+BayiFiyati-BayiIndirim)* Miktar as BayiSatisFiyatiKdvli , dbo.Urunler.indirim, SUM(dbo.Urunler.SatisFiyati * dbo.Sepet.Miktar) AS ToplamFiyat,SUM(dbo.Urunler.SatisFiyati*dbo.Sepet.Miktar-dbo.Urunler.indirim*dbo.Sepet.Miktar ) AS indirimliFiyat,SUM(dbo.Urunler.BayiFiyati*dbo.Sepet.Miktar-dbo.Urunler.BayiIndirim*dbo.Sepet.Miktar ) AS indirimliBayiFiyat,SUM(dbo.Urunler.BayiFiyati * dbo.Sepet.Miktar) AS ToplamBayiFiyati, dbo.Sepet.SepetId, dbo.Sepet.UrunId,dbo.Sepet.UyeId, dbo.Sepet.Tarih, dbo.Sepet.UyeIp, dbo.Sepet.SiparisId,  dbo.Sepet.Miktar FROM dbo.Sepet INNER JOIN dbo.Urunler ON dbo.Sepet.UrunId = dbo.Urunler.UrunId WHERE (dbo.Sepet.SiparisId = 0) AND (dbo.Sepet.UyeId = " + UyeId + ") GROUP BY dbo.Urunler.UrunAdi,dbo.Urunler.UrunPuan, dbo.Urunler.AnaResim150, dbo.Urunler.MinSparisMiktari, dbo.Urunler.MaxSparisMiktari,dbo.Urunler.Kdv, dbo.Urunler.SatisFiyati, dbo.Urunler.indirim,  dbo.Sepet.SepetId, dbo.Sepet.UrunId, dbo.Sepet.UyeId, dbo.Sepet.Tarih, dbo.Sepet.UyeIp, dbo.Sepet.SiparisId, dbo.Sepet.Miktar,dbo.Urunler.HavaleIndirim,dbo.Urunler.TekCekimIndirim,dbo.Urunler.Kdv,dbo.Urunler.indirim,dbo.Urunler.BayiFiyati,BayiIndirim");
            UyeTip = veri.GetDataCell("Select UyeTip From Uyeler Where UyeId=" + UyeId + "");
            if (dtSepet.Rows.Count > 0 && UyeTip == "0") //normal üye
            {
                RpSepet.DataSource = dtSepet;
                RpSepet.DataBind();
                lblBilgi.Text = "Sepetim - Sepetinizde " + dtSepet.Rows.Count + " ürün var.";
                UyeHesabi();

            }
            else if (dtSepet.Rows.Count > 0 && UyeTip == "1") // bayi
            {
                RpSepet.DataSource = dtSepet;
                RpSepet.DataBind();
                lblBilgi.Text = "Sepetim - Sepetinizde " + dtSepet.Rows.Count + " ürün var.";
                BayiHesabi();

            }
            else
            {
                divSepet.Visible = false;
                lblBilgi.Text = "Sepetim - Sepetinizde ürün yok.";
                lblUrunYok.Text = "Sepetiniz boş, biraz alışverişe ne dersiniz ? " + "<a href=\"/Default.aspx\">Ürünlere göz atabilirsiniz</a>";
            }

        }

        void UyeHesabi()
        {

            foreach (DataRow drUrun in dtSepet.Rows)
            {
                // tek tek ürün kdvsini al hesapla tut
                SatisFiyati = Convert.ToDouble(drUrun["indirimliFiyat"]);
                Kdv = Convert.ToDouble(drUrun["Kdv"]);

                Toplam += SatisFiyati * Kdv / 100;
                SatisFiyatToplam += SatisFiyati;

                // üye havale ürün indirim
                Haveleindirimi = Convert.ToDouble(drUrun["HavaleIndirim"]);
                TekCekimindirimi = Convert.ToDouble(drUrun["TekCekimIndirim"]);
                indirimliFiyati = Convert.ToDouble(drUrun["indirim"]);

                Miktar = Convert.ToDouble(drUrun["Miktar"]);

                // üye havale indirimi
                Haveleindirimi = Miktar * Haveleindirimi;
                indirimtoplam = SatisFiyati * Haveleindirimi / 100;
                KdvSizToplam = SatisFiyati - indirimtoplam;
                indirimliFiyatiToplami = KdvSizToplam * Kdv / 100;
                GenelindirimToplam = GenelindirimToplam + KdvSizToplam + indirimliFiyatiToplami;

                // üye tek çekim ürün indirim

                TekCekimindirimi = Miktar * TekCekimindirimi;
                TekCekimindirimtoplam = SatisFiyati * TekCekimindirimi / 100;
                TekCekimKdvSizToplam = SatisFiyati - TekCekimindirimtoplam;
                TekcekimindirimliFiyatiToplam = TekCekimKdvSizToplam * Kdv / 100;
                TekCekimGenelToplam = TekCekimGenelToplam + TekCekimKdvSizToplam + TekcekimindirimliFiyatiToplam;

            }
            //ürünün kdvsi
            lblKdvOran.Text = Toplam.ToString("c");
            lblAraToplam.Text = SatisFiyatToplam.ToString("c");
            // kdv dahil genel toplam.
            Toplam = Toplam + SatisFiyatToplam;
            lblKdvDahil.Text = Toplam.ToString("c");


            //havale indirimi fiyatı
            if (GenelindirimToplam.ToString() != Toplam.ToString()) // double de çalışmadı tostringe çevirdim
            {
                lblHavale.Text = GenelindirimToplam.ToString("c") + " Kdv Dahil";

            }
            else
            {
                // havale indirimi varsa. ana kdv dahil fiyatla eşitse o halde havale indirimi yoktur.

                trHavaleindirim.Visible = false;
            }


            //Tek çekim indirimi fiyatı
            if (TekCekimGenelToplam.ToString() != Toplam.ToString())
            {

                lblTekCekim.Text = TekCekimGenelToplam.ToString("c") + " Kdv Dahil";
            }
            else
            {

                // tek .ekim indirimi varsa. ana kdv dahil fiyatla eşitse o halde tek çekim indirimi yoktur.
                lblTekCekim.Text = "";
                trTekCekimindirim.Visible = false;
            }
        }
        void BayiHesabi()
        {
            // eğer giriş yapan bayi ise

            foreach (DataRow drUrun in dtSepet.Rows)
            {

                SatisFiyati = Convert.ToDouble(drUrun["indirimliBayiFiyat"]);
                Kdv = Convert.ToDouble(drUrun["Kdv"]);

                Toplam += SatisFiyati * Kdv / 100;
                SatisFiyatToplam += SatisFiyati;

                // Bayi havale ürün indirim
                Haveleindirimi = Convert.ToDouble(drUrun["HavaleIndirim"]);
                TekCekimindirimi = Convert.ToDouble(drUrun["TekCekimIndirim"]);


                Miktar = Convert.ToDouble(drUrun["Miktar"]);

                // bayi havale indirimi
                Haveleindirimi = Miktar * Haveleindirimi;
                indirimtoplam = SatisFiyati * Haveleindirimi / 100;
                KdvSizToplam = SatisFiyati - indirimtoplam;
                indirimliFiyatiToplami = KdvSizToplam * Kdv / 100;
                GenelindirimToplam = GenelindirimToplam + KdvSizToplam + indirimliFiyatiToplami;


                // bayi tek çekim ürün indirim

                TekCekimindirimi = Miktar * TekCekimindirimi;
                TekCekimindirimtoplam = SatisFiyati * TekCekimindirimi / 100;
                TekCekimKdvSizToplam = SatisFiyati - TekCekimindirimtoplam;
                TekcekimindirimliFiyatiToplam = TekCekimKdvSizToplam * Kdv / 100;
                TekCekimGenelToplam = TekCekimGenelToplam + TekCekimKdvSizToplam + TekcekimindirimliFiyatiToplam;

            }
            //ürünün kdvsi
            lblKdvOran.Text = Toplam.ToString("c");
            lblAraToplam.Text = SatisFiyatToplam.ToString("c");
            // kdv dahil genel toplam.
            Toplam = Toplam + SatisFiyatToplam;

            lblKdvDahil.Text = Toplam.ToString("c");


            //Bayi havale indirimi fiyatı
            if (GenelindirimToplam.ToString() != Toplam.ToString())
            {
                lblHavale.Text = GenelindirimToplam.ToString("c") + " Kdv Dahil";
            }
            else
            {
                // havale indirimi varsa. ana kdv dahil fiyatla eşitse o halde havale indirimi yoktur.

                trHavaleindirim.Visible = false;
            }

            //Tek çekim indirimi fiyatı
            if (TekCekimGenelToplam.ToString() != Toplam.ToString())
            {

                lblTekCekim.Text = TekCekimGenelToplam.ToString("c") + " Kdv Dahil";
            }
            else
            {

                // tek .ekim indirimi varsa. ana kdv dahil fiyatla eşitse o halde tek çekim indirimi yoktur.
                lblTekCekim.Text = "";
                trTekCekimindirim.Visible = false;
            }
        }

        // ürün puanları - paunları getir hesapla ve ekranda yazdır
        // puanı devre dışı bıraktım sonra yapacam
        //void PuanHesapla()
        // {
        //     foreach (DataRow drUrun in dtSepet.Rows)
        //     {

        //         UrunPuanlari += Convert.ToDouble(drUrun["UrunPuan"]);


        //     }

        //     if (UrunPuanlari>0)
        //     {
        //         trUrunPuan.Visible = true;
        //         lblPuan.Text = UrunPuanlari.ToString() + " Puan";
        //     }
        // }

        protected void RpSepet_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "Guncelle")
            {
                int Satir = (e.Item.ItemIndex);
                txtadet = (TextBox)RpSepet.Items[Satir].FindControl("txtAdet");


                UrunId = veri.GetDataCell("Select UrunId From Sepet Where SepetId =" + e.CommandArgument + "");
                DataRow drUrun = veri.GetDataRow("Select StokMiktari,MaxSparisMiktari,MinSparisMiktari from Urunler Where UrunId=" + UrunId + "");


                int Miktar = Convert.ToInt32(txtadet.Text);
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

                    veri.cmd("Update Sepet Set Miktar = " + Miktar + " Where SepetId=" + e.CommandArgument + "");
                    Session.Remove("KdvDahil");
                    Response.Redirect("/Uye/Sepet.aspx");
                }



            }
            else if (e.CommandName == "Sil")
            {
                veri.cmd("Delete From Sepet Where SepetId=" + e.CommandArgument + "");
                Session.Remove("KdvDahil");
                Response.Redirect("/Uye/Sepet.aspx");
            }
        }

        protected void RpSepet_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (UyeTip == "0") // normal üye
            {


                e.Item.FindControl("divBayiFiyat").Visible = false;
            }
            else if (UyeTip == "1")// bayi
            {
                e.Item.FindControl("divUyeFiyat").Visible = false;
            }
        }

        protected void btnSatinAl_Click(object sender, EventArgs e)
        {
            string KdvTutari = Kontrol.ParaBirim(lblKdvOran.Text);
            string KdvSizFiyat = Kontrol.ParaBirim(lblAraToplam.Text);
            string KdvDahil = Kontrol.ParaBirim(lblKdvDahil.Text);
            string Havale = Kontrol.ParaBirim(lblHavale.Text);
            string TekCekim = Kontrol.ParaBirim(lblTekCekim.Text);

            Session["KdvTutari"] = KdvTutari;
            Session["KdvDahil"] = KdvDahil;
            Session["KdvSizFiyat"] = KdvSizFiyat;

            if (Havale != KdvDahil)
            {
                Session.Add("Havaleindirim", Havale); // havale indirimi varsa gönder
            }
            if (TekCekim != KdvDahil)
            {
                Session.Add("TekCekimindirim", TekCekim);// tek çekim indirimi varsa gönder
            }

            Response.Redirect("/Siparis.aspx");

        }



    }
}