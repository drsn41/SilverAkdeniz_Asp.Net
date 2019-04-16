<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SidebarCategories.ascx.cs" Inherits="CategoriesUC" %>
<%@ OutputCache Duration="1000" VaryByControl="*" Shared="true" %>
<asp:Repeater ID="Repeater1" runat="server">

    <ItemTemplate>
        <li><a href='<%# Link.ToCategory(Eval("CategoryID").ToString()) %>'><span class="icon-chevron-right"></span><%# HttpUtility.HtmlEncode(Eval("Name").ToString()) %></a></li>
    </ItemTemplate>


</asp:Repeater>
