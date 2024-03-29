<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="Siparisler.aspx.cs" Inherits="Eticaret.yonetim.Siparisler" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 80px;
        }
        .auto-style6 {
            width: 57px;
        }
        .auto-style7 {
            width: 100%;
        }
        .auto-style11 {
            width: 22px;
        }
        .auto-style12 {
            width: 94px;
            font-weight: bold;
        }
        .auto-style13 {
            width: 94px;
            font-weight: bold;
            height: 30px;
        }
        .auto-style14 {
            width: 22px;
            height: 30px;
        }
        .auto-style15 {
            height: 30px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
    </div>
    <div class="btn-toolbar">

        <div>
            &nbsp;<asp:Button ID="btnSiparisler" runat="server" CssClass="btn" OnClick="btnSiparisler_Click" Text=" Bekleyen Siparişler" />
            &nbsp;<asp:Button ID="btnTamamlanan" runat="server" CssClass="btn" Text="Tamamlanan Siparişler" OnClick="btnTamamlanan_Click" />
            &nbsp;<asp:Button ID="btniptalEdilen" runat="server" CssClass="btn" Text="Üye'nin İptal Etiği Siparişler" OnClick="btniptalEdilen_Click" />
            &nbsp;<asp:Button ID="btniptalEdilenUrun" runat="server" CssClass="btn" Text="Üye'nin İptal Etiği Sipariş Ürünleri" OnClick="btniptalEdilenUrun_Click" />
           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    &nbsp;&nbsp;<asp:Button ID="btnAra" runat="server" CssClass="btn" Text="Ara" ValidationGroup="grbAra" OnClick="btnAra_Click" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAra" ErrorMessage="Lütfen Bir İsim Giriniz" ForeColor="Red" ValidationGroup="grbAra">*</asp:RequiredFieldValidator>
                    &nbsp;<asp:TextBox ID="txtAra" runat="server" CssClass="btn-toolbar" Height="16px" ValidationGroup="grbAra"></asp:TextBox>
                    <asp:TextBoxWatermarkExtender ID="txtAra_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtAra" WatermarkText="Ara...">
                    </asp:TextBoxWatermarkExtender>
                    &nbsp;<br />
                    </div>
                    </ContentTemplate>
            </asp:UpdatePanel>
                    &nbsp;&nbsp;
          
            </div>
            <div style="text-align:right;">Veriyi Aktar: <asp:ImageButton ID="btnExcel" ImageUrl="~/yonetim/images/excel.png" runat="server" Width="50px" ToolTip="Excel'e aktar" OnClick="btnExcel_Click" />
                 <asp:ImageButton ID="btnWord" ImageUrl="~/yonetim/images/word.png" runat="server" Width="50px" ToolTip="Word'e aktar" OnClick="btnWord_Click" />
               <asp:ImageButton ID="btnPdf" ImageUrl="~/yonetim/images/pdf.png" runat="server" Width="50px" ToolTip="Pdf çıkart" OnClick="btnPdf_Click"  />
            </div> 
        <%-- siparişler div--%>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
              
                <div class="well">

                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                        <ProgressTemplate>
                            &nbsp;<img src="images/yukleniyor.gif" />
                            Yükleniyor...
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <asp:Label ID="lblBilgi" runat="server" Font-Size="Medium" ForeColor="Maroon"></asp:Label>
                    <div id="divSiparisler" runat="server">
                        <div id="divDropDownListele" runat="server" visible="false">
                            &nbsp;Sipariş Durumu:&nbsp;<asp:DropDownList ID="ddSiparisListele" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddSiparisListele_SelectedIndexChanged">
                            </asp:DropDownList>
                            &nbsp;Ödeme Tipi:
                            <asp:DropDownList ID="ddOdemeTipi" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddOdemeTipi_SelectedIndexChanged">
                                <asp:ListItem Value="Seçiniz">Seçiniz</asp:ListItem>
                                <asp:ListItem Value="0">Kredi Kartı</asp:ListItem>
                                <asp:ListItem Value="1">Havale/EFT</asp:ListItem>
                                <asp:ListItem Value="2">Kapıda Ödeme</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <%-- siparişler div--%>

                        <table class="table">
                            <thead>
                                <tr>
                                    <th class="auto-style6">Sipariş No</th>
                                    <th>Üye Adı</th>
                                    <th>Ödeme Tipi</th>
                                    <th>Sipariş Tutarı</th>
                                    <th>Sipariş Tarihi</th>
                                    <th>Kart Sahibi</th>
                                    <th>Sipariş Durumu</th>
                                    <th>Kargo Takibi</th>
                                    <th style="width: 26px;">İşlem</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="RpSiparisler" runat="server" OnItemCreated="RpSiparisler_ItemCreated">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("SiparisId")%></td>
                                            <td><a href="Siparisler.aspx?Uye=<%#Eval("UyeId")%>&islem=uyedetay" title="Üyenin tüm siparişleri"><%#Eval("Ad")%> <%#Eval("Soyad")%></a></td>
                                            <td><%#Eval("OdemeTip")%></td>
                                            <td><%#Eval("Tutar","{0:c}")%></td>
                                            <td><%#Eval("SiparisTarihi")%></td>
                                            <td><%#Eval("Kartisim")%></td>
                                            <td>
                                                <asp:DropDownList ID="ddDurum" runat="server" SelectedValue='<%#Eval("DurumId") %>' DataValueField='<%#Eval("SiparisId")%>' Width="185" AutoPostBack="true" OnSelectedIndexChanged="DropDegerGetir"></asp:DropDownList></td>
                                            <td><a href="KargoTakip.aspx?s=<%#Eval("SiparisId")%>&u=<%#Eval("UyeId")%>&k=<%#Eval("KargoId")%>" title="Kargo Takip Numarası Gönder">Takip No Gönder</i></a>
                                            </td>
                                           <td>
                                            <a href="Siparisler.aspx?Detay=<%#Eval("SiparisId")%>&islem=siparisdetay" title="Sipariş detayları">
                                                <img src="images/detay.png" width="16" /></i></a>
                                            <a href="TeslimatBilgi.aspx?Detay=<%#Eval("SiparisId")%>&Return=<%=BulundugumUrl%>" title="Teslimat ve Fatura adresi detayları">
                                                <img src="images/fatura.png" width="17" /> </i></a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                    <%--// siparişler div--%>

                    <%--   div sipariş detay--%>
                    <div id="divSiparisDetay" runat="server">

                        <table class="table">
                            <thead>
                                <tr>
                                    <th class="auto-style3">Sipariş No</th>
                                    <th>Ürün</th>
                                    <th>Ürün Adeti</th>
                                    <th>Sipariş Tarihi</th>
                                    <th>Teslimat Tarihi</th>
                                    <th>Kargo</th>
                                    <th>Durum</th>
                                   <th>Varyasyon</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="RpSiparisDetay" runat="server" OnItemCreated="RpSiparisDetay_ItemCreated">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("SiparisId")%></td>
                                            <td><a href="/detay-<%#Eval("UrunId")%>-<%#Kontrol.UrlSeo(Eval("UrunAdi").ToString())%>.html" target="_blank" title="<%#Eval("UrunAdi")%>"><%#Eval("UrunAdi")%></a></td>
                                            <td><%#Eval("Miktar")%></td>
                                            <td><%#Eval("SiparisTarihi")%></td>
                                            <td><%#Eval("TeslimTarihi")%></td>
                                            <td><%#Eval("KargoAdi") %></td>
                                            <td>
                                                <asp:DropDownList ID="ddDetayDurum" runat="server" SelectedValue='<%#Eval("UrunDurumId") %>' DataValueField='<%#Eval("SepetId")%>' Width="185" AutoPostBack="true" OnSelectedIndexChanged="DropDetayDurum"></asp:DropDownList></td>
                                        
                                       <td><a href="Siparisler.aspx?v=<%#Eval("SepetId")%>&islem=varyasyon" title="Ürün varyasyonları">Varyasyonlar</a></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>

                            </tbody>

                        </table>
                        
                        <%--  div sipariş detay--%>
                    </div>
                    <%--   div üye siparişleri --%>
                    <div id="divUyeSiparisler" runat="server">

                        <table class="table">
                            <thead>
                                <tr>
                                    <th class="auto-style3">Sipariş No</th>
                                    <th>Üye Adı</th>
                                    <th>Ödeme Tipi</th>
                                    <th>Sipariş Tutarı</th>
                                    <th>Sipariş Tarihi</th>
                                    <th>Kart Sahibi</th>
                                    <th>Sipariş Durumu</th>
                                    <th style="width: 26px;">İşlem</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="RpUyeSiparisleri" runat="server" OnItemCreated="RpUyeSiparisleri_ItemCreated">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("SiparisId")%></td>
                                            <td><%#Eval("Ad")%> <%#Eval("Soyad")%></td>
                                            <td><%#Eval("OdemeTip")%></td>
                                            <td><%#Eval("Tutar","{0:c}")%></td>
                                            <td><%#Eval("SiparisTarihi")%></td>
                                            <td><%#Eval("Kartisim")%></td>
                                            <td>
                                                <asp:DropDownList ID="ddDurum" runat="server" SelectedValue='<%#Eval("DurumId") %>' DataValueField='<%#Eval("SiparisId")%>' Width="185" AutoPostBack="true" OnSelectedIndexChanged="DropDegerGetir"></asp:DropDownList></td>

                                             <td>
                                                <a href="Siparisler.aspx?Detay=<%#Eval("SiparisId")%>&islem=siparisdetay" title="Sipariş detayları">
                                                    <img src="images/detay.png" width="16" /></i></a>
                                                <a href="TeslimatBilgi.aspx?Detay=<%#Eval("SiparisId")%>&Return=<%=BulundugumUrl%>" title="Teslimat ve Fatura adresi detayları">
                                                    <img src="images/fatura.png" width="17" />
                                                    </i></a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <%--  div üye siparişleri --%>
                    </div>


                    <%--iptal edilen siparişler--%>
                    <div id="diviptalEdilenSiparisler" runat="server">

                        <table class="table">
                            <thead>
                                <tr>
                                    <th class="auto-style3">Sipariş No</th>
                                    <th>Üye Adı</th>
                                    <th>Ödeme Tipi</th>
                                    <th>Sipariş Tutarı</th>
                                    <th>Sipariş Tarihi</th>
                                    <th>Kart Sahibi</th>
                                    <th>İptal Onayı</th>
                                    <th style="width: 26px;">İşlem</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="RpiptalSiparis" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("SiparisId")%></td>
                                            <td><%#Eval("Ad")%> <%#Eval("Soyad")%></td>
                                            <td><%#Eval("OdemeTip")%></td>
                                            <td><%#Eval("Tutar","{0:c}")%></td>
                                            <td><%#Eval("SiparisTarihi")%></td>
                                            <td><%#Eval("Kartisim")%></td>
                                            <td>
                                                <asp:DropDownList ID="ddSiparisIptal" DataValueField='<%#Eval("SiparisId")%>' OnSelectedIndexChanged="DropSiparisIptali" runat="server" AutoPostBack="True">
                                                    <asp:ListItem Value="0">İşlem Seçiniz</asp:ListItem>
                                                    <asp:ListItem Value="1">Sipariş İptalini Onayla</asp:ListItem>
                                                    <asp:ListItem Value="2">Sipariş İptalini Onaylama</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>

                                            <td>
                                                <a href="Siparisler.aspx?Detay=<%#Eval("SiparisId")%>&islem=siparisdetay" title="Sipariş detayları">
                                                    <img src="images/detay.png" width="16" /></i></a>
                                                <a href="TeslimatBilgi.aspx?Detay=<%#Eval("SiparisId")%>&Return=<%=BulundugumUrl%>" title="Teslimat ve Fatura adresi detayları">
                                                    <img src="images/fatura.png" width="17" />
                                                    </i></a>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <%--  div üye siparişleri --%>
                    </div>
                    <%--iptal edilen siparişler--%>

                    <%--  div iptal edilen sipariş ürünleri --%>
                    <div id="divIptalEdilenUrunler" runat="server">

                        <table class="table">
                            <thead>
                                <tr>
                                    <th class="auto-style3">Sipariş No</th>
                                    <th>Ürün</th>
                                    <th>Ürün Adeti</th>
                                    <th>Sipariş Tarihi</th>
                                    <th>Teslimat Tarihi</th>
                                    <th>Kargo</th>
                                    <th>Durum</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="RpiptalEdilenUrunler" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("SiparisId")%></td>
                                            <td><a href="/detay-<%#Eval("UrunId")%>-<%#Kontrol.UrlSeo(Eval("UrunAdi").ToString())%>.html" target="_blank" title="<%#Eval("UrunAdi")%>"><%#Eval("UrunAdi")%></a></td>
                                            <td><%#Eval("Miktar")%></td>
                                            <td><%#Eval("SiparisTarihi")%></td>
                                            <td><%#Eval("TeslimTarihi")%></td>
                                            <td><%#Eval("KargoAdi") %></td>
                                            <td>
                                                <asp:DropDownList ID="ddDetayUrunDurum" runat="server" DataTextField='<%#Eval("SiparisId")%>' DataValueField='<%#Eval("SepetId")%>' AutoPostBack="true" OnSelectedIndexChanged="DropUrunIptali">
                                                    <asp:ListItem Value="0">İşlem Seçiniz</asp:ListItem>
                                                    <asp:ListItem Value="1">Sipariş İptalini Onayla</asp:ListItem>
                                                    <asp:ListItem Value="2">Sipariş İptalini Onaylama</asp:ListItem>
                                                </asp:DropDownList></td>

                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                        <%--  div iptal edilen sipariş ürünleri --%>
                    </div>
                   <%-- div varyasyon detay--%>
                    <div id="divVaryasyon" runat="server" visible="false">

                        <table class="auto-style7">
                            <tr>
                                <td class="auto-style13">Varyasyonlar</td>
                                <td class="auto-style14"></td>
                                <td class="auto-style15">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style12">
                                    <asp:Label ID="lblVarAdi1" runat="server"></asp:Label>
                                </td>
                                <td class="auto-style11">:</td>
                                <td>
                                    <asp:Label ID="lblVar1" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style12">
                                    <asp:Label ID="lblVarAdi2" runat="server"></asp:Label>
                                </td>
                                <td class="auto-style11">:</td>
                                <td>
                                    <asp:Label ID="lblVar2" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style12">
                                    <asp:Label ID="lblVarAdi3" runat="server"></asp:Label>
                                </td>
                                <td class="auto-style11">:</td>
                                <td>
                                    <asp:Label ID="lblVar3" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style12">&nbsp;</td>
                                <td class="auto-style11">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>

                        </div>
                    <%-- div varyasyon detay--%>
                </div>
                <div class="pagination">
                    <cc1:CollectionPager ID="CollectionPager1" runat="server" BackText="« Geri"
                        LabelText="Sayfa:" NextText="İleri »" PageNumbersDisplay="Numbers" PageSize="30"
                        ResultsFormat="Gösterilen Kayıtlar {0}-{1} (Toplam {2})"
                        QueryStringKey="Sayfa">
                    </cc1:CollectionPager>
                </div>

                </div>
        </div>
            </ContentTemplate>

        </asp:UpdatePanel>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="grbAra" />

    </div>

</asp:Content>
