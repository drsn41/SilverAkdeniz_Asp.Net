<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="check_out.aspx.cs" Inherits="check_out" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        
        .auto-style2 {
            text-align: left;
            width: 126px;
        }

        .auto-style3 {
            width: 126px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="span9">
        <ul class="breadcrumb">
            <li><a href="index.aspx">Anasayfa</a> <span class="divider">/</span></li>
            <li class="active">Ödeme İşlemi</li>
        </ul>
        <div class="well well-small">


            <table class="table table-bordered table-condensed">
                <tr>
                    <td class="auto-style2"><b>Durum:</b> </td>
                    <td>
                        <asp:Label ID="lblStatus" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"><b>Banka Seçiniz:</b></td>
                    <td>
                        <asp:Label ID="lblBankName" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"><b>Ödeme Tutarı:</b> </td>
                    <td>
                        <asp:Label ID="lblCost" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"><b>Alıcı İsmi:</b></td>
                    <td>
                        <asp:Label ID="lblAccountOwner"  runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"><b>IBAN:</b>  </td>
                    <td>
                        <asp:Label ID="lblBankNumber" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2"><b>Ödeme Kimligi:</b></td>
                    <td>
                        <asp:Label ID="lblPaymentID" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3"><b>Açıklama!</b></td>
                    <td>
                        <asp:Label ID="lblDecription" runat="server"></asp:Label>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        <br />
                    </td>
                    <td>
                        <asp:Button ID="btnPay" runat="server" CssClass="btn-success" Text="Alışverişi Tamamla" OnClick="btnPay_Click" />
                    </td>
                </tr>
            </table>


        </div>
    </div>
</asp:Content>

