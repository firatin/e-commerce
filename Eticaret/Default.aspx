<%@ Page Title="" Language="C#" MasterPageFile="~/Ana.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Eticaret.Default" %>

<%@ Register Src="~/user/usOrtailan.ascx" TagPrefix="uc1" TagName="usOrtailan" %>
<%@ Register Src="~/user/usSlider.ascx" TagPrefix="uc1" TagName="usSlider" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <%--  Popup baslangic  --%>    
    <div id="divPopup" runat="server" visible="false">
 
        <div id="popup1">
            <div id="abPopup">
                <div id="ab-ust">
                    <a href="#" id="ab-kapat">Kapat</a>
                    <h2 id="ab-baslik" >
                        <asp:Label ID="lblPBaslik" runat="server" ></asp:Label> </h2>
                </div><!-- ab-ust DIV kapanis -->
                <div id="ab-orta">
                    <p>
                      
                        <asp:Literal ID="ltrlPDetay" runat="server"></asp:Literal>
                    </p>
                </div><!-- ab-orta DIV kapanis -->
                <div id="ab-alt">
                   
                </div><!-- ab-alt DIV kapanis -->
            </div><!-- abPopup DIV kapanis -->
        </div>
           </div>  
  <%-- Popup bitis     --%>    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cntSlider" runat="server"> 
       <%--  Popup baslangic  --%>    
    <div id="div1" runat="server" visible="false">
 
        <div id="Div2">
            <div id="Div3">
                <div id="Div4">
                    <a href="#" id="a1">Kapat</a>
                    <h2 id="H1" >
                        <asp:Label ID="Label1" runat="server" ></asp:Label> </h2>
                </div><!-- ab-ust DIV kapanis -->
                <div id="Div5">
                    <p>
                      
                        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                    </p>
                </div><!-- ab-orta DIV kapanis -->
                <div id="Div6">
                   
                </div><!-- ab-alt DIV kapanis -->
            </div><!-- abPopup DIV kapanis -->
        </div>
           </div>  
  <%-- Popup bitis     --%>                
    <uc1:usSlider runat="server" id="usSlider" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cntİcerik" runat="server">                 
    <uc1:usOrtailan runat="server" ID="usOrtailan" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cntAlt" runat="server">
</asp:Content>
