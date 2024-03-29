<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="UrunEkle.aspx.cs" Inherits="Eticaret.yonetim.UrunEkle" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register assembly="CKEditor.NET" namespace="CKEditor.NET" tagprefix="CKEditor" %>
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
        .MyTabStyle .ajax__tab_header
        {
            font-family: "Helvetica Neue" , Arial, Sans-Serif;
            font-size: 14px;
            font-weight:bold;
            display: block;

        }
        .MyTabStyle .ajax__tab_header .ajax__tab_outer
        {
            border-color: #222;
            color: #222;
            padding-left: 10px;
            margin-right: 3px;
            border:solid 1px #d7d7d7;
        }
        .MyTabStyle .ajax__tab_header .ajax__tab_inner
        {
            border-color: #666;
            color: #666;
            padding: 3px 10px 2px 0px;
        }
        .MyTabStyle .ajax__tab_hover .ajax__tab_outer
        {
            background-color:#9c3;
        }
        .MyTabStyle .ajax__tab_hover .ajax__tab_inner
        {
            color: #fff;
        }
        .MyTabStyle .ajax__tab_active .ajax__tab_outer
        {
            border-bottom-color: #ffffff;
            background-color: #d7d7d7;
        }
        .MyTabStyle .ajax__tab_active .ajax__tab_inner
        {
            color: #000;
            border-color: #333;
        }
        .MyTabStyle .ajax__tab_body
        {
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
            width: 111px;
        }

        .auto-style18 {
            width: 124px;
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
        .auto-style61 {
            width: 35px;
            height: 57px;
        }
        .auto-style62 {
            width: 11%;
            height: 57px;
        }
        .auto-style63 {
            height: 57px;
        }
        .auto-style64 {
            width: 35px;
            height: 27px;
        }
        .auto-style65 {
            width: 11%;
            height: 27px;
        }
        .auto-style66 {
            height: 27px;
        }
        .auto-style67 {
            height: 42px;
        }
        </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table class="auto-style1">
        <tr>
            <td class="auto-style67">
                <asp:Button runat="server" Text="&#220;r&#252;n&#252; Ekle" ValidationGroup="urunekle" CssClass="btn" TabIndex="20" ID="btnEkle" OnClick="btnEkle_Click"></asp:Button>
                <asp:Button runat="server" PostBackUrl="~/yonetim/Urunler.aspx" Text="Vazge&#231;" CssClass="btn" ID="btnVazgec"></asp:Button>
            </td>
        </tr>
    </table>
    <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="844px" Style="margin-right: 0px" CssClass="MyTabStyle">
        <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
            <HeaderTemplate>Ürün Özellikleri</HeaderTemplate>
            <ContentTemplate>
                <table class="auto-style3"><tr><td class="auto-style18">Stok Kodu</td><td class="auto-style5">:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtStokKodu" ErrorMessage="Stok kodunu giriniz" ForeColor="Red" ValidationGroup="urunekle">*</asp:RequiredFieldValidator>
                    </td><td><asp:TextBox ID="txtStokKodu" runat="server"></asp:TextBox></td></tr><tr><td class="auto-style18">Ürün Adı</td><td class="auto-style5">:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUrunAdi" ErrorMessage="Ürün adını giriniz" ForeColor="Red" ValidationGroup="urunekle">*</asp:RequiredFieldValidator>
                    </td><td><asp:TextBox ID="txtUrunAdi" runat="server" Width="400px" TabIndex="1"></asp:TextBox></td></tr><tr><td class="auto-style18">&nbsp;</td><td class="auto-style5">&nbsp;</td><td>&nbsp;</td></tr></table><table class="auto-style3"><tr><td class="auto-style18">Kategori</td><td class="auto-style8">:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddKategori" ErrorMessage="Kategori seçiniz" ForeColor="Red" InitialValue="0" ValidationGroup="urunekle">*</asp:RequiredFieldValidator>
                </td><td class="auto-style9">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddKategori" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddKategori_SelectedIndexChanged" TabIndex="3">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td><td class="auto-style15">Stok Durumu</td><td class="auto-style13">:</td><td><asp:DropDownList ID="ddStokDurumu" runat="server" TabIndex="8">
                <asp:ListItem>Var, Hızlı Gönderi</asp:ListItem>
                <asp:ListItem>Var, 1-7 Günde Kargo</asp:ListItem>
                <asp:ListItem>Var, 1-15 Günde Kargo</asp:ListItem>
                <asp:ListItem>Var, Sınırlı Stok</asp:ListItem>
                <asp:ListItem>Yok, Ön Sparişte</asp:ListItem>
                <asp:ListItem>Yok, Temin Edilemiyor</asp:ListItem>
                </asp:DropDownList></td><td>&nbsp;</td></tr><tr><td class="auto-style18">Alt Kategori</td><td class="auto-style8">:<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddAltKategori" ErrorMessage="Alt Kategori seçiniz" ForeColor="Red" InitialValue="0" ValidationGroup="urunekle">*</asp:RequiredFieldValidator>
                </td><td class="auto-style9">
                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddAltKategori" runat="server" TabIndex="4">
                                <asp:ListItem Value="0">Kategori Seçiniz</asp:ListItem>
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td><td class="auto-style15">Stok Miktarı</td><td class="auto-style13">:</td><td>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtStokMiktar" runat="server" AutoPostBack="True" OnTextChanged="txtStokMiktar_TextChanged" TabIndex="9" Width="41px">10</asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="txtStokMiktar_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtStokMiktar">
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
                </td><td>&nbsp;</td></tr><tr><td class="auto-style18">Marka</td><td class="auto-style8">:<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddMarka" ErrorMessage="Marka seçiniz" ForeColor="Red" InitialValue="0" ValidationGroup="urunekle">*</asp:RequiredFieldValidator>
                </td><td class="auto-style9"><asp:DropDownList ID="ddMarka" runat="server" TabIndex="5"></asp:DropDownList></td><td class="auto-style15">Miktar Gösterimi</td><td class="auto-style13">:</td><td><asp:DropDownList ID="ddMiktarGosterim" runat="server" TabIndex="11">
                <asp:ListItem Value="0">Hayır Gösterme</asp:ListItem>
                <asp:ListItem Value="1">Evet Göster</asp:ListItem>
                </asp:DropDownList></td><td>&nbsp;</td></tr><tr><td class="auto-style18">Min.Spariş Miktarı</td><td class="auto-style8">:</td><td class="auto-style9">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtMinSparis" runat="server" TabIndex="6" Width="79px">1</asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="txtMinSparis_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtMinSparis">
                        </asp:FilteredTextBoxExtender>
                        &nbsp;<asp:Label ID="lblMin" runat="server">Adet</asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td><td class="auto-style15">Ürün Puanı</td><td class="auto-style13">:</td><td>
                <asp:TextBox ID="txtUrunPuan" runat="server" OnTextChanged="txtStokMiktar_TextChanged" TabIndex="9" Width="41px">0</asp:TextBox>
                <asp:FilteredTextBoxExtender ID="txtUrunPuan_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtUrunPuan">
                </asp:FilteredTextBoxExtender>
                </td><td>&nbsp;</td></tr><tr><td class="auto-style18">Max.Spariş Miktarı</td><td class="auto-style8">:</td><td class="auto-style9">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <asp:TextBox ID="txtMaxSparis" runat="server" TabIndex="7" Width="79px">10</asp:TextBox>
                        <asp:FilteredTextBoxExtender ID="txtMaxSparis_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtMaxSparis">
                        </asp:FilteredTextBoxExtender>
                        &nbsp;<asp:Label ID="lblMax" runat="server">Adet</asp:Label>
                    </ContentTemplate>
                </asp:UpdatePanel>
                </td><td class="auto-style15">&nbsp;</td><td class="auto-style13">&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr><tr><td class="auto-style18">&nbsp;</td><td class="auto-style8">&nbsp;</td><td class="auto-style9">&nbsp;</td><td class="auto-style15">&nbsp;</td><td class="auto-style13">&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr></table>&nbsp;<table class="auto-style3"><tr><td class="auto-style18">Satış Fiyatı</td><td class="auto-style23">:</td><td class="auto-style36">
                <asp:TextBox ID="txtSatisFiyati" runat="server" Width="79px" TabIndex="12"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="txtSatisFiyati_FilteredTextBoxExtender" FilterType="Custom, Numbers"  ValidChars=".," runat="server" Enabled="True" TargetControlID="txtSatisFiyati">
                </asp:FilteredTextBoxExtender>
                &nbsp;TL</td><td class="auto-style35">İndirim</td><td class="auto-style13">:</td><td class="auto-style36"><asp:TextBox ID="txtSatisIndirim" runat="server" Width="79px" TabIndex="15"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="txtSatisIndirim_FilteredTextBoxExtender" runat="server"  FilterType="Custom, Numbers"  ValidChars=".," Enabled="True" TargetControlID="txtSatisIndirim">
                </asp:FilteredTextBoxExtender>
                &nbsp;TL</td><td class="auto-style41">Kdv</td><td class="auto-style43">:</td><td>
                <asp:DropDownList ID="ddKdv" runat="server" Width="105px">
                    <asp:ListItem Value="0">Seçim Yok</asp:ListItem>
                    <asp:ListItem Value="25">% 25</asp:ListItem>
                    <asp:ListItem Value="18">% 18</asp:ListItem>
                    <asp:ListItem Value="15">% 15</asp:ListItem>
                    <asp:ListItem Value="12">% 12</asp:ListItem>
                    <asp:ListItem Value="8">% 8</asp:ListItem>
                    <asp:ListItem Value="5">% 5</asp:ListItem>
                    <asp:ListItem Value="1">% 1</asp:ListItem>
                </asp:DropDownList>
                </td></tr><tr><td class="auto-style18">Bayi Fiyatı</td><td class="auto-style23">:</td><td class="auto-style36"><asp:TextBox ID="txtBayiFiyati" runat="server" Width="79px" TabIndex="13"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="txtBayiFiyati_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Custom, Numbers"  ValidChars=".," TargetControlID="txtBayiFiyati">
                </asp:FilteredTextBoxExtender>
                &nbsp;TL</td><td class="auto-style35">İndirim</td><td class="auto-style13">:</td><td class="auto-style36"><asp:TextBox ID="txtBayiIndirim" runat="server" Width="79px" TabIndex="16"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="txtBayiIndirim_FilteredTextBoxExtender" runat="server"  FilterType="Custom, Numbers"  ValidChars=".," Enabled="True"  TargetControlID="txtBayiIndirim">
                </asp:FilteredTextBoxExtender>
                &nbsp;TL</td><td class="auto-style41">Maliyet Fiyatı</td><td class="auto-style43">:</td><td><asp:TextBox ID="txtMaliyetFiyati" runat="server" Width="79px" TabIndex="18"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="txtMaliyetFiyati_FilteredTextBoxExtender" runat="server"  FilterType="Custom, Numbers"  ValidChars=".," Enabled="True" TargetControlID="txtMaliyetFiyati">
                </asp:FilteredTextBoxExtender>
                &nbsp;TL</td></tr><tr><td class="auto-style19">Toptan Bayi Fiyatı</td><td class="auto-style22">:</td><td class="auto-style25">
                <asp:TextBox ID="txtToptanBayiFiyati" runat="server" Width="79px" TabIndex="14"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="txtToptanBayiFiyati_FilteredTextBoxExtender" runat="server" FilterType="Custom, Numbers"  ValidChars=".," Enabled="True" TargetControlID="txtToptanBayiFiyati">
                </asp:FilteredTextBoxExtender>
                &nbsp;TL</td><td class="auto-style28">İndirim</td><td class="auto-style30">:</td><td class="auto-style25"><asp:TextBox ID="txtToptanBayiIndirim" runat="server" Width="79px" TabIndex="17"></asp:TextBox>
                <asp:FilteredTextBoxExtender ID="txtToptanBayiIndirim_FilteredTextBoxExtender" runat="server"  FilterType="Custom, Numbers"  ValidChars=".," Enabled="True" TargetControlID="txtToptanBayiIndirim">
                </asp:FilteredTextBoxExtender>
                &nbsp;TL</td><td class="auto-style39">Piyasa Fiyatı</td><td class="auto-style42">:</td><td class="auto-style20"><asp:TextBox ID="txtPiyasaFiyati" runat="server" Width="79px" TabIndex="19"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="txtPiyasaFiyati_FilteredTextBoxExtender" runat="server"  FilterType="Custom, Numbers"  ValidChars=".," Enabled="True" TargetControlID="txtPiyasaFiyati">
                    </asp:FilteredTextBoxExtender>
                    &nbsp;TL</td></tr><tr><td class="auto-style18">&nbsp;</td><td class="auto-style23">&nbsp;</td><td class="auto-style36">&nbsp;</td><td class="auto-style35">&nbsp;</td><td class="auto-style13">&nbsp;</td><td class="auto-style36">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="urunekle" />
                    </td><td class="auto-style41">&nbsp;</td><td class="auto-style43">&nbsp;</td><td>&nbsp;</td></tr></table>
                &nbsp;<table class="auto-style54">
                    <tr>
                        <td class="auto-style55">&nbsp;</td>
                        <td class="auto-style56">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate>Ürün Detayı</HeaderTemplate>
            <ContentTemplate><CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" Height="265px" Width="">
</CKEditor:CKEditorControl>&nbsp;<div class="p5_0 f10" style="padding: 5px 0px; font-size: 10px; line-height: 12px; color: rgb(34, 34, 34); font-family: Verdana, Arial; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: auto; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">• Ürünün detay içeriğini istediğiniz gibi düzenleyebilirsiniz.</div><div class="p5_0 f10" style="padding: 5px 0px; font-size: 10px; line-height: 12px; color: rgb(34, 34, 34); font-family: Verdana, Arial; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: auto; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">• İçeriğe özel html kod v.b. kendi kodlarınızı entegre etmek istiyorsanız, ilk sıradaki Kaynak yazan alana tıklayarak, kodlarınızı yapıştırdıktan sonra tekrar kaynağa basıp dizayn görünümüne dönün.</div></ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
            <HeaderTemplate>Ürün İndirimleri</HeaderTemplate>
            <ContentTemplate><table class="auto-style3"><tr><td class="auto-style58">Havale İndirimi (%)</td><td class="auto-style5">:</td><td><asp:TextBox ID="txtHavale" runat="server" Width="86px"></asp:TextBox><asp:FilteredTextBoxExtender ID="txtHavale_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Custom, Numbers" TargetControlID="txtHavale" ValidChars=".,"></asp:FilteredTextBoxExtender></td></tr><tr><td class="auto-style58">Tek Çekim İndirimi (%)</td><td class="auto-style5">:</td><td><asp:TextBox ID="txtTekCekim" runat="server" Width="86px"></asp:TextBox><asp:FilteredTextBoxExtender ID="txtTekCekim_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Custom, Numbers" TargetControlID="txtTekCekim" ValidChars=".,"></asp:FilteredTextBoxExtender></td></tr><tr><td class="auto-style46"></td><td class="auto-style47"></td><td class="auto-style48"><a href="indirim.aspx" target="_blank">Varsayılan indirim değerlerini değiştirmek için tıklayınız.</a></td></tr><tr>
                <td class="auto-style58">&nbsp;</td><td class="auto-style5">&nbsp;</td><td>&nbsp;</td></tr></table></ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel4">
            <HeaderTemplate>Ürün Nitelikleri</HeaderTemplate>
            <ContentTemplate><table class="auto-style3"><tr><td class="auto-style5">&nbsp;</td><td class="auto-style53">&nbsp;<asp:CheckBox ID="cbAktif" runat="server" Checked="True" Text="Aktif" /></td><td class="auto-style52">&nbsp;<asp:CheckBox ID="cbYeniUrum" runat="server" Text="Yeni Ürün" /></td><td>&nbsp;<asp:CheckBox ID="cbHaftaninUrunu" runat="server" Text="Haftanın Ürünü" /></td></tr><tr><td class="auto-style5">&nbsp;</td><td class="auto-style53">&nbsp;<asp:CheckBox ID="cbOzelUrun" runat="server" Text="Özel Ürün" /></td><td class="auto-style52"><asp:CheckBox ID="cbFiyatDusen" runat="server" Text="Fiyatı Düşen" /></td><td>&nbsp;<asp:CheckBox ID="cbVitrin" runat="server" Text="Vitrin Ürünü" /></td></tr><tr><td class="auto-style5">&nbsp;</td><td class="auto-style53">&nbsp;</td><td class="auto-style52">&nbsp;</td><td>&nbsp;</td></tr></table></ContentTemplate>
        </asp:TabPanel>
        <asp:TabPanel ID="TabPanel5" runat="server" HeaderText="TabPanel5">
            <HeaderTemplate>
                Ürün Resimleri
            </HeaderTemplate>
            <ContentTemplate>

     <table class="auto-style1">
    <tr>
        <td class="auto-style61"></td>
        <td class="auto-style62">Resim:</td>
        <td class="auto-style63">
            <asp:FileUpload ID="FuResim" runat="server"/>
&nbsp;<asp:Button ID="btnResimYukle" runat="server" CssClass="btn" Text="Resim Yükle" OnClick="btnResimYukle_Click" />
        </td>
    </tr>
    <tr>
        <td class="auto-style64"></td>
        <td class="auto-style65"></td>
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
                        <td>                    <img src="/Resimler/Urun/150/<%#Eval("ResimYolu150")%> " width="130"  alt="" /></td>
                    </tr>
                    <tr>
                        <td> <a href="UrunEkle.aspx?Urun=<%#Eval("UrunId")%>&islem=AnaResim&Resim=<%#Eval("ResimId")%>"> <span class="span-red"><span class="span-red">Ana Resim Yap</span><br /></a>
               <a onclick="return confirm('Bu resmi silmek istediğinizden emin misiniz?');" href="UrunEkle.aspx?Urun=<%#Eval("UrunId")%>&islem=sil&Resim=<%#Eval("ResimId")%>"> <span class="span-red">Resmi Sil</span></a></td>
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
    </asp:TabContainer>
    <br />
   
</asp:Content>
