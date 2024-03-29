using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Eticaret.yonetim
{
    public partial class UrunResim : System.Web.UI.Page
    {
        baglanti veri = new baglanti();

        string islem = "", ResimId = "", UrunId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Ürün Resimleri";
            Label lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Ürün Resimleri";

            try
            {
                UrunId = Kontrol.SayiKontrol(Kontrol.UrlTemizle(Request.QueryString["UrunId"]));

            }
            catch (Exception)
            {
                Response.Redirect("Default.aspx");
            }

            if (UrunId == null || UrunId == "")
            {
                Response.Redirect("Default.aspx");
            }
            else
            {

                try
                {
                    ResimGetir();
                }
                catch (Exception ex)
                {

                    Msg.Show(ex.Message);
                }

                try
                {

                    islem = Request.QueryString["islem"];
                    ResimId = Kontrol.SayiKontrol(Request.QueryString["Resim"]);
                }
                catch (Exception)
                {
                    Response.Redirect("Default.aspx");
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

                        Response.Redirect("UrunResim.aspx?UrunId=" + UrunId + "");
                    }


                    catch (Exception)
                    {
                    }
                }
                else if (islem == "AnaResim")
                {
                    try
                    {

                        string AnaResim150 = veri.GetDataCell("Select ResimYolu150 From Resimler Where ResimId=" + ResimId + "");
                        string AnaResim800 = veri.GetDataCell("Select ResimYolu800 From Resimler Where ResimId=" + ResimId + "");
                        if (AnaResim150 != "" && AnaResim800 != "")
                        {
                            veri.cmd("Update Urunler Set AnaResim150='" + AnaResim150 + "' Where UrunId=" + UrunId + "");
                            veri.cmd("Update Urunler Set AnaResim800='" + AnaResim800 + "' Where UrunId=" + UrunId + "");
                            Msg.Show("Ürünün Ana Resmi Değiştirildi");
                        }


                    }
                    catch (Exception)
                    {

                    }
                }
            }

        }

        protected void btnResimYukle_Click(object sender, EventArgs e)
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

                            if (resimsayisi <1)
                            {
                                 veri.cmd("Update Urunler Set AnaResim150='" + resimadi + "' Where UrunId=" + UrunId + "");
                            veri.cmd("Update Urunler Set AnaResim800='" + resimadi + "' Where UrunId=" + UrunId + "");
                            }
                            Response.Redirect("UrunResim.aspx?UrunId=" + UrunId + "");
                        }
                        catch (Exception )
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