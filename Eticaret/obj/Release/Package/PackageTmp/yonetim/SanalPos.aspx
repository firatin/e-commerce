<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="SanalPos.aspx.cs" Inherits="Eticaret.yonetim.SanalPos" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style3 {
            width: 19px;
        }

        .auto-style4 {
            width: 164px;
            height: 21px;
        }

        .auto-style5 {
            width: 19px;
            height: 21px;
        }

        .auto-style6 {
            height: 21px;
        }

        .auto-style7 {
            width: 164px;
        }

        .auto-style11 {
            width: 164px;
            height: 18px;
        }

        .auto-style12 {
            width: 19px;
            height: 18px;
        }

        .auto-style13 {
            height: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="tbPosEkle" runat="server" visible="false" class="auto-style1">
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style6">
                <asp:DropDownList ID="ddBanka" runat="server" Visible="False">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Kullanıcı Adı</td>
            <td class="auto-style5">:</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtKull" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Şifre</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:TextBox ID="txtSifre" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Üye İşyeri No</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:TextBox ID="txtisYeriNo" runat="server"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="txtisYeriNo_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtisYeriNo">
                </asp:FilteredTextBoxExtender>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Sanal Pos Adresi</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:TextBox ID="txtPosAdresi" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style11">Pos No</td>
            <td class="auto-style12">:</td>
            <td class="auto-style13">
                <asp:TextBox ID="txtPosNo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style11">XCip</td>
            <td class="auto-style12">:</td>
            <td class="auto-style13">
                <asp:TextBox ID="txtXcip" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="auto-style11">MID</td>
            <td class="auto-style12">:</td>
            <td class="auto-style13">
                <asp:TextBox ID="txtMid" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="auto-style11">TID</td>
            <td class="auto-style12">:</td>
            <td class="auto-style13">
                <asp:TextBox ID="txtTid" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style11">Durum</td>
            <td class="auto-style12">:</td>
            <td class="auto-style13">
                <asp:CheckBox ID="cbAktif" runat="server" Text="Aktif" />
            </td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>
                <asp:Button ID="btnEkle" runat="server" CssClass="btn" Text="Ekle" ValidationGroup="grbPos" OnClick="btnEkle_Click" />
                &nbsp;<asp:Button ID="btnDuzenle" runat="server" CssClass="btn" OnClick="btnDuzenle_Click" Text="Düzenle" Visible="False" ValidationGroup="grbPos" />
                &nbsp;<asp:Button ID="btnGeri" runat="server" CssClass="btn" OnClick="btnGeri_Click" Text="&lt;&lt; Geri" ValidationGroup="grbkargo" Visible="False" />
            </td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:Button ID="btnBanka" runat="server" CssClass="btn" OnClick="btnBanka_Click1" Text="Yeni Ekle" Visible="False" />
    <br />
  
            <table class="table">
                <thead>
                    <tr>
                        <th>Pos ID</th>
                        <th>Banka Adı</th>
                        <th>Durum</th>
                        <th>İşlem</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="RpKayit" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("PosId")%></a></td>
                                <td><%#Eval("BankaAdi")%></td>
                                <td><%#Eval("Durumadi")%></td>
                                <td><a href="SanalPos.aspx?Banka=<%#Eval("PosId")%>&islem=duzenle" title="Düzenle"><i class="icon-pencil"></i></a></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
</asp:Content>
