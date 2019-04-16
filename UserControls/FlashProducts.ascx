<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FlashProducts.ascx.cs" Inherits="UserControls_FlashProducts" %>

<%@ Register src="Pager.ascx" tagname="Pager" tagprefix="uc1" %>

<br />

<uc1:Pager ID="topPager" runat="server" />

<br />

<br />
<asp:ListView runat="server" ID="list"
    GroupItemCount="3"
    DataKeyNames="ProductID">
    <LayoutTemplate>
        <table cellpadding="2" runat="server"
            id="tblProducts" style="height: 320px">
            <tr runat="server" id="groupPlaceholder">
            </tr>
        </table>

    </LayoutTemplate>
    <GroupTemplate>
        <tr runat="server" id="productRow"
            style="height: 80px">
            <td runat="server" id="itemPlaceholder"></td>
        </tr>
    </GroupTemplate>
    <ItemTemplate>
        <td valign="top" align="center" style="width: 110;" runat="server">
           
                    <div class="thumbnail">
                        <a href='<%#Link.ToProduct(Eval("ProductID").ToString()) %>' class="overlay"></a>
                        <a class="zoomTool" href='<%#Link.ToProduct(Eval("ProductID").ToString()) %>' title="Ürüne Git"><span class="icon-search"></span>Göz At</a>
                        <a href='<%#Link.ToProduct(Eval("ProductID").ToString()) %>'>
                            <img src='<%#Eval("Thumbnail").ToString() %>' alt=<%# HttpUtility.HtmlEncode(Eval("Name").ToString())%>></a>
                        <div class="caption cntr">
                            <p><%#HttpUtility.HtmlEncode(Eval("Name").ToString()) %></p>
                            <p><strong><%# Eval("Price","{0:c}") %><strong></p>
                            <h4><a class="shopBtn" href='<%#Link.ToProduct(Eval("ProductID").ToString()) %>' title="Ürüne Git">Ürüne Git</a></h4>
                            
                            <br class="clr">
                        </div>
                    </div>
        </td>
    </ItemTemplate>
</asp:ListView>


<uc1:Pager ID="bottomPager" runat="server" />



