<%@ Page Title="" Language="C#" MasterPageFile="~/Uye/UyeMaster.master" AutoEventWireup="true" CodeBehind="Sepet.aspx.cs" Inherits="Eticaret.Uye.Sepet1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntUye" runat="server">
            <asp:Label ID="lblBilgi" runat="server" Text="" Font-Bold="True" Font-Overline="False" Font-Size="XX-Large" ForeColor="#F15A23"></asp:Label>
      <div id="divSepet" runat="server">
     <div class="shoppingcart" id="lblKdv">
   <%--    <ul class="carthead">
                	<table style="width: 100%">
                       
                        <tr>
                            <td class="desc bold" style="width: 77px">&nbsp;</td>
                            <td style="width: 259px" class="desc bold">Ürün</td>
                            <td style="width: 150px" class="desc bold">Adet</td>
                            <td class="desc bold" style="width: 153px">Fiyat</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </ul>
               <table style="width: 100%">
                  <%-- <asp:Repeater ID="RpSepet" runat="server" OnItemCommand="RpSepet_ItemCommand" OnItemDataBound="RpSepet_ItemDataBound" >
                       <ItemTemplate>
                       
                    <tr>
                         <td  class="image" style="width: 76px"><a href="/detay-<%#Eval("UrunId")%>-<%#Kontrol.UrlSeo(Eval("UrunAdi").ToString())%>.html" title="<%#Eval("UrunAdi")%>"><img src="/Resimler/Urun/150/<%#Eval("AnaResim150")%>" width="50" alt="" /></a></td>
                        <td class="name" style="width: 261px"><h5><%#Eval("UrunAdi")%></h5></td>
                        <td class="price" style="width: 143px">  <asp:TextBox ID="txtAdet" runat="server" Text='<%#Eval("Miktar")%>' Width="30" Height="19" ></asp:TextBox > 
              	<asp:FilteredTextBoxExtender ID="txtAdet_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtAdet" >
                </asp:FilteredTextBoxExtender>
                            <asp:ImageButton ID="btnGuncelle" runat="server" Text="Güncelle" CommandName="Guncelle" ImageAlign="AbsMiddle" Width="23" CommandArgument='<%#Eval("SepetId")%>' ImageUrl="~/image/update.png" ToolTip="Sepeti güncelle" /></td>
                      <div id="divUyeFiyat" runat="server"><td><h5><%#Eval("UyeSatisFiyatiKdvli","{0:c}")%></h5></td></div>
                           <div id="divBayiFiyat" runat="server">  <td style="width: 141px"><h5><%#Eval("BayiSatisFiyatiKdvli","{0:c}")%></h5></td></div>
                        <td>
                            <asp:ImageButton ID="btnSil" runat="server" Text="Sil" CommandName="Sil" CommandArgument='<%#Eval("SepetId")%>' ImageUrl="/image/remove.png" Width="25" ToolTip="Bu ürünü sepetimden sil" />
                    <asp:ConfirmButtonExtender ID="btnSil_ConfirmButtonExtender" runat="server" ConfirmText="Bu ürünü silmek istediğinizden emin misiniz?" Enabled="True" TargetControlID="btnSil">
                    </asp:ConfirmButtonExtender>
                            </td>
                    </tr>
  </ItemTemplate>
                   </asp:Repeater>
                </table>--%>
          <div class="cart-info">
         <table>
            <thead>
              <tr>
                <td class="desc bold" style="width: 77px">&nbsp;</td>
                            <td style="width: 285px" class="desc bold">Ürün</td>
                 
                            <td style="width: 130px" class="desc bold">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Adet</td>
                            <td style="width: 132px" class="desc bold">Fiyat</td>
                            <td class="desc bold" style="width: 115px">Ürünü Kaldır</td>
              </tr>
            </thead>
            <tbody>
                    <asp:Repeater ID="RpSepet" runat="server" OnItemCommand="RpSepet_ItemCommand" OnItemDataBound="RpSepet_ItemDataBound" >
                    <ItemTemplate>
               <tr>
                         <td  class="image" style="width: 76px"><a href="/detay-<%#Eval("UrunId")%>-<%#Kontrol.UrlSeo(Eval("UrunAdi").ToString())%>.html" title="<%#Eval("UrunAdi")%>"><img src="/Resimler/Urun/150/<%#Eval("AnaResim150")%>" width="50" alt="" /></a></td>
                         <td class="name" style="width: 261px"><h5><%#Eval("UrunAdi")%></h5></td>
                         <td class="price" style="width: 143px">  <asp:TextBox ID="txtAdet" runat="server" Text='<%#Eval("Miktar")%>' Width="30" Height="19" ></asp:TextBox > 
                     <asp:FilteredTextBoxExtender ID="txtAdet_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtAdet" >
                     </asp:FilteredTextBoxExtender>
                     <asp:ImageButton ID="btnGuncelle" runat="server" Text="Güncelle" CommandName="Guncelle" ImageAlign="AbsMiddle" Width="23" CommandArgument='<%#Eval("SepetId")%>' ImageUrl="~/image/update.png" ToolTip="Sepeti güncelle" /></td>
                    <div id="divUyeFiyat" runat="server">
                        <td><h5><%#Eval("UyeSatisFiyatiKdvli","{0:c}")%></h5></td>

                    </div>
                    <div id="divBayiFiyat" runat="server">
                        <td style="width: 141px"><h5><%#Eval("BayiSatisFiyatiKdvli","{0:c}")%></h5></td>

                    </div>
                         <td>
                            <asp:ImageButton ID="btnSil" runat="server" Text="Sil" CommandName="Sil" CommandArgument='<%#Eval("SepetId")%>' ImageUrl="/image/remove.png" Width="25" ToolTip="Bu ürünü sepetimden sil" />
                     <asp:ConfirmButtonExtender ID="btnSil_ConfirmButtonExtender" runat="server" ConfirmText="Bu ürünü silmek istediğinizden emin misiniz?" Enabled="True" TargetControlID="btnSil">
                     </asp:ConfirmButtonExtender>
                         </td>
                    </tr>
                   </ItemTemplate>
                   </asp:Repeater>
            </tbody>
          </table>
&nbsp;<table style="border-width: inherit; width: 100%">
                    <tr>
                        <td style="width: 492px" rowspan="7"></td>
                        <td style="height: 20px; width: 127px"><b>Ara Toplam</b></td>
                        <td style="width: 17px; height: 20px">:</td>
                        <td style="height: 20px">
                            <asp:Label ID="lblAraToplam" runat="server"></asp:Label>
                        </td>
                    </tr>
                     <tr>
                        <td style="height: 20px; width: 127px"><b>KDV</b></td>
                        <td style="width: 17px; height: 20px">:</td>
                        <td style="height: 20px">
                            <asp:Label ID="lblKdvOran" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 20px; width: 127px"><b>Kdv Dahil Toplam Fiyat</b></td>
                        <td style="width: 17px; height: 20px">:</td>
                        <td style="height: 20px">
                            <asp:Label ID="lblKdvDahil" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trHavaleindirim" runat="server">
                        <td style="height: 19px; width: 127px"><b>Havale İndirimi</b></td>
                        <td style="width: 17px; height: 19px">:</td>
                        <td style="height: 19px">
                            <asp:Label ID="lblHavale" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trTekCekimindirim" runat="server">
                        <td style="height: 20px; width: 127px"><b>Tek Çekim İndirimi</b></td>
                        <td style="width: 17px; height: 20px">:</td>
                        <td style="height: 20px">
                            <asp:Label ID="lblTekCekim" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trUrunPuan" runat="server" visible="false">
                        <td style="height: 20px; width: 127px"><b>Puan Kazancınız</b></td>
                        <td style="width: 17px; height: 20px">:</td>
                        <td style="height: 20px">
                            <asp:Label ID="lblPuan" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 52px; width: 127px">
                            &nbsp;</td>
                        <td style="width: 17px; height: 52px">&nbsp;</td>
                        <td style="height: 52px">
                            <asp:Button ID="btnSatinAl" runat="server" CssClass="button" Text="Satın Al" OnClick="btnSatinAl_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div></div>
  <div style="text-align:center">  <asp:Label ID="lblUrunYok" runat="server" CssClass="colr" ></asp:Label>
    </div>  

</asp:Content>
