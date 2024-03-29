<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserSlider.ascx.cs" Inherits="Eticaret.User.UserSlider" %>
<div id="divslider" runat="server">  
 <div id="banner" >
        <div id="paginate-slider2" class="banner_nav">
              <asp:Repeater ID="RpBanner" runat="server">
            <ItemTemplate> 
                 <a href="#" title="<%#Eval("Baslik")%>" class="toc"><img src="Resimler/Banner/<%#Eval("Resim")%>"  height="90" width="130" alt="<%#Eval("Baslik")%>" /></a> 
         
                 </ItemTemplate>

        </asp:Repeater>
        </div>
        <div id="slider2">
            <div class="contentdiv banner_sec">
            	<div class="con_img">
                	<a href="<%=Adres1%>" target="<%=Acilis1%>" title="<%=Title1%>"> <img src="Resimler/Banner/<%=Res1%>"  height="300" width="762" alt="<%=Title1%>" /></a>
                </div>
               
            </div>
           <div class="contentdiv banner_sec">
            	<div class="con_img">
                <a href="<%=Adres2%>" target="<%=Acilis2%>" title="<%=Title2%>"> <img src="Resimler/Banner/<%=Res2%>"  height="300" width="762" alt="<%=Title2%>" /></a>
                </div>
               
            </div> 
            <div class="contentdiv banner_sec">
            	<div class="con_img">
                	<a href="<%=Adres3%>" target="<%=Acilis3%>" title="<%=Title3%>"> <img src="Resimler/Banner/<%=Res3%>"  height="300" width="762" alt="<%=Title3%>" /></a>
                </div>
               
            </div>
        </div>
        <script type="text/javascript" src="js/banner.js"></script>
    </div>
    </div> 