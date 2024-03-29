<%@ Page Title="" Language="C#" MasterPageFile="~/Ana.Master" AutoEventWireup="true" CodeBehind="OdemeBildirim.aspx.cs" Inherits="Eticaret.OdemeBildirim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style type="text/css">
        .auto-style1 {
            width: 127%;
            height: 260px;
        }

        .auto-style80 {
               width: 148px;
           }

        .auto-style82 {
               width: 148px;
               font-weight: bold;
           }

        .auto-style87 {
            height: 42px;
        }
        .auto-style88 {
            width: 148px;
            height: 42px;
        }
           .auto-style89 {
               width: 36px;
           }
           .auto-style90 {
               height: 42px;
               width: 36px;
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
            <td class="auto-style35"></td>
            <td class="auto-style82">Adınız Soyadınız</td>
            <td class="auto-style89">:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAdSoyad" ErrorMessage="Adınızı ve Soyadınızı yazınız" ForeColor="Red" ValidationGroup="grbMail">*</asp:RequiredFieldValidator>
            </td>
            <td class="auto-style38">
                <asp:TextBox ID="txtAdSoyad" runat="server" CssClass="text"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style45">&nbsp;</td>
            <td class="auto-style82">E-Posta Adresiniz</td>
            <td class="auto-style89">:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMail" ErrorMessage="E-posta adresinizi yazınzı" ForeColor="Red" ValidationGroup="grbMail">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMail" ErrorMessage="Mail adresinizi kontrol ediniz" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="grbMail">*</asp:RegularExpressionValidator>
            </td>
            <td class="auto-style44">
                <asp:TextBox ID="txtMail" runat="server" CssClass="text"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style69"></td>
            <td class="auto-style80" style="font-weight: bold">Telefon Numaranız</td>
            <td class="auto-style89">:<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTel" ErrorMessage="Telefon numaranızı yazınzı" ForeColor="Red" ValidationGroup="grbMail">*</asp:RequiredFieldValidator>
            </td>
            <td class="auto-style50">
                <asp:TextBox ID="txtTel" runat="server" CssClass="text"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="auto-style45">&nbsp;</td>
            <td class="auto-style82">Ödenen Tutar</td>
            <td class="auto-style89">:</td>
            <td class="auto-style44">
                <asp:TextBox ID="txtTutar" runat="server" CssClass="text"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style52">&nbsp;</td>
            <td class="auto-style80"><b>Ödemeyi Yatığınız Banka</b></td>
            <td class="auto-style89">:<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddBanka" ErrorMessage="Ödemeyi yaptığınız bankayı seçiniz" ForeColor="Red" ValidationGroup="grbMail" InitialValue="0">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:DropDownList ID="ddBanka" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style52">&nbsp;</td>
            <td class="auto-style80"><b>Ödemeyi Yapan</b></td>
            <td class="auto-style89">:</td>
            <td>
                <asp:TextBox ID="txtOdemeYapan" runat="server" CssClass="text"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="auto-style52">&nbsp;</td>
            <td class="auto-style80"><b>Açıklama</b></td>
            <td class="auto-style89">:</td>
            <td>
                <asp:TextBox ID="txtAciklama" runat="server" CssClass="text" Height="100px" TextMode="MultiLine" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style87"></td>
            <td class="auto-style88"></td>
            <td class="auto-style90"></td>
            <td class="auto-style87">
                <asp:Button ID="btnGonder" runat="server" CssClass="button" Text="Bildirimi Gönder" ValidationGroup="grbMail" OnClick="btnGonder_Click" />
                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="grbMail" />
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cntAlt" runat="server">
</asp:Content>
