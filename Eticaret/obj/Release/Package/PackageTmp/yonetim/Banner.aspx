<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="Banner.aspx.cs" Inherits="Eticaret.yonetim.Banner" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            height: 59px;
        }

        .auto-style4 {
            width: 16px;
        }

        .auto-style5 {
            width: 144px;
        }

        .auto-style6 {
            width: 144px;
            height: 43px;
        }

        .auto-style7 {
            width: 16px;
            height: 43px;
        }

        .auto-style8 {
            height: 43px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;<table class="auto-style1">
        <tr>
            <td class="auto-style2">
                <div class="well">

                    <br />
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style5">Başlık</td>
                            <td class="auto-style4">:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBaslik" ErrorMessage="Başlık alanını boş geçemezsiniz" ForeColor="Red" ValidationGroup="Banner">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="txtBaslik" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style5">Url Adres</td>
                            <td class="auto-style4">:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txturlAdres" ErrorMessage="Url adresini boş geçemezsiniz" ForeColor="Red" ValidationGroup="Banner">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:TextBox ID="txturlAdres" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style5">Aktif</td>
                            <td class="auto-style4">:</td>
                            <td>
                                <asp:CheckBox ID="cbAktif" runat="server" Checked="True" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style5">Yeni Sayfada Açılsın</td>
                            <td class="auto-style4">:</td>
                            <td>
                                <asp:CheckBox ID="cbYeniSayfa" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style6">Resim</td>
                            <td class="auto-style7">:</td>
                            <td class="auto-style8">
                                <asp:Panel ID="Panel1" runat="server">
                                    <asp:FileUpload ID="FuResim" runat="server" />
                                    <br />
                                    <asp:Image ID="imgResim" runat="server" Visible="False" Width="100px" />
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style5">&nbsp;</td>
                            <td class="auto-style4">&nbsp;</td>
                            <td>
                                <asp:Button ID="btnEkle" runat="server" CssClass="btn" OnClick="btnEkle_Click" Text="Ekle" ValidationGroup="Banner" />
                                &nbsp;<asp:Button ID="btnDuzenle" runat="server" CssClass="btn" Text="Düzenle" ValidationGroup="Banner" Visible="False" OnClick="btnDuzenle_Click" />
                            &nbsp;<asp:Button ID="btnGeri" runat="server" CssClass="btn" OnClick="btnGeri_Click" Text="Geri" Visible="False" />
                            </td>
                        </tr>
                    </table>


                </div>

            </td>
        </tr>
        <tr>
            <td>

                <div class="well">
                    &nbsp;
            <table class="table">
                <thead>
                    <tr>


                        <th>Başlık</th>
                        <th>Url Adres</th>
                        <th>Resim</th>
                        <th>Durum</th>
                        <th style="width: 26px;">İşlem</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="RpKayit" runat="server">
                        <ItemTemplate>
                            <tr>

                                <td><%#Eval("Baslik")%></td>
                                <td><%#Eval("UrlAdres")%></td>

                                <td>
                                    <img src="/Resimler/Banner/<%#Eval("Resim")%> " width="35" height="30" title="<%#Eval("Baslik")%>" /></td>
                                <td><%#Eval("Durumadi")%></td>

                                <td>


                                    <a href="Banner.aspx?BannerId=<%#Eval("BannerId")%>&islem=duzenle" title="Düzenle"><i class="icon-pencil"></i></a>

                                    <a onclick="return confirm('Dikkat: (<%#Eval("BannerId") %>) Numaralı Banneri Silmek İstediğinizden Emin Misiniz?');" href="Banner.aspx?BannerId=<%#Eval("BannerId")%>&islem=sil" title="Sil"><i class="icon-remove"></i></a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>

                </div>
                <div class="pagination">
                    <cc1:CollectionPager ID="CollectionPager1" runat="server" BackText="« Geri" LabelText="Sayfa:" NextText="İleri »" QueryStringKey="Sayfa" ResultsFormat="">
                    </cc1:CollectionPager>
                </div>

                </div>
        </div>
                 
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="grbAra" />

            </td>
        </tr>
    </table>
</asp:Content>
