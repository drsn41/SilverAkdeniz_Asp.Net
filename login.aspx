<%@ Page Title="" Language="C#" MasterPageFile="~/Other.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li><a href="index.aspx">Anasayfa</a> <span class="divider">/</span></li>
        <li class="active">Giriş</li>
    </ul>
    <div class="well well-small">
        <h1>Giriş Yapın</h1>
        <hr class="soften" />

        <div class="well well-small">
            <asp:Login ID="Login1" runat="server">
            </asp:Login>
            <br />

            <asp:PasswordRecovery  ID="PasswordRecovery1" runat="server">
            </asp:PasswordRecovery>
        </div>

    </div>

</asp:Content>

