<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Eticaret.yonetim.Default" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
     

            <div class="row-fluid">

                <div class="alert alert-info">
                    <button type="button" class="close" data-dismiss="alert">×</button>
                    <strong>Hoş Geldiniz:</strong> Siteyi sol alandaki menülerden yönetebilirsiniz.
                </div>

                <div class="block">
                    <a href="#page-stats" class="block-heading" data-toggle="collapse">İstatistikler</a>
                    <div id="page-stats" class="block-body collapse in">

                        <div class="stat-widget-container">
                            <div class="stat-widget">
                                <div class="stat-button">
                                    <p class="title" id="pUyeler" runat="server"></p>
                                    <p class="detail">Üyeler</p>
                                </div>
                            </div>

                            <div class="stat-widget">
                                <div class="stat-button">
                                    <p class="title" id="pYorumlar" runat="server"></p>
                                    <p class="detail">Yorumlar</p>
                                </div>
                            </div>

                            <div class="stat-widget">
                                <div class="stat-button">
                                    <p class="title" id="pUrunler" runat="server"></p>
                                    <p class="detail">Ürünler</p>
                                </div>
                            </div>
                            <div class="stat-widget">
                                <div class="stat-button">
                                    <p class="title" id="pStok" runat="server"></p>
                                    <p class="detail">Kritik Stok</p>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        <div class="block">
                    <a href="#stok" class="block-heading" data-toggle="collapse" >Kritik Durumdaki Stoklar
                    <asp:Label ID="lblBilgi" runat="server"></asp:Label>
                    </a>
                    &nbsp;
                    <div id="stok" class="block-body collapse in">
                        <div id="divstok" class="stat-widget-container" runat="server">
                       <table class="table" >
                <thead>
                    <tr>
                        
                        <th>Ürün No</th>
                        <th>Stok Kodu</th>
                        <th>Ürün Adı</th>
                        <th class="auto-style13">Miktar (Kalan)</th>
                        <th>Fiyat</th>
                        <th>Hit</th>
                        <th>Durum</th>
                        <th style="width: 26px;">İşlem</th>
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
                                 <%--   <a onclick="return confirm('Dikkat: (<%#Eval("UrunId") %>) Numaralı Ürünü Silmek İstediğinizden Emin Misiniz?');" href="Urunler.aspx?UrunId=<%#Eval("UrunId")%>&islem=sil" title="Sil"><i class="icon-remove"></i></a>--%>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>

                         <div class="pagination">
                            <cc1:CollectionPager ID="CollectionPager1" runat="server" BackText="« Geri" LabelText="Sayfa:" NextText="İleri »" QueryStringKey="Sayfa" ResultsFormat="" PageSize="5">
                            </cc1:CollectionPager>
                        </div>
                    </div>
                </div>
         </div>

        <div class="row-fluid">
            <div class="block span6">
                <a href="#tablewidget" class="block-heading" data-toggle="collapse">Son Üyeler<span class="label label-warning">5</span></a>
                <div id="tablewidget" class="block-body collapse in">
                    <div id="divSonUyeler" runat="server">
                    <table class="table">
                        <thead>
                            <tr>
                                <th>Ad Soyad</th>
                                <th>Email</th>
                                <th>Kayıt Tarihi</th>
                                <th>Tipi</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RpUyeler" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><a href="UyeDuzenle.aspx?UyeId=<%#Eval("UyeId")%>&islem=duzenle"><%#Eval("Ad")%> <%#Eval("Soyad")%></a></td>
                                        <td><%#Eval("Email")%></td>
                                        <td><%#Eval("KayitTarihi")%></td>
                                        <td><%#Eval("BayiMi")%></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <p><a href="Uyeler.aspx">Devamı...</a></p>
                        </div>
                </div>
            </div>
            <div class="block span6">
                <a href="#widget1container" class="block-heading" data-toggle="collapse">En Çok İncelenen Ürünler </a>
                <div id="widget1container" class="block-body collapse in">
                     <div id="divEnCokincelenen" runat="server">
                    <table class="table">
                        <thead>
                            <tr>
                                <th>Ürün No</th>
                                <th>Ürün</th>
                                <th>Hit Sayısı</th>

                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RpincelenenUrun" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><a href="/detay-<%#Eval("UrunId")%>-<%#Kontrol.UrlSeo(Eval("UrunAdi").ToString())%>.html" target="_blank"><%#Eval("UrunId")%></a></td>
                                        <td><%#Eval("UrunAdi")%></td>
                                        <td><%#Eval("Hit")%></td>

                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                         </div>
                </div>

            </div>
        </div>

        <div class="row-fluid">
            <div class="block span6">
                <div class="block-heading">
                    <span class="block-icon pull-right">
                    <%#Eval("UrunId")%>
                    </span>

                    <a href="#widget2container" data-toggle="collapse">En Çok Satılan Ürünler</a>
                </div>
                <div id="widget2container" class="block-body collapse in">
                    <div id="divEnCokSatilanUrun" runat="server">
                    <asp:Chart ID="chCokSatilan" runat="server" Width="470px">
                        <Series>

                            <asp:Series Name="Series1" ChartType="Pie" YValuesPerPoint="6" XValueMember="UrunAdi" YValueMembers="UrunId">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                        </div>
                </div>
            </div>

            <div class="block span6">
                <a href="#widget3container" class="block-heading" data-toggle="collapse">En Çok Alışveriş Yapan Üyeler </a>
                <div id="widget3container" class="block-body collapse in">
                     <div id="divEnCokAlisvarisYapan" runat="server">
                    <asp:Chart ID="chEncokUrunAlan" runat="server" Width="470px">
                        <Series>
                            <asp:Series Name="Series1" XValueMember="AdSoyad" YValueMembers="UrunId" ChartType="StackedBar"></asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </div>
                    </div>
            </div>
            </div>
               
                <div class="row-fluid">
            <div class="block span6">
                <div class="block-heading">
                    <span class="block-icon pull-right">
                    <%#Eval("StokKodu")%>
                    </span>

                    <a href="#widget4container" data-toggle="collapse">Günün Kazançları</a>
                </div>
                <div id="widget4container" class="block-body collapse in">
                      <div id="divGununSiparisleri" runat="server">
                     <table class="table">
                        <thead>
                            <tr>
                                <th>Sipariş No</th>
                                <th>Üye</th>
                                <th>Sipariş Tarihi</th>
                                <th>Tutar</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RpGununSiparisleri" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("SiparisId")%></td>
                                        <td><a href="Siparisler.aspx?Uye=<%#Eval("UyeId")%>&islem=uyedetay" title="Üyenin tüm siparişleri" target="_blank"><%#Eval("AdSoyad")%></a></td>
                                        <td><%#Eval("SiparisTarihi")%></td>
                                        <td><%#Eval("Tutar","{0:c}")%></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <asp:Label ID="lblBugun" runat="server"></asp:Label>
                    <p><a href="GelirDetay.aspx?islem=bugun">Devamı...</a></p>
                          </div>
                </div>
            </div>

            <div class="block span6">
                <a href="#widget5container" class="block-heading" data-toggle="collapse">Son 1 Ayın En Pahalı Alışverişleri</a>
                <div id="widget5container" class="block-body collapse in">
                    <div id="divSonBirAy" runat="server">
<table class="table">
                       <thead>
                            <tr>
                                <th>Sipariş No</th>
                                <th>Üye</th>
                                <th>Sipariş Tarihi</th>
                                <th>Tutar</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RpBuAy" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%#Eval("SiparisId")%></td>
                                        <td><a href="Siparisler.aspx?Uye=<%#Eval("UyeId")%>&islem=uyedetay" title="Üyenin tüm siparişleri" target="_blank"><%#Eval("AdSoyad")%></a></td>
                                        <td><%#Eval("SiparisTarihi")%></td>
                                        <td><%#Eval("Tutar","{0:c}")%></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>

                    <asp:Label ID="lblBuay" runat="server"></asp:Label>
                    <p><a href="GelirDetay.aspx?islem=buay">Devamı...</a></p>
                        </div>
                </div>

            </div>


            <footer>
            </footer>

        </div>
        </p>
</asp:Content>
