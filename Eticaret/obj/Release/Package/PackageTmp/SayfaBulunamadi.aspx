<%@ Page Title="" Language="C#" MasterPageFile="~/Ana.Master" AutoEventWireup="true" CodeBehind="SayfaBulunamadi.aspx.cs" Inherits="Eticaret.SayfaBulunamadi" %>

<%@ Register Src="~/user/usOrtailan.ascx" TagPrefix="uc1" TagName="usOrtailan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cntSlider" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cntİcerik" runat="server">
    <uc1:usOrtailan runat="server" ID="usOrtailan" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cntAlt" runat="server">
</asp:Content>
