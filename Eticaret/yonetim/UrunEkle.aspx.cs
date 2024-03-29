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

    public partial class UrunEkle : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        Label lbl1;
        string UrunId, islem, ResimId;
        protected void Page_Load(object sender, EventArgs e)
        {

            Page.Title = "Ürün Ekle";
            lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Ürün Ekle";

            try
            {
                UrunId = Kontrol.SayiKontrol(Request.QueryString["Urun"]);
            }
            catch (Exception)
            {
                Response.Redirect("Urunler.aspx");
            }

            if (UrunId != null)
            {
                TabContainer1.ActiveTabIndex = 4;
                
                    ResimGetir();
                
                try
                {

                    islem = Request.QueryString["islem"];
                    ResimId = Kontrol.SayiKontrol(Request.QueryString["Resim"]);
                }
                catch (Exception)
                {
                    Response.Redirect("Urunler.aspx");
                }

                if (islem == "sil")
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

                        Response.Redirect("UrunEkle.aspx?Urun=" + UrunId + "");
                    }


                    catch (Exception)
                    {
                    }
                }
                else if (islem == "AnaResim")
                {
                    try
                    {
                        string resimvarmi = veri.GetDataCell("Select ResimId from Resimler Where ResimId="+ResimId+"");
                        if (resimvarmi != null)
                        {
                            string AnaResim150 = veri.GetDataCell("Select ResimYolu150 From Resimler Where ResimId=" + ResimId + "");
                            string AnaResim800 = veri.GetDataCell("Select ResimYolu800 From Resimler Where ResimId=" + ResimId + "");
                            if (AnaResim150 != "" && AnaResim800 != "")
                            {
                                veri.cmd("Update Urunler Set AnaResim150='" + AnaResim150 + "' Where UrunId=" + UrunId + "");
                                veri.cmd("Update Urunler Set AnaResim800='" + AnaResim800 + "' Where UrunId=" + UrunId + "");
                                Msg.Show("Ürünün Ana Resmi Değiştirildi");
                                Response.Redirect("UrunEkle.aspx?Urun="+UrunId+"");
                            }
                        }


                    }
                    catch (Exception)
                    {

                    }
                }

            }
            else
            {
                TabContainer1.ActiveTabIndex = 0;
            }
            KategoriGetir();
            MarkaGetir();

            // indirim seçenekleri
            if (Page.IsPostBack == false)
            {
                FileBrowser f1 = new FileBrowser();
                f1.BasePath = "../ckfinder/";
                f1.SetupCKEditor(CKEditorControl1);

                try
                {

                    DataRow drindirim = veri.GetDataRow("Select * From indirimler");
                    if (drindirim != null)
                    {
                        txtHavale.Text = Convert.ToDouble(drindirim["HavaleIndirim"]).ToString();

                        txtTekCekim.Text = Convert.ToDouble(drindirim["TekCekimIndirim"]).ToString();

                    }
                }
                catch (Exception)
                {

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

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            int aktifmi = 0, YeniUrun = 0, HaftaninUrunu = 0, OzelUrun = 0, FiyatiDusen = 0, VitrinUrunu = 0;
            if (cbAktif.Checked) aktifmi = 1; if (cbYeniUrum.Checked) YeniUrun = 1;
            if (cbHaftaninUrunu.Checked) HaftaninUrunu = 1; if (cbOzelUrun.Checked) OzelUrun = 1;
            if (cbFiyatDusen.Checked) FiyatiDusen = 1; if (cbVitrin.Checked) VitrinUrunu = 1;

            SqlConnection baglanti = veri.baglan();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_UrunEkle";
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
            cmd.Parameters.AddWithValue("@AnaResim800", "Resimyok.jpg");
            cmd.Parameters.AddWithValue("@AnaResim150", "Resimyok.jpg");
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

            try
            {
                cmd.ExecuteNonQuery();
                string sonurun = veri.GetDataCell("select top 1 UrunId From Urunler Order By UrunId Desc");

                Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Ürün Eklendi. Ürüne Resim Eklemek için Tıklayınız.'); window.location.href ='UrunEkle.aspx?Urun=" + sonurun + "';</script>");


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
                                Response.Redirect("UrunEkle.aspx?Urun=" + UrunId + "");
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

    }
}