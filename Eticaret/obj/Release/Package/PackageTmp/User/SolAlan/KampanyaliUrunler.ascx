<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KampanyaliUrunler.ascx.cs" Inherits="Eticaret.User.SolAlan.KampanyaliUrunler" %>
<div class="cart_bag_small">
            	<h3 class="head">Kampanyalı Ürünler</h3>
                <ul>
                    <asp:Repeater ID="RpKampanyali" runat="server">
                        <ItemTemplate>

                	<li>
                    	<div class="thumb"><a href="detail.html"><img src="Resimler/Urun/150/<%#Eval("AnaResim150")%>" alt="<%#Eval("UrunAdi")%>" title="<%#Eval("UrunAdi")%>" /></a></div>
                        <div class="desc">
                        	<a href="detail.html"><%#Eval("UrunAdi")%></a>
                        </div>
                    </li>
                    </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="clear"></div>
        	</div>