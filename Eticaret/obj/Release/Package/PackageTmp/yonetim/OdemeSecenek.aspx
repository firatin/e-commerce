<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="OdemeSecenek.aspx.cs" Inherits="Eticaret.yonetim.OdemeSecenek" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 143px;
        }
        .auto-style3 {
            width: 14px;
        }
        .auto-style4 {
            width: 143px;
            height: 47px;
        }
        .auto-style5 {
            width: 14px;
            height: 47px;
        }
        .auto-style6 {
            height: 47px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style4">Kredi Kartı İle Ödeme</td>
            <td class="auto-style5">:</td>
            <td class="auto-style6">
                &nbsp;<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:CheckBox ID="cbKrediKart" runat="server" AutoPostBack="True" OnCheckedChanged="cbKrediKart_CheckedChanged" Text="Aktif" Width="30px" />
                        &nbsp;- Pos Seçiniz:
                        <asp:DropDownList ID="ddPos" runat="server" Enabled="False">
                            <asp:ListItem Value="0">Aktif Pos Seçiniz</asp:ListItem>
                            <asp:ListItem Value="1">Sanal Pos</asp:ListItem>
                            <asp:ListItem Value="2">İyzico Pos</asp:ListItem>
                            <asp:ListItem Value="3">İyzico Test</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;
                    </ContentTemplate>
                </asp:UpdatePanel>
               
            </td>
        </tr>
         <tr>
            <td class="auto-style2">3D Ortak Ödeme</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:CheckBox ID="cb3D" runat="server" Text="Aktif" Width="30px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Havale İle Ödeme</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:CheckBox ID="cbHavale" runat="server" Text="Aktif" Width="30px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Kapıda Ödeme</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:CheckBox ID="cbKapidaOdeme" runat="server" Text="Aktif" Width="30px" />
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
