<%@ Page Title="" Language="C#" MasterPageFile="~/Uye/UyeMaster.master" AutoEventWireup="true" CodeBehind="Siparislerim.aspx.cs" Inherits="Eticaret.Uye.Siparislerim1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cntUye" runat="server">
                    <asp:Label ID="lblBilgi" runat="server" Text="" Font-Bold="True" Font-Overline="False" Font-Size="XX-Large" ForeColor="#F15A23"></asp:Label>
    <div style="text-align:right;font-size:15px;" >
        <cc1:CollectionPager ID="CollectionPager1" runat="server" BackText="« Geri" LabelText="Sayfa:" NextText="İleri »" PageNumbersDisplay="Numbers" QueryStringKey="Sayfa" ResultsFormat="" PageSize="20"></cc1:CollectionPager>
    
    </div>
   
    <div id="divSiparis" runat="server">
        <div class="shoppingcart">
            <ul class="carthead">

                <table style="width: 100%; height: 36px;">
                    <tr>
                        <td style="height: 29px"><b>Sipariş No</b></td>
                        <td style="height: 29px; width: 104px"><b>Sipariş Tarihi</b></td>
                        <td style="height: 29px; width: 135px"><b>Sipariş Durumu</b></td>
                        <td style="height: 29px; width: 113px"><b>Sipariş Tutarı</b></td>
                        <td style="height: 29px"><b>Ödeme Tipi</b></td>
                        <td style="height: 29px"><b>İşlem</b></td>
                        <td style="height: 29px"><strong>Detay</strong></td>
                    </tr>
            </ul>
            <asp:Repeater ID="RpSiparislerim" runat="server" OnItemCommand="RpSiparislerim_ItemCommand">

                <ItemTemplate>

                    <tr>
                        <td style="width: 104px; height: 25px;"><%#Eval("SiparisId")%></td>
                        <td style="width: 135px; height: 25px;"><%#Eval("SiparisTarihi").ToString()%></td>
                        <td style="width: 113px; height: 25px;"><%#Eval("DurumAdi")%></td>
                        <td style="height: 25px"><%#Eval("Tutar","{0:c}")%></td>
                        <td style="height: 25px"><%#Eval("OdemeTip")%></td>
                        <td>
                            <asp:ImageButton ID="btniptalEt" runat="server" CommandName="iptalEt" CommandArgument='<%#Eval("SiparisId")%>' ToolTip='<%#Eval("iptalonay")%>' ImageUrl='<%#Eval("iptalresim")%>' Width="20px" />
                            <asp:ConfirmButtonExtender ID="btniptalEt_ConfirmButtonExtender" runat="server" ConfirmText="Bu siparişi iptal etmek istediğinizden emin misiniz?" Enabled="True" TargetControlID="btniptalEt">
                            </asp:ConfirmButtonExtender>
                        </td>
                        <td style="height: 25px"><a class="colr" href="Siparislerim.aspx?Detay=<%#Eval("SiparisId")%>">Detay</a></td>
                    </tr>

                </ItemTemplate>
                <SeparatorTemplate>
                    <tr>
                        <td colspan="7">
                            <hr />
                        </td>
                    </tr>
                </SeparatorTemplate>
            </asp:Repeater>
            </table>
        </div>
    </div>

    <%-- detay   --%>

    <div id="divSiparisDetay" runat="server">
        <div class="shoppingcart">
            <ul class="carthead">

                <table style="width: 100%; height: 36px;">

                    <tr>
                        <td style="height: 29px; width: 98px;"><b>Sipariş No</b></td>
                        <td style="height: 29px; width: 195px;"><b>Ürün</b></td>
                        <td style="height: 29px; width: 64px;"><b>Ürün Adeti</b></td>
                        <td style="height: 29px; width: 129px"><b>Sipariş Tarihi</b></td>
                        <td style="height: 29px; width: 138px"><b>Teslimat Tarihi</b></td>
                        <td style="height: 29px; width: 135px"><b>Kargo</b></td>
                        <td style="height: 29px"><b>İşlem</b></td>

                    </tr>
            </ul>
            <asp:Repeater ID="RpSiparisDetay" runat="server" OnItemCommand="RpSiparisDetay_ItemCommand">
                <SeparatorTemplate>
                    <tr>
                        <td colspan="7">
                            <hr />
                        </td>
                    </tr>
                </SeparatorTemplate>
                <ItemTemplate>


                    <tr>
                        <td style="width: 104px; height: 25px;"><%#Eval("SiparisId")%></td>
                        <td style="width: 135px; height: 25px;"><%#Eval("UrunAdi").ToString()%></td>
                        <td style="width: 113px; height: 25px;"><%#Eval("Miktar")%></td>
                        <td style="height: 25px"><%#Eval("SiparisTarihi")%></td>
                        <td style="height: 25px"><%#Eval("TeslimTarihi")%></td>
                        <td style="height: 25px"><%#Eval("KargoAdi")%></td>
                        <td>
                            <asp:ImageButton ID="btnDetayiptalEt" runat="server" CommandName="iptalEt" CommandArgument='<%#Eval("SepetId")%>' ToolTip='<%#Eval("iptalonay")%>' ImageUrl='<%#Eval("iptalresim")%>' Width="20px" />
                            <asp:ConfirmButtonExtender ID="btnDetayiptalEt_ConfirmButtonExtender" runat="server" ConfirmText="Bu siparişi iptal etmek istediğinizden emin misiniz?" Enabled="True" TargetControlID="btnDetayiptalEt">
                            </asp:ConfirmButtonExtender>
                        </td>

                    </tr>
                </ItemTemplate>

            </asp:Repeater>
            </table>
        
        </div>

    </div>
  
  

 &nbsp;<asp:Button ID="btnGeri" runat="server" CssClass="button" OnClick="btnGeri_Click" Text="&lt;&lt; Geri" Visible="False" />
</asp:Content>
