<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="SayfaEkle.aspx.cs" Inherits="Eticaret.yonetim.SayfaEkle" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 18px;
        }
        .auto-style4 {
            width: 81px;
        }
        .auto-style5 {
            width: 81px;
            height: 56px;
        }
        .auto-style6 {
            width: 18px;
            height: 56px;
        }
        .auto-style7 {
            height: 56px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style5">Aktif</td>
            <td class="auto-style6">:</td>
            <td class="auto-style7">
                <asp:CheckBox ID="cbAktif" runat="server" Checked="True" />
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Sayfa Adı</td>
            <td class="auto-style3">:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSayfaAdi" ErrorMessage="*" ForeColor="Red" ValidationGroup="btnSayfa"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtSayfaAdi" runat="server" Width="340px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Detay</td>
            <td class="auto-style3">:</td>
            <td>
                <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server">
                </CKEditor:CKEditorControl>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>
                <asp:Button ID="btnEkle" runat="server" CssClass="btn" OnClick="btnEkle_Click" Text="Sayfayı Ekle" ValidationGroup="btnSayfa" />
                <asp:Button ID="btnGuncelle" runat="server" CssClass="btn" OnClick="btnGuncelle_Click" Text="Sayfayı Güncelle" ValidationGroup="btnSayfa" Visible="False" />
    <asp:Button ID="btnGeri" runat="server" Text="&lt;&lt; Geri" CssClass="btn" OnClick="btnGeri_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
