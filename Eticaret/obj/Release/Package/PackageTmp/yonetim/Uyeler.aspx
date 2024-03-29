<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="Uyeler.aspx.cs" Inherits="Eticaret.yonetim.Uyeler" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
            <div class="row-fluid">
                    
<div class="btn-toolbar">

    &nbsp;<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Button ID="btnUyeler" runat="server" CssClass="btn" OnClick="btnUyeler_Click" Text="Tüm Üyeler" />
            <asp:Button ID="btnYetkili" runat="server" CssClass="btn" OnClick="btnYetkili_Click" Text="Yetkili Üyeler" />
            <div class="btn-group">
                &nbsp;&nbsp;&nbsp;<asp:Button ID="btnAra" runat="server" CssClass="btn" OnClick="btnAra_Click" Text="Ara" ValidationGroup="grbAra" />
                &nbsp;&nbsp;
            </div>
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAra" ErrorMessage="Lütfen Bir İsim Giriniz" ForeColor="Red" ValidationGroup="grbAra">*</asp:RequiredFieldValidator>
            &nbsp;<asp:TextBox ID="txtAra" runat="server" CssClass="btn-toolbar" Height="16px" ValidationGroup="grbAra"></asp:TextBox>
            <asp:TextBoxWatermarkExtender ID="txtAra_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtAra" WatermarkText="Üye Ad,Email,Tel...">
            </asp:TextBoxWatermarkExtender>
            &nbsp;
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
      <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>             
<div class="well">
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <img src="images/yukleniyor.gif" />
            Yükleniyor...
        </ProgressTemplate>
    </asp:UpdateProgress>
            <asp:Label ID="lblBilgi" runat="server"></asp:Label>
            &nbsp;
            <table class="table">
                <thead>
                    <tr>
                        <th>Adı Soyadı</th>
                        <th>Email</th>
                        <th>Telefon:</th>
                        <th>Cinsiyet:</th>
                        <th>Kayıt Tarihi:</th>
                        <th>Yetki:</th>
                        <th>Üye Tip:</th>
                        <th style="width: 26px;">İşlem</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="RpKayit" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><a href="UyeDuzenle.aspx?UyeId=<%#Eval("UyeId")%>&islem=duzenle" title="Düzenle"><%#Eval("Ad")%> <%#Eval("Soyad")%></a></td>
                                <td><%#Eval("Email")%></td>
                                <td><%#Eval("Tel1")%></td>
                                <td><%#Eval("Cinsiyet")%></td>
                                <td><%#Eval("KayitTarihi")%></td>
                                <td><%#Eval("YetkiAdi")%></td>
                                 <td><%#Eval("Durumadi")%></td>
                                <td><a href="UyeDuzenle.aspx?UyeId=<%#Eval("UyeId")%>&islem=duzenle" title="Düzenle"><i class="icon-pencil"></i></a>
                                 <a onclick="return confirm('Dikkat: (<%#Eval("Ad") %>) Adlı Üyeyi Silmek İstediğinizden Emin Misiniz?');" href="Uyeler.aspx?UyeId=<%#Eval("UyeId")%>&islem=sil" title="Sil"><i class="icon-remove"></i></a></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
      
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
        </div>
</asp:Content>
