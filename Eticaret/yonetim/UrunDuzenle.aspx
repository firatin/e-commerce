<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="UrunDuzenle.aspx.cs" Inherits="Eticaret.yonetim.UrunDuzenle" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style3 {
            width: 82px;
        }

        .auto-style5 {
            width: 85px;
        }
    </style>
    <style type="text/css">
        .MyTabStyle .ajax__tab_header {
            font-family: "Helvetica Neue", Arial, Sans-Serif;
            font-size: 14px;
            font-weight: bold;
            display: block;
        }

            .MyTabStyle .ajax__tab_header .ajax__tab_outer {
                border-color: #222;
                color: #222;
                padding-left: 10px;
                margin-right: 3px;
                border: solid 1px #d7d7d7;
            }

            .MyTabStyle .ajax__tab_header .ajax__tab_inner {
                border-color: #666;
                color: #666;
                padding: 3px 10px 2px 0px;
            }

        .MyTabStyle .ajax__tab_hover .ajax__tab_outer {
            background-color: #9c3;
        }

        .MyTabStyle .ajax__tab_hover .ajax__tab_inner {
            color: #fff;
        }

        .MyTabStyle .ajax__tab_active .ajax__tab_outer {
            border-bottom-color: #ffffff;
            background-color: #d7d7d7;
        }

        .MyTabStyle .ajax__tab_active .ajax__tab_inner {
            color: #000;
            border-color: #333;
        }

        .MyTabStyle .ajax__tab_body {
            font-family: verdana,tahoma,helvetica;
            font-size: 10pt;
            background-color: #fff;
            border-top-width: 0;
            border: solid 1px #d7d7d7;
            border-top-color: #ffffff;
        }
    </style>
    <style type="text/css">
        .auto-style3 {
            width: 100%;
            height: 159px;
        }

        .auto-style5 {
            width: 19px;
        }

        .auto-style8 {
            width: 20px;
        }

        .auto-style9 {
            width: 244px;
        }

        .auto-style13 {
            width: 24px;
        }

        .auto-style15 {
            width: 123px;
        }

        .auto-style18 {
            width: 129px;
        }

        .auto-style19 {
            width: 124px;
            height: 22px;
        }

        .auto-style20 {
            height: 22px;
        }

        .auto-style22 {
            height: 22px;
            width: 21px;
        }

        .auto-style23 {
            width: 21px;
        }

        .auto-style25 {
            height: 22px;
            width: 152px;
        }

        .auto-style28 {
            height: 22px;
            width: 51px;
        }

        .auto-style30 {
            height: 22px;
            width: 24px;
        }

        .auto-style35 {
            width: 51px;
        }

        .auto-style36 {
            width: 152px;
        }

        .auto-style39 {
            height: 22px;
            width: 93px;
        }

        .auto-style41 {
            width: 93px;
        }

        .auto-style42 {
            height: 22px;
            width: 12px;
        }

        .auto-style43 {
            width: 12px;
        }

        .auto-style46 {
            width: 171px;
            height: 29px;
        }

        .auto-style47 {
            width: 19px;
            height: 29px;
        }

        .auto-style48 {
            height: 29px;
        }

        .auto-style52 {
            width: 201px;
        }

        .auto-style53 {
            width: 160px;
        }

        .auto-style54 {
            width: 100%;
        }

        .auto-style55 {
            width: 147px;
        }

        .auto-style56 {
            width: 348px;
        }

        .auto-style58 {
            width: 171px;
        }

        .auto-style63 {
            width: 624px;
            height: 75px;
        }

        .auto-style66 {
            width: 584px;
        }

        .auto-style67 {
            width: 570px;
        }

        .auto-style69 {
            width: 100px;
        }

        .auto-style71 {
            width: 18px;
        }

        .auto-style72 {
            width: 28px;
        }

        .auto-style74 {
            width: 139px;
        }

        .auto-style75 {
            width: 78px;
        }

        .auto-style76 {
            width: 84px;
        }

        .auto-style77 {
            width: 84px;
            font-weight: bold;
        }

        .auto-style78 {
            width: 78px;
            font-weight: bold;
        }

        .auto-style79 {
            width: 139px;
            font-weight: bold;
        }

        .auto-style80 {
            width: 129px;
            font-weight: bold;
        }

        .auto-style81 {
            width: 28px;
            height: 30px;
        }

        .auto-style82 {
            width: 162px;
            height: 30px;
        }

        .auto-style83 {
            width: 18px;
            height: 30px;
        }

        .auto-style84 {
            width: 100px;
            height: 30px;
        }

        .auto-style85 {
            height: 30px;
        }

        .auto-style86 {
            width: 162px;
            font-weight: bold;
        }

        .auto-style87 {
            width: 130px;
        }

        .auto-style88 {
            width: 20px;
            height: 75px;
        }

        .auto-style89 {
            width: 130px;
            height: 75px;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="auto-style1">
        <tr>
            <td class="auto-style67">

                <asp:Button runat="server" Text="&#220;r&#252;n&#252; G&#252;ncelle" ValidationGroup="urunekle" CssClass="btn" TabIndex="20" ID="btnGuncelle" OnClick="btnGuncelle_Click"></asp:Button>

                &nbsp;<asp:Button runat="server" PostBackUrl="~/yonetim/Urunler.aspx" Text="Vazge&#231;" CssClass="btn" ID="btnVazgec"></asp:Button>

            </td>
        </tr>
    </table>
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="844px" Style="margin-right: 0px" CssClass="MyTabStyle">
        <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
            <HeaderTemplate>Ürün Özellikleri</HeaderTemplate>
            <ContentTemplate>
                <table class="auto-style3">
                    <tr>
                        <td class="auto-style18">Stok Kodu</td>
                        <td class="auto-style5">:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtStokKodu" ErrorMessage="Stok kodunu giriniz" ForeColor="Red" ValidationGroup="urunekle">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtStokKodu" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style18">Ürün Adı</td>
                        <td class="auto-style5">:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUrunAdi" ErrorMessage="Ürün adını giriniz" ForeColor="Red" ValidationGroup="urunekle">*</asp:RequiredFieldValidator>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUrunAdi" runat="server" Width="400px" TabIndex="1"></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style5">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                <table class="auto-style3">
                    <tr>
                        <td class="auto-style18">Kategori</td>
                        <td class="auto-style8">:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddKategori" ErrorMessage="Kategori seçiniz" ForeColor="Red" InitialValue="0" ValidationGroup="urunekle">*</asp:RequiredFieldValidator>
                        </td>
                        <td class="auto-style9">
                            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddKategori" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddKategori_SelectedIndexChanged" TabIndex="3">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td class="auto-style15">Stok Durumu</td>
                        <td class="auto-style13">:</td>
                        <td>

                            <asp:DropDownList ID="ddStokDurumu" runat="server" TabIndex="8">
                                <asp:ListItem>Var, Hızlı Gönderi</asp:ListItem>
                                <asp:ListItem>Var, 1-7 Günde Kargo</asp:ListItem>
                                <asp:ListItem>Var, 1-15 Günde Kargo</asp:ListItem>
                                <asp:ListItem>Var, Sınırlı Stok</asp:ListItem>
                                <asp:ListItem>Yok, Ön Sparişte</asp:ListItem>
                                <asp:ListItem>Yok, Temin Edilemiyor</asp:ListItem>
                                <asp:ListItem>Stokta Yok</asp:ListItem>
                            </asp:DropDownList>

                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style18">Alt Kategori</td>
                        <td class="auto-style8">:<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddAltKategori" ErrorMessage="Alt Kategori seçiniz" ForeColor="Red" InitialValue="0" ValidationGroup="urunekle">*</asp:RequiredFieldValidator>
                        </td>
                        <td class="auto-style9">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddAltKategori" runat="server" TabIndex="4">
                                        <asp:ListItem Value="0">Kategori Seçiniz</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td class="auto-style15">Stok Miktarı</td>
                        <td class="auto-style13">:</td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtStokMiktar" runat="server" AutoPostBack="True" OnTextChanged="txtStokMiktar_TextChanged" TabIndex="9" Width="41px">10</asp:TextBox>
                                    <asp:FilteredTextBoxExtender ID="txtStokMiktar_FilteredTextBoxExtender" runat="server" Enabled="True" TargetControlID="txtStokMiktar" ValidChars="-1234567890">
                                    </asp:FilteredTextBoxExtender>
                                    <asp:DropDownList ID="ddStokMiktari" runat="server" AutoPostBack="True" TabIndex="10" Width="161px" OnSelectedIndexChanged="ddStokMiktari_SelectedIndexChanged">
                                        <asp:ListItem>Adet</asp:ListItem>
                                        <asp:ListItem>Cm</asp:ListItem>
                                        <asp:ListItem>Çift</asp:ListItem>
                                        <asp:ListItem>Çuval</asp:ListItem>
                                        <asp:ListItem>Deste</asp:ListItem>
                                        <asp:ListItem>Düzine</asp:ListItem>
                                        <asp:ListItem>Gram</asp:ListItem>
                                        <asp:ListItem>Kilo</asp:ListItem>
                                        <asp:ListItem>Koli</asp:ListItem>
                                        <asp:ListItem>Kutu</asp:ListItem>
                                        <asp:ListItem>Litre</asp:ListItem>
                                        <asp:ListItem>M2</asp:ListItem>
                                        <asp:ListItem>M3</asp:ListItem>
                                        <asp:ListItem>Metre</asp:ListItem>
                                        <asp:ListItem>MTül</asp:ListItem>
                                        <asp:ListItem>Paket</asp:ListItem>
                                        <asp:ListItem>Takım</asp:ListItem>
                                        <asp:ListItem>Teneke</asp:ListItem>
                                        <asp:ListItem>Top</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style18">Marka</td>
                        <td class="auto-style8">:<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddMarka" ErrorMessage="Marka seçiniz" ForeColor="Red" InitialValue="0" ValidationGroup="urunekle">*</asp:RequiredFieldValidator>
                        </td>
                        <td class="auto-style9">
                            <asp:DropDownList ID="ddMarka" runat="server" TabIndex="5"></asp:DropDownList></td>
                        <td class="auto-style15">Miktar Gösterimi</td>
                        <td class="auto-style13">:</td>
                        <td>
                            <asp:DropDownList ID="ddMiktarGosterim" runat="server" TabIndex="11">
                                <asp:ListItem Value="0">Hayır Gösterme</asp:ListItem>
                                <asp:ListItem Value="1">Evet Göster</asp:ListItem>
                            </asp:DropDownList></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style18">Min.Spariş Miktarı</td>
                        <td class="auto-style8">:</td>
                        <td class="auto-style9">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtMinSparis" runat="server" TabIndex="6" Width="79px">1</asp:TextBox>
                                    <asp:FilteredTextBoxExtender ID="txtMinSparis_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtMinSparis">
                                    </asp:FilteredTextBoxExtender>
                                    &nbsp;<asp:Label ID="lblMin" runat="server">Adet</asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td class="auto-style15">Ürün Puanı</td>
                        <td class="auto-style13">:</td>
                        <td>
                            <asp:TextBox ID="txtUrunPuan" runat="server" OnTextChanged="txtStokMiktar_TextChanged" TabIndex="9" Width="41px">0</asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="txtUrunPuan_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtUrunPuan">
                            </asp:FilteredTextBoxExtender>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style18">Max.Spariş Miktarı</td>
                        <td class="auto-style8">:</td>
                        <td class="auto-style9">
                            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtMaxSparis" runat="server" TabIndex="7" Width="79px">10</asp:TextBox>
                                    <asp:FilteredTextBoxExtender ID="txtMaxSparis_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtMaxSparis">
                                    </asp:FilteredTextBoxExtender>
                                    &nbsp;<asp:Label ID="lblMax" runat="server">Adet</asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td class="auto-style15">&nbsp;</td>
                        <td class="auto-style13">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style8">&nbsp;</td>
                        <td class="auto-style9">&nbsp;</td>
                        <td class="auto-style15">&nbsp;</td>
                        <td class="auto-style13">&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                &nbsp;<table class="auto-style3">
                    <tr>
                        <td class="auto-style18">Satış Fiyatı</td>
                        <td class="auto-style23">:</td>
                        <td class="auto-style36">
                            <asp:TextBox ID="txtSatisFiyati" runat="server" Width="79px" TabIndex="12"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="txtSatisFiyati_FilteredTextBoxExtender" FilterType="Custom, Numbers" ValidChars=".," runat="server" Enabled="True" TargetControlID="txtSatisFiyati">
                            </asp:FilteredTextBoxExtender>
                            &nbsp;TL</td>
                        <td class="auto-style35">İndirim</td>
                        <td class="auto-style13">:</td>
                        <td class="auto-style36">
                            <asp:TextBox ID="txtSatisIndirim" runat="server" Width="79px" TabIndex="15"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="txtSatisIndirim_FilteredTextBoxExtender" runat="server" FilterType="Custom, Numbers" ValidChars=".," Enabled="True" TargetControlID="txtSatisIndirim">
                            </asp:FilteredTextBoxExtender>
                            &nbsp;TL</td>
                        <td class="auto-style41">Kdv</td>
                        <td class="auto-style43">:</td>
                        <td>
                            <asp:DropDownList ID="ddKdv" runat="server" Width="95px">
                                <asp:ListItem Value="0">Seçim Yok</asp:ListItem>
                                <asp:ListItem Value="25">% 25</asp:ListItem>
                                <asp:ListItem Value="18">% 18</asp:ListItem>
                                <asp:ListItem Value="15">% 15</asp:ListItem>
                                <asp:ListItem Value="12">% 12</asp:ListItem>
                                <asp:ListItem Value="8">% 8</asp:ListItem>
                                <asp:ListItem Value="5">% 5</asp:ListItem>
                                <asp:ListItem Value="1">% 1</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style18">Bayi Fiyatı</td>
                        <td class="auto-style23">:</td>
                        <td class="auto-style36">
                            <asp:TextBox ID="txtBayiFiyati" runat="server" Width="79px" TabIndex="13"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="txtBayiFiyati_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Custom, Numbers" ValidChars=".," TargetControlID="txtBayiFiyati">
                            </asp:FilteredTextBoxExtender>
                            &nbsp;TL</td>
                        <td class="auto-style35">İndirim</td>
                        <td class="auto-style13">:</td>
                        <td class="auto-style36">
                            <asp:TextBox ID="txtBayiIndirim" runat="server" Width="79px" TabIndex="16"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="txtBayiIndirim_FilteredTextBoxExtender" runat="server" FilterType="Custom, Numbers" ValidChars=".," Enabled="True" TargetControlID="txtBayiIndirim">
                            </asp:FilteredTextBoxExtender>
                            &nbsp;TL</td>
                        <td class="auto-style41">Maliyet Fiyatı</td>
                        <td class="auto-style43">:</td>
                        <td>
                            <asp:TextBox ID="txtMaliyetFiyati" runat="server" Width="79px" TabIndex="18"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="txtMaliyetFiyati_FilteredTextBoxExtender" runat="server" FilterType="Custom, Numbers" ValidChars=".," Enabled="True" TargetControlID="txtMaliyetFiyati">
                            </asp:FilteredTextBoxExtender>
                            &nbsp;TL</td>
                    </tr>
                    <tr>
                        <td class="auto-style19">Toptan Bayi Fiyatı</td>
                        <td class="auto-style22">:</td>
                        <td class="auto-style25">
                            <asp:TextBox ID="txtToptanBayiFiyati" runat="server" Width="79px" TabIndex="14"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="txtToptanBayiFiyati_FilteredTextBoxExtender" runat="server" FilterType="Custom, Numbers" ValidChars=".," Enabled="True" TargetControlID="txtToptanBayiFiyati">
                            </asp:FilteredTextBoxExtender>
                            &nbsp;TL</td>
                        <td class="auto-style28">İndirim</td>
                        <td class="auto-style30">:</td>
                        <td class="auto-style25">
                            <asp:TextBox ID="txtToptanBayiIndirim" runat="server" Width="79px" TabIndex="17"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="txtToptanBayiIndirim_FilteredTextBoxExtender" runat="server" FilterType="Custom, Numbers" ValidChars=".," Enabled="True" TargetControlID="txtToptanBayiIndirim">
                            </asp:FilteredTextBoxExtender>
                            &nbsp;TL</td>
                        <td class="auto-style39">Piyasa Fiyatı</td>
                        <td class="auto-style42">:</td>
                        <td class="auto-style20">
                            <asp:TextBox ID="txtPiyasaFiyati" runat="server" Width="79px" TabIndex="19"></asp:TextBox>
                            <asp:FilteredTextBoxExtender ID="txtPiyasaFiyati_FilteredTextBoxExtender" runat="server" FilterType="Custom, Numbers" ValidChars=".," Enabled="True" TargetControlID="txtPiyasaFiyati">
                            </asp:FilteredTextBoxExtender>
                            &nbsp;TL</td>
                    </tr>
                    <tr>
                        <td class="auto-style18">&nbsp;</td>
                        <td class="auto-style23">&nbsp;</td>
                        <td class="auto-style36">&nbsp;</td>
                        <td class="auto-style35">&nbsp;</td>
                        <td class="auto-style13">&nbsp;</td>
                        <td class="auto-style36">
                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="urunekle" />
                        </td>
                        <td class="auto-style41">&nbsp;</td>
                        <td class="auto-style43">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                &nbsp;<table class="auto-style54">
                    <tr>
                        <td class="auto-style55">&nbsp;</td>
                        <td class="auto-style56">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>Ürün Detayı</HeaderTemplate>
            <ContentTemplate>
                <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" Height="265px" Width="">
                </CKEditor:CKEditorControl>&nbsp;<div class="p5_0 f10" style="padding: 5px 0px; font-size: 10px; line-height: 12px; color: rgb(34, 34, 34); font-family: Verdana, Arial; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: auto; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">• Ürünün detay içeriğini istediğiniz gibi düzenleyebilirsiniz.</div>
                <div class="p5_0 f10" style="padding: 5px 0px; font-size: 10px; line-height: 12px; color: rgb(34, 34, 34); font-family: Verdana, Arial; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: auto; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">• İçeriğe özel html kod v.b. kendi kodlarınızı entegre etmek istiyorsanız, ilk sıradaki Kaynak yazan alana tıklayarak, kodlarınızı yapıştırdıktan sonra tekrar kaynağa basıp dizayn görünümüne dönün.</div>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
            <HeaderTemplate>Ürün İndirimleri</HeaderTemplate>
            <ContentTemplate>
                <table class="auto-style3">
                    <tr>
                        <td class="auto-style58">Havale İndirimi (%)</td>
                        <td class="auto-style5">:</td>
                        <td>
                            <asp:TextBox ID="txtHavale" runat="server" Width="86px"></asp:TextBox><asp:FilteredTextBoxExtender ID="txtHavale_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Custom, Numbers" TargetControlID="txtHavale" ValidChars=".,"></asp:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style58">Tek Çekim İndirimi (%)</td>
                        <td class="auto-style5">:</td>
                        <td>
                            <asp:TextBox ID="txtTekCekim" runat="server" Width="86px"></asp:TextBox><asp:FilteredTextBoxExtender ID="txtTekCekim_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Custom, Numbers" TargetControlID="txtTekCekim" ValidChars=".,"></asp:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style46"></td>
                        <td class="auto-style47"></td>
                        <td class="auto-style48"><a href="indirim.aspx" target="_blank">Varsayılan indirim değerlerini değiştirmek için tıklayınız.</a></td>
                    </tr>
                    <tr>
                        <td class="auto-style58">&nbsp;</td>
                        <td class="auto-style5">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel4">
            <HeaderTemplate>Ürün Nitelikleri</HeaderTemplate>
            <ContentTemplate>
                <table class="auto-style3">
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td class="auto-style53">&nbsp;<asp:CheckBox ID="cbAktif" runat="server" Checked="True" Text="Aktif" /></td>
                        <td class="auto-style52">&nbsp;<asp:CheckBox ID="cbYeniUrum" runat="server" Text="Yeni Ürün" /></td>
                        <td>&nbsp;<asp:CheckBox ID="cbHaftaninUrunu" runat="server" Text="Haftanın Ürünü" /></td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td class="auto-style53">&nbsp;<asp:CheckBox ID="cbOzelUrun" runat="server" Text="Özel Ürün" /></td>
                        <td class="auto-style52">
                            <asp:CheckBox ID="cbFiyatDusen" runat="server" Text="Fiyatı Düşen" /></td>
                        <td>&nbsp;<asp:CheckBox ID="cbVitrin" runat="server" Text="Vitrin Ürünü" /></td>
                    </tr>
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td class="auto-style53">&nbsp;</td>
                        <td class="auto-style52">&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel5" runat="server" HeaderText="TabPanel5">
            <HeaderTemplate>
                Ürün Resimleri
            </HeaderTemplate>
            <ContentTemplate>
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style88"></td>
                        <td class="auto-style89">Resim:</td>
                        <td class="auto-style63">
                            <asp:FileUpload ID="FuResim" runat="server" />
                            &nbsp;<asp:Button ID="btnResimYukle" runat="server" CssClass="btn" Text="Resim Yükle" OnClick="btnResimYukle_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style8"></td>
                        <td class="auto-style87"></td>
                        <td class="auto-style66">
                            <asp:Label ID="lblResim" runat="server"></asp:Label>
                        </td>
                    </tr>

                </table>

                <table class="auto-style1">
                    <tr>
                        <td class="auto-style5">&nbsp;</td>
                        <td>

                            <br />

                            <br />
                            <asp:DataList ID="DlisResimler" runat="server" RepeatDirection="Horizontal" RepeatColumns="6">
                                <ItemTemplate>
                                    <table class="auto-style1">

                                        <tr>
                                            <td>
                                                <img src="/Resimler/Urun/150/<%#Eval("ResimYolu150")%> " width="130" alt="" /></td>
                                        </tr>
                                        <tr>
                                            <td><a href="UrunDuzenle.aspx?UrunId=<%#Eval("UrunId")%>&islem=duzenle&v=AnaResim&Resim=<%#Eval("ResimId")%>"><span class="span-red"><span class="span-red">Ana Resim Yap</span><br /></a>
                                                <a onclick="return confirm('Bu resmi silmek istediğinizden emin misiniz?');" href="UrunDuzenle.aspx?UrunId=<%#Eval("UrunId")%>&islem=duzenle&v=sil&Resim=<%#Eval("ResimId")%>"><span class="span-red">Resmi Sil</span></a></td>
                                        </tr>

                                    </table>
                                </ItemTemplate>
                            </asp:DataList>

                        </td>

                    </tr>
                </table>
                <br />
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel6" runat="server" HeaderText="Ürün Varyantları">
            <ContentTemplate>
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style72"></td>
                        <td class="auto-style86">Stok Miktarı</td>
                        <td class="auto-style71">:</td>
                        <td class="auto-style71">
                            <asp:Label ID="lblVaryantStok" runat="server"></asp:Label></td>
                        <td class="auto-style69"></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style72"></td>
                        <td class="auto-style86">Varyantlar</td>
                        <td class="auto-style71">:<asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddVaryant" ErrorMessage="*" ForeColor="Red" InitialValue="0" ValidationGroup="grbvaryant"></asp:RequiredFieldValidator></td>
                        <td class="auto-style69">
                            <asp:DropDownList ID="ddVaryant" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddVaryant_SelectedIndexChanged" Width="170px"></asp:DropDownList></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style72"></td>
                        <td class="auto-style86">Varyant Seçenekleri</td>
                        <td class="auto-style71">:<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddAltVaryant" ErrorMessage="*" ForeColor="Red" InitialValue="0" ValidationGroup="grbvaryant"></asp:RequiredFieldValidator></td>
                        <td class="auto-style69">
                            <asp:DropDownList ID="ddAltVaryant" runat="server" AutoPostBack="True" Width="170px"></asp:DropDownList></td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style72"></td>
                        <td class="auto-style86">Stok Sayısı</td>
                        <td class="auto-style71">:<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtStok" ErrorMessage="*" ForeColor="Red" ValidationGroup="grbvaryant"></asp:RequiredFieldValidator></td>
                        <td class="auto-style69">
                            <asp:TextBox ID="txtStok" runat="server" Width="93px"></asp:TextBox><asp:FilteredTextBoxExtender ID="txtStok_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtStok"></asp:FilteredTextBoxExtender>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="auto-style81"></td>
                        <td class="auto-style82"></td>
                        <td class="auto-style83"></td>
                        <td class="auto-style84">
                            <asp:Button ID="btnVaryantEkle" runat="server" CssClass="btn" Text="Varyant Ekle" ValidationGroup="grbvaryant" OnClick="btnVaryantEkle_Click" /></td>
                        <td class="auto-style85"></td>
                    </tr>
                </table>
                &nbsp;<br />
                <table class="auto-style1">
                    <tr>
                        <td class="auto-style72">&nbsp;</td>
                        <td class="auto-style80">Ana Varyant</td>
                        <td class="auto-style79">Alt Varyant</td>
                        <td class="auto-style78">Stok</td>
                        <td class="auto-style77">İşlem</td>
                        <td></td>
                    </tr>
                    <asp:Repeater ID="RpVaryant" runat="server" OnItemCommand="RpVaryant_ItemCommand">
                        <ItemTemplate>
                            <tr>
                                <td class="auto-style72"></td>
                                <td class="auto-style18"><%#Eval("VaryantAdi")%></td>
                                <td class="auto-style74"><%#Eval("AltVaryantAdi")%></td>
                                <td class="auto-style75">
                                    <asp:TextBox ID="txtAdet" runat="server" Text='<%#Eval("StokSayi")%>' Width="30"></asp:TextBox><asp:FilteredTextBoxExtender ID="txtAdet_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Custom" TargetControlID="txtAdet" ValidChars="-0123456789"></asp:FilteredTextBoxExtender>
                                    <asp:ImageButton ID="btnGuncelle" runat="server" Text="Güncelle" CommandName="Guncelle" ImageAlign="AbsMiddle" Width="25" CommandArgument='<%#Eval("VaryantId")%>' ImageUrl="~/images/icon/update-icon.png" ToolTip="Sepeti güncelle" /></td>
                                <td class="auto-style76">
                                    <asp:LinkButton ID="lnkVaryantSil" CommandName="Sil" CommandArgument='<%#Eval("VaryantId")%>' runat="server">Sil</asp:LinkButton><asp:ConfirmButtonExtender ID="lnkVaryantSil_ConfirmButtonExtender" runat="server" ConfirmText="Not: Varyant Stok'u tükenince varyant gösterilmez. Yinede silmek istediğinizden emin misiniz?" Enabled="True" TargetControlID="lnkVaryantSil"></asp:ConfirmButtonExtender>
                                </td>
                                <td></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
                <br />
            </ContentTemplate>
        </asp:TabPanel>
    </asp:TabContainer>
    <br />

</asp:Content>
