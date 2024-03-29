<%@ Page Title="" Language="C#" MasterPageFile="~/Uye/UyeMaster.master" AutoEventWireup="true" CodeBehind="Kargom.aspx.cs" Inherits="Eticaret.Uye.Kargom1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntUye" runat="server">

            <asp:Label ID="lblBilgi" runat="server" Text="KARGO TAKİP" Font-Bold="True" Font-Overline="False" Font-Size="XX-Large" ForeColor="#F15A23"></asp:Label>
         <div style="text-align:right;font-size:15px;" >
        <cc1:CollectionPager ID="CollectionPager1" runat="server" BackText="« Geri" LabelText="Sayfa:" NextText="İleri »" PageNumbersDisplay="Numbers" QueryStringKey="Sayfa" ResultsFormat="" PageSize="20"></cc1:CollectionPager>
    
    </div>
    <div id="divSiparis" runat="server">
 <div class="carthead">
                         <ul class="carthead">
               
                <table style="width: 100%; height: 36px; margin-left: 0px;">
                    <tr>
                           <td style="height: 29px; width: 121px;"><b>Sipariş No</b></td>
                            <td style="height: 29px; width: 133px"><b>Takip No</b></td>
                            <td style="height: 29px; width: 193px"><b>Kargo</b></td>
                            <td style="height: 29px; width: 183px"><b>Kargom Nerede</b></td>
                            <td style="height: 29px"><strong>Detay</strong></td>
                          
                    </tr>
                     <td colspan="7">
                            <hr color="#FF3300" size="10"/>
                        </td>
            </ul>
            <asp:Repeater ID="RpSiparislerim" runat="server">
                <ItemTemplate>
                       
                    <tr>
                        <td style="width: 144px; height: 25px;"><%#Eval("SiparisId")%></td>
                        <td style="width: 155px; height: 25px;"><%#Eval("TakipNo").ToString()%></td>
                        <td style="width: 133px; height: 25px;"><%#Eval("KargoAdi")%></td>
                        <td style="height: 45px"><a class="colr" href="<%#Eval("SorgulaAdres")%>" target="_blank" style="color: #FF3300">Kargoyu Görüntüle</a></td>
                    <td style="height: 45px"><a class="colr" href="Siparislerim.aspx?Detay=<%#Eval("SiparisId")%>&r=Kargo" style="color: #FF3300">Detayı Görüntüle</a></td>
                    </tr>
                     <td colspan="7">
                           <hr />
                        </td>
                </ItemTemplate>
            </asp:Repeater>
            </table>
                             </div>
        </div>
</asp:Content>
