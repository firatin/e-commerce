<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="Mail.aspx.cs" Inherits="Eticaret.yonetim.Mail" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 113px;
        }
        .auto-style3 {
            width: 17px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">Kullanıcı</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:DropDownList ID="ddMail" runat="server" Width="300px" AutoPostBack="True" OnSelectedIndexChanged="ddMail_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
                <asp:ListBox ID="lbMail" runat="server" Visible="False"></asp:ListBox>
                <asp:Button ID="btnSil" runat="server" CssClass="btn" OnClick="btnSil_Click" Text="Seçiliyi Sil" Visible="False" Width="100px" />
            </td>
        </tr>
  
        <tr>
            <td class="auto-style2">Başlık</td>
            <td class="auto-style3">:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtBaslik" ErrorMessage="Mesajınızın Başlığını Yazınız" ForeColor="Red" ValidationGroup="grbMail">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtBaslik" runat="server" Width="800px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Mesaj</td>
            <td class="auto-style3">:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="CKEditorControl1" ErrorMessage="Mesajınızı Yazınız" ForeColor="Red" ValidationGroup="grbMail">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" Width="815px">
                </CKEditor:CKEditorControl>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>
                <asp:Button ID="btnGonder" runat="server" CssClass="btn" OnClick="btnGonder_Click" Text="Mesajı Gönder" ValidationGroup="grbMail" />
&nbsp;<asp:Button ID="btnTemizle" runat="server" CssClass="btn" OnClick="btnTemizle_Click" Text="Temizle" />
            </td>
        </tr>
        
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="grbMail" />
            </td>
        </tr>
    </table>
</asp:Content>
