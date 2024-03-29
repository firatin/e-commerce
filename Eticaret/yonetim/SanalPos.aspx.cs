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
    public partial class SanalPos : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        string islem, PosId;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lbl = (Label)Master.FindControl("lblBilgi");
            lbl.Text = "Sanal Pos Ayarları";

            try
            {
                PosId = Kontrol.SayiKontrol(Request.QueryString["Banka"]);
                islem = Request.QueryString["islem"];

            }
            catch (Exception)
            {
                Response.Redirect("SanalPos.aspx");
            }

            PosGetir();
          //  BankaGetir();
            if (islem == "duzenle" && PosId != null)
            {
                tbPosEkle.Visible = true;
                btnEkle.Visible = false;
                btnDuzenle.Visible = true;
                btnGeri.Visible = true;

                if (Page.IsPostBack == false)
                {
                    DataRow DrPos = veri.GetDataRow("Select * From Pos Where PosId=" + PosId + "");

                    if (DrPos != null)
                    {
                        ddBanka.SelectedValue = DrPos["BankaId"].ToString().Trim();
                        txtKull.Text = DrPos["Name"].ToString().Trim();
                        txtSifre.Text = DrPos["Sifre"].ToString().Trim();
                        txtisYeriNo.Text = DrPos["CliendId"].ToString().Trim();
                        txtPosAdresi.Text = DrPos["HostUrl"].ToString().Trim();
                        txtPosNo.Text = DrPos["PosNo"].ToString().Trim();
                        txtXcip.Text = DrPos["Xcip"].ToString().Trim();
                        txtMid.Text = DrPos["Mid"].ToString().Trim();
                        txtTid.Text = DrPos["Tid"].ToString().Trim();


                        if (DrPos["Aktif"].ToString() == "True")
                        {
                            cbAktif.Checked = true;
                        }
                    }

                }
            }
            else if (islem == "Ekle")
            {
                tbPosEkle.Visible = true;
                btnBanka.Visible = false;
                btnGeri.Visible = true;
            }



        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            //string BankaId = ddBanka.SelectedValue;

            //int Varmi = Convert.ToInt32(veri.GetDataCell("Select PosId From Pos Where BankaId=" + BankaId + ""));
            //if (Varmi >= 1)
            //{
            //    Msg.Show("Daha önce bu bankayı eklediniz");
            //}
            //else
            //{

            //    int aktif = 0;
            //    if (cbAktif.Checked)
            //    {
            //        aktif = 1;
            //    }
            //    SqlConnection baglanti = veri.baglan();
            //    SqlCommand cmd = new SqlCommand();
            //    cmd.Connection = baglanti;
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.CommandText = "sp_PosEkle";
            //    cmd.Parameters.AddWithValue("@BankaId", ddBanka.SelectedValue);
            //    cmd.Parameters.AddWithValue("@HostUrl", txtPosAdresi.Text);
            //    cmd.Parameters.AddWithValue("@Name", txtKull.Text);
            //    cmd.Parameters.AddWithValue("@Sifre", txtSifre.Text);
            //    cmd.Parameters.AddWithValue("@CliendId", txtisYeriNo.Text);
            //    cmd.Parameters.AddWithValue("@PosNo", txtPosNo.Text);
            //    cmd.Parameters.AddWithValue("@Xcip", txtXcip.Text);
            //    cmd.Parameters.AddWithValue("@Aktif", aktif);
            //    cmd.Parameters.AddWithValue("@Mid", txtMid.Text);
            //    cmd.Parameters.AddWithValue("@Tid", txtTid.Text);

            //    try
            //    {
            //        cmd.ExecuteNonQuery();
            //        Response.Redirect("SanalPos.aspx");
            //    }
            //    catch (Exception)
            //    {
            //        Msg.Show("Bir hata meydana geldi. Lütfen etkrar deneyin.");
            //    }
            //}
        }

        protected void btnDuzenle_Click(object sender, EventArgs e)
        {
            int aktif = 0;
            if (cbAktif.Checked)
            {
                aktif = 1;
            }
            SqlConnection baglanti = veri.baglan();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = baglanti;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_PosDuzenle";
            cmd.Parameters.AddWithValue("@HostUrl", txtPosAdresi.Text);
            cmd.Parameters.AddWithValue("@Name", txtKull.Text);
            cmd.Parameters.AddWithValue("@Sifre", txtSifre.Text);
            cmd.Parameters.AddWithValue("@CliendId", txtisYeriNo.Text);
            cmd.Parameters.AddWithValue("@PosNo", txtPosNo.Text);
            cmd.Parameters.AddWithValue("@Xcip", txtXcip.Text);
            cmd.Parameters.AddWithValue("@Aktif", aktif);
            cmd.Parameters.AddWithValue("@Mid", txtMid.Text);
            cmd.Parameters.AddWithValue("@Tid", txtTid.Text);
            cmd.Parameters.AddWithValue("@PosId", PosId);

            try
            {
                cmd.ExecuteNonQuery();
                Response.Redirect("SanalPos.aspx");
            }
            catch (Exception  )
            {
                Msg.Show("Bir hata meydana geldi. Lütfen etkrar deneyin.");
            }
        }

        protected void btnGeri_Click(object sender, EventArgs e)
        {
            Response.Redirect("SanalPos.aspx");
        }

        void PosGetir()
        {
            try
            {
                if (Page.IsPostBack == false)
                {
                    DataTable dtPos = veri.GetDataTable("Select p.PosId,p.Aktif,t.BankaAdi, Case p.Aktif When 1 then 'Aktif' when 0 then 'Pasif' end as 'DurumAdi' from Pos  as p inner join TaksitSecenekleri as t on p.BankaId = t.TaksitId");
                    RpKayit.DataSource = dtPos;
                    RpKayit.DataBind();
                }

            }
            catch (Exception)
            {

            }
        }


        protected void btnBanka_Click1(object sender, EventArgs e)
        {
          //  Response.Redirect("SanalPos.aspx?islem=Ekle");
        }

        void BankaGetir()
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    ddBanka.Items.Add("Seçiniz");
                    ddBanka.Items[0].Value = "0";
                    DataTable DtVeriler = veri.GetDataTable("Select TaksitId,BankaAdi From TaksitSecenekleri  ");

                    int sira = 1;
                    for (int i = 0; i < DtVeriler.Rows.Count; i++)
                    {
                        DataRow DrKayit = DtVeriler.Rows[i];
                        ddBanka.Items.Add(DrKayit["BankaAdi"].ToString());
                        ddBanka.Items[sira].Value = DrKayit["TaksitId"].ToString();
                        sira++;
                    }
                }
                
            }
            catch (Exception)
            {

            }
        }
    }
}