<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="BankaHesap.aspx.cs" Inherits="Eticaret.yonetim.BankaHesap" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 19px;
        }
        .auto-style4 {
            width: 164px;
            height: 21px;
        }
        .auto-style5 {
            width: 19px;
            height: 21px;
        }
        .auto-style6 {
            height: 21px;
        }
        .auto-style7 {
            width: 164px;
        }
        .auto-style11 {
            width: 164px;
            height: 18px;
        }
        .auto-style12 {
            width: 19px;
            height: 18px;
        }
        .auto-style13 {
            height: 18px;
        }
        .auto-style14 {
            width: 164px;
            height: 20px;
        }
        .auto-style15 {
            width: 19px;
            height: 20px;
        }
        .auto-style16 {
            height: 20px;
        }
        .auto-style17 {
            width: 64px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style4">Banka Adı</td>
            <td class="auto-style5">:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBankaAdi" ErrorMessage="Banka adınızı yazınız" ForeColor="Red" ValidationGroup="grb1">*</asp:RequiredFieldValidator>
            </td>
            <td class="auto-style6">
                <asp:TextBox ID="txtBankaAdi" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Şube Adı</td>
            <td class="auto-style3">:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSubeAdi" ErrorMessage="Şube adını yazınız" ForeColor="Red" ValidationGroup="grb1">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtSubeAdi" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Şube Kodu</td>
            <td class="auto-style3">:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtSubeKodu" ErrorMessage="Şube kodunu yazınız" ForeColor="Red" ValidationGroup="grb1">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:TextBox ID="txtSubeKodu" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style14">Hesap No</td>
            <td class="auto-style15">:<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtBankaAdi" ErrorMessage="Hesap numarasını yazınız" ForeColor="Red" ValidationGroup="grb1">*</asp:RequiredFieldValidator>
            </td>
            <td class="auto-style16">
                <asp:TextBox ID="txtHesapNo" runat="server"></asp:TextBox>
            </td>
        </tr>
       <tr>
            <td class="auto-style11">Hesap Sahibi</td>
            <td class="auto-style12">:<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtBankaAdi" ErrorMessage="Hesap sahibini yazınız" ForeColor="Red" ValidationGroup="grb1">*</asp:RequiredFieldValidator>
            </td>
            <td class="auto-style13">
                <asp:TextBox ID="txtHesapSahibi" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td class="auto-style11">IBAN No</td>
            <td class="auto-style12">:<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtBankaAdi" ErrorMessage="IBAN numarasını yazınız" ForeColor="Red" ValidationGroup="grb1">*</asp:RequiredFieldValidator>
             </td>
            <td class="auto-style13">
                <asp:TextBox ID="txtiban" runat="server"></asp:TextBox>
            &nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="grb1" />
            </td>
        </tr>
        <tr>
            <td class="auto-style11">Durum</td>
            <td class="auto-style12">:</td>
            <td class="auto-style13">
                <asp:CheckBox ID="cbAktif" runat="server" Text="Aktif" />
            </td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>
                <asp:Button ID="btnEkle" runat="server" CssClass="btn" Text="Banka Ekle" ValidationGroup="grb1" OnClick="btnEkle_Click" />
            &nbsp;<asp:Button ID="btnDuzenle" runat="server" CssClass="btn" Text="Banka Düzenle" Visible="False" OnClick="btnDuzenle_Click" ValidationGroup="grb1" />
            &nbsp;<asp:Button ID="btnGeri" runat="server" CssClass="btn" OnClick="btnGeri_Click" Text="&lt;&lt; Geri" ValidationGroup="grbkargo" Visible="False" />
            </td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
      <br />
    Bankalar:
  
            <table class="table">
                <thead>
                    <tr>
                        <th>Banka Adı</th>
                        <th>Şube Adı</th>
                        <th>Şube Kodu</th>
                        <th>Hesap No</th>
                        <th>Hesap Sahibi</th>
                        <th>IBAN No</th>
                        <th class="auto-style17">Durum</th>
                        <th style="width: 26px;">İşlem</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="RpKayit" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("BankaAdi")%></a></td>
                                <td><%#Eval("SubeAdi")%></td>
                                <td><%#Eval("SubeKodu")%></td>
                                <td><%#Eval("HesapNo")%></td>
                                <td><%#Eval("IBAN")%></td>
                                <td><%#Eval("AliciAdi")%></td>
                                <td><%#Eval("Durumadi")%></td>
                                <td><a href="BankaHesap.aspx?BankaId=<%#Eval("BankaId")%>&islem=duzenle" title="Düzenle"><i class="icon-pencil"></i></a>
                                 <a onclick="return confirm('Dikkat: (<%#Eval("BankaAdi") %>) Adlı Bankayı Silmek İstediğinizden Emin Misiniz?');" href="BankaHesap.aspx?BankaId=<%#Eval("BankaId")%>&islem=sil" title="Sil"><i class="icon-remove"></i></a></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
</asp:Content>
