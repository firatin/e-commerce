<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="Taksit.aspx.cs" Inherits="Eticaret.yonetim.Taksit" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
        width: 100%;
            height: 214px;
        }
        .auto-style3 {
            width: 18px;
        }
        .auto-style4 {
            width: 98px;
        }
        .auto-style5 {
            width: 98px;
            height: 22px;
        }
        .auto-style6 {
            width: 18px;
            height: 22px;
        }
        .auto-style7 {
            height: 22px;
            width: 290px;
        }
        .auto-style8 {
            width: 417px;
        }
        .auto-style10 {
            width: 290px;
        }
        .auto-style11 {
            width: 59px;
        }
        .auto-style13 {
            width: 157px;
        }
        .auto-style14 {
            width: 200px;
        }
        .auto-style15 {
            width: 81px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnYeniBanka" runat="server" Text="Yeni Banka Ekle" CssClass="btn" OnClick="btnYeniBanka_Click" Visible="False" />
    <br />
    <div id="divTaksitler" runat="server"> 

<div class="well">

            <table class="table">
                <thead>
                    <tr>
                        <th class="auto-style15"> </th>
                        <th class="auto-style13">Banka</th>
                        <th class="auto-style14">Kart Adı</th>
                        <th class="auto-style14">Durum</th>
                        <th style="width: 26px;">İşlem</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="RpKayit" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td> <img src="/Resimler/Banka/<%#Eval("BankaLogo")%> " width="100" height="100" title="<%#Eval("BankaAdi")%>" />
                                    </td>
                                <td><%#Eval("BankaAdi")%></td>
                                <td><%#Eval("KartAdi")%></td>
                                 <td><%#Eval("DurumAdi")%></td>
                                <td><a href="Taksit.aspx?Banka=<%#Eval("TaksitId")%>&islem=detay" title="Düzenle"><i class="icon-pencil"></i></a>
                                 
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
      
</div>
    </div>

   <div id="divTaksitKaydet" runat="server" visible="false">
     <table class="auto-style1">
    <tr>
        <td class="auto-style8">
            <table class="auto-style1">
                <tr>
                    <td class="auto-style5">Aktif</td>
                    <td class="auto-style6">:</td>
                    <td class="auto-style7">
                        <asp:CheckBox ID="cbAktif" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Banka Adı</td>
                    <td class="auto-style3">:</td>
                    <td class="auto-style10">
                        <asp:TextBox ID="txtBankaAdi" runat="server" Enabled="False"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBankaAdi" ErrorMessage="*" ForeColor="Red" ValidationGroup="grbBanka"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Kart Adı</td>
                    <td class="auto-style3">:</td>
                    <td class="auto-style10">
                        <asp:TextBox ID="txtKartAdi" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtKartAdi" ErrorMessage="*" ForeColor="Red" ValidationGroup="grbBanka"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Banka Logosu</td>
                    <td class="auto-style3">:</td>
                    <td class="auto-style10">
                        <asp:FileUpload ID="FuResim" runat="server" />
                        <br />
                        <br />
                        <asp:Image ID="imgResim" runat="server" Height="50px" Width="140px" />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style10">
                        <asp:Button ID="btnKaydet" runat="server" CssClass="btn" Text="Kaydet" OnClick="btnKaydet_Click" ValidationGroup="grbBanka" Visible="False" />
                    &nbsp;<asp:Button ID="btnDuzenle" runat="server" CssClass="btn" OnClick="btnDuzenle_Click" Text="Düzenle" Visible="False" />
&nbsp;<asp:Button ID="btnVazgec" runat="server" CssClass="btn" OnClick="btnVazgec_Click" Text="Vazgeç" />
                    </td>
                </tr>
            </table>

            <br />
        </td>
        <td>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style11">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td><strong>Taksit Seçeneleri</strong></td>
                </tr>
                <tr>
                    <td class="auto-style11">2 Taksit</td>
                    <td>&nbsp;</td>
                    <td>%
                        <asp:TextBox ID="txt2" runat="server" Width="50px"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="txt2_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Custom, Numbers" ValidChars=".," TargetControlID="txt2">
                </asp:FilteredTextBoxExtender>
&nbsp;vade</td>
                </tr>
                <tr>
                    <td class="auto-style11">3 Taksit</td>
                    <td>&nbsp;</td>
                    <td>%
                        <asp:TextBox ID="txt3" runat="server" Width="50px"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="txt3_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Custom, Numbers" ValidChars=".," TargetControlID="txt3">
                </asp:FilteredTextBoxExtender>
&nbsp;vade</td>
                </tr>
                <tr>
                    <td class="auto-style11">4 Taksit</td>
                    <td>&nbsp;</td>
                    <td>%
                        <asp:TextBox ID="txt4" runat="server" Width="50px"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="txt4_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Custom, Numbers" ValidChars=".," TargetControlID="txt4">
                </asp:FilteredTextBoxExtender>
&nbsp;vade</td>
                </tr>
                <tr>
                    <td class="auto-style11">5 Taksit</td>
                    <td>&nbsp;</td>
                    <td>%
                        <asp:TextBox ID="txt5" runat="server" Width="50px"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="txt5_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Custom, Numbers" ValidChars=".," TargetControlID="txt5">
                </asp:FilteredTextBoxExtender>
&nbsp;vade</td>
                </tr>
                <tr>
                    <td class="auto-style11">6 Taksit</td>
                    <td>&nbsp;</td>
                    <td>%
                        <asp:TextBox ID="txt6" runat="server" Width="50px"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="txt6_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Custom, Numbers" ValidChars=".," TargetControlID="txt6">
                </asp:FilteredTextBoxExtender>
&nbsp;vade</td>
                </tr>
                <tr>
                    <td class="auto-style11">7 Taksit</td>
                    <td>&nbsp;</td>
                    <td>%
                        <asp:TextBox ID="txt7" runat="server" Width="50px"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="txt7_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Custom, Numbers" ValidChars=".," TargetControlID="txt7">
                </asp:FilteredTextBoxExtender>
&nbsp;vade</td>
                </tr>
                <tr>
                    <td class="auto-style11">8 Taksit</td>
                    <td>&nbsp;</td>
                    <td>%
                        <asp:TextBox ID="txt8" runat="server" Width="50px"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="txt8_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Custom, Numbers" ValidChars=".," TargetControlID="txt8">
                </asp:FilteredTextBoxExtender>
&nbsp;vade</td>
                </tr>
                <tr>
                    <td class="auto-style11">9 Taksit</td>
                    <td>&nbsp;</td>
                    <td>%
                        <asp:TextBox ID="txt9" runat="server" Width="50px"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="txt9_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Custom, Numbers" ValidChars=".," TargetControlID="txt9">
                </asp:FilteredTextBoxExtender>
&nbsp;vade</td>
                </tr>
                <tr>
                    <td class="auto-style11">10 Taksit</td>
                    <td>&nbsp;</td>
                    <td>%
                        <asp:TextBox ID="txt10" runat="server" Width="50px"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="txt10_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Custom, Numbers" ValidChars=".," TargetControlID="txt10">
                </asp:FilteredTextBoxExtender>
&nbsp;vade</td>
                </tr>
                <tr>
                    <td class="auto-style11">11 Taksit</td>
                    <td>&nbsp;</td>
                    <td>%
                        <asp:TextBox ID="txt11" runat="server" Width="50px"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="txt11_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Custom, Numbers" ValidChars=".," TargetControlID="txt11">
                </asp:FilteredTextBoxExtender>
&nbsp;vade</td>
                </tr>
                <tr>
                    <td class="auto-style11">12 Taksit</td>
                    <td>&nbsp;</td>
                    <td>%
                        <asp:TextBox ID="txt12" runat="server" Width="50px"></asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="txt12_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Custom, Numbers" ValidChars=".," TargetControlID="txt12">
                </asp:FilteredTextBoxExtender>
&nbsp;vade</td>
                </tr>
                <tr>
                    <td class="auto-style11"><strong>Not:</strong></td>
                    <td>&nbsp;</td>
                    <td>Vade farksız taksit için Sıfır (0) giriniz.<br />
                        Taksit yapılmayacak alanları ise boş bırakın.</td>
                </tr>
            </table>
        </td>
    </tr>
</table>
       </div>
</asp:Content>
