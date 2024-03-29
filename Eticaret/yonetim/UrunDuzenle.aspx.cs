using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using CKFinder;
using System.IO;
using System.Drawing;

namespace Eticaret.yonetim
{
    public partial class UrunDuzenle : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        string UrunId, islem, islem2, KategoriId, ResimId;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Ürün Düzenle";
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Ürün Düzenle";

            KategoriGetir();
            MarkaGetir();
            VaryantGetir();


            try
            {
                islem = Request.QueryString["islem"];
                UrunId = Kontrol.SayiKontrol(Request.QueryString["UrunId"]);
                islem2 = Request.QueryString["v"];
                ResimId = Kontrol.SayiKontrol(Request.QueryString["Resim"]);

            }
            catch (Exception)
            {
                Response.Redirect("Urunler.aspx");
            }

            if (UrunId == null)
            {
                Response.Redirect("Urunler.aspx");
            }
            else
            {
                VaryantDoldur();// metodda urunıd kullandığımdan urunId aldıktan sonra çağırdım

                // resim işlemleri
                ResimGetir();
                //resim sil
                if (islem2 == "sil")
                {
                    try
                    {

                        string AnaResim = veri.GetDataCell("Select AnaResim800 From Urunler Where UrunId=" + UrunId + "");

                        string resimadi800 = veri.GetDataCell("Select ResimYolu800 From Resimler Where ResimId=" + ResimId);
                        string resimadi150 = veri.GetDataCell("Select ResimYolu150 From Resimler Where ResimId=" + ResimId);
                        if (resimadi800 != "" || resimadi150 != "")
                        {

                            FileInfo fi800sil = new FileInfo(Server.MapPath("../Resimler/Urun/800/") + resimadi800);
                            fi800sil.Delete();

                            FileInfo fi150sil = new FileInfo(Server.MapPath("../Resimler/Urun/150/") + resimadi150);
                            fi150sil.Delete();

                        }

                        // Anaresim getir ana resim silindiyse ana resim resim yok resmi ile güncelle
                        if (resimadi800 == AnaResim)
                        {

                            veri.cmd("Update Urunler Set AnaResim150='resimyok.jpg', AnaResim800='resimyok.jpg' where UrunId=" + UrunId + "");

                        }

                        veri.cmd("Delete From Resimler Where ResimId=" + ResimId);

                        Response.Redirect("UrunDuzenle.aspx?UrunId=" + UrunId + "&islem=duzenle&v=resim");
                    }

                    catch (Exception)
                    {
                    }
                }
                else if (islem2 == "AnaResim")
                {
                    try
                    {
                        string resimvarmi = veri.GetDataCell("Select ResimId from Resimler Where ResimId=" + ResimId + "");
                        if (resimvarmi != null)
                        {
                            string AnaResim150 = veri.GetDataCell("Select ResimYolu150 From Resimler Where ResimId=" + ResimId + "");
                            string AnaResim800 = veri.GetDataCell("Select ResimYolu800 From Resimler Where ResimId=" + ResimId + "");
                            if (AnaResim150 != "" && AnaResim800 != "")
                            {
                                veri.cmd("Update Urunler Set AnaResim150='" + AnaResim150 + "' Where UrunId=" + UrunId + "");
                                veri.cmd("Update Urunler Set AnaResim800='" + AnaResim800 + "' Where UrunId=" + UrunId + "");
                                Msg.Show("Ürünün Ana Resmi Değiştirildi");
                                Response.Redirect("UrunDuzenle.aspx?UrunId=" + UrunId + "&islem=duzenle&v=resim");
                            }
                        }

                    }
                    catch (Exception)
                    {

                    }
                }
                else if (islem2 == "var")
                {
                    TabContainer1.ActiveTab = TabPanel6;
                }
                // sil bitiş

                // resim işlemleri son
                if (Page.IsPostBack == false)
                {
                    FileBrowser f1 = new FileBrowser();
                    f1.BasePath = "../ckfinder/";
                    f1.SetupCKEditor(CKEditorControl1);

                    DataRow DrUrun = veri.GetDataRow("Select * From Urunler Where UrunId=" + UrunId + " and Sil=0");


                    if (DrUrun != null)
                    {

                        KategoriId = DrUrun["KategoriId"].ToString().Trim();

                        AltKategoriGetir();

                        txtStokKodu.Text = DrUrun["StokKodu"].ToString().Trim();
                        txtUrunAdi.Text = DrUrun["UrunAdi"].ToString().Trim();
                        ddKategori.SelectedValue = DrUrun["KategoriId"].ToString().Trim();
                        ddAltKategori.SelectedValue = DrUrun["AltKategoriId"].ToString().Trim(); ;
                        ddMarka.SelectedValue = DrUrun["MarkaId"].ToString().Trim();
                        txtMinSparis.Text = DrUrun["MinSparisMiktari"].ToString().Trim();
                        txtMaxSparis.Text = DrUrun["MaxSparisMiktari"].ToString().Trim();
                        txtSatisFiyati.Text = Convert.ToDouble(DrUrun["SatisFiyati"]).ToString().Trim();
                        txtSatisIndirim.Text = Convert.ToDouble(DrUrun["indirim"]).ToString().Trim();
                        txtMaliyetFiyati.Text = Convert.ToDouble(DrUrun["MaliyetFiyati"]).ToString().Trim();
                        txtPiyasaFiyati.Text = Convert.ToDouble(DrUrun["PiyasaFiyati"]).ToString().Trim();
                        txtBayiFiyati.Text = Convert.ToDouble(DrUrun["BayiFiyati"]).ToString().Trim();
                        txtBayiIndirim.Text = Convert.ToDouble(DrUrun["BayiIndirim"]).ToString().Trim();
                        txtToptanBayiFiyati.Text = Convert.ToDouble(DrUrun["ToptanBayiFiyati"]).ToString().Trim();
                        txtToptanBayiIndirim.Text = Convert.ToDouble(DrUrun["ToptanBayiIndirim"]).ToString().Trim();
                        CKEditorControl1.Text = DrUrun["Detay"].ToString().Trim();
                        txtUrunPuan.Text = DrUrun["UrunPuan"].ToString().Trim();
                        txtHavale.Text = Convert.ToDouble(DrUrun["HavaleIndirim"]).ToString().Trim();
                        txtTekCekim.Text = Convert.ToDouble(DrUrun["TekCekimIndirim"]).ToString().Trim();
                        ddStokDurumu.Text = DrUrun["StokDurumu"].ToString().Trim();
                        txtStokMiktar.Text = DrUrun["StokMiktari"].ToString().Trim();
                        lblVaryantStok.Text = txtStokMiktar.Text;
                        ddStokMiktari.Text = DrUrun["StokOlcutu"].ToString().Trim();
                        ddKdv.SelectedValue = DrUrun["Kdv"].ToString().Trim();

                        int miktargoster = 0;
                        if (DrUrun["MiktarGosterim"].ToString() == "True")
                        {
                            miktargoster = 1;
                        }
                        ddMiktarGosterim.SelectedValue = miktargoster.ToString();

                        if (DrUrun["AktifMi"].ToString() == "True")
                        {
                            cbAktif.Checked = true;
                        }
                        else
                        {
                            cbAktif.Checked = false;
                        }
                        if (DrUrun["YeniUrun"].ToString() == "True") cbYeniUrum.Checked = true;
                        if (DrUrun["HaftaninUrunu"].ToString() == "True") cbHaftaninUrunu.Checked = true;
                        if (DrUrun["OzelUrun"].ToString() == "True") cbOzelUrun.Checked = true;
                        if (DrUrun["FiyatiDusen"].ToString() == "True") cbFiyatDusen.Checked = true;
                        if (DrUrun["VitrinUrunu"].ToString() == "True") cbVitrin.Checked = true;


                        if (islem == "duzenle" && UrunId != null && islem2 == "resim")
                        {

                            TabContainer1.ActiveTabIndex = 4;

                        }

                    }
                    else
                    {
                        Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Böyle bir ürün yok'); window.location.href ='Urunler.aspx';</script>");
                    }
                }
            }
        }
        void KategoriGetir()
        {
            if (Page.IsPostBack == false)
            {
                try
                {
                    ddKategori.Items.Add("Seçiniz");
                    ddKategori.Items[0].Value = "0";
                    DataTable dtArac = veri.GetDataTable("Select * From Kategoriler Where Aktif=1 and Sil =0 ");

                    int sira = 1;
                    for (int i = 0; i < dtArac.Rows.Count; i++)
                    {
                        DataRow DrAracTipi = dtArac.Rows[i];
                        ddKategori.Items.Add(DrAracTipi["KategoriAdi"].ToString());
                        ddKategori.Items[sira].Value = DrAracTipi["KategoriId"].ToString();
                        sira++;
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        void MarkaGetir()
        {
            if (Page.IsPostBack == false)
            {
                try
                {
                    ddMarka.Items.Add("Seçiniz");
                    ddMarka.Items[0].Value = "0";
                    DataTable dtArac = veri.GetDataTable("Select * From Markalar Where Aktif=1 and Sil=0");

                    int sira = 1;
                    for (int i = 0; i < dtArac.Rows.Count; i++)
                    {
                        DataRow DrAracTipi = dtArac.Rows[i];
                        ddMarka.Items.Add(DrAracTipi["MarkaAdi"].ToString());
                        ddMarka.Items[sira].Value = DrAracTipi["MarkaId"].ToString();
                        sira++;
                    }
                }
                catch (Exception)
                {

                }
            }
        }
        // ürün düzenle AltKategori getir
        void AltKategoriGetir()
        {
            try
            {
                ddAltKategori.Items.Clear();
                ddAltKategori.Items.Add("Seçiniz");
                ddAltKategori.Items[0].Value = "0";
                DataTable dtKayit = veri.GetDataTable("Select * From AltKategoriler Where Aktif=1 and Sil =0  and KategoriId=" + KategoriId + " ");

                int sira = 1;
                for (int i = 0; i < dtKayit.Rows.Count; i++)
                {
                    DataRow DrKayitlar = dtKayit.Rows[i];
                    ddAltKategori.Items.Add(DrKayitlar["AltKategoriAdi"].ToString());
                    ddAltKategori.Items[sira].Value = DrKayitlar["AltKategoriId"].ToString();
                    sira++;
                }
            }
            catch (Exception)
            {

            }
        }
        protected void txtStokMiktar_TextChanged(object sender, EventArgs e)
        {
            txtMaxSparis.Text = txtStokMiktar.Text;

        }

        protected void ddStokMiktari_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMin.Text = ddStokMiktari.SelectedItem.Value;
            lblMax.Text = ddStokMiktari.SelectedItem.Value;
        }

        protected void ddKategori_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddAltKategori.Items.Clear();
                ddAltKategori.Items.Add("Seçiniz");
                ddAltKategori.Items[0].Value = "0";
                DataTable dtModel = veri.GetDataTable("Select * From AltKategoriler Where KategoriId =" + ddKategori.SelectedValue + " and Aktif=1 and Sil=0");


                int sira = 1;
                for (int i = 0; i < dtModel.Rows.Count; i++)
                {
                    DataRow DrModel = dtModel.Rows[i];
                    ddAltKategori.Items.Add(DrModel["AltKategoriAdi"].ToString());
                    ddAltKategori.Items[sira].Value = DrModel["AltKategoriId"].ToString();
                    sira++;
                }

            }
            catch (Exception)
            {

            }
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            int aktifmi = 0, YeniUrun = 0, HaftaninUrunu = 0, OzelUrun = 0, FiyatiDusen = 0, VitrinUrunu = 0;
            if (cbAktif.Checked) aktifmi = 1; if (cbYeniUrum.Checked) YeniUrun = 1;
            if (cbHaftaninUrunu.Checked) HaftaninUrunu = 1; if (cbOzelUrun.Checked) OzelUrun = 1;
            if (cbFiyatDusen.Checked) FiyatiDusen = 1; if (cbVitrin.Checked) VitrinUrunu = 1;

            SqlConnection baglanti = veri.baglan();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_UrunDuzenle";
            cmd.Parameters.AddWithValue("@StokKodu", txtStokKodu.Text.Trim());
            cmd.Parameters.AddWithValue("@UrunAdi", txtUrunAdi.Text.Trim());
            cmd.Parameters.AddWithValue("@KategoriId", ddKategori.SelectedValue);
            cmd.Parameters.AddWithValue("@AltKategoriId", ddAltKategori.SelectedValue);
            cmd.Parameters.AddWithValue("@MarkaId", ddMarka.SelectedValue);
            cmd.Parameters.AddWithValue("@MinSparisMiktari", txtMinSparis.Text.Trim());
            cmd.Parameters.AddWithValue("@MaxSparisMiktari", txtMaxSparis.Text.Trim());
            cmd.Parameters.AddWithValue("@SatisFiyati", txtSatisFiyati.Text.Trim());
            cmd.Parameters.AddWithValue("@indirim", txtSatisIndirim.Text);
            cmd.Parameters.AddWithValue("@MaliyetFiyati", txtMaliyetFiyati.Text.Trim());
            cmd.Parameters.AddWithValue("@PiyasaFiyati", txtPiyasaFiyati.Text.Trim());
            cmd.Parameters.AddWithValue("@BayiFiyati", txtBayiFiyati.Text.Trim());
            cmd.Parameters.AddWithValue("@BayiIndirim", txtBayiIndirim.Text.Trim());
            cmd.Parameters.AddWithValue("@ToptanBayiFiyati", txtToptanBayiFiyati.Text.Trim());
            cmd.Parameters.AddWithValue("@ToptanBayiIndirim", txtToptanBayiIndirim.Text.Trim());
            cmd.Parameters.AddWithValue("@Detay", CKEditorControl1.Text.Trim());
            cmd.Parameters.AddWithValue("@UrunPuan", txtUrunPuan.Text.Trim());
            cmd.Parameters.AddWithValue("@HavaleIndirim", txtHavale.Text.Trim());
            cmd.Parameters.AddWithValue("@TekCekimIndirim", txtTekCekim.Text.Trim());
            cmd.Parameters.AddWithValue("@StokDurumu", ddStokDurumu.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@StokMiktari", txtStokMiktar.Text.Trim());
            cmd.Parameters.AddWithValue("@StokOlcutu", ddStokMiktari.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@MiktarGosterim", ddMiktarGosterim.SelectedValue);
            //
            cmd.Parameters.AddWithValue("@AktifMi", aktifmi);
            cmd.Parameters.AddWithValue("@YeniUrun", YeniUrun);
            cmd.Parameters.AddWithValue("@HaftaninUrunu", HaftaninUrunu);
            cmd.Parameters.AddWithValue("@OzelUrun", OzelUrun);
            cmd.Parameters.AddWithValue("@FiyatiDusen", FiyatiDusen);
            cmd.Parameters.AddWithValue("@VitrinUrunu", VitrinUrunu);
            cmd.Parameters.AddWithValue("@Kdv", ddKdv.SelectedValue);
            cmd.Parameters.AddWithValue("@UrunId", UrunId);

            try
            {
                cmd.ExecuteNonQuery();
                Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Ürün Güncellendi'); window.location.href ='Urunler.aspx';</script>");


            }
            catch (Exception)
            {
                Msg.Show("Bir hata meydana geldi");
            }
        }

        protected void btnResimYukle_Click(object sender, EventArgs e)
        {
            if (UrunId == null)
            {
                Msg.Show("Lütfen Önce Ürünü Ekleyiniz.");
            }
            else
            {
                int resimsayisi = Convert.ToInt32(veri.GetDataCell("Select COUNT(ResimId) from Resimler Where UrunId=" + UrunId + ""));

                if (resimsayisi >= 6)
                {
                    Msg.Show("Bir Üründe En Fazla 6 Adet Resim Kullanabilirsiniz");
                }
                else
                {
                    string resimadi = "";
                    string uzanti = "";
                    string resimtip = "";
                    if (FuResim.HasFile)
                    {
                        resimtip = FuResim.PostedFile.ContentType;

                        if (resimtip == "image/jpeg" || resimtip == "image/jpg" || resimtip == "image/png" || resimtip == "image/bmp")
                        {

                            //rasgale sayı
                            Random numara = new Random();
                            Random numara2 = new Random();

                            int resimadisayi = numara.Next(1, 10000);
                            int resimSayi = numara2.Next(1, 7);
                            uzanti = Path.GetExtension(FuResim.PostedFile.FileName);
                            string[] resimDizi = { "r", "re", "res", "resi", "resim", "urunres", "urunrsm" };
                            resimadi = resimDizi[resimSayi] + resimadisayi + uzanti;

                            FuResim.SaveAs(Server.MapPath("../Resimler/Temp/" + resimadi));

                            // 800 boyuta düşür.
                            int donusturme = 800;

                            Bitmap bmp = new Bitmap(Server.MapPath("../Resimler/Temp/" + resimadi));
                            using (Bitmap OrjinalResim = bmp)
                            {
                                double ResYukseklik = OrjinalResim.Height;
                                double ResGenislik = OrjinalResim.Width;
                                double oran = 0;

                                if (ResGenislik >= donusturme)
                                {
                                    oran = ResGenislik / ResYukseklik;
                                    ResGenislik = donusturme;
                                    ResYukseklik = donusturme / oran;

                                    Size yenidegerler = new Size(Convert.ToInt32(ResGenislik), Convert.ToInt32(ResYukseklik));
                                    Bitmap yeniresim = new Bitmap(OrjinalResim, yenidegerler);
                                    yeniresim.Save(Server.MapPath("../Resimler/Urun/800/" + resimadi));

                                    yeniresim.Dispose();
                                    OrjinalResim.Dispose();

                                    bmp.Dispose();
                                }

                                else // eğer resmin boyutu zaten 800 den küçükse.
                                {
                                    FuResim.SaveAs(Server.MapPath("../Resimler/Urun/800/" + resimadi));
                                }
                            }
                            // 150 boyuta düşür.
                            donusturme = 150;

                            bmp = new Bitmap(Server.MapPath("../Resimler/Temp/" + resimadi));
                            using (Bitmap OrjinalResim = bmp)
                            {
                                double ResYukseklik = OrjinalResim.Height;
                                double ResGenislik = OrjinalResim.Width;
                                double oran = 0;

                                if (ResGenislik >= donusturme)
                                {
                                    oran = ResGenislik / ResYukseklik;
                                    ResGenislik = donusturme;
                                    ResYukseklik = donusturme / oran;

                                    Size yenidegerler = new Size(Convert.ToInt32(ResGenislik), Convert.ToInt32(ResYukseklik));
                                    Bitmap yeniresim = new Bitmap(OrjinalResim, yenidegerler);
                                    yeniresim.Save(Server.MapPath("../Resimler/Urun/150/" + resimadi));

                                    yeniresim.Dispose();
                                    OrjinalResim.Dispose();
                                    bmp.Dispose();
                                }

                                else // eğer resmin boyutu zaten 150 den küçükse.
                                {
                                    FuResim.SaveAs(Server.MapPath("../Resimler/Urun/150/" + resimadi));
                                }


                                try
                                {

                                    FileInfo fianaresimsil = new FileInfo(Server.MapPath("../Resimler/Temp/" + resimadi));
                                    fianaresimsil.Delete();
                                }
                                catch (Exception)
                                {


                                }

                            }


                            // resimleri çağır ve eklenen resimler sayısı 6 dan büyükse uyar
                            try
                            {
                                SqlConnection baglanti = veri.baglan();
                                SqlCommand cmd = new SqlCommand();
                                cmd.Connection = baglanti;
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "sp_ResimEkle";
                                cmd.Parameters.AddWithValue("@ResimYolu800", resimadi);
                                cmd.Parameters.AddWithValue("@ResimYolu150", resimadi);
                                cmd.Parameters.AddWithValue("@UrunId", UrunId);
                                cmd.ExecuteNonQuery();

                                //eğer ilk eklenen resimse onu ana resim yap

                                if (resimsayisi < 1)
                                {
                                    veri.cmd("Update Urunler Set AnaResim150='" + resimadi + "' Where UrunId=" + UrunId + "");
                                    veri.cmd("Update Urunler Set AnaResim800='" + resimadi + "' Where UrunId=" + UrunId + "");
                                }
                                Response.Redirect("UrunDuzenle.aspx?UrunId=" + UrunId + "&islem=duzenle&v=resim");
                            }
                            catch (Exception)
                            {

                                //Msg.Show(ex.Message);
                                Msg.Show("Bir Hata Meydana Geldi, Resim Eklenemedi");

                            }

                        }
                        else
                        {
                            Msg.Show("Sadece (Jpg,Png,Bmp) uzantılarını kullanabilirsiniz.");
                        }

                    }
                    else // resim seçilmediyse
                    {
                        Msg.Show("Lütfen Bir Resim Seçiniz");
                    }
                }
            }
        }
        void ResimGetir()
        {
            try
            {
                DataTable DtKayitlar = veri.GetDataTable("Select * From Resimler Where UrunId=" + UrunId + "");
                DlisResimler.DataSource = DtKayitlar;
                DlisResimler.DataBind();
            }
            catch (Exception)
            {

            }

        }

        void VaryantGetir()
        {
            if (Page.IsPostBack == false)
            {
                try
                {
                    ddVaryant.Items.Add("Seçiniz");
                    ddVaryant.Items[0].Value = "0";
                    DataTable dtveriler = veri.GetDataTable("Select * From AnaVaryant Where Aktif=1 and Sil=0 ");

                    int sira = 1;
                    for (int i = 0; i < dtveriler.Rows.Count; i++)
                    {
                        DataRow DrVeri = dtveriler.Rows[i];
                        ddVaryant.Items.Add(DrVeri["VaryantAdi"].ToString());
                        ddVaryant.Items[sira].Value = DrVeri["AnaVaryantId"].ToString();
                        sira++;
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        protected void ddVaryant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddVaryant.SelectedValue != "0")
            {
                try
                {
                    ddAltVaryant.Items.Clear();
                    ddAltVaryant.Items.Add("Seçiniz");
                    ddAltVaryant.Items[0].Value = "0";
                    DataTable dtKayit = veri.GetDataTable("Select * From AltVaryantlar Where Aktif=1 and Sil =0  and AnaVaryantId=" + ddVaryant.SelectedValue + " ");

                    int sira = 1;
                    for (int i = 0; i < dtKayit.Rows.Count; i++)
                    {
                        DataRow DrKayitlar = dtKayit.Rows[i];
                        ddAltVaryant.Items.Add(DrKayitlar["AltVaryantAdi"].ToString());
                        ddAltVaryant.Items[sira].Value = DrKayitlar["AltVaryantId"].ToString();
                        sira++;
                    }
                }
                catch (Exception)
                {

                }

            }
            else
            {
                ddAltVaryant.Items.Clear();
                ddAltVaryant.Items.Add("Ana Varyant Seçiniz");
                ddAltVaryant.Items[0].Value = "0";

            }
        }

        protected void btnVaryantEkle_Click(object sender, EventArgs e)
        {
            int toplamstoksayisi, stoksayisi;

            int eklenecekstok = Convert.ToInt32(txtStok.Text);

            string stoksayisigetir = veri.GetDataCell("Select StokMiktari From Urunler Where UrunId=" + UrunId + ""); // ürünün stoku

            string varyantvarmi = veri.GetDataCell("Select VaryantId From Varyantlar Where AnaVaryantId=" + ddVaryant.SelectedValue + " and AltVaryantId=" + ddAltVaryant.SelectedValue + " and UrunId=" + UrunId + "");

            string toplamstok = veri.GetDataCell("Select Sum(StokSayi) as 'Stok' From Varyantlar Where UrunId=" + UrunId + ""); // toplam stok sayisi

            // henüz ürün eklenmemişe hata vermemesi için
            if (stoksayisigetir == "" || stoksayisigetir == null)
            {
                stoksayisi = 0;
            }
            else
            {
                stoksayisi = Convert.ToInt32(stoksayisigetir);
            }
            if (toplamstok == "" || toplamstok == null)
            {
                toplamstoksayisi = 0;
            }
            else
            {
                toplamstoksayisi = Convert.ToInt32(toplamstok);
            }


            int toplam = toplamstoksayisi + eklenecekstok;


            if (varyantvarmi != null)
            {
                Msg.Show("Bu varyant seçeneğini daha önce eklediniz");
            }
            else if (toplam > stoksayisi)
            {
                Msg.Show("Hata: Stok Miktar Aşımı. Ürün stoğu: " + stoksayisi + " Şuan varyant için kullanılan " + toplamstoksayisi + " stok var. Ekleme işleminden sonra oluşacak stok: " + toplam + "");
            }

            else
            {
                SqlConnection baglanti = veri.baglan();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_Varyantlar";
                cmd.Parameters.AddWithValue("@AnaVaryantId", ddVaryant.SelectedValue);
                cmd.Parameters.AddWithValue("@AltVaryantId", ddAltVaryant.SelectedValue);
                cmd.Parameters.AddWithValue("@UrunId", UrunId);
                cmd.Parameters.AddWithValue("@StokSayi", txtStok.Text);

                try
                {
                    cmd.ExecuteNonQuery();
                    Response.Redirect("UrunDuzenle.aspx?UrunId=" + UrunId + "&islem=duzenle&v=var");

                }
                catch (Exception ex)
                {
                    Msg.Show("Bir Hata Oluştu: " + ex.Message);

                }

            }



        }

        void VaryantDoldur()// repeater için
        {

            try
            {
                if (!Page.IsPostBack)
                {
                    DataTable DtVeri = veri.GetDataTable("SELECT dbo.AltVaryantlar.AltVaryantAdi, dbo.AnaVaryant.VaryantAdi, dbo.Varyantlar.VaryantId, dbo.Varyantlar.UrunId, dbo.Varyantlar.StokSayi FROM dbo.AltVaryantlar INNER JOIN dbo.AnaVaryant ON dbo.AltVaryantlar.AnaVaryantId = dbo.AnaVaryant.AnaVaryantId INNER JOIN dbo.Varyantlar ON dbo.AltVaryantlar.AltVaryantId = dbo.Varyantlar.AltVaryantId WHERE  (dbo.Varyantlar.UrunId = " + UrunId + " )");
                    RpVaryant.DataSource = DtVeri;
                    RpVaryant.DataBind();
                }
            }
            catch (Exception ex)
            {

                Msg.Show(ex.Message);
            }
        }

        protected void RpVaryant_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "Sil")
            {
                try
                {
                    veri.cmd("Delete From Varyantlar Where VaryantId=" + e.CommandArgument + "");
                    Response.Redirect("UrunDuzenle.aspx?UrunId=" + UrunId + "&islem=duzenle&v=var");
                }
                catch (Exception ex)
                {
                    Msg.Show("Silme işleminde hata oluştu: Hata" + ex.Message);

                }


            }
            else if (e.CommandName == "Guncelle")
            {
                try
                {
                    TextBox txtAdet;
                    int Satir = (e.Item.ItemIndex);
                    txtAdet = (TextBox)RpVaryant.Items[Satir].FindControl("txtAdet");

                    int Miktar = Convert.ToInt32(txtAdet.Text);

                    int stoksayisigetir = Convert.ToInt32(veri.GetDataCell("Select StokMiktari From Urunler Where UrunId=" + UrunId + "")); // ürünün stoku

                    int toplamstok = Convert.ToInt32(veri.GetDataCell("Select Sum(StokSayi) as 'Stok' From Varyantlar Where UrunId=" + UrunId + "")); // toplam stok sayisi

                    // önce değişiklik yapılan kolondaki stok miktarını bul çıkar sonra yeni ekleneceği genel toplamın üzerine ekle, aksi halde yeni değiştirilecek olanıda toplamdan hesaplar.

                    int alanineskistoku = Convert.ToInt32(veri.GetDataCell("Select StokSayi From Varyantlar Where VaryantId=" + e.CommandArgument + ""));


                    int toplam = toplamstok - alanineskistoku;
                    toplam = toplam + Miktar;
                    if (toplam > stoksayisigetir)
                    {
                        Msg.Show("Hata: Stok Miktar Aşımı. Ürün stoğu: " + stoksayisigetir + " Şuan varyant için kullanılan " + toplamstok + " stok var. Ekleme işleminden sonra oluşacak stok: " + toplam + "");
                    }
                    else
                    {
                        veri.cmd("Update Varyantlar Set StokSayi = " + Miktar + " Where VaryantId=" + e.CommandArgument + "");

                        Response.Redirect("UrunDuzenle.aspx?UrunId=" + UrunId + "&islem=duzenle&v=var");
                    }



                }
                catch (Exception ex)
                {
                    Msg.Show("Bir hata oluştu.  Hata:" + ex.Message);
                }

            }


        }



    }
}