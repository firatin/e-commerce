<%@ Page Title="" Language="C#" MasterPageFile="~/yonetim/AnaPage.Master" AutoEventWireup="true" CodeBehind="Reklam.aspx.cs" Inherits="Eticaret.yonetim.Reklam" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            height: 22px;
        }
        .auto-style4 {
            height: 22px;
            width: 92px;
        }
        .auto-style7 {
            height: 22px;
            width: 27px;
        }
        .auto-style8 {
            width: 27px;
        }
        .auto-style9 {
            width: 92px;
        }
        .auto-style10 {
            width: 136px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="divReklam" runat="server" visible="false">
    <table class="auto-style1">
        <tr>
            <td class="auto-style9">Reklam Alanı</td>
            <td class="auto-style8">:</td>
            <td>
                <asp:Label ID="lblAlan" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">Aktif</td>
            <td class="auto-style8">:</td>
            <td>
                <asp:CheckBox ID="cbAktif" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style9">Başlık</td>
            <td class="auto-style8">:</td>
            <td>
                <asp:TextBox ID="txtBaslik" runat="server" Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">Url Adres</td>
            <td class="auto-style8">:</td>
            <td>
                <asp:TextBox ID="txtUrl" runat="server" Width="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">Logo</td>
            <td class="auto-style8">:</td>
            <td>
                <asp:FileUpload ID="FuResim" runat="server" />
                <br />
                <asp:Image ID="Image1" runat="server" Height="100px" Width="400px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style4"></td>
            <td class="auto-style7"></td>
            <td class="auto-style2">
                <asp:Button ID="btnKaydet" runat="server" CssClass="btn" Text="Kaydet" OnClick="btnKaydet_Click" />
            &nbsp;<asp:Button ID="btnVazgec" runat="server" CssClass="btn" Text="Vazgeç" OnClick="btnVazgec_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style4"></td>
            <td class="auto-style7"></td>
            <td class="auto-style2"></td>
        </tr>
    </table>
    </div>
    &nbsp;<table class="table">
                <thead>
                    <tr>
                        <th class="auto-style10">Alan</th>
                        <th>Başlık</th>
                        <th>Url Adres</th>
                        <th>Logo</th>
                        <th class="auto-style17">Durum</th>
                        <th style="width: 26px;">İşlem</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="RpKayit" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("AlanAdi")%></a></td>
                                <td><%#Eval("Baslik")%></td>
                              <td> <a href="<%#Eval("UrlAdres")%>" target="_blank"><%#Eval("UrlAdres")%></a></td>
                              <td>  <img src="/Resimler/Banner/<%#Eval("Logo")%>" width="40" height="50" title="<%#Eval("Baslik")%>" /></td>
                                <td><%#Eval("Durumadi")%></td>
                                <td><a href="Reklam.aspx?Alan=<%#Eval("ReklamId")%>&islem=duzenle" title="Düzenle"><i class="icon-pencil"></i></a>
                               </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
</asp:Content>
