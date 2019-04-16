<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductsOfCategory.ascx.cs" Inherits="UserControls_ProductsOfCategory2" %>
<%@ Register Src="~/UserControls/Pager.ascx" TagPrefix="uc1" TagName="Pager" %>


<uc1:Pager runat="server" ID="topPager" />
<asp:ListView ID="ListViewProductsOfCategory" runat="server" EnableViewState="false" ViewStateMode="Disabled" OnItemDataBound="ListViewProductsOfCategory_ItemDataBound">
    <ItemTemplate>
        <div class="row-fluid">
            <div class="span2">
                <img src='<%#Eval("Thumbnail").ToString()%>' alt='<%#HttpUtility.HtmlEncode(Eval("Name").ToString())%>' />
            </div>
            <div class="span6">
                <h5><%# HttpUtility.HtmlEncode(Eval("Name").ToString())%></h5>
                <p>
                    <%# HttpUtility.HtmlEncode(Eval("Description").ToString())%>
                </p>
            </div>
            <div class="span4 alignR">
                <form class="form-horizontal qtyFrm">
                    <h3><%#Eval("Price","{0:c}")%></h3>
                    <br>
                    
                    <asp:PlaceHolder ID="attrPlaceHolder" runat="server">
                    </asp:PlaceHolder>
                    
                    <div class="btn-group">
                        <a href='<%# Link.ToProduct(Eval("ProductID")+"") %>'class="defaultBtn"><span class=" icon-shopping-cart"></span>Ürüne Git</a>
                        <a href='<%# Link.ToProduct(Eval("ProductID")+"") %>' class="shopBtn">GÖZ AT</a>
                    </div>
                </form>
            </div>
        </div>
        <hr class="soften">
    </ItemTemplate>
</asp:ListView>


<uc1:Pager runat="server" ID="bottomPager" />
