<%@ Page Title="" Language="C#" MasterPageFile="~/Ana.Master" AutoEventWireup="true" CodeBehind="UrunDetay.aspx.cs" Inherits="Eticaret.UrunDetay2" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="/jstoast/jqui-tr.js"></script> <%--toast message --%>
    <link href="/css/taksit.css" rel="stylesheet" />

    <script type="text/javascript" lang="Javascript">
        function textCounter(field, countfield, maxlimit) {

            if (field.value.length > maxlimit) {

                field.value = field.value.substring(0, maxlimit);

                field.enabled = false;

            }

            else

                countfield.value = maxlimit - field.value.length;

        }

    </script>

    <style type="text/css">
        .TabLayout {
            height: 120px;
        }

        .ajax__tab_panel .ajax__tab_header {
            font-size: small;
            border-bottom: solid 1px #2647a0;
            border-bottom-color: #CCCCCC;
            border-bottom-width: 1px;
        }

            .ajax__tab_panel .ajax__tab_header .ajax__tab_outer {
                border-bottom-width: 0px;
                border-width: 1px;
                border-color: #CCCCCC;
                margin: 0px 0.16em 0px 0px;
                padding: 0px 0px 0px 0px;
                vertical-align: bottom;
                border-top-style: solid;
                border-right-style: solid;
                border-left-style: solid;
                background-color: #FFFF99;
                color: #000000;
                font-weight: bold;
            }

            .ajax__tab_panel .ajax__tab_header .ajax__tab_tab {
                color: #333333;
                padding: 0.35em 0.75em;
                margin-right: 0.01em;
            }

        .ajax__tab_panel .ajax__tab_hover .ajax__tab_outer {
            border-bottom-width: 0px;
            border-width: 1px;
            border-color: #CCCCCC;
            cursor: pointer;
            border-top-style: solid;
            border-right-style: solid;
            border-left-style: solid;
            background-color: #FFFFFF;
        }

        .ajax__tab_panel .ajax__tab_active .ajax__tab_tab {
            border-color: #CCCCCC;
            border-style: solid solid none solid;
            border-width: 0px;
            color: #000000;
        }

        .ajax__tab_panel .ajax__tab_active .ajax__tab_outer {
            border-style: solid solid none solid;
            border-width: 1px;
            background: #fff repeat-x left -1400px;
            color: #333333;
        }

        .ajax__tab_panel .ajax__tab_body {
            padding: 0.25em;
            color: #000000;
        }
    </style>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
            height: 39px;
        }

        .auto-style2 {
            width: 174px;
            text-align: left;
        }

        .auto-style3 {
            width: 8px;
        }

        .auto-style4 {
            height: 16px;
        }

        .auto-style5 {
            width: 79px;
        }

        .auto-style6 {
            width: 79px;
            height: 16px;
        }

        .auto-style9 {
            width: 8px;
            height: 16px;
        }

        .auto-style11 {
            width: 8px;
            height: 27px;
        }

        .auto-style12 {
            height: 27px;
        }

        .table {
            width: 438px;
        }

        .auto-style13 {
            width: 174px;
            text-align: left;
            height: 16px;
        }

        .auto-style14 {
            width: 140px;
            text-align: left;
            font-weight: bold;
        }
        .auto-style15 {
            width: 140px;
            text-align: left;
            height: 16px;
            font-weight: bold;
        }
        .auto-style16 {
            width: 10px;
        }
        .auto-style17 {
            width: 141px;
        }
        .auto-style18 {
            width: 140px;
            text-align: left;
            height: 27px;
            color: #993333;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cntSlider" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cntİcerik" runat="server">
     <div id="content">
      <!--Breadcrumb Part Start-->
      <!--Breadcrumb Part End-->
      <div class="product-info">
        <div class="left">
             <asp:Panel ID="PanelResimYok" runat="server" Visible="False">
                    <img src="/Resimler/resimyok.jpg" width="340" height="370" alt="" />
                </asp:Panel>
        
          <div class="image">             
               <div class="left">
          <div class="image">
              <a href="" title="iPhone" class="cloud-zoom colorbox" id='zoom1' rel="adjustX: 0, adjustY:0, tint:'#000000',tintOpacity:0.2, zoomWidth:360, position:'inside', showTitle:false">
                  <img src="<%=Anaresim%>" title="<%#Eval("UrunAdi")%>" alt="<%#Eval("UrunAdi")%>" id="image" width="300px" height="300px"/><span id="zoom-image"><i class=""></i></span></a>

          </div>
                  
          <div class="image-additional"> 
              <asp:Repeater ID="RpResimler" runat="server">
                 <ItemTemplate>
              <a href="/Resimler/Urun/800/<%#Eval("ResimYolu800")%>" title="" class="cloud-zoom-gallery" rel="useZoom: 'zoom1', smallImage: '/Resimler/Urun/800/<%#Eval("ResimYolu800")%>' "> <img src="/Resimler/Urun/150/<%#Eval("ResimYolu150")%>" width="62" alt="" /></a>

               </ItemTemplate>
              </asp:Repeater> </div>
               
        </div>
                    
          </div>
                 
          <div class="image-additional">
           
          </div>
        </div>
        <div class="right">
          <h1><asp:Label ID="lblAd" runat="server" Text="sasas"></asp:Label></h4></h1>
          <div id="divUye" runat="server">
                    <table class="price" >

                        <tr id="trPiyasa" runat="server">
                            <td class="auto-style2">
                                <asp:Label ID="lblPiyasaAd" runat="server" Text="Piyasada" Font-Bold="True"></asp:Label>
                            </td>
                            <td class="auto-style3">:</td>
                            <td>
                               <asp:Label ID="lblPiyasaFiyat" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">
                                <asp:Label ID="lblFiyati" runat="server" Text="Fiyatı " Font-Bold="True"></asp:Label>
                            </td>
                            <td class="auto-style3">:</td>
                            <td>
                               <asp:Label ID="lblFiyatiFiyat" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trindirim" runat="server">
                            <td class="auto-style2">
                               <asp:Label ID="lblindirimli" runat="server" Text="İndirimli" Font-Bold="True"></asp:Label>
                            </td>
                            <td class="auto-style3">:</td>
                            <td>
                               <asp:Label ID="lblindirimliFiyat" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        
                        <tr id="trHavaleindirim" runat="server">
                            <td class="auto-style2">
                               <asp:Label ID="lblHavale" runat="server" Text="Havale İndirimi" Font-Bold="True"></asp:Label>
                            </td>
                            <td class="auto-style3">:</td>
                            <td>
                               <asp:Label ID="lblHavaleFiyat" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trTekCekimindirim" runat="server">
                            <td class="auto-style2">
                               <asp:Label ID="lblTekCekim" runat="server" Text="Tek Çekim İndirim" Font-Bold="True"></asp:Label>
                            </td>
                            <td class="auto-style3">:</td>
                            <td>
                              <asp:Label ID="lblTekCekimFiyat" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trStok" runat="server">
                            <td class="auto-style2">
                              <asp:Label ID="lblStok" runat="server" Text="Stok Sayısı" Font-Bold="True"></asp:Label>
                            </td>
                            <td class="auto-style3">:</td>
                            <td>
                               <asp:Label ID="lblStokAdet" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trStokDurum" runat="server">
                            <td>
                               <asp:Label ID="lblStokDr" runat="server" Text="Stok Durumu" Font-Bold="True"></asp:Label>
                            </td>
                            <td >:</td>
                            <td>
                              <asp:Label ID="lblStokDurum" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                             <asp:Label ID="lblKdvDahil" runat="server" Text="Kdv Dahil" Font-Bold="True" Font-Overline="False" Font-Size="X-Large" ForeColor="#F15A23"></asp:Label>                                        
                            </td>
                            <td class="auto-style3">:</td>
                            <td>
                                
                                 <div class="price-tag"><asp:Label ID="lblKdvDahilFiyat" runat="server" Font-Bold="True"></asp:Label></div>
                            </td>
                        </tr>
                        <tr id="trsiparisSayisi" runat="server">
                            <td>
                               <asp:Label ID="lblSiparisMiktar" runat="server" Text="Sipariş Sayısı" Font-Bold="True"></asp:Label>
                                &nbsp(<asp:Label ID="lblStokSayiOlcut" runat="server" Font-Bold="True"></asp:Label>)
                            </td>
                            <td>:</td>
                            <td> 
                                <asp:DropDownList ID="ddStokAdet" runat="server" Height="29px" Width="50px">
                                </asp:DropDownList>                                                             
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="divBayi" runat="server">
                    <table class="price">
                        <tr>
                            <td class="auto-style18">
                                <strong>Bayi Fiyatları</strong></td>
                            <td class="auto-style11"></td>
                            <td class="auto-style12"></td>
                        </tr>

                        <tr id="tr1" runat="server">
                            <td class="auto-style15">Bayi Fiyatı
                            </td>
                            <td class="auto-style9">:</td>
                            <td class="auto-style4">
                                <asp:Label ID="lblBayiFiyati" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>

                        <tr id="trBayiindirim" runat="server">
                            <td class="auto-style15">İndirimli&nbsp; Fiyatı</td>
                            <td class="auto-style9">:</td>
                            <td class="auto-style4">
                                <asp:Label ID="lblindirimliBayiFiyat" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                      
                        <tr id="trBayiHavaleindirim" runat="server">
                            <td class="auto-style14">&nbsp;Havale İndirimi</td>
                            <td class="auto-style3">:</td>
                            <td>
                                <asp:Label ID="lblBayiHavale" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trBayiTekCekimindirim" runat="server">
                            <td class="auto-style14">&nbsp;Tek Çekim İndirimi</td>
                            <td class="auto-style3">:</td>
                            <td>
                                <asp:Label ID="lblBayiTekCekim" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                          <tr id="tr2" runat="server">
                            <td class="auto-style15">Kdv Dahil</td>
                            <td class="auto-style9">:</td>
                            <td class="auto-style4">
                                <div class="price-tag"><asp:Label ID="lblBayiKdvDahil" runat="server" Font-Bold="True"></asp:Label></div>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style18">
                                <strong>Toptan Bayi Fiyatları</strong></td>
                            <td class="auto-style11"></td>
                            <td class="auto-style12"></td>
                        </tr>

                        <tr>
                            <td class="auto-style14">Toptan Bayi Fiyatı</td>
                            <td class="auto-style3">:</td>
                            <td>
                                <asp:Label ID="lblToptanBayiFiyat" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                        <tr id="trToptanBayiindirim" runat="server">
                            <td class="auto-style14">İndirimli&nbsp; Fiyatı</td>
                            <td class="auto-style3">:</td>
                            <td>
                                <asp:Label ID="lblindirimToptanBayi" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>

                      
                        <tr id="trToptanBayiHavaleindirim" runat="server">
                            <td class="auto-style14">&nbsp;Havale İndirimi</td>
                            <td class="auto-style3">:</td>
                            <td>
                                <asp:Label ID="lblToptanBayiHavale" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>

                        <tr id="trToptanBayiTekCekimindirim" runat="server">
                            <td class="auto-style14">&nbsp;Tek Çekim İndirimi</td>
                            <td class="auto-style3">:</td>
                            <td>
                                <asp:Label ID="lblToptanBayiTekCekindirim" runat="server" Font-Bold="True"></asp:Label>
                            </td>
                        </tr>
                          <tr id="tr3" runat="server">
                            <td class="auto-style15">Kdv Dahil</td>
                            <td class="auto-style9">:</td>
                            <td class="auto-style4">
                                <div class="price-tag"> <asp:Label ID="lblToptanBayiKdvDahil" runat="server" Font-Bold="True"></asp:Label></div>
                            </td>
                        </tr>
                    </table>
                     <table class="price" id="tblVaryant" runat="server" visible="false">
                  <tr>
                      <td class="auto-style17"><strong>Seçenekler</strong></td>
                      <td class="auto-style16"></td>
                      <td>&nbsp;</td>
                  </tr>
                  <tr id="trVar1" runat="server" visible="false">
                      <td class="auto-style17">
                          <asp:Label ID="lblVar1Adi" runat="server" style="font-weight: 700"></asp:Label>
                      </td>
                      <td class="auto-style16">:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddVar1" ErrorMessage="*" ForeColor="Red" InitialValue="0" ValidationGroup="grbVar"></asp:RequiredFieldValidator>
                      </td>
                      <td>
                          <asp:DropDownList ID="ddVar1" runat="server" Width="120px">
                          </asp:DropDownList>
                      </td>
                  </tr>
                  <tr id="trVar2" runat="server" visible="false">
                      <td class="auto-style17">
                          <asp:Label ID="lblVar2Adi" runat="server" style="font-weight: 700"></asp:Label>
                      </td>
                      <td class="auto-style16">:<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddVar2" ErrorMessage="*" ForeColor="Red" InitialValue="0" ValidationGroup="grbVar"></asp:RequiredFieldValidator>
                      </td>
                      <td>
                          <asp:DropDownList ID="ddVar2" runat="server" Width="120px">
                          </asp:DropDownList>
                      </td>
                  </tr>
                  <tr id="trVar3" runat="server" visible="false">
                      <td class="auto-style17">
                          <asp:Label ID="lblVar3Adi" runat="server" style="font-weight: 700"></asp:Label>
                      </td>
                      <td class="auto-style16">:<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddVar3" ErrorMessage="*" ForeColor="Red" InitialValue="0" ValidationGroup="grbVar"></asp:RequiredFieldValidator>
                      </td>
                      <td>
                          <asp:DropDownList ID="ddVar3" runat="server" Width="120px">
                          </asp:DropDownList>
                      </td>
                  </tr>
            </table>
                </div>
             <asp:Button ID="btnSepeteEkle" runat="server" Text="Sepete Ekle" CssClass="button" ValidationGroup="grbVar" OnClick="btnSepeteEkle_Click" />
            <asp:Button ID="btnHemenAl" runat="server" Text="Hemen Al" CssClass="button" ValidationGroup="grbVar" OnClick="btnHemenAl_Click" />
        </div>
      </div>
      <!-- Tabs Start -->
      <%--<div id="tabs" class="htabs"> <a href="#tab-description">Description</a> <a href="#tab-review">Reviews</a> </div>--%>
               <%-- <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="694px" class="htabs" CssClass="ajax__tab_panel">
                <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
                   <%-- <HeaderTemplate>
                        Ürün Açıklaması
                    </HeaderTemplate>
                    <ContentTemplate>
                        <asp:Literal ID="ltrlDetay" runat="server"></asp:Literal>
                    </ContentTemplate>--%>
              <%--  </asp:TabPanel>
                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                    <HeaderTemplate>
                        Ürün Yorumları
                    </HeaderTemplate>
                    <ContentTemplate>--%>
                        <%--<table class="auto-style1">
                            <tr>
                                <td>
                                    <asp:Panel ID="PanelUyeOl" runat="server" Visible="False">
                                        Yorum yazabilmek için <a href="/Uyelik/Giris.aspx" class="colr">Üye Girişi</a> yapmalısınız.
                                    </asp:Panel>
                                    <asp:Panel ID="PanelYorumYaz" runat="server" Visible="False" Wrap="False">
                                        <table class="auto-style1">
                                            </tr>
                                                                                            <td class="auto-style5">Yorumunuz :<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtYorum" ErrorMessage="*" ForeColor="Red" ValidationGroup="yorum"></asp:RequiredFieldValidator>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                                                                Kalan Karakter &nbsp&nbsp&nbsp&nbsp<input readonly="readonly" name="remLen" type="text" value="500" size="10" /> </td>

                                            <tr>
                                                </td>
                                                                                            <caption>
                                                                                                <br />
                                                                                                <td>
                                                                                                    <asp:TextBox ID="txtYorum" runat="server" Height="85px" onkeyup="textCounter(this, this.form.remLen, 500);" TextMode="MultiLine" Width="577px"></asp:TextBox>
                                                                                                    <asp:FilteredTextBoxExtender ID="txtYorum_FilteredTextBoxExtender" runat="server" Enabled="True" FilterMode="InvalidChars" InvalidChars="&lt;&gt;" TargetControlID="txtYorum">
                                                                                                    </asp:FilteredTextBoxExtender>
                                                                                                </td>
                                                                                            </caption>
                                            <tr>
                                                <td class="auto-style5">
                                                    <asp:Button ID="btnYorumGonder0" runat="server" CssClass="button" OnClick="btnYorumGonder_Click" Text="Yorumu Gönder" ValidationGroup="yorum" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                                    
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style6"></td>
                                                <td class="auto-style4"></td>
                                                </asp:Panel>
                                            </tr>
                                        </table>--%>
                            <%--        
                                </td>
                            </tr>--%>
                           <%-- <tr>
                                <td class="auto-style4">
                                    <div class="comments">
                                        <h4 class="heading colr">
                                            <asp:Label ID="lblYorumSayisi" runat="server"></asp:Label></h4>
                                        <ul>
                                            <asp:Repeater ID="RpYorumlar" runat="server">
                                                <ItemTemplate>

                                                    <li>
                                                        <div class="says left">
                                                            <h6>
                                                                <p><%#Eval("Ad")%> <%#Eval("Soyad")%></p>
                                                            </h6>
                                                            <div class="clear"></div>
                                                            <p>
                                                                <%#Eval("Tarih")%>
                                                            </p>
                                                        </div>
                                                        <div class="clear"></div>
                                                        <p>
                                                            <%#Kontrol.Yonlendirme(Eval("Yorum").ToString())%>
                                                        </p>

                                                    </li>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                            <cc1:CollectionPager ID="CollectionPager1" runat="server" BackNextButtonStyle="" BackNextDisplay="HyperLinks" BackNextLinkSeparator="·" BackNextLocation="Right" BackNextStyle="" BackText="« Geri" ControlCssClass="" ControlStyle="" FirstText="First" HideOnSinglePage="True" IgnoreQueryString="False" LabelStyle="FONT-WEIGHT: bold;" LabelText="Sayfa:" LastText="Last" MaxPages="10" NextText="İleri »" PageNumbersDisplay="Numbers" PageNumbersSeparator="-" PageNumbersStyle="" PageNumberStyle="" PageSize="5" PagingMode="QueryString" QueryStringKey="Sayfa" ResultsFormat="Listelenen Yorumlar {0}-{1} (toplam {2})" ResultsLocation="Top" ResultsStyle="PADDING-BOTTOM:4px;PADDING-TOP:4px;FONT-WEIGHT: bold;" SectionPadding="10" ShowFirstLast="False" ShowLabel="True" ShowPageNumbers="True" SliderSize="10" UseSlider="True"></cc1:CollectionPager>
                                        </ul>
                                    </div>
                                </td>
                            </tr>--%>
                   <%--     </table>
                    </ContentTemplate>
                </asp:TabPanel>--%>
               <%-- <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                    <HeaderTemplate>
                        Taksit Seçenekleri
                    </HeaderTemplate>
                    <ContentTemplate>--%>
                        <%--<div id="divUyeTaksit" runat="server">

                            <asp:DataList ID="DlTaksit" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" CellPadding="4" ForeColor="#333333">
                                <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <ItemTemplate>


                                    <div class="taksit">
                                        <div class="<%#Eval("BankaCss")%>">
                                            <div class="baslik" style="font-size: large; font-weight: bold"><%#Eval("KartAdi")%>
                                                <img src='/Resimler/Banka/<%#Eval("BankaLogo") %>' width="50" height="25" alt="<%#Eval("KartAdi")%>" title="<%#Eval("KartAdi")%>" />
                                            </div>
                                        </div>
                                        <div class="taskitnum">Taksit</div>
                                        <div class="<%#Eval("FiyatCss")%>"><strong>Taksit Tutarı</strong></div>
                                        <div class="<%#Eval("FiyatCss")%>"><strong>Toplam Tutar</strong></div>
                                        <div class="taskitnum">2</div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("Taksit2").ToString() == "9999,0000" ? "-" :Eval("Taksit2","{0:c}") %></div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("ToplamFiyat2").ToString() == "9999,0000" ? "-" :Eval("ToplamFiyat2","{0:c}") %></div>
                                        <div class="taskitnum">3</div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("Taksit3").ToString() == "9999,0000" ? "-" :Eval("Taksit3","{0:c}") %></div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("ToplamFiyat3").ToString() == "9999,0000" ? "-" :Eval("ToplamFiyat3","{0:c}") %></div>
                                        <div class="taskitnum">4</div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("Taksit4").ToString() == "9999,0000" ? "-" :Eval("Taksit4","{0:c}") %></div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("ToplamFiyat4").ToString() == "9999,0000" ? "-" :Eval("ToplamFiyat4","{0:c}") %></div>
                                        <div class="taskitnum">5</div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("Taksit5").ToString() == "9999,0000" ? "-" :Eval("Taksit5","{0:c}") %></div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("ToplamFiyat5").ToString() == "9999,0000" ? "-" :Eval("ToplamFiyat5","{0:c}") %></div>
                                        <div class="taskitnum">6</div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("Taksit6").ToString() == "9999,0000" ? "-" :Eval("Taksit6","{0:c}") %></div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("ToplamFiyat6").ToString() == "9999,0000" ? "-" :Eval("ToplamFiyat6","{0:c}") %></div>
                                        <div class="taskitnum">7</div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("Taksit7").ToString() == "9999,0000" ? "-" :Eval("Taksit7","{0:c}") %></div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("ToplamFiyat7").ToString() == "9999,0000" ? "-" :Eval("ToplamFiyat7","{0:c}") %></div>
                                        <div class="taskitnum">8</div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("Taksit8").ToString() == "9999,0000" ? "-" :Eval("Taksit8","{0:c}") %></div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("ToplamFiyat8").ToString() == "9999,0000" ? "-" :Eval("ToplamFiyat8","{0:c}") %></div>
                                        <div class="taskitnum">9</div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("Taksit9").ToString() == "9999,0000" ? "-" :Eval("Taksit9","{0:c}") %></div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("ToplamFiyat9").ToString() == "9999,0000" ? "-" :Eval("ToplamFiyat9","{0:c}") %></div>
                                        <div class="taskitnum">10</div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("Taksit10").ToString() == "9999,0000" ? "-" :Eval("Taksit10","{0:c}") %></div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("ToplamFiyat10").ToString() == "9999,0000" ? "-" :Eval("ToplamFiyat10","{0:c}") %></div>
                                        <div class="taskitnum">11</div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("Taksit11").ToString() == "9999,0000" ? "-" :Eval("Taksit11","{0:c}") %></div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("ToplamFiyat11").ToString() == "9999,0000" ? "-" :Eval("ToplamFiyat11","{0:c}") %></div>
                                        <div class="taskitnum">12</div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("Taksit12").ToString() == "9999,0000" ? "-" :Eval("Taksit12","{0:c}") %></div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("ToplamFiyat12").ToString() == "9999,0000" ? "-" :Eval("ToplamFiyat12","{0:c}") %></div>
                                    </div>

                                </ItemTemplate>
                                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            </asp:DataList>
                        </div>--%>
                  <%--  </ContentTemplate>
                </asp:TabPanel>
            </asp:TabContainer>--%>
         <br />
         <%-- Tab2--%>
    <div id="tabs" class="htabs">
        <a href="#tab-description">Ürün Bilgisi</a> <a href="#tab-review">Kullanıcı Görüşleri</a> <a href="#tab-taksit">Taksit Seçenekleri</a>
    </div>
      <div id="tab-description" class="tab-content">
                        <asp:Literal ID="ltrlDetay" runat="server"></asp:Literal>                  
      </div>
      <div class="tab-content" id="tab-review">
        <div class="review-list">       
        <asp:Panel ID="PanelUyeOl" runat="server" Visible="False" Font-Bold="True" Font-Size="Small" ForeColor="#F15A23">
                Yorum yazabilmek için <a href="/Uyelik/Giris.aspx" class="colr" style="font-size: medium; font-weight: bold">Üye Girişi</a> yapmalısınız.
        </asp:Panel><br />           
             <asp:Label ID="lblYorumSayisi" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="Large" ForeColor="#F15A23"></asp:Label>
            <table class="auto-style1">                  
    <asp:Panel ID="PanelYorumYaz" runat="server" Visible="False" Wrap="False">
        <table class="auto-style1">
            <td class="auto-style5">
                <h2>Yorumunuz :</h2><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtYorum" ErrorMessage="*" ForeColor="Red" ValidationGroup="yorum"></asp:RequiredFieldValidator>
            </td>
                <caption>
                    <br />
                    <td>
                        <asp:TextBox ID="txtYorum" runat="server" Height="85px" onkeyup="textCounter(this, this.form.remLen, 500);" TextMode="MultiLine" Width="577px"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="txtYorum_FilteredTextBoxExtender" runat="server" Enabled="True" FilterMode="InvalidChars" InvalidChars="&lt;&gt;" TargetControlID="txtYorum">
                        </asp:FilteredTextBoxExtender>
                    </td>
                </caption>
            <tr>
                <td class="auto-style5" style="text-align: right">
                    Kalan Karakter &nbsp&nbsp&nbsp&nbsp<input readonly="readonly" name="remLen" type="text" value="500" size="1" />
                    <asp:Button ID="btnYorumGonder0" runat="server" CssClass="button" OnClick="btnYorumGonder_Click" Text="Yorumu Gönder" ValidationGroup="yorum" />

                </td>
           
                <td>
                    &nbsp;</td>
            </tr>
  
        </table>
     </asp:Panel>
     <ul>
            <asp:Repeater ID="RpYorumlar" runat="server">
                <ItemTemplate>

                    <li>
                        <div class="says left">
                            <h6>
                                <p style="font-size: small; font-weight: bold; color: #FF3300;"><%#Eval("Ad")%> <%#Eval("Soyad")%></p>
                            </h6>
                            <div class="clear"></div>
                            <p>
                                <%#Eval("Tarih")%>
                            </p>
                        </div>
                        <div class="clear"></div>
                        <p>
                            <%#Kontrol.Yonlendirme(Eval("Yorum").ToString())%>
                        </p>
                    </li>
                </ItemTemplate>
            </asp:Repeater>
            <cc1:CollectionPager ID="CollectionPager1" runat="server" BackNextButtonStyle="" BackNextDisplay="HyperLinks" BackNextLinkSeparator="·" BackNextLocation="Right" BackNextStyle="" BackText="« Geri" ControlCssClass="" ControlStyle="" FirstText="First" HideOnSinglePage="True" IgnoreQueryString="False" LabelStyle="FONT-WEIGHT: bold;" LabelText="Sayfa:" LastText="Last" MaxPages="10" NextText="İleri »" PageNumbersDisplay="Numbers" PageNumbersSeparator="-" PageNumbersStyle="" PageNumberStyle="" PageSize="5" PagingMode="QueryString" QueryStringKey="Sayfa" ResultsFormat="Listelenen Yorumlar {0}-{1} (toplam {2})" ResultsLocation="Top" ResultsStyle="PADDING-BOTTOM:4px;PADDING-TOP:4px;FONT-WEIGHT: bold;" SectionPadding="10" ShowFirstLast="False" ShowLabel="True" ShowPageNumbers="True" SliderSize="10" UseSlider="True"></cc1:CollectionPager>
        </ul>
      </table>
        </div>          
      <!-- Tabs End -->    
    </div>
          <div id="tab-taksit" class="tab-content">
              <div id="divUyeTaksit" runat="server">

                            <asp:DataList ID="DlTaksit" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" CellPadding="4" ForeColor="#333333" Width="599px">
                                <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <ItemTemplate>
                                    <div class="taksit">
                                        <div class="<%#Eval("BankaCss")%>">
                                            <div class="baslik" style="font-size: large; font-weight: bold"><%#Eval("KartAdi")%>
                                                <img src='/Resimler/Banka/<%#Eval("BankaLogo") %>' width="50" height="25" alt="<%#Eval("KartAdi")%>" title="<%#Eval("KartAdi")%>" />
                                            </div>
                                        </div>
                                        <div class="taskitnum">Taksit</div>
                                        <div class="<%#Eval("FiyatCss")%>"><strong>Taksit Tutarı</strong></div>
                                        <div class="<%#Eval("FiyatCss")%>"><strong>Toplam Tutar</strong></div>
                                        <div class="taskitnum">2</div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("Taksit2").ToString() == "9999,0000" ? "-" :Eval("Taksit2","{0:c}") %></div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("ToplamFiyat2").ToString() == "9999,0000" ? "-" :Eval("ToplamFiyat2","{0:c}") %></div>
                                        <div class="taskitnum">3</div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("Taksit3").ToString() == "9999,0000" ? "-" :Eval("Taksit3","{0:c}") %></div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("ToplamFiyat3").ToString() == "9999,0000" ? "-" :Eval("ToplamFiyat3","{0:c}") %></div>
                                        <div class="taskitnum">4</div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("Taksit4").ToString() == "9999,0000" ? "-" :Eval("Taksit4","{0:c}") %></div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("ToplamFiyat4").ToString() == "9999,0000" ? "-" :Eval("ToplamFiyat4","{0:c}") %></div>
                                        <div class="taskitnum">5</div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("Taksit5").ToString() == "9999,0000" ? "-" :Eval("Taksit5","{0:c}") %></div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("ToplamFiyat5").ToString() == "9999,0000" ? "-" :Eval("ToplamFiyat5","{0:c}") %></div>
                                        <div class="taskitnum">6</div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("Taksit6").ToString() == "9999,0000" ? "-" :Eval("Taksit6","{0:c}") %></div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("ToplamFiyat6").ToString() == "9999,0000" ? "-" :Eval("ToplamFiyat6","{0:c}") %></div>
                                        <div class="taskitnum">7</div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("Taksit7").ToString() == "9999,0000" ? "-" :Eval("Taksit7","{0:c}") %></div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("ToplamFiyat7").ToString() == "9999,0000" ? "-" :Eval("ToplamFiyat7","{0:c}") %></div>
                                        <div class="taskitnum">8</div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("Taksit8").ToString() == "9999,0000" ? "-" :Eval("Taksit8","{0:c}") %></div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("ToplamFiyat8").ToString() == "9999,0000" ? "-" :Eval("ToplamFiyat8","{0:c}") %></div>
                                        <div class="taskitnum">9</div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("Taksit9").ToString() == "9999,0000" ? "-" :Eval("Taksit9","{0:c}") %></div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("ToplamFiyat9").ToString() == "9999,0000" ? "-" :Eval("ToplamFiyat9","{0:c}") %></div>
                                        <div class="taskitnum">10</div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("Taksit10").ToString() == "9999,0000" ? "-" :Eval("Taksit10","{0:c}") %></div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("ToplamFiyat10").ToString() == "9999,0000" ? "-" :Eval("ToplamFiyat10","{0:c}") %></div>
                                        <div class="taskitnum">11</div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("Taksit11").ToString() == "9999,0000" ? "-" :Eval("Taksit11","{0:c}") %></div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("ToplamFiyat11").ToString() == "9999,0000" ? "-" :Eval("ToplamFiyat11","{0:c}") %></div>
                                        <div class="taskitnum">12</div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("Taksit12").ToString() == "9999,0000" ? "-" :Eval("Taksit12","{0:c}") %></div>
                                        <div class="<%#Eval("FiyatCss")%>"><%#Eval("ToplamFiyat12").ToString() == "9999,0000" ? "-" :Eval("ToplamFiyat12","{0:c}") %></div>
                                    </div>
                                </ItemTemplate>
                                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            </asp:DataList>
                     </div>      
      </div>
    <!--Middle Part End--></div><br /><br />
     <!-- Related Products Start -->
      
      <!-- Related Products End -->
    <div class="box">
<div class="box-heading">
              <asp:Label ID="lblicerik" runat="server" Text="Benzer Ürünler" Font-Bold="True" Font-Overline="False" Font-Size="XX-Large" ForeColor="#F15A23"></asp:Label>

        </div>
 
          <div class="box-content">
               
          <div class="box-product">
                  <asp:Repeater ID="RpUrunler" runat="server" OnItemCommand="RpUrunler_ItemCommand">
                      <ItemTemplate> 
            <div>
              <div class="image"><a href="/detay-<%#Eval("UrunId")%>-<%#Kontrol.UrlSeo(Eval("UrunAdi").ToString())%>.html"><img src="/Resimler/Urun/150/<%#Eval("AnaResim150")%>" width="180" height="180" alt="<%#Eval("UrunAdi")%>" /></a></div>
              <div class="name"><a href="/detay-<%#Eval("UrunId")%>-<%#Kontrol.UrlSeo(Eval("UrunAdi").ToString())%>.html"><%#Eval("UrunAdi")%></a></div>
              <div class="price"> <%#Eval("SatisFiyatiKdvli", "{0:c}")%> </div>
              <div class="cart">
                          
                  <a href="detay-<%#Eval("UrunId")%>-<%#Kontrol.UrlSeo(Eval("UrunAdi").ToString())%>.html" title="<%#Eval("UrunAdi")%>" class="button">Satın Al</a>
              </div>  
 
            </div>
                </ItemTemplate>
                  </asp:Repeater> 
          </div>
             
        </div>
        
      </div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="cntAlt" runat="server">
     
</asp:Content>
