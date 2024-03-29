<%@ Page Title="" Language="C#" MasterPageFile="~/Ana.Master" AutoEventWireup="true" CodeBehind="SifremiUnuttum.aspx.cs" Inherits="Eticaret.Uyelik.SifremiUnuttum1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 116px;
        }
        .auto-style3 {
            width: 14px;
        }
        .auto-style4 {
            width: 116px;
            height: 20px;
        }
        .auto-style5 {
            width: 14px;
            height: 20px;
        }
        .auto-style6 {
            height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cntSlider" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cntİcerik" runat="server">
    <table class="auto-style1" style="border: thin dotted #FF0000">
        <tr>
            <td class="auto-style2">E-Posta Adresiniz</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:TextBox ID="txtMail" runat="server" CssClass="text"></asp:TextBox>
&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMail" ErrorMessage="E-Posta Adresinizi Giriniz" ForeColor="Red" ValidationGroup="Sifre">*</asp:RequiredFieldValidator>
&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMail" ErrorMessage="E-Posta Adresinizi Kontrol Ediniz" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Sifre">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4"></td>
            <td class="auto-style5"></td>
            <td class="auto-style6">
                <asp:Button ID="btnGonder" runat="server" CssClass="button" OnClick="btnGonder_Click" Text="Gönder" ValidationGroup="Sifre" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Sifre" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cntAlt" runat="server">
</asp:Content>
