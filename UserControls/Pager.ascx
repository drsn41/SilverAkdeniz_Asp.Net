<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Pager.ascx.cs" Inherits="UserControls_Pager" %>
<p>

   Toplam:
    <asp:Label ID="howManyPageslbl" runat="server" />
    Sayfadan
    <asp:Label ID="currentPagelbl" runat="server" />
    Numaralı Sayfadasınız. |
    <asp:HyperLink ID="previousLink" runat="server"> <- </asp:HyperLink>

    <asp:Repeater ID="PagesRepeater" runat="server">
        <ItemTemplate>
            <asp:HyperLink
                NavigateUrl='<%#Eval("Url") %>'
                ID="HyperLink1"
                runat="server"
                Text='<%#Eval("Page")%>'></asp:HyperLink>
        </ItemTemplate>
    </asp:Repeater>

    <asp:HyperLink ID="nextLink" runat="server"> -> </asp:HyperLink>
</p>
