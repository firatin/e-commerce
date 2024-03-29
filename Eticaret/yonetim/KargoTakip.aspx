<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="KargoTakip.aspx.cs" Inherits="Eticaret.yonetim.KargoTakip" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 126px;
        }
        .auto-style3 {
            width: 20px;
        }
        .auto-style4 {
            width: 126px;
            height: 30px;
        }
        .auto-style5 {
            width: 20px;
            height: 30px;
        }
        .auto-style6 {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">Sipariş No</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:Label ID="lblSiparisno" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Kargo Adı</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:Label ID="lblKargoAdi" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Kargo Takip No</td>
            <td class="auto-style3">:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTakipNo" ErrorMessage="*" ForeColor="Red" ValidationGroup="grbGonder"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtTakipNo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Mail&#39;de Gitsin mi?</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:CheckBox ID="cbMail" runat="server" Text="Evet" />
            </td>
        </tr>
        <tr>
            <td class="auto-style4"></td>
            <td class="auto-style5"></td>
            <td class="auto-style6">
                <asp:Button ID="btnGonder" runat="server" CssClass="btn" Text="Gönder" OnClick="btnGonder_Click" ValidationGroup="grbGonder" />
            </td>
        </tr>
        
    </table>
</asp:Content>
