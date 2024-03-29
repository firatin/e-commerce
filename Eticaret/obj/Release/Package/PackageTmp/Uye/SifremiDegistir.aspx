<%@ Page Title="" Language="C#" MasterPageFile="~/Uye/UyeMaster.master" AutoEventWireup="true" CodeBehind="SifremiDegistir.aspx.cs" Inherits="Eticaret.Uye.SifremiDegistir1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntUye" runat="server">
                <asp:Label ID="lblBilgi" runat="server" Text="" Font-Bold="True" Font-Overline="False" Font-Size="XX-Large" ForeColor="#F15A23"></asp:Label>

    <table style="width: 100%">
        <tr>
            <td style="width: 94px">Eski Şifreniz</td>
            <td style="width: 21px">:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEski" ErrorMessage="*" ForeColor="Red" ValidationGroup="SifreDegis"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtEski" runat="server" CssClass="text" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 94px">Yeni Şifreniz</td>
            <td style="width: 21px">:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtYeni" ErrorMessage="*" ForeColor="Red" ValidationGroup="SifreDegis"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtYeni" runat="server" CssClass="text" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 94px; height: 23px;">Yeni Şifre Tekrar</td>
            <td style="width: 21px; height: 23px;">:<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtYeniTekrar" ErrorMessage="*" ForeColor="Red" ValidationGroup="SifreDegis"></asp:RequiredFieldValidator>
            </td>
            <td style="height: 23px">
                <asp:TextBox ID="txtYeniTekrar" runat="server" CssClass="text" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtYeni" ControlToValidate="txtYeniTekrar" ErrorMessage="Şifreler Uyuşmuyor!" ForeColor="Red" ValidationGroup="SifreDegis"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 94px">&nbsp;</td>
            <td style="width: 21px">&nbsp;</td>
            <td>
                <asp:Button ID="btnDegistir" runat="server" CssClass="button" OnClick="btnDegistir_Click" Text="Şifremi Değiştir" ValidationGroup="SifreDegis" Width="158px" />
            </td>
        </tr>
        <tr>
            <td style="width: 94px; height: 16px;"></td>
            <td style="width: 21px; height: 16px;"></td>
            <td style="height: 16px"></td>
        </tr>
        <tr>
            <td style="width: 94px">&nbsp;</td>
            <td style="width: 21px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
