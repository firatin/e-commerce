<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="Firma.aspx.cs" Inherits="Eticaret.yonetim.Firma" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 22px;
        }
        .auto-style4 {
            width: 115px;
        }
        .auto-style5 {
            width: 115px;
            height: 22px;
        }
        .auto-style6 {
            width: 22px;
            height: 22px;
        }
        .auto-style7 {
            height: 22px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style4">Firma Adı</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:TextBox ID="txtFirmaAdi" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="auto-style4">Yetkili Kişi</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:TextBox ID="txtYetkili" runat="server" MaxLength="50"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Mail Adresi</td>
            <td class="auto-style3">:<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMail" ErrorMessage="Eposta uygun formatta değil" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="grb1">*</asp:RegularExpressionValidator>
            </td>
            <td>
                <asp:TextBox ID="txtMail" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="auto-style4">Mail Şifresi</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:TextBox ID="txtSifre" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="auto-style4">Mail Smtp</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:TextBox ID="txtSmtp" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="auto-style4">Smtp Portu</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:TextBox ID="txtPort" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">Telefon</td>
            <td class="auto-style6">:</td>
            <td class="auto-style7">
                <asp:TextBox ID="txtTel1" runat="server" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Gsm</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:TextBox ID="txtTel2" runat="server" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Faks</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:TextBox ID="txtFax" runat="server" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Firma Adresi</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:TextBox ID="txtAdres" runat="server" Height="50px" MaxLength="250" TextMode="MultiLine" Width="206px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Posta Kodu</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:TextBox ID="txtPostaKodu" runat="server" MaxLength="10"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">İl</td>
            <td class="auto-style6">:</td>
            <td class="auto-style7">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddil" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddil_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">İlçe</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddilce" runat="server" AutoPostBack="True">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Vergi Dairesi</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:TextBox ID="txtVergiDaire" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Vergi No</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:TextBox ID="txtVergiNo" runat="server" MaxLength="11"></asp:TextBox>
            </td>
        </tr>
       
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>
                <asp:Button ID="bnGuncelle" runat="server" CssClass="btn" Text="Bilgileri Güncelle" ValidationGroup="grb1" OnClick="bnGuncelle_Click" />
                <br />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="grb1" />
            </td>
        </tr>
    </table>
</asp:Content>
