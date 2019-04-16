<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="products.aspx.cs" Inherits="products" EnableEventValidation="false" %>

<%@ Register Src="~/UserControls/ProductsOfCategory.ascx" TagPrefix="uc1" TagName="ProductsOfCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="span9">
        <ul class="breadcrumb">
            <li><a href="index.aspx">Anasayfa</a> <span class="divider">/</span></li>
            <li><a href="products.aspx">Ürünler</a> <span class="divider">/</span></li>
        </ul>
        <div class="well well-small">

            <uc1:ProductsOfCategory runat="server" ID="ProductsOfCategory" />
        </div>
    </div>

</asp:Content>

