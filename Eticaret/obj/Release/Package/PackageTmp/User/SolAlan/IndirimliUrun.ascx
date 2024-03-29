<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndirimliUrun.ascx.cs" Inherits="Eticaret.User.SolAlan.IndirimliUrun" %>

<div class="cart_bag_small">
            	<h3 class="head">İndirimli Ürünler</h3>
                <ul>
                    <asp:Repeater ID="Rpindirimli" runat="server">
                        <ItemTemplate>

                	<li>
                    	<div class="thumb"><a href="detail.html"><img src="Resimler/Urun/150/<%#Eval("AnaResim150")%>" width="40" height="35" alt="<%#Eval("UrunAdi")%>" title="<%#Eval("UrunAdi")%>" /></a></div>
                        <div class="desc">
                        	<a href="UrunDetay.aspx"><%#Eval("UrunAdi")%></a>
                        </div>
                    </li>
                    </ItemTemplate>
                    </asp:Repeater>
                </ul>
                <div class="clear"></div>
        	</div>