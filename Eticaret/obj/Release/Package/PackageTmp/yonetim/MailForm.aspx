<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="MailForm.aspx.cs" Inherits="Eticaret.yonetim.MailForm" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 58px;
        }
        .auto-style4 {
            width: 205px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="auto-style1">
        <tr>
            <td class="auto-style4">Siparişten Sonra Gönderilecek Mail Formu</td>
            <td class="auto-style3">
                <asp:CheckBox ID="cbSiparis" runat="server" Text="Aktif" />
            </td>
            <td>
                <CKEditor:CKEditorControl ID="txtSiparisSonra" runat="server" Height="150px" Width="700px"></CKEditor:CKEditorControl>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Sipariş Teslim Olduktan Sonra Gönderilecek Mail Formu</td>
            <td class="auto-style3">
                <asp:CheckBox ID="cbSiparisTamam" runat="server" Text="Aktif" />
            </td>
            <td>
                <CKEditor:CKEditorControl ID="txtSiparisTamam" runat="server" Height="150px" Width="700px"></CKEditor:CKEditorControl>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Üye Olduktan Sonra Gidecek Mail Formu</td>
            <td class="auto-style3">
                <asp:CheckBox ID="cbUyeOl" runat="server" Text="Aktif" />
            </td>
            <td>
                <CKEditor:CKEditorControl ID="txtUyeOl" runat="server" Height="150px" Width="700px"></CKEditor:CKEditorControl>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>
                <asp:Button ID="btnKaydet" runat="server" CssClass="btn" OnClick="btnKaydet_Click" Text="Bilgileri Kaydet" />
            </td>
        </tr>
    </table>
</asp:Content>
