<%@ Page Title="" Language="C#" MasterPageFile="~/Ana.Master" AutoEventWireup="true" CodeBehind="KategoriDetay.aspx.cs" Inherits="Eticaret.KategoriDetay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cntSlider" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cntİcerik" runat="server">
   <div class="box">
     <%--   <div class="box-heading">
              <asp:Label ID="lblicerik" runat="server" Text="Ürünler" Font-Bold="True" Font-Overline="False" Font-Size="XX-Large" ForeColor="#F15A23"></asp:Label>

        </div>
  --%>
          <div class="box-content">
               
          <div class="box-product">
                  <asp:Repeater ID="RpUrunler" runat="server">
                      <ItemTemplate> 
            <div>
              <div class="image"><a href="/detay-<%#Eval("UrunId")%>-<%#Kontrol.UrlSeo(Eval("UrunAdi").ToString())%>.html"><img src="/Resimler/Urun/150/<%#Eval("AnaResim150")%>" width="180" height="180" alt="<%#Eval("UrunAdi")%> /></a></div>
              <div class="name"><a href="/detay-<%#Eval("UrunId")%>-<%#Kontrol.UrlSeo(Eval("UrunAdi").ToString())%>.html"><%#Eval("UrunAdi")%></a></div>
              <div class="price"> <%#Eval("SatisFiyatiKdvli", "{0:c}")%> </div>
             <%-- <div class="rating"><img src="image/stars-0.png" alt="Based on 0 reviews." /></div>--%>
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
