<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="Markalar.aspx.cs" Inherits="Eticaret.yonetim.Markalar" %>
<%@ Register assembly="CollectionPager" namespace="SiteUtils" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 85px;
        }
        .auto-style3 {
            width: 17px;
        }
        .auto-style4 {
            width: 85px;
            height: 52px;
        }
        .auto-style5 {
            width: 17px;
            height: 52px;
        }
        .auto-style6 {
            height: 52px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style2"><strong>Marka Ekle</strong></td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">Aktif</td>
            <td class="auto-style5">:</td>
            <td class="auto-style6">
                <asp:CheckBox ID="cbAktif" runat="server" Checked="True" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Marka Adı</td>
            <td class="auto-style3">:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtMarkaAdi" ErrorMessage="*" ForeColor="Red" ValidationGroup="grbMarka"></asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtMarkaAdi" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>
                <asp:Button ID="btnMarkaEkle" runat="server" CssClass="btn" OnClick="btnMarkaEkle_Click" Text="Marka Ekle" ValidationGroup="grbMarka" />
                <asp:Button ID="btnMarkaDuzenle" runat="server" CssClass="btn" OnClick="btnMarkaDuzenle_Click" Text="Marka Düzenle" Visible="False" ValidationGroup="grbMarka" />
    <asp:Button ID="btnGeri" runat="server" Text="&lt;&lt; Geri" CssClass="btn" OnClick="btnGeri_Click" Visible="False" />
            </td>
        </tr>
    </table>
         <asp:Label ID="lblAltBilgi" runat="server"></asp:Label>
        &nbsp;<table class="table">
                <thead>
                    <tr>
                        <th class="auto-style20">Marka Adı</th>
                        <th class="input-medium">Durum</th>
                        <th>İşlem</th>
                        
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="RpMarka" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("MarkaAdi")%></a></td>
                           
                                <td><%#Eval("Durumadi")%></td>
                                <td><a href="Markalar.aspx?Marka=<%#Eval("MarkaId")%>&islem=duzenle" title="Düzenle"><i class="icon-pencil"></i></a>
                                    <a onclick="return confirm('Dikkat: (<%#Eval("MarkaAdi") %>) Adlı Markayı Silmek İstediğinizden Emin Misiniz?');" href="Markalar.aspx?Marka=<%#Eval("MarkaId")%>&islem=sil" title="Sil"><i class="icon-remove"></i></a></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
    &nbsp;<cc1:CollectionPager ID="CollectionPager1" runat="server" BackText="« Geri" LabelText="Sayfa:" NextText="İleri »" PageSize="15" PagingMode="QueryString" QueryStringKey="Sayfa" ResultsFormat=""></cc1:CollectionPager>
        </asp:Content>
