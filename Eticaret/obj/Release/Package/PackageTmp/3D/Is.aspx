<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Is.aspx.cs" Inherits="Eticaret._3D.Is" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .auto-style1 {
            width: 135px;
        }
        .auto-style2 {
            width: 135px;
            height: 24px;
        }
        .auto-style3 {
            height: 24px;
        }
        .auto-style4 {
            width: 135px;
            height: 29px;
        }
        .auto-style5 {
            height: 29px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentSlider" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentSolAlan" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceMaster2" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentOrtaUrunler" runat="server">
     <input type="hidden" name="clientid" value="<%=CliendId%>" />
    <input type="hidden" name="amount" value="1.00" />
    <input type="hidden" name="storekey" value="<%=strKey%>" />
    <input type="hidden" name="taksit" value="" />

    <input type="hidden" name="Currency" value="949" />
    <input type="hidden" name="oid" value="" />
    <input type="hidden" name="okUrl" value="https://magazam.com.tr/odemesayfasi" />
    <input type="hidden" name="failUrl" value="https://magazam.com.tr/hatasayfasi" />
    <input type="hidden" name="islemtipi" value="Auth" />
    <input type="hidden" name="hash" value="VBDuNtC5psXG9j5izUuh6kkFay0=" />
    <input type="hidden" name="storetype" value="3D_Pay_Hosting" />
    <input type="hidden" name="refreshtime" value="10" />
    <input type="hidden" name="lang" value="tr" />
    <input type="hidden" name="firmaadi" value="<%=ffirmaadi%>" />
    <input type="hidden" name="fismi" value="<%=fismi%>" />
    <input type="hidden" name="faturaFirma" value="<%=ffirmaadi%>" />
    <input type="hidden" name="Fadres" value="<%=Fadres%>" />

    <input type="hidden" name="Fil" value="<%=Fil%>" />
    <input type="hidden" name="Filce" value="<%=Filce%>" />
    <input type="hidden" name="Fpostakodu" value="<%=FPostaKodu%>" />
    <input type="hidden" name="tel" value="<%=ttel%>" />
    <input type="hidden" name="fulkekod" value="tr" />
    <input type="hidden" name="nakliyeFirma" value="" />
    <input type="hidden" name="tismi" value="<%=tismi%>" />
    <input type="hidden" name="tadres" value="<%=tadres%>" />

    <input type="hidden" name="til" value="<%=til%>" />
    <input type="hidden" name="tilce" value="<%=tilce%>" />
    <input type="hidden" name="tpostakodu" value="<%=tpostakodu%>" />
    <input id="Hidden1" type="hidden" runat="server" name="tulkekod" value="tr" />
    <input type="hidden" name="itemnumber1" value="" />
    <input type="hidden" name="productcode1" value="" />
    <input type="hidden" name="qty1" value="3" />
    <input type="hidden" name="desc1" value="a4 desc" />
    <input type="hidden" name="id1" value="a5" />
    <input type="hidden" name="price1" value="6.25" />
    <input type="hidden" name="total1" value="7.50" />
    <%--<input type="hidden" name="pan" value="4508034508034509">
    <input type="hidden" name="Ecom_Payment_Card_ExpDate_Year" value="16" >
    <input type="hidden" name="Ecom_Payment_Card_ExpDate_Month" value="12">--%>
    <input type="hidden" name="sID" value="1" />

    <table class="small-12">
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style3">İşlemi onayladıktan sonra ödeme sayfasına yönlendirileceksiniz.</td>
        </tr>
        <tr>
            <td class="auto-style4">İşlem Tutarı:</td>
            <td class="auto-style5">
                <asp:Label ID="lblTutar" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">İşlem Onayı:</td>
            <td>
                <asp:Button ID="btnOnay" runat="server" CssClass="btn2" Text="İşlemi Onaylayın" PostBackUrl="https://testsanalpos.est.com.tr/servlet/est3Dgate" />
            </td>
        </tr>
    </table>
</asp:Content>
