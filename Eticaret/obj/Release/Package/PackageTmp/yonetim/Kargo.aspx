<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="Kargo.aspx.cs" Inherits="Eticaret.yonetim.Kargo" %>
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
        .auto-style8 {
            width: 164px;
            height: 113px;
        }
        .auto-style9 {
            width: 19px;
            height: 113px;
        }
        .auto-style10 {
            height: 113px;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style4">Kargo Adı</td>
            <td class="auto-style5">:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtKargoAdi" ErrorMessage="*" ForeColor="Red" ValidationGroup="grbkargo"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style6">
                <asp:TextBox ID="txtKargoAdi" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style7">Ücretsiz Kargo Alt Limiti</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:TextBox ID="txtUcretsiz" runat="server" Width="68px" MaxLength="10">0</asp:TextBox>
                <asp:FilteredTextBoxExtender ID="txtUcretsiz_FilteredTextBoxExtender" runat="server" Enabled="True"  FilterType="Custom, Numbers" ValidChars=".," TargetControlID="txtUcretsiz">
                </asp:FilteredTextBoxExtender>
&nbsp;TL</td>
        </tr>
        <tr>
            <td class="auto-style7">Kargo Sabit Ücreti</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:TextBox ID="txtSabitUcret" runat="server" Width="68px" MaxLength="10">0</asp:TextBox>
                <asp:FilteredTextBoxExtender ID="txtSabitUcret_FilteredTextBoxExtender" runat="server" Enabled="True"  FilterType="Custom, Numbers" ValidChars=".," TargetControlID="txtSabitUcret">
                </asp:FilteredTextBoxExtender>
&nbsp;TL</td>
        </tr>
        <tr>
            <td class="auto-style7">Kapıda Ödeme Ücreti</td>
            <td class="auto-style3">:</td>
            <td>
                <asp:TextBox ID="txtOdeme" runat="server" Width="68px" MaxLength="10">0</asp:TextBox>
                <asp:FilteredTextBoxExtender ID="txtOdeme_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Custom, Numbers" ValidChars=".," TargetControlID="txtOdeme">
                </asp:FilteredTextBoxExtender>
&nbsp;TL</td>
        </tr>
        <tr>
            <td >Kargo Sorgulama Adresi (Url)</td>
            <td >:</td>
            <td>
                <asp:TextBox ID="txtKargoSorgulama" runat="server" Width="300px"></asp:TextBox>
            &nbsp;- Kargonun internet sitesindeki sorgulama adresi.</td>
        </tr>
        <tr>
            <td class="auto-style8">Açıklama</td>
            <td class="auto-style9">:</td>
            <td class="auto-style10">
                <asp:TextBox ID="txtAciklama" runat="server" Height="92px" TextMode="MultiLine" Width="211px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style11">Durum</td>
            <td class="auto-style12">:</td>
            <td class="auto-style13">
                <asp:CheckBox ID="cbAktif" runat="server" Text="Aktif" Checked="True" />
            </td>
        </tr>
        <tr>
            <td class="auto-style7">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>
                <asp:Button ID="btnKargoEkle" runat="server" CssClass="btn" OnClick="btnKargoEkle_Click" Text="Kargo Ekle" ValidationGroup="grbkargo" />
            &nbsp;<asp:Button ID="btnDuzenle" runat="server" CssClass="btn" OnClick="btnDuzenle_Click" Text="Kargo Düzenle" Visible="False" />
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
    Kargolar:
  
            <table class="table">
                <thead>
                    <tr>
                        <th>Kargo Adı</th>
                        <th title="Ücretsiz Kargo Alt Limiti">Alt Limiti</th>
                        <th title="Kargo Sabit Ücreti" >Sabit Ücreti</th>
                        <th>Kapıda Ödeme Ücreti</th>
                        <th>Kargo Açıklaması</th>
                        <th>Durum</th>
                        <th>İşlem</th>
                        <th style="width: 26px;"></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="RpKayit" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("KargoAdi")%></a></td>
                                <td><%#Eval("AltLimit","{0:c}")%></td>
                                <td><%#Eval("SabitUcret","{0:c}")%></td>
                                <td><%#Eval("KapidaOdeme","{0:c}")%></td>
                                <td><%#Eval("Aciklama")%></td>
                                <td><%#Eval("Durumadi")%></td>
                                <td><a href="Kargo.aspx?KargoId=<%#Eval("KargoId")%>&islem=duzenle" title="Düzenle"><i class="icon-pencil"></i></a>
                                 <a onclick="return confirm('Dikkat: (<%#Eval("KargoAdi") %>) Adlı Kargoyu Silmek İstediğinizden Emin Misiniz?');" href="Kargo.aspx?KargoId=<%#Eval("KargoId")%>&islem=sil" title="Sil"><i class="icon-remove"></i></a></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
</asp:Content>
