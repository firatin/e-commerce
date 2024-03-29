<%@ Page Title="" Language="C#" ValidateRequest="false" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="Seo.aspx.cs" Inherits="Eticaret.yonetim.Seo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 204px;
        }
        .auto-style3 {
            width: 17px;
        }
        .auto-style4 {
            width: 204px;
            height: 41px;
        }
        .auto-style5 {
            width: 17px;
            height: 41px;
        }
        .auto-style6 {
            height: 41px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">Site Başlığı (Title)</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:TextBox ID="txtTitle" runat="server" MaxLength="80" Width="295px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Site Açıklaması (Description)</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:TextBox ID="txtDesc" runat="server" Height="72px" MaxLength="500" TextMode="MultiLine" Width="295px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Anahtar Kelimeler (Keywords)</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:TextBox ID="txtKeyw" runat="server" Height="72px" MaxLength="200" TextMode="MultiLine" Width="295px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Google Site Doğrulama Kodu</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:TextBox ID="txtGdogrulama" runat="server"  Width="295px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Google Analytics Kodu</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:TextBox ID="txtGanalytics" runat="server" Height="72px" TextMode="MultiLine" Width="295px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Twitter Adresi</td>
            <td class="auto-style5">:</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtTwitter" runat="server"  Width="295px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Facebook Adresi</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:TextBox ID="txtFacebook" runat="server"  Width="295px"></asp:TextBox>
            </td>
        </tr>
          <tr>
            <td class="auto-style2">Google Harita</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:TextBox ID="txtHarita" runat="server"  Width="295px" Height="72px" TextMode="MultiLine" OnTextChanged="txtHarita_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>
                <asp:TextBox ID="txtFooter" runat="server"  Width="295px" Visible="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Site Logo (230x30)</td>
            <td class="auto-style3">:</td>
            <td>
                    <asp:FileUpload ID="FuResim" runat="server" />
                    &nbsp;&nbsp; <asp:Button ID="btnResimYukle" runat="server" CssClass="btn" OnClick="btnResimYukle_Click" Text="Resmi Yükle" />
                
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>
                <asp:Panel ID="PanelSil" runat="server">
                    <asp:Image ID="Image1" runat="server" Height="30px" Width="230px" />
                    &nbsp;
                    <asp:Button ID="btnSil" runat="server" CssClass="btn" OnClick="btnSil_Click" Text="Resmi Sil" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>
                <br />
                <asp:Button ID="btnKaydet" runat="server" CssClass="btn" OnClick="btnKaydet_Click" Text="Kaydet" />
            </td>
        </tr>
    </table>
</asp:Content>
