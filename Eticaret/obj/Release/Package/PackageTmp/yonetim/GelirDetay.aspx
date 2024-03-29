<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="GelirDetay.aspx.cs" Inherits="Eticaret.yonetim.GelirDetay" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 80px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        </div>
        <div class="btn-toolbar">
           
                    <div>
                        &nbsp;<asp:Button ID="btnBugun" runat="server" CssClass="btn" OnClick="btnBugun_Click" Text="Bugün" />
                        &nbsp;<asp:Button ID="btnHafta" runat="server" CssClass="btn" Text="Bu Hafta" OnClick="btnHafta_Click" />
                        &nbsp;<asp:Button ID="btnAy" runat="server" CssClass="btn" Text="Bu Ay" OnClick="btnAy_Click" />
                         &nbsp;<asp:Button ID="btnTumu" runat="server" CssClass="btn" Text="Tüm Zamanlar" OnClick="btnTumu_Click" />
                         &nbsp;<asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                <ContentTemplate>
                        &nbsp;&nbsp;<asp:Button ID="btnAra" runat="server" CssClass="btn" Text="Ara" ValidationGroup="grbAra" OnClick="btnAra_Click" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAra" ErrorMessage="Lütfen Bir İsim Giriniz" ForeColor="Red" ValidationGroup="grbAra">*</asp:RequiredFieldValidator>
                        &nbsp;<asp:TextBox ID="txtAra" runat="server" CssClass="btn-toolbar" Height="16px" ValidationGroup="grbAra"></asp:TextBox>
                        <asp:TextBoxWatermarkExtender ID="txtAra_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtAra" WatermarkText="Ara...">
                        </asp:TextBoxWatermarkExtender>
                        &nbsp;<br /> 
                    </div>
                    &nbsp;&nbsp;
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <div class="well">
                    
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                        <ProgressTemplate>
                           
&nbsp;<img src="images/yukleniyor.gif" />
                            Yükleniyor...
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <asp:Label ID="lblBilgi" runat="server" Font-Size="Medium" ForeColor="Maroon" Visible="False"></asp:Label>
                    <div id="divSiparisler" runat="server">
                        <%-- siparişler div--%>

                        <table class="table">
                            <thead>
                                <tr>
                                    <th class="auto-style3">Sipariş No</th>
                                    <th>Üye Adı</th>
                                    <th>Ödeme Tipi</th>
                                    <th>Sipariş Tutarı</th>
                                    <th>Sipariş Tarihi</th>
                                  
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="RpSiparisler" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%#Eval("SiparisId")%></td>
                                            <td><a href="Siparisler.aspx?Uye=<%#Eval("UyeId")%>&islem=uyedetay" title="Üyenin tüm siparişleri" target="_blank"><%#Eval("AdSoyad")%></a></td>
                                            <td><%#Eval("OdemeTip")%></td>
                                            <td><%#Eval("Tutar","{0:c}")%></td>
                                            <td><%#Eval("SiparisTarihi")%></td>
                                          
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                    <%--// siparişler div--%>

                    <asp:Label ID="lblAltBilgi" runat="server" Font-Bold="True" ></asp:Label>
                    </div>
                <div class="pagination">
                    <cc1:CollectionPager ID="CollectionPager1" runat="server" BackText="« Geri"
                        LabelText="Sayfa:" NextText="İleri »" PageNumbersDisplay="Numbers" PageSize="30"
                        ResultsFormat="Gösterilen Kayıtlar {0}-{1} (Toplam {2})"
                        QueryStringKey="Sayfa">
                    </cc1:CollectionPager>
                </div>

                </div>
        </div>
            </ContentTemplate>
           
        </asp:UpdatePanel>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="grbAra" />

    </div>
    
</asp:Content>
