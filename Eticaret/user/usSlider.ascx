<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="usSlider.ascx.cs" Inherits="Eticaret.user.usSlider" %>

<div id="divslider" runat="server">

    <div class="slider-wrapper">
        <%--<asp:Repeater ID="RpBanner" runat="server">
          <ItemTemplate>--%>
        <div id="SolAlan1" runat="server">
            <div id="slideshow" class="nivoSlider">
                <div id="ress1" runat="server" visible="false"><a href="<%=Adres1%>" target="<%=Acilis1%>" title="<%=Title1%>">
                    <img src="/Resimler/Banner/<%=Res1%>" alt="<%=Title1%>" width="300px" height="300px"/></a></div>
                <div id="ress2" runat="server" visible="false"><a href="<%=Adres2%>" target="<%=Acilis2%>" title="<%=Title2%>">
                    <img src="/Resimler/Banner/<%=Res2%>" alt="<%=Title2%>" width="300px" height="300px"/></a></div>
                <div id="ress3" runat="server" visible="false"><a href="<%=Adres3%>" target="<%=Acilis3%>" title="<%=Title3%>">
                    <img src="/Resimler/Banner/<%=Res3%>" alt="<%=Title3%>" width="300px" height="300px" /></a></div>
                <div id="ress4" runat="server" visible="false"><a  href="<%=Adres4%>" target="<%=Acilis4%>" title="<%=Title4%>">
                    <img src="/Resimler/Banner/<%=Res4%>" alt="<%=Title4%>" width="300px" height="300px" /></a></div>
            </div>
        </div>
        <%--</ItemTemplate>
      </asp:Repeater>--%>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#slideshow').nivoSlider();
        });
    </script>
</div>