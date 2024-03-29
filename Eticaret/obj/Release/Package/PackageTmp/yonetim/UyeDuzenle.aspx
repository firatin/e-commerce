<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="UyeDuzenle.aspx.cs" Inherits="Eticaret.yonetim.UyeDuzenle" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style3 {
            width: 118px;
        }

        .auto-style4 {
            width: 27px;
        }
        .auto-style5 {
            width: 118px;
            height: 41px;
        }
        .auto-style6 {
            width: 27px;
            height: 41px;
        }
        .auto-style7 {
            height: 41px;
        }
         .auto-style9 {
             width: 118px;
             height: 24px;
         }
         .auto-style10 {
             width: 27px;
             height: 24px;
         }
         .auto-style11 {
             height: 24px;
         }
         .auto-style12 {
             width: 53px;
         }
         .auto-style13 {
             width: 50px;
         }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<asp:Panel ID="PanelUye" runat="server">--%>

             <table class="auto-style1">
                 <asp:Panel ID="PanelBayi" runat="server">
                 <tr>
                <td class="auto-style3">Firma Adı</td>
                <td class="auto-style4">:<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtFirmaAdi" ErrorMessage="Firma Adını Yazınız" ForeColor="Red" ValidationGroup="uyeduzenle">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtFirmaAdi" runat="server"></asp:TextBox>
                </td>
            </tr>
                 <tr>
                <td class="auto-style3">Vergi Dairesi</td>
                <td class="auto-style4">:<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtVergiDairesi" ErrorMessage="Vergi Dairesini Yazınız" ForeColor="Red" ValidationGroup="uyeduzenle">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtVergiDairesi" runat="server"></asp:TextBox>
                </td>
            </tr>
                 <tr>
                <td class="auto-style3">Vergi No</td>
                <td class="auto-style4">:<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtVergiNo" ErrorMessage="Vergi Nosunu Yazınız" ForeColor="Red" ValidationGroup="uyeduzenle">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtVergiNo" runat="server"></asp:TextBox>
                </td>
            </tr>
                     </asp:Panel>
            <tr>
                <td class="auto-style3">Ad</td>
                <td class="auto-style4">:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtAdiniz" ErrorMessage="Adınızı Yazınız" ForeColor="Red" ValidationGroup="uyeduzenle">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtAdiniz" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Soyad</td>
                <td class="auto-style4">:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSoyad" ErrorMessage="Soyadınızı Yazınız" ForeColor="Red" ValidationGroup="uyeduzenle">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtSoyad" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Email Adresi</td>
                <td class="auto-style4">:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMail" ErrorMessage="Mail Adresini Yazınız" ForeColor="Red" ValidationGroup="uyeduzenle">*</asp:RequiredFieldValidator>
                    &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMail" ErrorMessage="Mail Formatı Yanlış" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="uyeduzenle">*</asp:RegularExpressionValidator>
                </td>
                <td>
                    <asp:TextBox ID="txtMail" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Cinsiyet</td>
                <td class="auto-style4">:</td>
                <td>
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style13">
                    <asp:RadioButton ID="RadioErkek" runat="server" Text="Erkek" GroupName="radio" />
                            </td>
                            <td>
                    <asp:RadioButton ID="RadioKadin" runat="server" GroupName="radio" Text="Kadın" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
           
            <tr>
                <td class="auto-style5">Doğum Tarihi</td>
                <td class="auto-style6">:</td>
                <td class="auto-style7">
                    <asp:TextBox ID="txtDogum" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Telefon:</td>
                <td class="auto-style4">:</td>
                <td>
                    <asp:TextBox ID="txtTel" runat="server" MaxLength="12"></asp:TextBox>
                    <asp:MaskedEditExtender ID="txtTel_MaskedEditExtender" runat="server" Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="(999)9999999" MaskType="Number" TargetControlID="txtTel">
                    </asp:MaskedEditExtender>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Telefon 2:</td>
                <td class="auto-style4">:</td>
                <td>
                    <asp:TextBox ID="txtTel2" runat="server" MaxLength="12"></asp:TextBox>
                    <asp:MaskedEditExtender ID="txtTel2_MaskedEditExtender" runat="server" Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="(999)9999999" MaskType="Number" TargetControlID="txtTel2">
                    </asp:MaskedEditExtender>
                </td>
            </tr>
           
             <tr>
                <td class="auto-style9">Üye Durum</td>
                <td class="auto-style10">:</td>
                <td class="auto-style11">
                    
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style12">
                                <asp:RadioButton ID="RadioAktif" runat="server" Text="Aktif" GroupName="aktif" />
                            </td>
                            <td>
                                <asp:RadioButton ID="RadioPasif" runat="server" Text="Pasif" GroupName="aktif" />
                            </td>
                        </tr>
                    </table>
                    
                </td>
            </tr>
                  <tr>
                <td class="auto-style9">Üye İp</td>
                <td class="auto-style10">:</td>
                <td class="auto-style11">
   
                    <asp:TextBox ID="txtIp" runat="server"></asp:TextBox>
   
                </td>
            </tr>
                 
                  <tr>
                <td class="auto-style9">Üye Puanı</td>
                <td class="auto-style10">:</td>
                <td class="auto-style11">
   
                    <asp:TextBox ID="txtUyePuan" runat="server"></asp:TextBox>
   
                </td>
            </tr>
                 <tr>
                <td class="auto-style9">Üye Şifre</td>
                <td class="auto-style10">:</td>
                <td class="auto-style11">
   
                    <asp:TextBox ID="txtSifre" runat="server" TextMode="Password"></asp:TextBox>
   
                    <asp:TextBoxWatermarkExtender ID="txtSifre_TextBoxWatermarkExtender" runat="server" Enabled="True" TargetControlID="txtSifre" WatermarkText="******">
                    </asp:TextBoxWatermarkExtender>
   
                </td>
            </tr>
                  <tr>
                <td class="auto-style9">İl</td>
                <td class="auto-style10">:</td>
                <td class="auto-style11">
   
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddil" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddil_SelectedIndexChanged">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
   
                </td>
                  <tr>
                <td class="auto-style9">İlçe</td>
                <td class="auto-style10">:</td>
                <td class="auto-style11">
   
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddilce" runat="server">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
   
                </td>
                  <tr>
                <td class="auto-style9">Üye Tip</td>
                <td class="auto-style10">:</td>
                <td class="auto-style11">
   
                    <asp:DropDownList ID="ddUyeTip" runat="server">
                        <asp:ListItem Value="0">Bireysel Üye</asp:ListItem>
                        <asp:ListItem Value="1">Bayi Üye</asp:ListItem>
                    </asp:DropDownList>
   
                </td>
            </tr>
                  <tr>
                <td class="auto-style9">Üye Yetki</td>
                <td class="auto-style10">:</td>
                <td class="auto-style11">
   
                    <asp:DropDownList ID="ddYetki" runat="server">
                        <asp:ListItem Value="0">Yetki Yok</asp:ListItem>
                        <asp:ListItem Value="1">Yönetici</asp:ListItem>
                    </asp:DropDownList>
   
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    <asp:CheckBox ID="cbHaber" runat="server" Text="Bana uygun kampanyalardan haberdar olmak istiyorum." />
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    <asp:Button ID="btnGuncelle" runat="server" Text="Güncelle" OnClick="btnGuncelle_Click" CssClass="btn" ValidationGroup="uyeduzenle" />
&nbsp;<asp:Button ID="btnGeri" runat="server" CssClass="btn" OnClick="btnGeri_Click" Text="&lt;&lt; Geri" />
                    <br />
                    <asp:Label ID="lblBilgi" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label>
                    &nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="uyeduzenle" />
                </td>
            </tr>
        </table>
            
        <%--</asp:Panel>--%>

        </asp:Content>
