<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="Varyantlar.aspx.cs" Inherits="Eticaret.yonetim.Varyantlar" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 216%;
        }

        .auto-style5 {
            width: 180px;
        }

        .auto-style6 {
            width: 109px;
            height: 52px;
        }

        .auto-style7 {
            height: 52px;
        }

        .auto-style9 {
            width: 180px;
            height: 52px;
        }
        .auto-style10 {
            width: 109px;
        }
        .auto-style14 {
            width: 17px;
        }
        .auto-style15 {
            height: 52px;
            width: 17px;
        }
        .auto-style16 {
            width: 369px;
        }
        .auto-style17 {
            width: 369px;
            height: 52px;
        }
        .auto-style20 {
            width: 211px;
        }
        .auto-style22 {
            height: 52px;
            width: 21px;
        }
        .auto-style23 {
            width: 21px;
        }
        .auto-style24 {
            width: 119px;
        }
        .auto-style25 {
            width: 119px;
            height: 52px;
        }
        .auto-style26 {
        height: 37px;
    }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="PanelAnaKategori" runat="server">
    <table class="auto-style1" id="tbVaryantEkle" runat="server" visible="false">
        <tr>
            <td class="auto-style10"><strong>Varyant Ekle</strong></td>
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6">Aktif
                </td>
            <td class="auto-style15">:</td>
            <td class="auto-style17">
                <asp:CheckBox ID="cbKatAktif" runat="server" Checked="True" />
            </td>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style7">
                &nbsp;</td>
        </tr>
        
        
        <tr>
            <td class="auto-style10">Varyant Adı</td>
            <td class="auto-style14">:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtKategoriAdi" ErrorMessage="*" ForeColor="Red" ValidationGroup="grbKat"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style16">
                <asp:TextBox ID="txtKategoriAdi" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style5">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style14">&nbsp;</td>
            <td class="auto-style16">
                <asp:Button ID="btnKategoriEkle" runat="server" CssClass="btn" OnClick="btnKategoriEkle_Click" Text="Varyant Ekle" ValidationGroup="grbKat" Visible="False" />
                <asp:Button ID="btnDuzenle" runat="server" CssClass="btn" OnClick="btnDuzenle_Click" Text="Varyant Düzenle" ValidationGroup="grbKat" Visible="False" />
                <asp:Button ID="btnAnaGit" runat="server" CssClass="btn" OnClick="btnAnaGit_Click" Text="&lt;&lt; Geri" Visible="False" />
            </td>
            <td class="auto-style5">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br />
        Varyantlar:
  
            <table class="table">
                <thead>
                    <tr>
                        <th class="auto-style20">Varyant Adı</th>
                         <th class="input-medium">Alt Varyant</th>
                        <th class="input-medium">Durum</th>
                        <th>İşlem</th>
                        <th style="width: 26px;"></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="RpKayit" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("VaryantAdi")%></a></td>
                           <td><a href="Varyantlar.aspx?islem=Alt&v=<%#Eval("AnaVaryantId")%>">Alt Varyant Ekle</a></td>
                                <td><%#Eval("Durumadi")%></td>
                                <td><a href="Varyantlar.aspx?v=<%#Eval("AnaVaryantId")%>&islem=duzenle" title="Düzenle"><i class="icon-pencil"></i></a>
                                   <%-- <a onclick="return confirm('Dikkat: (<%#Eval("VaryantAdi")%>) Adlı Varyantı Silmek İstediğinizden Emin Misiniz?');" href="Varyantlar.aspx?v=<%#Eval("AnaVaryantId")%>&islem=sil" title="Sil"><i class="icon-remove"></i></a>--%></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        <cc1:CollectionPager ID="CollectionPager1" runat="server" BackText="« Geri" LabelText="Sayfa:" NextText="İleri »" PageSize="15" PagingMode="QueryString" QueryStringKey="Sayfa" ResultsFormat=""></cc1:CollectionPager>
        </asp:Panel>
    <asp:Panel ID="PanelAltKategori" runat="server" Visible="False">
        <table class="auto-style1">
        <tr>
            <td class="auto-style24"><strong>Alt Varyant Ekle</strong></td>
            <td class="auto-style23">&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style25">Aktif
                </td>
            <td class="auto-style22">:</td>
            <td class="auto-style17">
                <asp:CheckBox ID="cbAltKat" runat="server" Checked="True" />
            </td>
            <td class="auto-style9"></td>
            <td class="auto-style7">
                </td>
        </tr>
         <tr>
            <td class="auto-style25">Ana Varyant</td>
            <td class="auto-style22">:</td>
            <td class="auto-style17">
                <asp:Label ID="lblAna" runat="server"></asp:Label>
                &nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style7">
                &nbsp;</td>
        </tr>
         <tr>
            <td class="auto-style24">&nbsp;</td>
            <td class="auto-style23">&nbsp;</td>
            <td class="auto-style16">
                <asp:DropDownList ID="ddAltKategori" runat="server" Visible="False">
                </asp:DropDownList>
            </td>
            <td class="auto-style5">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style24">Alt Varyant Adı</td>
            <td class="auto-style23">:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAltKat" ErrorMessage="*" ForeColor="Red" ValidationGroup="grbAltKat"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style16">
                <asp:TextBox ID="txtAltKat" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style5">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style24">&nbsp;</td>
            <td class="auto-style23">&nbsp;</td>
            <td class="auto-style16">
                <asp:Button ID="btnAltEkle" runat="server" CssClass="btn" OnClick="btnAltEkle_Click" Text="Varyant Ekle" ValidationGroup="grbAltKat" />
                <asp:Button ID="btnAltDuzenle" runat="server" CssClass="btn" Text="Varyant Düzenle" ValidationGroup="grbAltKat" Visible="False" OnClick="btnAltDuzenle_Click" />
                <asp:Button ID="btnGeri" runat="server" CssClass="btn" OnClick="btnGeri_Click" Text="&lt;&lt; Geri" Visible="False" />
                &nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <br />
        <asp:Label ID="lblAltBilgi" runat="server"></asp:Label>
        &nbsp;<table class="table">
                <thead>
                    <tr>
                        <th class="auto-style20">Alt Varyant Adı</th>
                        <th class="input-medium">Durum</th>
                        <th>İşlem</th>
                        <th style="width: 26px;"></th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rpAltKategori" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("AltVaryantAdi")%></a></td>
                           
                                <td><%#Eval("Durumadi")%></td>
                                <td><a href="Varyantlar.aspx?Alt=<%#Eval("AltVaryantId")%>&v=<%#Eval("AnaVaryantId")%>&islem=ad" title="Düzenle"><i class="icon-pencil"></i></a>
                                    <a onclick="return confirm('Dikkat: (<%#Eval("AltVaryantAdi") %>) Adlı Varyantı Silmek İstediğinizden Emin Misiniz?');" href="Varyantlar.aspx?Alt=<%#Eval("AltVaryantId")%>&islem=as&v=<%#Eval("AnaVaryantId")%>" title="Sil"><i class="icon-remove"></i></a></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
    </asp:Panel>
</asp:Content>
