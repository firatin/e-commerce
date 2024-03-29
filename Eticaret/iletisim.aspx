<%@ Page Title="" Language="C#" MasterPageFile="~/Ana.Master" AutoEventWireup="true" CodeBehind="iletisim.aspx.cs" Inherits="Eticaret.iletisim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .auto-style1 {
            width: 127%;
            height: 260px;
        }

        .auto-style80 {
            width: 161px;
        }

        .auto-style82 {
            width: 161px;
            font-weight: bold;
        }

        .auto-style83 {
            height: 21px;
        }

        .auto-style84 {
            width: 161px;
            font-weight: bold;
            height: 21px;
        }
        .auto-style85 {
            height: 59px;
        }
        .auto-style86 {
            width: 161px;
            font-weight: bold;
            height: 59px;
          
        }
        .auto-style87 {
            height: 42px;
        }
        .auto-style88 {
            width: 161px;
            height: 42px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cntSlider" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cntİcerik" runat="server">
     <table class="auto-style1">

        <tr>
            <td class="auto-style83"></td>
            <td class="auto-style84">Firma</td>
            <td class="auto-style83">:</td>
            <td class="auto-style83">
                <asp:Label ID="lblFirma" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style83"></td>
            <td class="auto-style84">E-Posta</td>
            <td class="auto-style83">:</td>
            <td class="auto-style83">
                <asp:Label ID="lblMail" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style83"></td>
            <td class="auto-style84">Telefon</td>
            <td class="auto-style83">:</td>
            <td class="auto-style83">
                <asp:Label ID="lblTel" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style83"></td>
            <td class="auto-style84">Gsm</td>
            <td class="auto-style83">:</td>
            <td class="auto-style83">
                <asp:Label ID="lblGsm" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style83"></td>
            <td class="auto-style84">Fax</td>
            <td class="auto-style83">:</td>
            <td class="auto-style83">
                <asp:Label ID="lblFax" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style83"></td>
            <td class="auto-style84">Adres</td>
            <td class="auto-style83">:</td>
            <td class="auto-style83">
                <asp:Label ID="lblAdres" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style85"></td>
            <td  class="auto-style86">Bize Yazın</td>
            <td class="auto-style85"></td>
            <td class="auto-style85"></td>
        </tr>
        <tr>
            <td class="auto-style35"></td>
            <td class="auto-style82">Adınız Soyadınız</td>
            <td class="auto-style37">:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAdSoyad" ErrorMessage="Adınızı ve Soyadınızı yazınız" ForeColor="Red" ValidationGroup="grbMail">*</asp:RequiredFieldValidator>
            </td>
            <td class="auto-style38">
                <asp:TextBox ID="txtAdSoyad" runat="server" CssClass="text"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style45">&nbsp;</td>
            <td class="auto-style82">E-Posta Adresiniz</td>
            <td class="auto-style43">:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMail" ErrorMessage="E-posta adresinizi yazınzı" ForeColor="Red" ValidationGroup="grbMail">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMail" ErrorMessage="Mail adresinizi kontrol ediniz" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="grbMail">*</asp:RegularExpressionValidator>
            </td>
            <td class="auto-style44">
                <asp:TextBox ID="txtMail" runat="server" CssClass="text"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style69"></td>
            <td class="auto-style80" style="font-weight: bold">Telefon Numaranız</td>
            <td class="auto-style71">:<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTel" ErrorMessage="Telefon numaranızı yazınzı" ForeColor="Red" ValidationGroup="grbMail">*</asp:RequiredFieldValidator>
            </td>
            <td class="auto-style50">
                <asp:TextBox ID="txtTel" runat="server" CssClass="text"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="auto-style45">&nbsp;</td>
            <td class="auto-style82">Mesajınızın Konusu</td>
            <td class="auto-style43">:</td>
            <td class="auto-style44">
                <asp:TextBox ID="txtKonu" runat="server" CssClass="text"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style52">&nbsp;</td>
            <td class="auto-style80"><b>Mesajınız</b></td>
            <td class="auto-style16">:<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtMesaj" ErrorMessage="Mesajınızı yazınız" ForeColor="Red" ValidationGroup="grbMail">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtMesaj" runat="server" CssClass="text" Height="100px" TextMode="MultiLine" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style87"></td>
            <td class="auto-style88"></td>
            <td class="auto-style87"></td>
            <td class="auto-style87">
                <asp:Button ID="btnGonder" runat="server" CssClass="button" Text="Mesajı Gönder" OnClick="btnGonder_Click" ValidationGroup="grbMail" />
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="grbMail" />
            </td>
        </tr>
    </table><br /><br />
    
    <asp:Literal ID="ltrlHarita" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cntAlt" runat="server">

</asp:Content>
