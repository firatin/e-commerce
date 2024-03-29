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
    public partial class _3dPos : System.Web.UI.Page
    {
        baglanti veri = new baglanti();
        string islem, PosId;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label lbl = (Label)Master.FindControl("lblBilgi");
            lbl.Text = "3D Ortak Ödeme Ayarları";

            try
            {
                PosId = Kontrol.SayiKontrol(Request.QueryString["Banka"]);
                islem = Request.QueryString["islem"];

            }
            catch (Exception)
            {
                Response.Redirect("3dPos.aspx");
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
                    DataRow DrPos = veri.GetDataRow("Select * From Pos3D Where PosId=" + PosId + "");

                    if (DrPos != null)
                    {

                        txtKull.Text = DrPos["Name"].ToString();
                        txtSifre.Text = DrPos["Sifre"].ToString();
                        txtisYeriNo.Text = DrPos["CliendId"].ToString();
                        txtPosAdresi.Text = DrPos["HostUrl"].ToString();
                        txtMid.Text = DrPos["Mid"].ToString();
                        txtProvUserId.Text = DrPos["ProvUserId"].ToString();
                        txtTidUserId.Text = DrPos["TidUserId"].ToString();
                        txtTid.Text = DrPos["Tid"].ToString();
                        txtStoreKey.Text = DrPos["StrKey"].ToString();
                        txtStorePw.Text = DrPos["StrPassword"].ToString();
                        if (DrPos["Aktif"].ToString() == "True")
                        {
                            cbAktif.Checked = true;
                        }
                    }

                }
            }
            //else if (islem == "Ekle")
            //{
            //    tbPosEkle.Visible = true;
            //    btnBanka.Visible = false;
            //    btnGeri.Visible = true;
            //}



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
            SqlCommand cmd = new SqlCommand("Update Pos3D Set HostUrl=@HostUrl,Name=@Name,Sifre=@Sifre,ProvUserId=@ProvUserId,TidUserId=@TidUserId,CliendId=@CliendId,Mid=@Mid,Tid=@Tid,StrKey=@StrKey,StrPassword=@StrPassword,Aktif=@Aktif where PosId=@PosId", baglanti);

            cmd.Parameters.AddWithValue("@HostUrl", txtPosAdresi.Text.Trim());
            cmd.Parameters.AddWithValue("@Name", txtKull.Text.Trim());
            cmd.Parameters.AddWithValue("@Sifre", txtSifre.Text.Trim());
            cmd.Parameters.AddWithValue("@ProvUserId", txtProvUserId.Text.Trim());
            cmd.Parameters.AddWithValue("@TidUserId", txtTidUserId.Text.Trim());
            cmd.Parameters.AddWithValue("@CliendId", txtisYeriNo.Text.Trim());
            cmd.Parameters.AddWithValue("@Mid", txtMid.Text.Trim());
            cmd.Parameters.AddWithValue("@Tid", txtTid.Text.Trim());
            cmd.Parameters.AddWithValue("@StrKey", txtStoreKey.Text.Trim());
            cmd.Parameters.AddWithValue("@StrPassword", txtStorePw.Text.Trim());
            cmd.Parameters.AddWithValue("@Aktif", aktif);
            cmd.Parameters.AddWithValue("@PosId", PosId);

            try
            {
                cmd.ExecuteNonQuery();
                Response.Redirect("3DPos.aspx");
            }
            catch (Exception ex)
            {
                Msg.Show("Bir hata meydana geldi. Lütfen etkrar deneyin.");
            }
        }

        protected void btnGeri_Click(object sender, EventArgs e)
        {
            Response.Redirect("3DPos.aspx");
        }

        void PosGetir()
        {
            try
            {
                if (Page.IsPostBack == false)
                {
                    DataTable dtPos = veri.GetDataTable("Select *,Case Aktif When 1 then 'Aktif' when 0 then 'Pasif' end as 'DurumAdi' From Pos3D");
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


    }
}