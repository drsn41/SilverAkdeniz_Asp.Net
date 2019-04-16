<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CartSummary.ascx.cs" Inherits="UserControls_CartSummary" %>
<a href="cart.aspx">
    <span class="icon-shopping-cart"></span>
    Toplam - 
    <span class="badge badge-warning">
        <asp:Label ID="lbltotalAmount" runat="server" />
    </span>

</a>

