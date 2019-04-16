<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchBar.ascx.cs" Inherits="UserControls_Search" %>

<li style="margin-left: 250px; margin-right:5px; " class="navbar-search pull-left">
    <asp:TextBox ID="txtSearchText" placeHolder="Ürün Ara" CssClass="search-query span2" runat="server"></asp:TextBox>
    <asp:CheckBox ID="AllWordsCheckBox" runat="server" />
    <asp:Button CssClass="icon-lock" ID="btnSearch" runat="server" Text="Ara" OnClick="btnSearch_Click" />

</li>
