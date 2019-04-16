<%@ Page Title="" Language="C#" MasterPageFile="~/Other.master" AutoEventWireup="true" CodeFile="forget_password.aspx.cs" Inherits="forget_password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li><a href="index.aspx">Anasayfa</a> <span class="divider">/</span></li>
        <li class="active">Şifremi Unuttum</li>
    </ul>
    <div class="well well-small">
        <h3>FORGOT YOUR PASSWORD</h3>
        <hr class="soft" />

        Please enter the e-mail address used to register. We will e-mail you your new password.<br />
        <br />
        <br />


        <asp:PasswordRecovery ID="PasswordRecovery1" runat="server"></asp:PasswordRecovery>
    </div>

</asp:Content>

