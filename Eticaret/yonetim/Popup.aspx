<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="Popup.aspx.cs" Inherits="Eticaret.yonetim.Popup" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 68px;
        }
        .auto-style3 {
            width: 28px;
        }
        .auto-style4 {
            width: 68px;
            height: 48px;
        }
        .auto-style5 {
            width: 28px;
            height: 48px;
        }
        .auto-style6 {
            height: 48px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style4">Aktif</td>
            <td class="auto-style5">:</td>
            <td class="auto-style6">
                <asp:CheckBox ID="cBoxAktif" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Başlık</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:TextBox ID="txtBaslik" runat="server" Width="434px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Mesaj</td>
            <td class="auto-style3">:</td>
            <td>
                <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server">
                </CKEditor:CKEditorControl>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>
                <asp:Button ID="btnKaydet" runat="server" CssClass="btn" OnClick="btnKaydet_Click" Text="Kaydet" />
            </td>
        </tr>
    </table>
</asp:Content>
