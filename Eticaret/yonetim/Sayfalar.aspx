<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="Sayfalar.aspx.cs" Inherits="Eticaret.yonetim.Sayfalar" %>
<%@ Register assembly="CollectionPager" namespace="SiteUtils" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="Button1" runat="server" CssClass="btn" PostBackUrl="~/yonetim/SayfaEkle.aspx" Text="Yeni Sayfa Ekle" />
    <br />
  <table class="table">
                <thead>
                    <tr>
                        <th class="auto-style20">Sayfa Adı</th>
                        <th class="input-medium">Durum</th>
                        <th>İşlem</th>
                        
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="RpSayfalar" runat="server">
                        <ItemTemplate>
                            <tr>
                              <td><%#Eval("SayfaAdi")%></a></td>
                           
                                <td><%#Eval("Durumadi")%></td>
                                <td><a href="SayfaEkle.aspx?Sayfa=<%#Eval("SayfaId")%>&islem=duzenle" title="Düzenle"><i class="icon-pencil"></i></a>
                                    <a onclick="return confirm('Dikkat: (<%#Eval("SayfaAdi") %>) Adlı Sayfayı Silmek İstediğinizden Emin Misiniz?');" href="Sayfalar.aspx?Sayfa=<%#Eval("SayfaId")%>&islem=sil" title="Sil"><i class="icon-remove"></i></a></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
    &nbsp;<cc1:CollectionPager ID="CollectionPager1" runat="server" BackText="« Geri" LabelText="Sayfa:" NextText="İleri »" PageSize="15" PagingMode="QueryString" QueryStringKey="Sayfa" ResultsFormat=""></cc1:CollectionPager>
        </asp:Content>


