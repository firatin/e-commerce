<%@ Page Title="" Language="C#" MasterPageFile="~/Ana.Master" AutoEventWireup="true" CodeBehind="Giris.aspx.cs" Inherits="Eticaret.Uyelik.Giris1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .auto-style2 {
            width: 313px;
        }
    .auto-style3 {
        width: 16px;
    }
    .auto-style4 {
        width: 313px;
        height: 20px;
    }
    .auto-style5 {
        width: 16px;
        height: 20px;
    }
    .auto-style6 {
        height: 20px;
            width: 413px;
        }
    .auto-style7 {
        width: 313px;
        height: 25px;
    }
    .auto-style8 {
        width: 16px;
        height: 25px;
    }
    .auto-style9 {
        height: 25px;
    }
    .auto-style10 {
        width: 313px;
        height: 38px;
    }
    .auto-style11 {
        width: 16px;
        height: 38px;
    }
    .auto-style12 {
        height: 38px;
            width: 413px;
        }
        .auto-style13 {
            height: 25px;
            width: 413px;
        }
        .auto-style14 {
            width: 413px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cntSlider" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cntİcerik" runat="server">
    <br />
<br />
    <table class="auto-style9" style="border: thin dotted #FF0000; width: 486px;">
    <tr>
        <td class="auto-style7">E-Posta Adresiniz</td>
        <td class="auto-style8">:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMail" ErrorMessage="E-Posta Adresinizi Giriniz" ForeColor="Red" ValidationGroup="Giris">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMail" ErrorMessage="E-Posta Formatnı Kontrol Ediniz." ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Giris">*</asp:RegularExpressionValidator>
        </td>
        <td class="auto-style13">
            <asp:TextBox ID="txtMail" runat="server" CssClass="text" ></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Şifreniz</td>
        <td class="auto-style3">:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSifre" ErrorMessage="Şifrenizi Giriniz" ForeColor="Red" ValidationGroup="Giris">*</asp:RequiredFieldValidator>
        </td>
        <td class="auto-style14">
            <asp:TextBox ID="txtSifre" runat="server" TextMode="Password" CssClass="text"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style10"></td>
        <td class="auto-style11"></td>
        <td class="auto-style12">
            <asp:Button ID="btnGiris" runat="server" CssClass="button" Text="Giriş Yap" OnClick="btnGiris_Click" ValidationGroup="Giris" Height="30px" Width="170px" />
        </td>
    </tr>
    <tr>
        <td class="auto-style4"></td>
        <td class="auto-style5"></td>
        <td class="auto-style6">
            <br />
            <asp:LinkButton ID="linkUyeOl" runat="server" CssClass="colr" PostBackUrl="~/Uyelik/UyeOl.aspx" Font-Size="Medium">Yeni Üyelik</asp:LinkButton>
            <br />
            <br />
            <asp:LinkButton ID="linkSifreUnuttum" runat="server" CssClass="colr" PostBackUrl="~/Uyelik/SifremiUnuttum.aspx" Font-Size="Medium">Şifremi Unuttum</asp:LinkButton>
            <br />
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">&nbsp;</td>
        <td class="auto-style14">
            <br />
            <asp:Label ID="lblBilgi" runat="server" Font-Size="Small" ForeColor="Red"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">&nbsp;</td>
        <td class="auto-style14">
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="Giris" />
        </td>
    </tr>
</table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cntAlt" runat="server">
</asp:Content>
