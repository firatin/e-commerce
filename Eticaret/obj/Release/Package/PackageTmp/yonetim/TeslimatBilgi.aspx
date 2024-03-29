<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="TeslimatBilgi.aspx.cs" Inherits="Eticaret.yonetim.TeslimatBilgi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .auto-style11 {
            width: 20px;
        }
        .auto-style12 {
            width: 7px;
        }
        .auto-style18 {
            width: 278px;
        }
        .auto-style20 {
            width: 180px;
        }
        .auto-style21 {
            height: 35px;
            width: 14px;
        }
        .auto-style22 {
            width: 20px;
            height: 35px;
        }
        .auto-style23 {
            width: 278px;
            height: 35px;
        }
        .auto-style24 {
            width: 180px;
            height: 35px;
        }
        .auto-style25 {
            width: 7px;
            height: 35px;
        }
        .auto-style26 {
            height: 72px;
            width: 14px;
        }
        .auto-style27 {
            width: 20px;
            height: 72px;
        }
        .auto-style28 {
            width: 278px;
            height: 72px;
        }
        .auto-style29 {
            width: 180px;
            height: 72px;
        }
        .auto-style30 {
            width: 7px;
            height: 72px;
        }
        .auto-style32 {
            height: 35px;
            width: 117px;
        }
        .auto-style33 {
            height: 72px;
            width: 117px;
        }
        .auto-style34 {
            width: 117px;
        }
        .auto-style35 {
            width: 14px;
        }
         .auto-style36 {
             height: 38px;
             width: 117px;
         }
         .auto-style37 {
             width: 20px;
             height: 38px;
         }
         .auto-style38 {
             width: 278px;
             height: 38px;
         }
         .auto-style39 {
             height: 38px;
             width: 14px;
         }
         .auto-style40 {
             width: 180px;
             height: 38px;
         }
         .auto-style41 {
             width: 7px;
             height: 38px;
         }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnGeri" runat="server" Text="<< Geri" CssClass="btn" OnClick="btnGeri_Click" />
    <table style="width:70%";>
        <tr>
            <td class="auto-style36"></td>
            <td class="auto-style37"></td>
            <td class="auto-style38"><b>Teslimat Adresi</td>
            <td class="auto-style39"></td>
            <td class="auto-style40"></td>
            <td class="auto-style37"></td>
            <td class="auto-style41"><strong>Fatura Adresi</strong></td>
        </tr>
        <tr id="trTBayi" runat="server">
            <td class="auto-style32">Firma Adı</td>
            <td class="auto-style22">:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirmaAd" ErrorMessage="Teslimat Adresi Firma Adını Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
            <td class="auto-style23">
                <asp:TextBox ID="txtFirmaAd" runat="server" CssClass="txt" Width="200px"></asp:TextBox>
                        </td>
            <td class="auto-style21"></td>
            <td class="auto-style24">Firma Adı</td>
            <td class="auto-style22">:<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtFaturaFirmaAd" ErrorMessage="Fatura Firma Adını Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
            <td class="auto-style25">
                <asp:TextBox ID="txtFaturaFirmaAd" runat="server" CssClass="txt" TabIndex="10" Width="200px"></asp:TextBox>
                        </td>
        </tr>
        <tr>
            <td class="auto-style32">Ad</td>
            <td class="auto-style22">:<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtAd" ErrorMessage="Teslimat Adresi Adınızı Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
            <td class="auto-style23">
                <asp:TextBox ID="txtAd" runat="server" CssClass="txt" TabIndex="1" Width="200px"></asp:TextBox>
                        </td>
            <td class="auto-style21"></td>
            <td class="auto-style24">Ad</td>
            <td class="auto-style22">:<asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtFaturaAd" ErrorMessage="Fatura Adını Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
            <td class="auto-style25">
                <asp:TextBox ID="txtFaturaAd" runat="server" CssClass="txt" TabIndex="10" Width="200px"></asp:TextBox>
                        </td>
        </tr>
        <tr>
            <td class="auto-style32">Soyad</td>
            <td class="auto-style22">:<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtSoyad" ErrorMessage="Teslimat Adresi Soyadınızı Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
            <td class="auto-style23">
                <asp:TextBox ID="txtSoyad" runat="server" CssClass="txt" TabIndex="2" Width="200px"></asp:TextBox>
                        </td>
            <td class="auto-style21"></td>
            <td class="auto-style24">Soyad</td>
            <td class="auto-style22">:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFaturaSoyad" ErrorMessage="Fatura Soyadını Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
            <td class="auto-style25">
                <asp:TextBox ID="txtFaturaSoyad" runat="server" CssClass="txt" TabIndex="12" Width="200px"></asp:TextBox>
                        </td>
        </tr>
        <tr>
            <td class="auto-style33">Adres</td>
            <td class="auto-style27">:<asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtAdres" ErrorMessage="Teslimat Adresini Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
            <td class="auto-style28">
                <asp:TextBox ID="txtAdres" runat="server" CssClass="txt" TabIndex="3" ToolTip="1. Adres satırı" MaxLength="100" Height="60px" TextMode="MultiLine" Width="200px"></asp:TextBox>
                        </td>
            <td class="auto-style26"></td>
            <td class="auto-style29">Adres</td>
            <td class="auto-style27"><asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtFaturaAdres" ErrorMessage="Fatura Adresini Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
            <td class="auto-style30">
                <asp:TextBox ID="txtFaturaAdres" runat="server" CssClass="txt" TabIndex="13" ToolTip="1. Adres satırı" MaxLength="100" Height="60px" TextMode="MultiLine" Width="200px"></asp:TextBox>
                        </td>
        </tr>
        <tr>
            <td class="auto-style32">Posta Kodu</td>
            <td class="auto-style22">:</td>
            <td class="auto-style23">
                <asp:TextBox ID="txtPostaKodu" runat="server" CssClass="txt" TabIndex="5" Width="200px"></asp:TextBox>
                        </td>
            <td class="auto-style21"></td>
            <td class="auto-style24">Posta Kodu</td>
            <td class="auto-style22">:</td>
            <td class="auto-style25">
                <asp:TextBox ID="txtFaturaPostaKodu" runat="server" CssClass="txt" TabIndex="15" Width="200px"></asp:TextBox>
                        </td>
        </tr>
        <tr>
            <td class="auto-style32">İl</td>
            <td class="auto-style22">:</td>
            <td class="auto-style23">
                <asp:TextBox ID="txtTil" runat="server" CssClass="txt" TabIndex="5" Width="200px"></asp:TextBox>
                        </td>
            <td class="auto-style21"></td>
            <td class="auto-style24">İl</td>
            <td class="auto-style22">:</td>
            <td class="auto-style25">
                <asp:TextBox ID="txtFil" runat="server" CssClass="txt" TabIndex="5" Width="200px"></asp:TextBox>
                        </td>
        </tr>
        <tr>
            <td class="auto-style32">İlçe</td>
            <td class="auto-style22">:</td>
            <td class="auto-style23">
                <asp:TextBox ID="txtTilce" runat="server" CssClass="txt" TabIndex="5" Width="200px"></asp:TextBox>
                        </td>
            <td class="auto-style21"></td>
            <td class="auto-style24">İlçe</td>
            <td class="auto-style22">:</td>
            <td class="auto-style25">
                <asp:TextBox ID="txtFilce" runat="server" CssClass="txt" TabIndex="5" Width="200px"></asp:TextBox>
                        </td>
        </tr>
        <tr>
            <td class="auto-style32">Telefon</td>
            <td class="auto-style22">:<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtTel" ErrorMessage="Teslimat Adresi Numaranızı Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
            <td class="auto-style23">
                <asp:TextBox ID="txtTel" runat="server" CssClass="txt" TabIndex="8" Width="200px" MaxLength="11"></asp:TextBox>
                        </td>
            <td class="auto-style21"></td>
            <td class="auto-style24">Telefon</td>
            <td class="auto-style22">:<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtFaturaTel" ErrorMessage="Fatura Telefon Numaranızı Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
            <td class="auto-style25">
                <asp:TextBox ID="txtFaturaTel" runat="server" CssClass="txt" TabIndex="18" Width="200px" MaxLength="11"></asp:TextBox>
                        </td>
        </tr>
        <tr>
            <td class="auto-style32">Gsm</td>
            <td class="auto-style22">:<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtGsm" ErrorMessage="Teslimat Adresi Gsm Numaranızı Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
            <td class="auto-style23">
                <asp:TextBox ID="txtGsm" runat="server" CssClass="txt" TabIndex="9" Width="200px" MaxLength="11"></asp:TextBox>
                        </td>
            <td class="auto-style21"></td>
            <td class="auto-style24">Gsm</td>
            <td class="auto-style22">:<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtFaturaGsm" ErrorMessage="Fatura Gsm Numaranızı Giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
            <td class="auto-style25">
                <asp:TextBox ID="txtFaturaGsm" runat="server" CssClass="txt" TabIndex="19" Width="200px" MaxLength="11" ></asp:TextBox>
                        </td>
        </tr>
        <tr>
            <td class="auto-style34">&nbsp;</td>
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style18">
                &nbsp;</td>
            <td class="auto-style35">&nbsp;</td>
            <td class="auto-style20">TC - Vergi No</td>
            <td class="auto-style11">:<asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtTcVergi" ErrorMessage="Tc Kimlik veya Veri Numaranızı giriniz" ForeColor="Red" ValidationGroup="UyeOl">*</asp:RequiredFieldValidator>
                        </td>
            <td class="auto-style12">
                <asp:TextBox ID="txtTcVergi" runat="server" CssClass="txt" TabIndex="20" Width="200px"></asp:TextBox>
                        </td>
        </tr>
        <tr>
            <td class="auto-style34">&nbsp;</td>
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style18">
                            &nbsp;</td>
            <td class="auto-style35">&nbsp;</td>
            <td class="auto-style20">&nbsp;</td>
            <td class="auto-style11">&nbsp;</td>
            <td class="auto-style12">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
