<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="UrunResim.aspx.cs" Inherits="Eticaret.yonetim.UrunResim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style3 {
        width: 82px;
    }
        .auto-style4 {
            width: 86px;
        }
        .auto-style5 {
            width: 85px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <asp:Button ID="Button1" runat="server" CssClass="btn" PostBackUrl="~/yonetim/Urunler.aspx" Text="&lt;&lt; Geri" />
     <br />

     <table class="auto-style1">
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td class="auto-style3">Resim:</td>
        <td>
            <asp:FileUpload ID="FuResim" runat="server"/>
&nbsp;<asp:Button ID="btnResimYukle" runat="server" CssClass="btn" Text="Resim Yükle" OnClick="btnResimYukle_Click" />
        </td>
    </tr>
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td class="auto-style3">&nbsp;</td>
        <td>
            <asp:Label ID="lblResim" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td class="auto-style3">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
    
    <table class="auto-style1">
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td>
     
            <br />
        
                <br />
             <asp:DataList ID="DlisResimler" runat="server" RepeatDirection="Horizontal" RepeatColumns="4">
        <ItemTemplate>
                <table class="auto-style1">
                    
                    <tr>
                        <td>                    <img src="/Resimler/Urun/150/<%#Eval("ResimYolu150")%> " width="170" height="150" alt="" /></td>
                    </tr>
                    <tr>
                        <td> <a href="UrunResim.aspx?UrunId=<%#Eval("UrunId")%>&islem=AnaResim&Resim=<%#Eval("ResimId")%>"> <span class="span-red"><span class="span-red">Ana Resim Yap</span><br /></a>
               <a onclick="return confirm('Bu resmi silmek istediğinizden emin misiniz?');" href="UrunResim.aspx?UrunId=<%#Eval("UrunId")%>&islem=sil&Resim=<%#Eval("ResimId")%>"> <span class="span-red">Resmi Sil</span></a></td>
                    </tr>
          
                </table>
              </ItemTemplate>
    </asp:DataList>
            
            </td>
             
        </tr>
    </table>
    <br />
</asp:Content>
