<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="Urunler.aspx.cs" Inherits="Eticaret.yonetim.Urunler" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            height: 59px;
        }
        .auto-style6 {
            width: 93px;
        }
        .auto-style7 {
            width: 93px;
            height: 28px;
        }
        .auto-style8 {
            width: 205px;
            height: 28px;
        }
        .auto-style9 {
            height: 28px;
        }
        .auto-style12 {
            width: 205px;
        }
        .auto-style13 {
            width: 113px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1"  runat="server">
    <asp:Button ID="btnUrunler" runat="server" CssClass="btn" Text="Tüm Ürünler" OnClick="btnUrunler_Click" Visible="False" />
    &nbsp;<asp:Button ID="Button1" runat="server" CssClass="btn" PostBackUrl="~/yonetim/UrunEkle.aspx" Text="Yeni Ürün Ekle" />
    <table class="auto-style1">
        <tr>
            <td class="auto-style2">
                 <div class="well">
                     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                 
                                 &nbsp;&nbsp;Ürün Ara<table class="auto-style1">
                                     <tr>
                                         <td class="auto-style6">&nbsp;Kategoriler:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                         <td class="auto-style12">
                                             <asp:DropDownList ID="ddKategori" runat="server" OnSelectedIndexChanged="ddKategori_SelectedIndexChanged" Width="188px" AutoPostBack="True">
                                             </asp:DropDownList>
                                         </td>
                                         <td>&nbsp;Markalar:&nbsp;
                                             <asp:DropDownList ID="ddMarka" runat="server" Width="188px">
                                             </asp:DropDownList>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td class="auto-style7">Alt Kategoriler: </td>
                                         <td class="auto-style8">
                                             <asp:DropDownList ID="ddAltKategori" runat="server" Width="188px">
                                             </asp:DropDownList>
                                         </td>
                                         <td class="auto-style9">&nbsp;Ara:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="txtAra" runat="server" CssClass="btn-toolbar" Height="16px" ValidationGroup="grbAra" Width="180px"></asp:TextBox>
                                             &nbsp;<asp:Button ID="btnAra" runat="server" CssClass="btn" OnClick="btnAra_Click" Text="Ürün Ara" ValidationGroup="grbAra" />
                                         </td>
                                     </tr>
                                     <tr>
                                         <td class="auto-style6">&nbsp;</td>
                                         <td class="auto-style12">&nbsp;</td>
                                         <td>&nbsp;</td>
                                     </tr>
                                 </table>
                          
            </ContentTemplate>
                     </asp:UpdatePanel>
                 </div>

            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="well">
                            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                <ProgressTemplate>
                                    <img src="images/yukleniyor.gif" />
                                    Yükleniyor...
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            <asp:Label ID="lblBilgi" runat="server"></asp:Label>
                            &nbsp;
            <table class="table">
                <thead>
                    <tr>
                        
                        <th>Ürün No</th>
                        <th>Stok Kodu</th>
                        <th>Ürün Adı</th>
                        <th class="auto-style13">Miktar (Kalan)</th>
                        <th>Fiyat</th>
                        <th>Hit</th>
                        <th>Durum</th>
                        <th style="width: 46px;">İşlem</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="RpKayit" runat="server">
                        <ItemTemplate>
                            <tr>
                               
                                <td><a href="UrunDuzenle.aspx?UrunId=<%#Eval("UrunId")%>&islem=duzenle" title="Düzenle"><%#Eval("UrunId")%></a></td>
                                <td><%#Eval("StokKodu")%></td>
                                <td>
                                    <img src="/Resimler/Urun/150/<%#Eval("AnaResim150")%> " width="35" height="30" title="<%#Eval("UrunAdi")%>" />
                                    - <%#Eval("UrunAdi")%></td>
                                <td><%#Eval("StokMiktari")%></td>
                                <td><%#Eval("SatisFiyati","{0:c}")%></td>
                                <td><%#Eval("Hit")%></td>
                                <td><%#Eval("Durumadi")%></td>

                                <td>
                                     
                                       
                                    <a href="UrunDuzenle.aspx?UrunId=<%#Eval("UrunId")%>&islem=duzenle" title="Düzenle"><i class="icon-pencil"></i></a>
                                    <a href="UrunDuzenle.aspx?UrunId=<%#Eval("UrunId")%>&islem=duzenle&v=var" title="Varyant ekle">V</i></a>
                                    <a onclick="return confirm('Dikkat: (<%#Eval("UrunId") %>) Numaralı Ürünü Silmek İstediğinizden Emin Misiniz?');" href="Urunler.aspx?UrunId=<%#Eval("UrunId")%>&islem=sil" title="Sil"><i class="icon-remove"></i></a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>

                        </div>
                        <div class="pagination">
                            <cc1:CollectionPager ID="CollectionPager1" runat="server" BackText="« Geri" LabelText="Sayfa:" NextText="İleri »" QueryStringKey="Sayfa" ResultsFormat="">
                            </cc1:CollectionPager>
                        </div>

                        </div>
        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="grbAra" />

            </td>
        </tr>
    </table>
</asp:Content>
