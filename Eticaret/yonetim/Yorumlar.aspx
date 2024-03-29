<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="Yorumlar.aspx.cs" Inherits="Eticaret.yonetim.Yorumlar" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style4 {
            width: 12px;
        }
        .auto-style5 {
            width: 72px;
        }
        .auto-style6 {
            width: 72px;
            height: 30px;
        }
        .auto-style7 {
            width: 12px;
            height: 30px;
        }
        .auto-style8 {
            height: 30px;
        }
        .auto-style9 {
            width: 72px;
            height: 28px;
        }
        .auto-style10 {
            width: 12px;
            height: 28px;
        }
        .auto-style11 {
            height: 28px;
        }
        .auto-style12 {
            width: 72px;
            height: 27px;
        }
        .auto-style13 {
            width: 12px;
            height: 27px;
        }
        .auto-style14 {
            height: 27px;
        }
        .auto-style15 {
            width: 87px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Panel ID="PanelAna" runat="server">
    <div class="container-fluid">
            <div class="row-fluid">
                    
<div class="btn-toolbar">

    &nbsp;<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%><asp:Button ID="btnOnayli" runat="server" CssClass="btn" Text="Onaylı Yorumlar" OnClick="btnOnayli_Click" />
            <asp:Button ID="btnOnayBekleyen" runat="server" CssClass="btn" Text="Onay Bekleyenler" OnClick="btnOnayBekleyen_Click" />
            <div class="btn-group">
                &nbsp;&nbsp;&nbsp;<asp:Button ID="btnAra" runat="server" CssClass="btn" OnClick="btnAra_Click" Text="Ara" ValidationGroup="grbAra" />
                &nbsp;&nbsp;
            </div>
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAra" ErrorMessage="Lütfen Bir İsim Giriniz" ForeColor="Red" ValidationGroup="grbAra">*</asp:RequiredFieldValidator>
            &nbsp;<asp:TextBox ID="txtAra" runat="server" CssClass="btn-toolbar" Height="16px" ValidationGroup="grbAra"></asp:TextBox>
            <asp:TextBoxWatermarkExtender ID="txtAra_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtAra" WatermarkText="Üye Adı,Yorum No">
            </asp:TextBoxWatermarkExtender>
            &nbsp;
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</div>
      <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>  --%>           
<div class="well">
   <%-- <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <img src="images/yukleniyor.gif" />
            Yükleniyor...
        </ProgressTemplate>
    </asp:UpdateProgress>--%>
            <asp:Label ID="lblBilgi" runat="server"></asp:Label>
            &nbsp;
            <table class="table">
                <thead>
                    <tr>
                        <th>Yorum No:</th>
                        <th>Adı Soyadı</th>
                        <th>Ürün Adı</th>
                        <th>Yorum Tarihi</th>
                      
                        <th style="width: 50px;">İşlem</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="RpKayit" runat="server" OnItemCommand="RpKayit_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("YorumId")%></td>
                                <td><a href="Yorumlar.aspx?YorumId=<%#Eval("YorumId")%>&islem=detay" title="Düzenle"><%#Eval("Ad")%> <%#Eval("Soyad")%></a></td>
                                <td><%#Eval("UrunAdi")%></td>
                                <td><%#Eval("Tarih")%></td>
                               <td> <asp:ImageButton ID="btnYorum" runat="server"  CommandName="YorumOnay" CommandArgument='<%#Eval("YorumId")%>' ToolTip='<%#Eval("islemyap")%>' ImageUrl='<%#Eval("yorumresim")%>' Width="18px" />
                                <a href="Yorumlar.aspx?YorumId=<%#Eval("YorumId")%>&islem=detay" title="Düzenle"><i class="icon-pencil"></i></a>
                                 <a onclick="return confirm('Dikkat:   Bu Yorumu Silmek İstediğinizden Emin Misiniz?');" href="Yorumlar.aspx?YorumId=<%#Eval("YorumId")%>&islem=sil" title="Sil"><i class="icon-remove"></i></a></td>
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
      <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="grbAra" />
</div>
        </div>


    </asp:Panel>
    <asp:Panel ID="PanelDetay" runat="server" Visible="False">
        <div class="well">
            <table class="auto-style1">
                <tr>
                    <td class="auto-style5">Aktif</td>
                    <td class="auto-style4">:</td>
                    <td>
                        <asp:CheckBox ID="cbAktif" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6">Adı Soyadı</td>
                    <td class="auto-style7">:</td>
                    <td class="auto-style8">
                        <asp:Label ID="lblAdSoyad" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">Email</td>
                    <td class="auto-style10">:</td>
                    <td class="auto-style11">
                        <asp:Label ID="lblMail" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">Ürün Adı</td>
                    <td class="auto-style13">:</td>
                    <td class="auto-style14">
                        <asp:Label ID="lblUrunAdi" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style12">İp No</td>
                    <td class="auto-style13">:</td>
                    <td class="auto-style14">
                        <asp:Label ID="lblip" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style5">Yorum</td>
                    <td class="auto-style4">:</td>
                    <td>
                        <asp:TextBox ID="txtYorum" runat="server" Height="162px" MaxLength="500" TextMode="MultiLine" Width="460px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style9">&nbsp;</td>
                    <td class="auto-style10"></td>
                    <td class="auto-style11">
                        <asp:Button ID="btnGuncelle" runat="server" CssClass="btn" Text="Güncelle" OnClick="btnGuncelle_Click" />
                        &nbsp;<asp:Button ID="btnVazgec" runat="server" CssClass="btn" Text="&lt;&lt; Geri" OnClick="btnVazgec_Click" />
                    </td>
                </tr>
                
            </table>
            </div>
          <div class="well">
              Bu üyeye ait yorumlar
              <table class="table">
                <thead>
                    <tr>
                        <th>Yorum No:</th>
                        <th>Adı Soyadı</th>
                        <th>Ürün Adı</th>
                        <th>Yorum Tarihi</th>
                         <th>Durum</th>
                       
                        <th style="width: 26px;">İşlem</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="RpUyeyeAitYorumlar" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("YorumId")%></td>
                                <td><a href="Yorumlar.aspx?YorumId=<%#Eval("YorumId")%>&islem=detay" title="Düzenle"><%#Eval("Ad")%> <%#Eval("Soyad")%></a></td>
                                <td><%#Eval("UrunAdi")%></td>
                                <td><%#Eval("Tarih")%></td>
                                <td><%#Eval("DurumAdi")%></td>
                                <td><a href="Yorumlar.aspx?YorumId=<%#Eval("YorumId")%>&islem=detay" title="Düzenle"><i class="icon-pencil"></i></a>
                                 <a onclick="return confirm('Dikkat:   Bu Yorumu Silmek İstediğinizden Emin Misiniz?');" href="Yorumlar.aspx?YorumId=<%#Eval("YorumId")%>&islem=sil" title="Sil"><i class="icon-remove"></i></a></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
      
</div>
<div class="pagination">
  <cc1:CollectionPager ID="CollectionPager2" runat="server" BackText="« Geri" 
                    LabelText="Sayfa:" NextText="İleri »" PageNumbersDisplay="Numbers" PageSize="15" 
                    ResultsFormat="Gösterilen Kayıtlar {0}-{1} (Toplam {2})" 
                    QueryStringKey="Sayfa">
                </cc1:CollectionPager>
</div>
    </asp:Panel>
</asp:Content>
