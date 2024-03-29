<%@ Page Title="" Language="C#" MasterPageFile="~/Ana.Master" AutoEventWireup="true" CodeBehind="Siparis.aspx.cs" Inherits="Eticaret.Siparis" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="http://code.jquery.com/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('.textatla').keyup(function () {
                var c = $(this);
                if (c && c.val().length >= (c.attr("maxlength") * 1)) {
                    var tab = (c.attr("tabindex") * 1) + 1;
                    $('.textatla[tabindex="' + tab + '"]').focus().select();
                }
            });
        });

    </script>

    <style type="text/css">
        .TabLayout {
            height: 120px;
        }

        .ajax__tab_panel .ajax__tab_header {
            font-size: small;
            border-bottom: solid 1px #2647a0;
            border-bottom-color: #CCCCCC;
            border-bottom-width: 1px;
        }

            .ajax__tab_panel .ajax__tab_header .ajax__tab_outer {
                border-bottom-width: 0px;
                border-width: 1px;
                border-color: #CCCCCC;
                margin: 0px 0.16em 0px 0px;
                padding: 0px 0px 0px 0px;
                vertical-align: bottom;
                border-top-style: solid;
                border-right-style: solid;
                border-left-style: solid;
                background-color: #FFFF99;
                color: #000000;
                font-weight: bold;
            }

            .ajax__tab_panel .ajax__tab_header .ajax__tab_tab {
                color: #333333;
                padding: 0.35em 0.75em;
                margin-right: 0.01em;
            }

        .ajax__tab_panel .ajax__tab_hover .ajax__tab_outer {
            border-bottom-width: 0px;
            border-width: 1px;
            border-color: #CCCCCC;
            cursor: pointer;
            border-top-style: solid;
            border-right-style: solid;
            border-left-style: solid;
            background-color: #FFFFFF;
        }

        .ajax__tab_panel .ajax__tab_active .ajax__tab_tab {
            border-color: #CCCCCC;
            border-style: solid solid none solid;
            border-width: 0px;
            color: #000000;
        }

        .ajax__tab_panel .ajax__tab_active .ajax__tab_outer {
            border-style: solid solid none solid;
            border-width: 1px;
            background: #fff repeat-x left -1400px;
            color: #333333;
        }

        .ajax__tab_panel .ajax__tab_body {
            padding: 0.25em;
            color: #000000;
        }

        .auto-style1 {
            width: 100%;
            height: 108px;
        }

        .auto-style4 {
            height: 39px;
        }

        .auto-style5 {
            height: 82px;
        }

        .auto-style6 {
            height: 38px;
            width: 151px;
        }

        .auto-style7 {
            height: 82px;
            width: 290px;
        }

        .auto-style8 {
            height: 82px;
            width: 92px;
        }

        .auto-style9 {
            height: 38px;
            width: 92px;
        }

        .auto-style10 {
            width: 23px;
        }

        .auto-style13 {
            width: 138px;
        }

        .auto-style15 {
            width: 40px;
        }

        .auto-style18 {
            height: 15px;
        }

        .auto-style20 {
            height: 15px;
            width: 138px;
        }

        .auto-style24 {
            width: 171px;
        }
        .auto-style25 {
            width: 40px;
            height: 30px;
        }
        .auto-style26 {
            height: 30px;
        }
        .auto-style27 {
            width: 40px;
            height: 26px;
        }
        .auto-style28 {
            height: 26px;
        }
        .auto-style29 {
            width: 40px;
            height: 33px;
        }
        .auto-style30 {
            height: 33px;
        }
        .auto-style31 {
            width: 138px;
            height: 26px;
        }
        .auto-style33 {
            width: 170px;
        }
        .auto-style34 {
            width: 138px;
            height: 39px;
        }
        .auto-style35 {
            width: 16px;
            height: 39px;
        }
        .auto-style37 {
            width: 16px;
        }
        .auto-style39 {
            height: 15px;
            width: 14px;
        }
        .auto-style40 {
            height: 26px;
            width: 14px;
        }
        .auto-style41 {
            width: 14px;
        }
        .auto-style42 {
            width: 100%;
        }
        .auto-style43 {
            text-align: center;
        }
    </style>

    <%--radio buton--%>
    <script type="text/javascript">
        function SetSingleRadioButton(nameregex, current) {
            //alert(nameregex);
            var seciliindex

            seciliindex = nameregex;
            //alert(seciliindex)
            re = new RegExp(nameregex);
            $("#<%=HiddenBankaId.ClientID%>").val(seciliindex);
            for (i = 0; i < document.forms[0].elements.length; i++) {
                elm = document.forms[0].elements[i];
                if (elm.type == 'radio') {
                    if (elm != current) {
                        elm.checked = false;
                    }
                }
            }
            current.checked = true;
        }
    </script>
    <script type="text/javascript">
        function RadioButonSec(gelenid, currents) {
            //alert(nameregex);

            re = new RegExp(gelenid);
            $("#<%=HiddenKargoSec.ClientID%>").val(gelenid);
            for (i = 0; i < document.forms[0].elements.length; i++) {
                elm = document.forms[0].elements[i];
                if (elm.type == 'radio') {
                    if (elm != currents) {
                        elm.checked = false;
                    }
                }
            }
            current.checked = true;
        }
    </script>
    <%--radio buton--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cntSlider" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cntİcerik" runat="server">
          <div class="htabs">
        <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" Width="694px" CssClass="tab-content" >
            <asp:TabPanel runat="server" HeaderText="Tab1" ID="Tab1">
                <HeaderTemplate>Adres Bilgileri</HeaderTemplate>
                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style9"></td>
                            <td class="auto-style6"><strong>Teslimat Adresi</strong></td>
                            <td class="auto-style4"><strong>Fatura Adresi</strong></td>
                        </tr>

                        <tr>
                            <td class="auto-style8"></td>
                            <td class="auto-style7">
                                <div>
                                    <asp:Label ID="lblAdSoyad" runat="server"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="lblAdres" runat="server"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="lblTel" runat="server"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="lblilIlce" runat="server"></asp:Label>
                                </div>
                            </td>
                            <td class="auto-style5">
                                <div>
                                    <asp:Label ID="lblFaturaAdSoyad" runat="server"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="lblFaturaAdres" runat="server"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="lblFaturaTel" runat="server"></asp:Label>
                                </div>
                                <div>
                                    <asp:Label ID="lblFaturailIlce" runat="server"></asp:Label>
                                </div>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>

            </asp:TabPanel>
            <asp:TabPanel ID="Tab2" runat="server" HeaderText="Tab2" >
                <HeaderTemplate>Kargo Seçenekleri</HeaderTemplate>

                <ContentTemplate>
                    <div class="shoppingcart">
                        <ul class="carthead">
                            <table style="width: 100%; height: 24px;">

                                <tr>

                                    <td class="auto-style33">Kargo Firması</td>
                                    <td style="width: 300px" class="desc ">Kargo Notu</td>
                                    <td class="auto-style43" style="width: 153px">Kargo Ücreti</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </ul>
                        <table style="width: 100%">
                            <asp:Repeater ID="RpKargo" runat="server" OnItemDataBound="RpKargo_ItemDataBound" >
                                <ItemTemplate>

                                    <tr>
                                        <td style="width: 30px">
                                            
                                            
                                        <asp:RadioButton ID="RadioKargoId" runat="server" onKeyPress="return suppress(event);" Text='<%#Eval("KargoId")%>' GroupName="grbKargo" Font-Size="0"  />
                                             </td>
                                        <td style="width: 130px">
                                            <h5><%#Eval("KargoAdi")%></h5>
                                        </td>
                                        <td style="width: 300px"><%#Eval("Aciklama")%> </td>
                                        <td style="text-align:center">
                                            <h5><%#Convert.ToDouble(Eval("AltLimit")) >= Convert.ToDouble("50,0000") ? "-" :Eval("AltLimit","{0:c}") %></h5>
                                        </td>

                                        <td></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </table>
                        &nbsp;<asp:HiddenField ID="HiddenKargoSec" runat="server"  />
                        <br />


                    </div>
                </ContentTemplate>

            </asp:TabPanel>
            <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3" CssClass="tab-content">
                <HeaderTemplate>
                    Ödeme Seçenekleri
                </HeaderTemplate>
                <ContentTemplate>
                    <strong>Ödeme Tercihiniz</strong><asp:TabContainer ID="TabKrediKarti" runat="server" ActiveTabIndex="0" Width="682px" CssClass="review-list">
                    
                          <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                            <HeaderTemplate>
                                Kredi Kartı
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table class="auto-style1">
                                    <tr>
                                        <td class="auto-style13">Ara Toplam</td>
                                        <td class="auto-style41">:</td>
                                        <td>
                                            <asp:Label ID="lblKartAraToplam" runat="server" Font-Size="Large"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style20">KDV</td>
                                        <td class="auto-style39">:</td>
                                        <td class="auto-style18">
                                            <asp:Label ID="lblKartKdv" runat="server" Font-Size="Large"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style13">Kargo Ücreti</td>
                                        <td class="auto-style41">:</td>
                                        <td>
                                            <asp:Label ID="lblKartKargo" runat="server" Font-Size="Large"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="Td1" runat="server" class="auto-style31">Genel Toplam</td>
                                        <td id="Td2" runat="server" class="auto-style40">:</td>
                                        <td id="Td3" runat="server" class="auto-style28">
                                            <asp:Label ID="lblKartKdvDahil" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="trHavale1" runat="server">
                                        <td id="Td4" runat="server" class="auto-style13">&nbsp;</td>
                                        <td id="Td5" runat="server" class="auto-style41">&nbsp;</td>
                                        <td id="Td6" runat="server">&nbsp;</td>
                                    </tr>
                                </table>
                                <table class="auto-style1">
                                    <tr>
                                        <td class="auto-style13">Kart Numarası</td>
                                        <td class="auto-style37">:</td>
                                        <td>
                                            
                                            <asp:TextBox ID="txtKartNo1" autocomplete="off" runat="server" CssClass="text textatla" MaxLength="4" Width="41px" TabIndex="1"  ></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txtKartNo1_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtKartNo1">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtKartNo1" ErrorMessage="Kartınızın ilk 4 rakamlı numarasını giriniz" ForeColor="Red" ValidationGroup="grbodeme">*</asp:RequiredFieldValidator>
                                            -&nbsp; <asp:TextBox ID="txtKartNo2" runat="server" autocomplete="off" CssClass="text textatla" MaxLength="4" Width="41px" TabIndex="2"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txtKartNo2_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtKartNo2">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtKartNo2" ErrorMessage="Kartınızın ikinci 4 rakamlı numarasını giriniz" ForeColor="Red" ValidationGroup="grbodeme">*</asp:RequiredFieldValidator>
                                            -&nbsp;
                                            <asp:TextBox ID="txtKartNo3" runat="server" autocomplete="off" CssClass="text textatla" MaxLength="4" Width="41px" TabIndex="3"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txtKartNo3_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtKartNo3">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtKartNo3" ErrorMessage="Kartınızın üçüncü 4 rakamlı numarasını giriniz" ForeColor="Red" ValidationGroup="grbodeme">*</asp:RequiredFieldValidator>
                                            -&nbsp;
                                            <asp:TextBox ID="txtKartNo4" runat="server" autocomplete="off" CssClass="text textatla" MaxLength="4" Width="41px" TabIndex="4"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txtKartNo4_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtKartNo4">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtKartNo4" ErrorMessage="Kartınızın dördüncü 4 rakamlı numarasını giriniz" ForeColor="Red" SetFocusOnError="True" ValidationGroup="grbodeme">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style13">Son Kullanma Tarihi</td>
                                        <td class="auto-style37">:</td>
                                        <td>
                                            <asp:DropDownList ID="ddAy" runat="server" Width="50px">
                                                <asp:ListItem Value="0">Ay</asp:ListItem>
                                                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                                                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                                                <asp:ListItem Text="5" Value="5"></asp:ListItem>
                                                <asp:ListItem Text="6" Value="6"></asp:ListItem>
                                                <asp:ListItem Text="7" Value="7"></asp:ListItem>
                                                <asp:ListItem Text="8" Value="8"></asp:ListItem>
                                                <asp:ListItem Text="9" Value="9"></asp:ListItem>
                                                <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddAy" ErrorMessage="Son kullanma tarihi Ay'ı seçiniz" ForeColor="Red" InitialValue="0" ValidationGroup="grbodeme">*</asp:RequiredFieldValidator>
                                            &nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddYil" runat="server">
                                                <asp:ListItem Value="0">Yıl</asp:ListItem>
                                                <asp:ListItem Text="2010" Value="2010"></asp:ListItem>
                                                <asp:ListItem Text="2011" Value="2011"></asp:ListItem>
                                                <asp:ListItem Text="2012" Value="2012"></asp:ListItem>
                                                <asp:ListItem Text="2013" Value="2013"></asp:ListItem>
                                                <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                                                <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                                                <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                                                <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                                                <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                                <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                                <asp:ListItem Text="2021" Value="2021"></asp:ListItem>
                                                <asp:ListItem Text="2022" Value="2022"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddYil" ErrorMessage="Son kullanma tarihi Yıl'ı seçiniz" ForeColor="Red" ValidationGroup="grbodeme" InitialValue="0">*</asp:RequiredFieldValidator>
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style13">Güvenlik (CVC) Kodu</td>
                                        <td class="auto-style37">:</td>
                                        <td>
                                            <asp:TextBox ID="txtCvc" runat="server" autocomplete="off" CssClass="text textatla" MaxLength="3"  ToolTip="Güvenlik kodu Visa ve Master türündeki kredi kartlarının arka yüzünde bulunan 3 haneli numaradır. (American Express kartlarında bu numara ön yüzde sağ üst köşede ve 4 hanedir.)" Width="41px" TabIndex="7"></asp:TextBox>
                                            <asp:FilteredTextBoxExtender ID="txtCvc_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtCvc">
                                            </asp:FilteredTextBoxExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtCvc" ErrorMessage="Kartınızın güvenlik (CVC) kodunu yazınız" ForeColor="Red" ValidationGroup="grbodeme">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style13">Kart Üzerindeki İsim</td>
                                        <td class="auto-style37">:</td>
                                        <td>
                                            <asp:TextBox ID="txtKartSahibi" autocomplete="off" runat="server" CssClass="text textatla" Width="200px" TabIndex="8"></asp:TextBox>
                                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtKartSahibi" ErrorMessage="Kart üzerindeki adı yazınız" ForeColor="Red" ValidationGroup="grbodeme">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                     <tr>
                                        <td class="auto-style13">Taksit Seçeneği</td>
                                        <td class="auto-style37">:</td>
                                        <td>
                                            &nbsp;<asp:RadioButton ID="RadioTaksitli" runat="server" Checked="True" Text="Tek Çekim" AutoPostBack="True" GroupName="grbTaksit" OnCheckedChanged="RadioTaksitli_CheckedChanged" />
&nbsp;
                                            <asp:RadioButton ID="RadioTaksit" runat="server" Text="Taksitli Ödeme" AutoPostBack="True" GroupName="grbTaksit" OnCheckedChanged="RadioTaksit_CheckedChanged" />
                                            &nbsp;</td>
                                    </tr>
                                      <tr runat="server" id="trTaksit" visible="False">
                                        <td id="Td7" class="auto-style13" runat="server">Taksit </td>
                                        <td id="Td8" class="auto-style37" runat="server">:</td>
                                        <td id="Td9" runat="server">
                                            <asp:DropDownList ID="ddBanka" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddBanka_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            &nbsp;-
                                            <asp:DropDownList ID="ddTaksit" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddTaksit_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="ddTaksit" ErrorMessage="Taksit Seçiniz" ForeColor="Red" InitialValue="0" ValidationGroup="grbodeme">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="trTekCekimOdeme" visible="False">
                                        <td id="Td10" class="auto-style13" runat="server">Ödeme Yapacağınız Banka</td>
                                        <td id="Td11" class="auto-style37" runat="server">:</td>
                                        <td id="Td12" runat="server">
                                            <asp:DropDownList ID="ddTekCekBanka" runat="server" OnSelectedIndexChanged="ddBanka_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddTekCekBanka" ErrorMessage="Ödeme yapacağınız bankayı seçiniz" ForeColor="Red" InitialValue="0" ValidationGroup="grbodeme">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style34">
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="grbodeme" />
                                        </td>
                                        <td class="auto-style35"></td>
                                        <td class="auto-style4">
                                            <asp:Button ID="btnKrediKartiOde" runat="server" CssClass="button" Text="Ödemeyi Tamamla" ValidationGroup="grbodeme" Width="208px" OnClick="btnKrediKartiOde_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style13">&nbsp;</td>
                                        <td class="auto-style37">&nbsp;</td>
                                        <td>
                                            <asp:Label ID="lblBilgi" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                               
                            </ContentTemplate>
                            
                        </asp:TabPanel>
                         <asp:TabPanel ID="Tab3DOdeme" runat="server" HeaderText="TabPanel3">
                             <HeaderTemplate>
                                 Kredi Kartı 3D Ortak Ödeme
                             </HeaderTemplate>
                            <ContentTemplate>
                                <table class="auto-style1">
                                    <tr>
                                        <td class="auto-style57">Ara Toplam</td>
                                        <td class="auto-style58">:</td>
                                        <td class="auto-style59">
                                            <asp:Label ID="lblKartAraToplam3D" runat="server" Font-Size="Large"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style60">KDV</td>
                                        <td class="auto-style61">:</td>
                                        <td class="auto-style62">
                                            <asp:Label ID="lblKartKdv3D" runat="server" Font-Size="Large"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style47">Kargo Ücreti</td>
                                        <td class="auto-style48">:</td>
                                        <td class="auto-style30">
                                            <asp:Label ID="lblKartKargo3D" runat="server" Font-Size="Large"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td id="Td25" runat="server" class="auto-style47">Genel Toplam</td>
                                        <td id="Td26" runat="server" class="auto-style48">:</td>
                                        <td id="Td27" runat="server" class="auto-style30">
                                            <asp:Label ID="lblKartKdvDahil3D" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style44">Taksit Seçeneği</td>
                                        <td class="auto-style37">:</td>
                                        <td>
                                            &nbsp;<asp:RadioButton ID="RadioTekCek3D" runat="server" Checked="True" Text="Tek Çekim" AutoPostBack="True" GroupName="grbTaksit" OnCheckedChanged="RadioTekCek3D_CheckedChanged" Width="100px" />
&nbsp;
                                            <asp:RadioButton ID="RadioTaksitli3D" runat="server" Text="Taksitli Ödeme" AutoPostBack="True" GroupName="grbTaksit" OnCheckedChanged="RadioTaksitli3D_CheckedChanged" Width="200px" />
                                            &nbsp;</td>
                                    </tr>
                                      <tr runat="server" id="trTaksit3d" visible="False">
                                        <td id="Td31" class="auto-style44" runat="server">Taksit </td>
                                        <td id="Td32" class="auto-style37" runat="server">:</td>
                                        <td id="Td33" runat="server">
                                            <asp:DropDownList ID="ddBanka3D" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddBanka3D_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            &nbsp;-
                                            <asp:DropDownList ID="ddTaksit3D" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddTaksit3D_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="ddTaksit3D" ErrorMessage="Taksit Seçiniz" ForeColor="Red" InitialValue="0" ValidationGroup="grbodeme3d">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr runat="server" id="trTekCekimOdeme3D" visible="False">
                                        <td id="Td34" class="auto-style54" runat="server">Ödeme Yapacağınız Banka</td>
                                        <td id="Td35" class="auto-style55" runat="server">:</td>
                                        <td id="Td36" runat="server" class="auto-style56">
                                            <asp:DropDownList ID="ddTekCekBanka3D" runat="server" OnSelectedIndexChanged="ddTekCekBanka3D_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddTekCekBanka3D" ErrorMessage="Ödeme yapacağınız bankayı seçiniz" ForeColor="Red" InitialValue="0" ValidationGroup="grbodeme3d">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                   
                                    <tr id="tr1" runat="server">
                                        <td id="Td28" runat="server" class="auto-style44">   <asp:ValidationSummary ID="ValidationSummary3D" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="grbodeme3d" /></td>
                                        <td id="Td29" runat="server" class="auto-style41">&nbsp;</td>
                                        <td id="Td30" runat="server">
                                            <asp:Button ID="btn3dOdeme" runat="server" CssClass="button" Height="40px" Text="Ödeme İşlemi" ValidationGroup="grbodeme3d" Width="180px" OnClick="btn3dOdeme_Click" />
                                            <br />
                                            <br />
                                            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                            <br />
                                            <br />
                                            <asp:Label ID="lblTrnxID" runat="server" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                          </asp:TabPanel>
                        <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                            <HeaderTemplate>
                                Havale/EFT
                            </HeaderTemplate>
                            <ContentTemplate>

                                <table style="width: 100%; height: 30px;">

                                    <tr>
                                        <td class="auto-style10">&nbsp;</td>
                                        <td style="width: 96px" class="desc "><strong>Banka</strong></td>
                                        <td style="width: 235px" class="desc "><strong>Şube - Hesap No</strong></td>


                                    </tr>

                                </table>
                                <hr />
                                <table style="width: 100%">

                                    <asp:Repeater ID="RpBankaHavale" runat="server" OnItemDataBound="RpBankaHavale_ItemDataBound">

                                        <ItemTemplate>

                                            <tr>
                                                <td style="width: 30px">
                                                    <asp:RadioButton ID="RadioKargo" runat="server" onKeyPress="return suppress(event);" Text='<%#Eval("BankaId")%>' GroupName="grbBanka" Font-Size="0"  />

                                                </td>
                                                <td style="width: 130px"><%#Eval("BankaAdi")%></td>
                                                <td style="width: 320px">Şube: <%#Eval("SubeAdi")%> - Şube Kodu: <%#Eval("SubeKodu")%><br />
                                                    <h5>Hesap No: <%#Eval("HesapNo" )%>&nbsp;IBAN: <%#Eval("IBAN")%></h5>
                                                </td>

                                            </tr>

                                        </ItemTemplate>

                                    </asp:Repeater>
                                    <tr>
                                        <td style="width: 30px"></td>
                                        <td style="width: 130px">&nbsp;</td>
                                        <td style="width: 320px">
                                            <br />
                                            &nbsp;<table class="auto-style1">
                                                <tr>
                                                    <td class="auto-style24">Ara Toplam</td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:Label ID="lblHavaleAraToplam" runat="server" Font-Size="Large"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style20">KDV</td>
                                                    <td class="auto-style18">:</td>
                                                    <td class="auto-style18">
                                                        <asp:Label ID="lblHavaleKdv" runat="server" Font-Size="Large"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="auto-style24">Kargo Ücreti</td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:Label ID="lblHavaleKargo" runat="server" Font-Size="Large"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr id="trHavaleKDV" runat="server">
                                                    <td id="Td13" class="auto-style24" runat="server">Genel Toplam</td>
                                                    <td id="Td14" runat="server">:</td>
                                                    <td id="Td15" runat="server">
                                                        <asp:Label ID="lblHavaleKdvDahil" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr id="trHavale" runat="server">
                                                    <td id="Td16" class="auto-style24" runat="server">Genel Toplam</td>
                                                    <td id="Td17" runat="server">:</td>
                                                    <td id="Td18" runat="server">
                                                        <asp:Label ID="lblHavaleFiyat" runat="server" Font-Size="Large" ForeColor="Maroon"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <br />
                                            <asp:Button ID="btnHavaleTamamla" runat="server" CssClass="button" Text="Siparişi Tamamla" Width="204px" OnClick="btnHavaleTamamla_Click" />
                                            &nbsp;<asp:HiddenField ID="HiddenBankaId" runat="server" />
                                            <br />

                                        </td>

                                    </tr>
                                </table>
                                <strong>
                                    <br />
                                    <br />
                                    Havale/EFT yaparken dikkat edilmesi gerekenler:</strong> &nbsp;<br />Siparişinizin gecikmemesi için, Havale/EFT işleminizi gerçekleştirdikten sonra&nbsp;<a href="/OdemeBildirim.aspx" target="_blank">Ödeme Bildirim Formu</a>&#39;nu doldurarak ödeme bilgisini bize iletiniz.<br />
                                <br />
                                &nbsp;
                            </ContentTemplate>
                        </asp:TabPanel>
                        <asp:TabPanel ID="Tabs3" runat="server" HeaderText="Tabs3">
                            <HeaderTemplate>
                                Kapıda Ödeme
                            </HeaderTemplate>
                            <ContentTemplate>
                                <table class="auto-style1">
                                    <tr>
                                        <td class="auto-style25"><strong></strong></td>
                                        <td class="auto-style26"><strong>Siparişinizi tamamladıktan sonra müşteri hizmetleri departmanımız sizinle iletişime geçecektir.</strong></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style27"></td>
                                        <td class="auto-style28"><strong>Seçtiğiniz kargo&#39;nun kapıda ödeme ücreti varsa fiyata dahil edilecektir.</strong></td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style29"></td>
                                        <td class="auto-style30">
                                            <table class="auto-style1">
                                                <tr>
                                                    <td class="auto-style24">Ara Toplam</td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:Label ID="lblKapidaAraToplam" runat="server" Font-Size="Large"></asp:Label>
                                                    </td>
                                                </tr>
                                                 
                                                <tr>
                                                    <td class="auto-style20">KDV</td>
                                                    <td class="auto-style18">:</td>
                                                    <td class="auto-style18">
                                                        <asp:Label ID="lblKapidaKdv" runat="server" Font-Size="Large"></asp:Label>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td class="auto-style24">Kargo Ücreti</td>
                                                    <td>:</td>
                                                    <td>
                                                        <asp:Label ID="lblKapidaKargo" runat="server" Font-Size="Large"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td id="Td19" runat="server" class="auto-style31">Genel Toplam</td>
                                                    <td id="Td20" runat="server" class="auto-style28">:</td>
                                                    <td id="Td21" runat="server" class="auto-style28">
                                                        <asp:Label ID="lblKapidaKdvDahil" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr id="trHavale0" runat="server">
                                                    <td id="Td22" runat="server" class="auto-style24">&nbsp;</td>
                                                    <td id="Td23" runat="server">&nbsp;</td>
                                                    <td id="Td24" runat="server">
                                                        <asp:Button ID="btnKapidaOdeme" runat="server" CssClass="button" OnClick="btnKapidaOdeme_Click" Text="Siparişi Tamamla" Width="204px" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style15">&nbsp;</td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:TabPanel>
                         
                    </asp:TabContainer>
                </ContentTemplate>
            </asp:TabPanel>
        </asp:TabContainer>
      
 <table class="auto-style42">
        <tr>
            <td style="text-align:left"><asp:Button ID="btnGeri" runat="server" CssClass="button" Height="40px" OnClick="btnGeri_Click" Text="&lt;&lt; Geri" Width="102px" /></td>
            <td style="text-align:right">
        <asp:Button ID="btnileri" runat="server" CssClass="button" Height="40px" OnClick="btnileri_Click" Text="İleri &gt;&gt;" Width="102px" /></td>
        </tr>
    </table>
  </div>  <br />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cntAlt" runat="server">
</asp:Content>
