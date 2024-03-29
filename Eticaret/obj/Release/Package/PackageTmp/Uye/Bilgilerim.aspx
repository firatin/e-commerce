<%@ Page Title="" Language="C#" MasterPageFile="~/Uye/UyeMaster.master" AutoEventWireup="true" CodeBehind="Bilgilerim.aspx.cs" Inherits="Eticaret.Uye.Bilgilerim" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceUye" runat="server">
    
    <table style="width: 100%">
          <asp:Panel ID="PanelBayi" runat="server">
        <tr>
            <td style="width: 77px">Firma Adı</td>
            <td style="width: 28px">:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirmaAdi" ErrorMessage="Firma Adını Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
            <td>
                            <asp:TextBox ID="txtFirmaAdi" runat="server" CssClass="text"></asp:TextBox>
                        </td>
        </tr>
        <tr>
            <td style="height: 16px; width: 77px">Vergi Dairesi</td>
            <td style="width: 28px; height: 16px">:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtVergiDaire" ErrorMessage="Vergi Dairesini Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
            <td style="height: 16px">
                            <asp:TextBox ID="txtVergiDaire" runat="server" CssClass="text" TabIndex="1"></asp:TextBox>
                        </td>
        </tr>
        <tr>
            <td style="width: 77px">Vergi No</td>
            <td style="width: 28px">:<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtVergiDaire" ErrorMessage="Vergi Dairesini Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
            <td>
                            <asp:TextBox ID="txtVergiNo" runat="server" CssClass="text" TabIndex="2"></asp:TextBox>
                        </td>
        </tr>
</asp:Panel>
        <tr>
            <td style="width: 77px">E-Posta Adresi</td>
            <td style="width: 28px">:<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMail" ErrorMessage="E-Posta Adresinizi Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMail" ErrorMessage="Mail Adresinizi Kontrol Edin" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="UyeOl">*</asp:RegularExpressionValidator>
            </td>
            <td>
                <asp:TextBox ID="txtMail" runat="server" CssClass="text" TabIndex="3" Enabled="False"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 77px">Ad</td>
            <td style="width: 28px">:<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAd" ErrorMessage="Adınızı Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtAd" runat="server" CssClass="text" TabIndex="6"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 77px">Soyad</td>
            <td style="width: 28px">:<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtSoyad" ErrorMessage="Soyadınızı Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtSoyad" runat="server" CssClass="text" TabIndex="7"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 77px">Gsm</td>
            <td style="width: 28px">:<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtGsm" ErrorMessage="Soyadınızı Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtGsm" runat="server" CssClass="text" TabIndex="8"></asp:TextBox>
                <asp:MaskedEditExtender ID="txtGsm_MaskedEditExtender" runat="server" Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="(999)9999999" MaskType="Number" TargetControlID="txtGsm">
                </asp:MaskedEditExtender>
            </td>
        </tr>
        <tr>
            <td style="width: 77px">Tel</td>
            <td style="width: 28px">:</td>
            <td>
                    <asp:TextBox ID="txtTel" runat="server" CssClass="text" TabIndex="9"></asp:TextBox>
                    <asp:MaskedEditExtender ID="txtTel_MaskedEditExtender" runat="server" Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" TargetControlID="txtTel" Mask="(999)9999999" MaskType="Number">
                    </asp:MaskedEditExtender>
                </td>
        </tr>
        <tr>
            <td style="width: 77px; height: 25px;">Cinsiyet</td>
            <td style="width: 28px; height: 25px;">:</td>
            <td style="height: 25px">
                    <asp:RadioButton ID="RadioBay" runat="server" Checked="True" GroupName="grbuye" Text="Erkek" TabIndex="10" />
                    &nbsp;&nbsp;
                    <asp:RadioButton ID="RadioBayan" runat="server" GroupName="grbuye" Text="Kadın" TabIndex="11" />
                </td>
        </tr>
        <tr>
            <td style="width: 77px">Doğum Tarihi</td>
            <td style="width: 28px">:<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtDogumTarihi" ErrorMessage="Doğum Tarihiniz Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                </td>
            <td>
                    <asp:TextBox ID="txtDogumTarihi" runat="server" CssClass="text" TabIndex="9" MaxLength="20"></asp:TextBox>
                    </td>
        </tr>
        <tr>
            <td style="width: 77px">İl</td>
            <td style="width: 28px">:<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddil" ErrorMessage="İl Seçiniz" ForeColor="Red" InitialValue="0" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                </td>
            <td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddil" runat="server" AutoPostBack="True" Height="22px" OnSelectedIndexChanged="ddil_SelectedIndexChanged" TabIndex="15" Width="158px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 77px; height: 25px;">İlçe</td>
            <td style="width: 28px; height: 25px;">:<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddilce" ErrorMessage="İlçe Seçiniz" ForeColor="Red" InitialValue="0" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                </td>
            <td style="height: 25px">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddilce" runat="server" AutoPostBack="True" Height="22px" TabIndex="16" Width="158px">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td style="width: 77px">&nbsp;</td>
            <td style="width: 28px">&nbsp;</td>
            <td>
                    <asp:CheckBox ID="cbKampanya" runat="server" Text=" Kampanyalardan e-posta ve sms ile haberdar olmak istiyorum" TabIndex="17" />
                </td>
        </tr>
        <tr>
            <td style="height: 64px; width: 77px"></td>
            <td style="width: 28px; height: 64px"></td>
            <td style="height: 64px">
                <br />
                <asp:Button ID="btnGuncelle" runat="server" CssClass="button" Text="Bilgileri Güncelle" ValidationGroup="UyeOl" OnClick="btnGuncelle_Click" />
                <br />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="UyeOl" />
                    </td>
        </tr>
    </table>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceUyeTitle" runat="server">
    <asp:Label ID="lblBilgi" runat="server"></asp:Label>
</asp:Content>
