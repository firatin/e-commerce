<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="indirim.aspx.cs" Inherits="Eticaret.yonetim.indirim" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 158px;
        }
        .auto-style3 {
            width: 21px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">Havale İndirimi (%)</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:TextBox ID="txtHavale" runat="server" Width="86px"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="txtHavale_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Custom, Numbers" ValidChars=".," TargetControlID="txtHavale">
                </asp:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Tek Çekim İndirimi (%)</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:TextBox ID="txtHTekCekim" runat="server" Width="84px"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="txtHTekCekim_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Custom, Numbers" ValidChars=".," TargetControlID="txtHTekCekim">
                </asp:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>
                <asp:Button ID="btnGuncelle" runat="server" CssClass="btn" OnClick="btnGuncelle_Click" Text="Güncelle" />
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
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
