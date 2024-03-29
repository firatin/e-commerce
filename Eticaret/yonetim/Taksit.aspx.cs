using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
namespace Eticaret.yonetim
{
    public partial class Taksit : System.Web.UI.Page
    {
        Label lbl1;
        baglanti veri = new baglanti();
        string islem, TaksitId;
        int aktif;
       
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl1 = (Label)Master.FindControl("lblBilgi");
            lbl1.Text = "Banka Taksit Seçenekleri";

            try
            {
                TaksitId = Kontrol.SayiKontrol(Request.QueryString["Banka"]);
                islem = Request.QueryString["islem"];
            }
            catch (Exception)
            {
                Response.Redirect("Taksit.aspx");
            }

            if (islem == "detay" && TaksitId != null)
            {
                btnYeniBanka.Visible = false;
                divTaksitler.Visible = false;
                divTaksitKaydet.Visible = true;

                btnKaydet.Visible = false;
                btnDuzenle.Visible = true;
                if (TaksitId != null)
                {
                    DataRow drBanka = veri.GetDataRow("Select * From TaksitSecenekleri where TaksitId=" + TaksitId + "");

                    if (drBanka != null)
                    {
                        if (Page.IsPostBack == false)
                        {
                            try
                            {

                           
                            txtBankaAdi.Text = drBanka["BankaAdi"].ToString();
                            txtKartAdi.Text = drBanka["BankaAdi"].ToString();
                            if (drBanka["Aktif"].ToString() == "True")
                            {
                                cbAktif.Checked = true;
                            }

                          
                            imgResim.ImageUrl = "../Resimler/Banka/" + drBanka["BankaLogo"].ToString();

                            if (Convert.ToDouble(drBanka["Taksit2"]).ToString()=="9999") txt2.Text = "";
                            else txt2.Text = Convert.ToDouble(drBanka["Taksit2"]).ToString();

                            if (Convert.ToDouble(drBanka["Taksit3"]).ToString() == "9999") txt3.Text = "";
                            else txt3.Text = Convert.ToDouble(drBanka["Taksit3"]).ToString();

                            if (Convert.ToDouble(drBanka["Taksit4"]).ToString() == "9999") txt4.Text = "";
                            else txt4.Text = Convert.ToDouble(drBanka["Taksit4"]).ToString();

                            if (Convert.ToDouble(drBanka["Taksit5"]).ToString() == "9999") txt5.Text = "";
                            else txt5.Text = Convert.ToDouble(drBanka["Taksit5"]).ToString();

                            if (Convert.ToDouble(drBanka["Taksit6"]).ToString() == "9999") txt6.Text = "";
                            else txt6.Text = Convert.ToDouble(drBanka["Taksit6"]).ToString();

                            if (Convert.ToDouble(drBanka["Taksit7"]).ToString() == "9999") txt7.Text = "";
                            else txt7.Text = Convert.ToDouble(drBanka["Taksit7"]).ToString();

                            if (Convert.ToDouble(drBanka["Taksit8"]).ToString() == "9999") txt8.Text = "";
                            else txt8.Text = Convert.ToDouble(drBanka["Taksit8"]).ToString();

                            if (Convert.ToDouble(drBanka["Taksit9"]).ToString() == "9999") txt9.Text = "";
                            else txt9.Text = Convert.ToDouble(drBanka["Taksit9"]).ToString();

                            if (Convert.ToDouble(drBanka["Taksit10"]).ToString() == "9999") txt10.Text = "";
                            else txt10.Text = Convert.ToDouble(drBanka["Taksit10"]).ToString();

                            if (Convert.ToDouble(drBanka["Taksit11"]).ToString() == "9999") txt11.Text = "";
                            else txt11.Text = Convert.ToDouble(drBanka["Taksit11"]).ToString();

                            if (Convert.ToDouble(drBanka["Taksit12"]).ToString() == "9999") txt12.Text = "";
                            else txt12.Text = Convert.ToDouble(drBanka["Taksit12"]).ToString();
                          
                            }
                            catch (Exception)
                            {

                            }

                        }

                    }

                }

            }
            else if (islem == "yeni")
            {
                btnYeniBanka.Visible = false;
                divTaksitler.Visible = false;
                divTaksitKaydet.Visible = true;
            }
            else
            {
                TaksitGetir();
            }

        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            //// eğer textbox değeri boş girildiyse değeri 9999 yap.

            //if (txt2.Text == "") txt2.Text = "9999";
            //if (txt3.Text == "") txt3.Text = "9999";
            //if (txt4.Text == "") txt4.Text = "9999";
            //if (txt5.Text == "") txt5.Text = "9999";
            //if (txt6.Text == "") txt6.Text = "9999";
            //if (txt7.Text == "") txt7.Text = "9999";
            //if (txt8.Text == "") txt8.Text = "9999";
            //if (txt9.Text == "") txt9.Text = "9999";
            //if (txt10.Text == "") txt10.Text = "9999";
            //if (txt11.Text == "") txt11.Text = "9999";
            //if (txt12.Text == "") txt12.Text = "9999";

           
            //if (cbAktif.Checked)
            //{
            //    aktif = 1;
            //}
            //else
            //{
            //    aktif = 0;
            //}

            //string resimadi = "";
            //string uzanti = "";
            //string resimtip = "";
            //if (FuResim.HasFile)
            //{
            //    resimtip = FuResim.PostedFile.ContentType;

            //    if (resimtip == "image/jpeg" || resimtip == "image/jpg" || resimtip == "image/png" || resimtip == "image/bmp")
            //    {

            //        uzanti = Path.GetExtension(FuResim.PostedFile.FileName);
            //        Random Sayi = new Random();
            //        int sayitut = Sayi.Next(1, 10000);
            //        resimadi = "BankaRes" + sayitut + uzanti;

            //        FuResim.SaveAs(Server.MapPath("../Resimler/Banka/" + resimadi));

            //        SqlConnection baglanti = veri.baglan();
            //        SqlCommand cmd = new SqlCommand();
            //        cmd.Connection = baglanti;
            //        cmd.CommandType = CommandType.StoredProcedure;
            //        cmd.CommandText = "sp_TaksitGuncelle";

            //        cmd.Parameters.AddWithValue("@BankaAdi", txtBankaAdi.Text);
            //        cmd.Parameters.AddWithValue("@KartAdi", txtKartAdi.Text);
            //        cmd.Parameters.AddWithValue("@BankaLogo", resimadi);
            //        cmd.Parameters.AddWithValue("@Taksit2", txt2.Text);
            //        cmd.Parameters.AddWithValue("@Taksit3", txt3.Text);
            //        cmd.Parameters.AddWithValue("@Taksit4", txt4.Text);
            //        cmd.Parameters.AddWithValue("@Taksit5", txt5.Text);
            //        cmd.Parameters.AddWithValue("@Taksit6", txt6.Text);
            //        cmd.Parameters.AddWithValue("@Taksit7", txt7.Text);
            //        cmd.Parameters.AddWithValue("@Taksit8", txt8.Text);
            //        cmd.Parameters.AddWithValue("@Taksit9", txt9.Text);
            //        cmd.Parameters.AddWithValue("@Taksit10", txt10.Text);
            //        cmd.Parameters.AddWithValue("@Taksit11", txt11.Text);
            //        cmd.Parameters.AddWithValue("@Taksit12", txt12.Text);
            //        cmd.Parameters.AddWithValue("@Aktif", aktif);
            //        cmd.Parameters.AddWithValue("@TaksitId", TaksitId);

            //        try
            //        {

            //            cmd.ExecuteNonQuery();
            //            Response.Redirect("Taksit.aspx");
            //        }
            //        catch (Exception)
            //        {

            //        }


            //    }
            //    else
            //    {
            //        Msg.Show("Resmin uzantısı sadece, JPG,PNG ve BMP olmalıdır.");
            //    }

            //}
            //else
            //{
            //    Msg.Show("Resim Seçmediniz");
            //}
        }

        void TaksitGetir()
        {

            DataTable dtTaksit = veri.GetDataTable("Select TaksitId,BankaAdi,KartAdi,BankaLogo,Case Aktif  when 1 then 'Aktif' when 0 Then 'Pasif' end as Durumadi From TaksitSecenekleri");
            RpKayit.DataSource = dtTaksit;
            RpKayit.DataBind();
        }

        protected void btnYeniBanka_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Taksit.aspx?islem=yeni");
        }

        protected void btnVazgec_Click(object sender, EventArgs e)
        {
            Response.Redirect("Taksit.aspx");
        }

        protected void btnDuzenle_Click(object sender, EventArgs e)
        {
            // eğer textbox değeri boş girildiyse değeri 9999 yap.

            if (txt2.Text == "") txt2.Text = "9999";
            if (txt3.Text == "") txt3.Text = "9999";
            if (txt4.Text == "") txt4.Text = "9999";
            if (txt5.Text == "") txt5.Text = "9999";
            if (txt6.Text == "") txt6.Text = "9999";
            if (txt7.Text == "") txt7.Text = "9999";
            if (txt8.Text == "") txt8.Text = "9999";
            if (txt9.Text == "") txt9.Text = "9999";
            if (txt10.Text == "") txt10.Text = "9999";
            if (txt11.Text == "") txt11.Text = "9999";
            if (txt12.Text == "") txt12.Text = "9999";

          
            if (cbAktif.Checked)
            {
                aktif = 1;
            }
            else
            {
                aktif = 0;
            }

            string resimadi = "";
            string uzanti = "";
            string resimtip = "";
            if (FuResim.HasFile)
            {
                resimtip = FuResim.PostedFile.ContentType;

                if (resimtip == "image/jpeg" || resimtip == "image/jpg" || resimtip == "image/png" || resimtip == "image/bmp")
                {

                    uzanti = Path.GetExtension(FuResim.PostedFile.FileName);
                    Random Sayi = new Random();
                    int sayitut = Sayi.Next(1, 10000);
                    resimadi = "BankaRes" + sayitut + uzanti;

                    FuResim.SaveAs(Server.MapPath("../Resimler/Banka/" + resimadi));

                    // resim seçildiyse
                    SqlConnection baglanti = veri.baglan();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = baglanti;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_TaksitGuncelle";

                    cmd.Parameters.AddWithValue("@BankaAdi", txtBankaAdi.Text);
                    cmd.Parameters.AddWithValue("@KartAdi", txtKartAdi.Text);
                    cmd.Parameters.AddWithValue("@BankaLogo", resimadi);
                    cmd.Parameters.AddWithValue("@Taksit2", txt2.Text);
                    cmd.Parameters.AddWithValue("@Taksit3", txt3.Text);
                    cmd.Parameters.AddWithValue("@Taksit4", txt4.Text);
                    cmd.Parameters.AddWithValue("@Taksit5", txt5.Text);
                    cmd.Parameters.AddWithValue("@Taksit6", txt6.Text);
                    cmd.Parameters.AddWithValue("@Taksit7", txt7.Text);
                    cmd.Parameters.AddWithValue("@Taksit8", txt8.Text);
                    cmd.Parameters.AddWithValue("@Taksit9", txt9.Text);
                    cmd.Parameters.AddWithValue("@Taksit10", txt10.Text);
                    cmd.Parameters.AddWithValue("@Taksit11", txt11.Text);
                    cmd.Parameters.AddWithValue("@Taksit12", txt12.Text);
                    cmd.Parameters.AddWithValue("@Aktif", aktif);
                    cmd.Parameters.AddWithValue("@TaksitId", TaksitId);

                    try
                    {

                        cmd.ExecuteNonQuery();
                        Response.Redirect("Taksit.aspx");
                    }
                    catch (Exception)
                    {

                    }


                }
                else
                {
                    Msg.Show("Resmin uzantısı sadece, JPG,PNG ve BMP olmalıdır.");
                }

            }
            else
            {
               // Msg.Show("Resim Seçmediniz");
                //resim seçilmediyse

                resimadi = veri.GetDataCell("Select BankaLogo From TaksitSecenekleri Where TaksitId="+TaksitId+"");
                SqlConnection baglanti = veri.baglan();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = baglanti;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_TaksitGuncelle";

                cmd.Parameters.AddWithValue("@BankaAdi", txtBankaAdi.Text);
                cmd.Parameters.AddWithValue("@KartAdi", txtKartAdi.Text);
                cmd.Parameters.AddWithValue("@BankaLogo", resimadi);
                cmd.Parameters.AddWithValue("@Taksit2", txt2.Text);
                cmd.Parameters.AddWithValue("@Taksit3", txt3.Text);
                cmd.Parameters.AddWithValue("@Taksit4", txt4.Text);
                cmd.Parameters.AddWithValue("@Taksit5", txt5.Text);
                cmd.Parameters.AddWithValue("@Taksit6", txt6.Text);
                cmd.Parameters.AddWithValue("@Taksit7", txt7.Text);
                cmd.Parameters.AddWithValue("@Taksit8", txt8.Text);
                cmd.Parameters.AddWithValue("@Taksit9", txt9.Text);
                cmd.Parameters.AddWithValue("@Taksit10", txt10.Text);
                cmd.Parameters.AddWithValue("@Taksit11", txt11.Text);
                cmd.Parameters.AddWithValue("@Taksit12", txt12.Text);
                cmd.Parameters.AddWithValue("@Aktif", aktif);
                cmd.Parameters.AddWithValue("@TaksitId", TaksitId);

                try
                {

                    cmd.ExecuteNonQuery();
                    Response.Redirect("Taksit.aspx");
                }
                catch (Exception)
                {

                }

            }
        }

      
    }
}