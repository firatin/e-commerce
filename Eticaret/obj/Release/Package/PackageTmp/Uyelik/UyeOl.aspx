<%@ Page Title="" Language="C#" MasterPageFile="~/Ana.Master" AutoEventWireup="true" CodeBehind="UyeOl.aspx.cs" Inherits="Eticaret.UyeOl" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;

        }

        .auto-style3 {
            width: 18px;
        }

        .auto-style4 {
            width: 155px;
            height: 25px;
        }

        .auto-style5 {
            width: 18px;
            height: 25px;
        }

        .auto-style6 {
            height: 25px;
        }

        .auto-style7 {
            width: 155px;
            height: 28px;
        }

        .auto-style8 {
            width: 18px;
            height: 28px;
        }

        .auto-style9 {
            height: 28px;
        }

        .auto-style10 {
            width: 155px;
            height: 27px;
        }

        .auto-style11 {
            width: 18px;
            height: 27px;
        }

        .auto-style12 {
            height: 27px;
        }

        .auto-style13 {
            width: 155px;
            height: 29px;
        }

        .auto-style14 {
            width: 18px;
            height: 29px;
        }

        .auto-style15 {
            height: 29px;
        }
        .auto-style19 {
            width: 155px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cntSlider" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cntİcerik" runat="server">
    <table class="auto-style1">
     
        <tr>
            <td class="auto-style19">Üyelik Tipi</td>
            <td class="auto-style3">:</td>
            <td style="border-width: medium">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddUyeTipi" runat="server" AutoPostBack="True" Height="40px" Width="175px" OnSelectedIndexChanged="ddUyeTipi_SelectedIndexChanged">
                            <asp:ListItem Value="0">Bireysel</asp:ListItem>
                            <asp:ListItem Value="1">Kurumsal</asp:ListItem>
                        </asp:DropDownList>
               </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        </table>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
                <asp:Panel ID="PanelBayi" runat="server" Visible="False">
    <table class="auto-style1" style="border-width: medium">
      
                    <tr>
                        <td class="auto-style19">Firma Adı</td>
                        <td class="auto-style3">:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirmaAdi" ErrorMessage="Firma Adını Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFirmaAdi" runat="server" CssClass="text"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style19">Vergi Dairesi</td>
                        <td class="auto-style3">:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtVergiDaire" ErrorMessage="Vergi Dairesini Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtVergiDaire" runat="server" CssClass="text" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style19">Vergi No</td>
                        <td class="auto-style3">:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtVergiNo" ErrorMessage="Vergi Numarasını Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtVergiNo" runat="server" CssClass="text" TabIndex="2"></asp:TextBox>
                        </td>
                    </tr>
              
        </table>
                  </asp:Panel>
             </ContentTemplate>
        </asp:UpdatePanel>
    <table class="auto-style1">
        <tr>
            <td class="auto-style19">E-Posta Adresi</td>
            <td class="auto-style3">:<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMail" ErrorMessage="E-Posta Adresinizi Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtMail" ErrorMessage="Mail Adresinizi Kontrol Edin" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="UyeOl">*</asp:RegularExpressionValidator>
            </td>
            <td>
                <asp:TextBox ID="txtMail" runat="server" CssClass="text" TabIndex="3"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style19">Şifre</td>
            <td class="auto-style3">:<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtSifre" ErrorMessage="Şifrenizi Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtSifre" runat="server" CssClass="text" TextMode="Password" TabIndex="4"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style19">Şifre Tekrar</td>
            <td class="auto-style3">:<asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtSifre" ControlToValidate="txtSifreTekrar" ErrorMessage="Şifreler Uyuşmuyor" ForeColor="Red" ValidationGroup="UyeOl">*</asp:CompareValidator>
            </td>
            <td>
                <asp:TextBox ID="txtSifreTekrar" runat="server" CssClass="text" TextMode="Password" TabIndex="5"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style19">Ad</td>
            <td class="auto-style3">:<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAd" ErrorMessage="Adınızı Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtAd" runat="server" CssClass="text" TabIndex="6"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style19">Soyad</td>
            <td class="auto-style3">:<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtSoyad" ErrorMessage="Soyadınızı Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtSoyad" runat="server" CssClass="text" TabIndex="7"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">Gsm</td>
            <td class="auto-style11">:<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtGsm" ErrorMessage="Gsm Numaranızı Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
            </td>
            <td class="auto-style12">
                <asp:TextBox ID="txtGsm" runat="server" CssClass="text" TabIndex="8"></asp:TextBox>
                <asp:MaskedEditExtender ID="txtGsm_MaskedEditExtender" runat="server" Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" Mask="(999)9999999" MaskType="Number" TargetControlID="txtGsm">
                </asp:MaskedEditExtender>
            </td>
        </tr>
        <caption>

            <tr>
                <td class="auto-style4">Tel</td>
                <td class="auto-style5">:</td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtTel" runat="server" CssClass="text" TabIndex="9"></asp:TextBox>
                    <asp:MaskedEditExtender ID="txtTel_MaskedEditExtender" runat="server" Century="2000" CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" TargetControlID="txtTel" Mask="(999)9999999" MaskType="Number">
                    </asp:MaskedEditExtender>
                </td>
            </tr>
            
           <tr>
                <td class="auto-style4">Cinsiyet</td>
                <td class="auto-style5">:</td>
                <td class="auto-style6">
                    <asp:RadioButton ID="RadioBay" runat="server" Checked="True" GroupName="grbuye" Text="Erkek" TabIndex="10" />
                    &nbsp;&nbsp;
                    <asp:RadioButton ID="RadioBayan" runat="server" GroupName="grbuye" Text="Kadın" TabIndex="11" />
                </td>
            </tr>
            <tr>
                <td class="auto-style13">Doğum Tarihi</td>
                <td class="auto-style14">:<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddGun" ErrorMessage="Doğum Tarihiniz (Gün) Seçmediniz" ForeColor="Red" InitialValue="0" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style15">
                    <asp:DropDownList ID="ddGun" runat="server" Width="70px" TabIndex="12">
                        <asp:ListItem Value="0">Gün</asp:ListItem>
                        <asp:ListItem Value="01">01</asp:ListItem>
                        <asp:ListItem Value="02">02</asp:ListItem>
                        <asp:ListItem Value="03">03</asp:ListItem>
                        <asp:ListItem Value="04">04</asp:ListItem>
                        <asp:ListItem Value="05">05</asp:ListItem>
                        <asp:ListItem Value="06">06</asp:ListItem>
                        <asp:ListItem Value="07">07</asp:ListItem>
                        <asp:ListItem Value="08">08</asp:ListItem>
                        <asp:ListItem Value="09">09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>26</asp:ListItem>
                        <asp:ListItem>27</asp:ListItem>
                        <asp:ListItem>28</asp:ListItem>
                        <asp:ListItem>29</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>31</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddAy" ForeColor="Red" InitialValue="0" ValidationGroup="UyeOl" ErrorMessage="Doğum Tarihiniz (Ay) Seçmediniz">*</asp:RequiredFieldValidator>
                    <asp:DropDownList ID="ddAy" runat="server" Width="70px" TabIndex="13">
                        <asp:ListItem Value="0">Ay</asp:ListItem>
                        <asp:ListItem Value="01">Ocak</asp:ListItem>
                        <asp:ListItem Value="02">Şubat</asp:ListItem>
                        <asp:ListItem Value="03">Mart</asp:ListItem>
                        <asp:ListItem Value="04">Nisan</asp:ListItem>
                        <asp:ListItem Value="05">Mayıs</asp:ListItem>
                        <asp:ListItem Value="06">Haziran</asp:ListItem>
                        <asp:ListItem Value="07">Temmuz</asp:ListItem>
                        <asp:ListItem Value="08">Ağustos</asp:ListItem>
                        <asp:ListItem Value="09">Eylül</asp:ListItem>
                        <asp:ListItem Value="10">Ekim</asp:ListItem>
                        <asp:ListItem Value="11">Kasım</asp:ListItem>
                        <asp:ListItem Value="12">Aralık</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddYil" ErrorMessage="Doğum Tarihiniz (Yıl) Seçmediniz" ForeColor="Red" InitialValue="0" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                    <asp:DropDownList ID="ddYil" runat="server" Width="70px" TabIndex="14">
                        <asp:ListItem Value="0">Yıl</asp:ListItem>
                        <asp:ListItem>2003</asp:ListItem>
                        <asp:ListItem>2002</asp:ListItem>
                        <asp:ListItem>2001</asp:ListItem>
                        <asp:ListItem>2000</asp:ListItem>
                        <asp:ListItem>1999</asp:ListItem>
                        <asp:ListItem>1998</asp:ListItem>
                        <asp:ListItem>1997</asp:ListItem>
                        <asp:ListItem>1996</asp:ListItem>
                        <asp:ListItem>1995</asp:ListItem>
                        <asp:ListItem>1994</asp:ListItem>
                        <asp:ListItem>1993</asp:ListItem>
                        <asp:ListItem>1992</asp:ListItem>
                        <asp:ListItem>1991</asp:ListItem>
                        <asp:ListItem>1990</asp:ListItem>
                        <asp:ListItem>1989</asp:ListItem>
                        <asp:ListItem>1988</asp:ListItem>
                        <asp:ListItem>1987</asp:ListItem>
                        <asp:ListItem>1986</asp:ListItem>
                        <asp:ListItem>1985</asp:ListItem>
                        <asp:ListItem>1984</asp:ListItem>
                        <asp:ListItem>1983</asp:ListItem>
                        <asp:ListItem>1982</asp:ListItem>
                        <asp:ListItem>1981</asp:ListItem>
                        <asp:ListItem>1980</asp:ListItem>
                        <asp:ListItem>1979</asp:ListItem>
                        <asp:ListItem>1978</asp:ListItem>
                        <asp:ListItem>1977</asp:ListItem>
                        <asp:ListItem>1976</asp:ListItem>
                        <asp:ListItem>1975</asp:ListItem>
                        <asp:ListItem>1974</asp:ListItem>
                        <asp:ListItem>1973</asp:ListItem>
                        <asp:ListItem>1972</asp:ListItem>
                        <asp:ListItem>1971</asp:ListItem>
                        <asp:ListItem>1970</asp:ListItem>
                        <asp:ListItem>1969</asp:ListItem>
                        <asp:ListItem>1968</asp:ListItem>
                        <asp:ListItem>1967</asp:ListItem>
                        <asp:ListItem>1966</asp:ListItem>
                        <asp:ListItem>1965</asp:ListItem>
                        <asp:ListItem>1964</asp:ListItem>
                        <asp:ListItem>1963</asp:ListItem>
                        <asp:ListItem>1962</asp:ListItem>
                        <asp:ListItem>1961</asp:ListItem>
                        <asp:ListItem>1960</asp:ListItem>
                        <asp:ListItem>1959</asp:ListItem>
                        <asp:ListItem>1958</asp:ListItem>
                        <asp:ListItem>1957</asp:ListItem>
                        <asp:ListItem>1956</asp:ListItem>
                        <asp:ListItem>1955</asp:ListItem>
                        <asp:ListItem>1954</asp:ListItem>
                        <asp:ListItem>1953</asp:ListItem>
                        <asp:ListItem>1952</asp:ListItem>
                        <asp:ListItem>1951</asp:ListItem>
                        <asp:ListItem>1950</asp:ListItem>
                        <asp:ListItem>1949</asp:ListItem>
                        <asp:ListItem>1948</asp:ListItem>
                        <asp:ListItem>1947</asp:ListItem>
                        <asp:ListItem>1946</asp:ListItem>
                        <asp:ListItem>1945</asp:ListItem>
                        <asp:ListItem>1944</asp:ListItem>
                        <asp:ListItem>1943</asp:ListItem>
                        <asp:ListItem>1942</asp:ListItem>
                        <asp:ListItem>1941</asp:ListItem>
                        <asp:ListItem>1940</asp:ListItem>
                        <asp:ListItem>1939</asp:ListItem>
                        <asp:ListItem>1938</asp:ListItem>
                        <asp:ListItem>1937</asp:ListItem>
                        <asp:ListItem>1936</asp:ListItem>
                        <asp:ListItem>1935</asp:ListItem>
                        <asp:ListItem>1934</asp:ListItem>
                        <asp:ListItem>1933</asp:ListItem>
                        <asp:ListItem>1932</asp:ListItem>
                        <asp:ListItem>1931</asp:ListItem>
                        <asp:ListItem>1930</asp:ListItem>
                        <asp:ListItem>1929</asp:ListItem>
                        <asp:ListItem>1928</asp:ListItem>
                        <asp:ListItem>1927</asp:ListItem>
                        <asp:ListItem>1926</asp:ListItem>
                        <asp:ListItem>1925</asp:ListItem>
                        <asp:ListItem>1924</asp:ListItem>
                        <asp:ListItem>1923</asp:ListItem>
                        <asp:ListItem>1922</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style19">İl</td>
                <td class="auto-style3">:<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddil" ErrorMessage="İl Seçiniz" ForeColor="Red" InitialValue="0" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddil" runat="server" AutoPostBack="True" Height="32px" OnSelectedIndexChanged="ddil_SelectedIndexChanged" Width="158px" TabIndex="15">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="auto-style7">İlçe</td>
                <td class="auto-style8">:<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddilce" ErrorMessage="İlçe Seçiniz" ForeColor="Red" InitialValue="0" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                </td>
                <td class="auto-style9">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddilce" runat="server" AutoPostBack="True" Height="32px" Width="158px" TabIndex="16">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style3">:</td>
                <td>
                    <asp:CheckBox ID="cbKampanya" runat="server" Text=" Kampanyalardan e-posta ve sms ile haberdar olmak istiyorum" TabIndex="17" />
                </td>
            </tr>
               </caption>
    </table>
    
       
     <table class="auto-style1">
            <tr>
                <td class="auto-style19">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td>&nbsp;</td>
                <tr>
                    <td class="auto-style19">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td>
                        <asp:Button ID="btnUyeOl" runat="server" CssClass="button" OnClick="btnUyeOl_Click" Text="Üye Ol" ValidationGroup="UyeOl" TabIndex="18" />
                        <br />
                        <br />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="UyeOl" />
                    </td>
                </tr>
            </tr>
        
    </table> 
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cntAlt" runat="server">
</asp:Content>
