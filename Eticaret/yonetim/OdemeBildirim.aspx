<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="OdemeBildirim.aspx.cs" Inherits="Eticaret.yonetim.OdemeBildirim" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 56px;
        }

        .auto-style2 {
            width: 26px;
            height: 56px;
        }

        .auto-style3 {
            width: 100%;
        }

        .auto-style5 {
            width: 20px;
        }

        .auto-style6 {
            width: 146px;
            height: 29px;
        }

        .auto-style7 {
            width: 20px;
            height: 29px;
        }

        .auto-style8 {
            height: 29px;
        }

        .auto-style10 {
            width: 20px;
            height: 33px;
        }

        .auto-style11 {
            height: 33px;
        }

        .auto-style12 {
            width: 146px;
            height: 35px;
        }

        .auto-style13 {
            width: 20px;
            height: 35px;
        }

        .auto-style14 {
            height: 35px;
        }

        .auto-style15 {
            width: 146px;
            height: 32px;
        }

        .auto-style16 {
            width: 20px;
            height: 32px;
        }

        .auto-style17 {
            height: 32px;
        }

        .auto-style18 {
            width: 146px;
            height: 30px;
        }

        .auto-style19 {
            width: 20px;
            height: 30px;
        }

        .auto-style20 {
            height: 30px;
        }

        .auto-style21 {
            width: 146px;
            height: 31px;
        }

        .auto-style22 {
            width: 20px;
            height: 31px;
        }

        .auto-style23 {
            height: 31px;
        }

        .auto-style24 {
            width: 146px;
            height: 34px;
        }

        .auto-style25 {
            width: 20px;
            height: 34px;
        }

        .auto-style26 {
            height: 34px;
        }
        .auto-style27 {
            width: 146px;
            height: 33px;
        }
        .auto-style28 {
            width: 146px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel ID="PanelAna" runat="server">


        <div class="btn-toolbar">
           
    &nbsp;<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
           
            <div class="btn-group">
                &nbsp;<asp:Button ID="btnBildirimler" runat="server" CssClass="btn" OnClick="btnBildirimler_Click" Text="Tüm Bildirimler" />
                &nbsp;&nbsp;<asp:Button ID="btnAra" runat="server" CssClass="btn" OnClick="btnAra_Click" Text="Ara" ValidationGroup="grbAra" />
                &nbsp;&nbsp;
            </div>
            &nbsp;
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAra" ErrorMessage="Lütfen Bir İsim Giriniz" ForeColor="Red" ValidationGroup="grbAra">*</asp:RequiredFieldValidator>
            &nbsp;<asp:TextBox ID="txtAra" runat="server" CssClass="btn-toolbar" Height="16px" ValidationGroup="grbAra"></asp:TextBox>
            <asp:TextBoxWatermarkExtender ID="txtAra_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtAra" WatermarkText="Ad Soyad,Konu...">
            </asp:TextBoxWatermarkExtender>
            &nbsp;
        </ContentTemplate>
    </asp:UpdatePanel>
        </div>
         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>   
        <div class="well">
            <asp:Label ID="lblBilgi" runat="server"></asp:Label>
            &nbsp;
           <table class="table">
               <thead>
                   <tr>
                       <th class="auto-style1">Adı Soyadı</th>
                       <th class="auto-style1">Email</th>
                       <th class="auto-style1">Ödenen Miktar</th>
                       <th class="auto-style1">Ödemeyi Yapan</th>
                       <th class="auto-style1">Ödemeyi Yöntemi</th>
                       <th class="auto-style1">Tel</th>
                       <th class="auto-style1">Tarih</th>
                       <th class="auto-style1">Okuma</th>
                       <th class="auto-style2">İşlem:</th>
                   </tr>
               </thead>
               <tbody>
                   <asp:Repeater ID="RpKayit" runat="server">
                       <ItemTemplate>
                           <tr>

                               <td><a href="OdemeBildirim.aspx?islem=detay&OdemeId=<%#Eval("OdemeId")%>"><%#Eval("AdSoyad")%></a></td>
                               <td><%#Eval("Email")%></td>
                               <td><%#Eval("OdenenTutar")%></td>
                               <td><%#Eval("OdemeYapanAdSoyad")%></td>
                                <td><%#Eval("OdemeSekli")%></td>
                               <td><%#Eval("Tel")%></td>
                               <td><%#Eval("Tarih")%></td>
                               <td><%#Eval("DurumAdi")%></td>

                               <td><a href="OdemeBildirim.aspx?islem=detay&OdemeId=<%#Eval("OdemeId")%>" title="Detayı Görüntüle"><i class="icon-pencil"></i></a>
                                   <a onclick="return confirm('Dikkat: Silmek İstediğinizden Emin Misiniz?');" href="OdemeBildirim.aspx?OdemeId=<%#Eval("OdemeId")%>&islem=sil" title="Sil"><i class="icon-remove"></i></a></td>
                           </tr>
                       </ItemTemplate>
                   </asp:Repeater>
               </tbody>
           </table>

        </div>
        <div class="pagination">
            <cc1:CollectionPager ID="CollectionPager1" runat="server" BackText="« Geri"
                LabelText="Sayfa:" NextText="İleri »" PageNumbersDisplay="Numbers" PageSize="20"
                ResultsFormat="Gösterilen Kayıtlar {0}-{1} (Toplam {2})"
                QueryStringKey="Sayfa">
            </cc1:CollectionPager>
        </div>
 </ContentTemplate>
    </asp:UpdatePanel>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="grbAra" />
        </div>
        </div>
    
             
    </asp:Panel>
    <asp:Panel ID="PanelDetay" runat="server" ViewStateMode="Disabled" Visible="False">
        <table class="auto-style3">
            <tr>
                <td class="auto-style6">Adı Soyadı</td>
                <td class="auto-style7">:</td>
                <td class="auto-style8">
                    <asp:Label ID="lblAdSoyad" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style27">Email</td>
                <td class="auto-style10">:</td>
                <td class="auto-style11">
                    <asp:Label ID="lblMail" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style27">Ödenen Miktar</td>
                <td class="auto-style10">:</td>
                <td class="auto-style11">
                    <asp:Label ID="lblOdenenMiktar" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">Ödemeyi Yapan</td>
                <td class="auto-style13">:</td>
                <td class="auto-style14">
                    <asp:Label ID="lblOdemeYapan" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style15">Ödeme Yapılan Banka</td>
                <td class="auto-style16">:</td>
                <td class="auto-style17">
                    <asp:Label ID="lblBanka" runat="server"></asp:Label>
                </td>
            </tr
            <tr>
            </tr>
            <td class="auto-style15">Ödeme Yöntemi</td>
            <td class="auto-style16">:</td>
            <td class="auto-style17">
                <asp:Label ID="lblOdemeYontemi" runat="server"></asp:Label>
            </td>
            <tr>
                <td class="auto-style18">Telefon Numarası</td>
                <td class="auto-style19">:</td>
                <td class="auto-style20">
                    <asp:Label ID="lblTel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style21">Açıklama</td>
                <td class="auto-style22">:</td>
                <td class="auto-style23">
                    <asp:Label ID="lblAciklama" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style24">Bildirim Tarihi</td>
                <td class="auto-style25">:</td>
                <td class="auto-style26">
                    <asp:Label ID="lblTarih" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style28">İp Numarası</td>
                <td class="auto-style5">:</td>
                <td>
                    <asp:Label ID="lblip" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style28">&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>
                    <asp:Button ID="btnGeri" runat="server" CssClass="btn" OnClick="btnGeri_Click" Text="&lt;&lt; Geri" />
                </td>
            </tr>
        </table>


    </asp:Panel>
</asp:Content>
