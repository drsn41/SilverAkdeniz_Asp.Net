<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="user_info.aspx.cs" Inherits="MyInfo" %>

<%@ Register Src="~/UserControls/CustomerDetail.ascx" TagPrefix="uc1" TagName="CustomerDetail" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="span9">
        <ul class="breadcrumb">
            <li><a href="index.aspx">Anasayfa</a> <span class="divider">/</span></li>
            <li>Müşrei Bilgileri<span class="divider">/</span></li>
        </ul>
        <div class="well well-small">
            <h4>Bilgelinizi Düzenleyin.</h4>
            <uc1:CustomerDetail runat="server" ID="CustomerDetail" />
        </div>
    </div>
</asp:Content>

