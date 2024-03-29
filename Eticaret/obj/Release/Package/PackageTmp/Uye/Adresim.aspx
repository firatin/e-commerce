<%@ Page Title="" Language="C#" MasterPageFile="~/Uye/UyeMaster.master" AutoEventWireup="true" CodeBehind="Adresim.aspx.cs" Inherits="Eticaret.Uye.Adresim1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cntUye" runat="server">
        <asp:Label ID="lblBilgi" runat="server" Text="" Font-Bold="True" Font-Overline="False" Font-Size="XX-Large" ForeColor="#F15A23"></asp:Label>

     <table style="width: 100%">
        <tr>
            <td>
                <table style="width: 97%">
                    <tr>
                        <td style="width: 111px; height: 23px;"></td>
                        <td style="width: 21px; height: 23px;"></td>
                        <td style="height: 23px; width: 346px"><strong>Teslimat Adresi</strong></td>
                    </tr>
                    <tr id="trTBayi" runat="server">
                        <td style="width: 111px">Firma Adı</td>
                        <td style="width: 21px">:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirmaAd" ErrorMessage="Teslimat Adresi Firma Adını Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 346px">
                <asp:TextBox ID="txtFirmaAd" runat="server" CssClass="text"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 111px">Ad</td>
                        <td style="width: 21px">:<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAd" ErrorMessage="Teslimat Adresi Adınızı Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 346px">
                <asp:TextBox ID="txtAd" runat="server" CssClass="text" TabIndex="1"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 111px">Soyad</td>
                        <td style="width: 21px">:<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtSoyad" ErrorMessage="Teslimat Adresi Soyadınızı Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 346px">
                <asp:TextBox ID="txtSoyad" runat="server" CssClass="text" TabIndex="2"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 111px; height: 16px">Adres</td>
                        <td style="height: 16px; width: 21px">:<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtAdres" ErrorMessage="Teslimat Adresini Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="height: 16px; width: 346px;">
                <asp:TextBox ID="txtAdres" runat="server" CssClass="text" TabIndex="3" ToolTip="1. Adres satırı" MaxLength="100" Height="60px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td style="width: 111px">&nbsp;</td>
                        <td style="width: 21px">&nbsp;</td>
                        <td style="width: 346px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 111px">Posta Kodu</td>
                        <td style="width: 21px">:</td>
                        <td style="width: 346px">
                <asp:TextBox ID="txtPostaKodu" runat="server" CssClass="text" TabIndex="5"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 111px; height: 33px;">İl</td>
                        <td style="width: 21px; height: 23px;">:<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddil" ErrorMessage="Teslimat Adresi İl Seçiniz" ForeColor="Red" InitialValue="0" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 346px; height: 23px;">
                        <asp:DropDownList ID="ddil" runat="server" AutoPostBack="True" Height="33px" OnSelectedIndexChanged="ddil_SelectedIndexChanged" TabIndex="6" Width="158px">
                        </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 111px">İlçe</td>
                        <td style="width: 21px">:<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddil" ErrorMessage="Teslimat Adresi İlçe Seçiniz" ForeColor="Red" InitialValue="0" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 346px">
                        <asp:DropDownList ID="ddilce" runat="server" AutoPostBack="True" Height="33px" TabIndex="7" Width="158px">
                        </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 111px">Telefon</td>
                        <td style="width: 21px">:<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtTel" ErrorMessage="Teslimat Adresi Numaranızı Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 346px">
                <asp:TextBox ID="txtTel" runat="server" CssClass="text" TabIndex="8"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 111px; height: 27px;">Gsm</td>
                        <td style="width: 21px; height: 27px;">:<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtAd" ErrorMessage="Teslimat Adresi Gsm Numaranızı Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 346px; height: 27px;">
                <asp:TextBox ID="txtGsm" runat="server" CssClass="text" TabIndex="9"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 111px; height: 36px;"></td>
                        <td style="width: 21px; height: 36px;"></td>
                        <td style="width: 346px; height: 36px;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 111px">&nbsp;</td>
                        <td style="width: 21px">&nbsp;</td>
                        <td style="width: 346px">
                            <asp:Button ID="btnKaydet" runat="server" CssClass="button" Text="Bilgilerimi Kaydet" OnClick="btnKaydet_Click" TabIndex="30" ValidationGroup="UyeOl" Width="160px" />
                        </td>
                    </tr>
                </table>
            </td>
            <td> <table style="width: 100%">
                    <tr>
                        <td style="width: 123px; height: 25px;"></td>
                        <td style="width: 21px; height: 25px;"></td>
                        <td style="height: 25px; width: 346px"><strong>Fatura Adresi</strong></td>
                    </tr>
                  <tr id="trFBayi" runat="server">
                        <td style="width: 123px">Firma Adı</td>
                        <td style="width: 21px">:<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtFaturaFirmaAd" ErrorMessage="Fatura Firma Adını Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 346px">
                <asp:TextBox ID="txtFaturaFirmaAd" runat="server" CssClass="text" TabIndex="10"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 123px">Ad</td>
                        <td style="width: 21px">:<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtFaturaAd" ErrorMessage="Fatura Adını Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 346px">
                <asp:TextBox ID="txtFaturaAd" runat="server" CssClass="text" TabIndex="11"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 123px">Soyad</td>
                        <td style="width: 21px">:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFaturaSoyad" ErrorMessage="Fatura Soyadını Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 346px">
                <asp:TextBox ID="txtFaturaSoyad" runat="server" CssClass="text" TabIndex="12"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 123px; height: 16px">Adres</td>
                        <td style="height: 16px; width: 21px">:<asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtFaturaAdres" ErrorMessage="Fatura Adresini Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="height: 16px; width: 346px;">
                <asp:TextBox ID="txtFaturaAdres" runat="server" CssClass="text" TabIndex="13" ToolTip="1. Adres satırı" MaxLength="100" Height="60px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td style="width: 123px">&nbsp;</td>
                        <td style="width: 21px">&nbsp;</td>
                        <td style="width: 346px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 123px">Posta Kodu</td>
                        <td style="width: 21px">:</td>
                        <td style="width: 346px">
                <asp:TextBox ID="txtFaturaPostaKodu" runat="server" CssClass="text" TabIndex="15"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 123px">İl</td>
                        <td style="width: 21px">:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddFaturail" ErrorMessage="Fatura İl Seçiniz" ForeColor="Red" InitialValue="0" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 346px">
                        <asp:DropDownList ID="ddFaturail" runat="server" AutoPostBack="True" Height="33px" OnSelectedIndexChanged="ddFaturail_SelectedIndexChanged" TabIndex="16" Width="158px">
                        </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 123px">İlçe</td>
                        <td style="width: 21px">:<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddFaturailce" ErrorMessage="Fatura İlçe Seçiniz" ForeColor="Red" InitialValue="0" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 346px">
                        <asp:DropDownList ID="ddFaturailce" runat="server" AutoPostBack="True" Height="33px" TabIndex="17" Width="158px">
                        </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 123px">Telefon</td>
                        <td style="width: 21px">:<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFaturaTel" ErrorMessage="Fatura Telefon Numaranızı Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 346px">
                <asp:TextBox ID="txtFaturaTel" runat="server" CssClass="text" TabIndex="18"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 123px">Gsm</td>
                        <td style="width: 21px">:<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtFaturaGsm" ErrorMessage="Fatura Gsm Numaranızı Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 346px">
                <asp:TextBox ID="txtFaturaGsm" runat="server" CssClass="text" TabIndex="19"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 123px; height: 44px;">TC - Vergi No:</td>
                        <td style="width: 21px; height: 44px;"><asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtTcVergi" ErrorMessage="Tc Kimlik veya Veri Numaranızı giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
                        <td style="width: 346px; height: 44px;">
                <asp:TextBox ID="txtTcVergi" runat="server" CssClass="text" TabIndex="20"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 123px; height: 16px;"></td>
                        <td style="width: 21px; height: 16px;"></td>
                        <td style="width: 346px; height: 16px;">
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>
            </td></td>
        </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="UyeOl" />

    
</asp:Content>
