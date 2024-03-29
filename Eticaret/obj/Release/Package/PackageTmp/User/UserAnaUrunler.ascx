<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserAnaUrunler.ascx.cs" Inherits="Eticaret.User.UserAnaUrunler" %>

<div class="listingbasic">
          <asp:DataList ID="RpUrunler" runat="server" RepeatColumns="4" OnItemCommand="RpUrunler_ItemCommand" RepeatDirection="Horizontal">
    <ItemTemplate>
            	<ul>
                
                    <li>
                     
                    	<h6 title="<%#Eval("UrunAdi")%>"><a href="detay-<%#Eval("UrunId")%>-<%#Kontrol.UrlSeo(Eval("UrunAdi").ToString())%>.html" class="bold"><%#Eval("UrunAdi")%></a></h6>
                        <a href="detay-<%#Eval("UrunId")%>-<%#Kontrol.UrlSeo(Eval("UrunAdi").ToString())%>.html" class="thumb"><img src="/Resimler/Urun/150/<%#Eval("AnaResim150")%>" width="140" height="140" alt="<%#Eval("UrunAdi")%>" /></a>
                        <p class="bold colr"><%#Eval("SatisFiyatiKdvli", "{0:c}")%></p>

                      
                        <div class="list_btn">
                        	<%-- <a href="detay-<%#Eval("UrunId")%>-<%#Kontrol.UrlSeo(Eval("UrunAdi").ToString())%>.html" class="button"><span>Detay</span></a>--%>
                           <asp:Button ID="btnSepeteEkle" runat="server" CssClass="button" Text="Sepete Ekle" CommandName="SepeteEkle" CommandArgument='<%#Eval("UrunId")%>' />
                        </div>
                    </li>
                
                </ul>
             
   </ItemTemplate>
</asp:DataList>
            </div>





