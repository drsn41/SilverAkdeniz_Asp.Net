<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchResults.ascx.cs" Inherits="UserControls_SearchResults" %>
<%@ Register Src="~/UserControls/Pager.ascx" TagPrefix="uc1" TagName="Pager" %>


<uc1:Pager runat="server" ID="topPager" />
<asp:Label ID="lblNotFound" runat="server"></asp:Label>
<asp:ListView ID="ListViewProductsOfCategory" runat="server" EnableViewState="false" ViewStateMode="Disabled">
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
                    <label class="checkbox">
                        <input type="checkbox">
                        Karşılaştır
                    </label>
                    &nbsp;&nbsp;&nbsp;&nbsp;<br>
                    <div class="btn-group">
                        <a href="#" class="defaultBtn"><span class=" icon-shopping-cart"></span>Sepete Ekle</a>
                        <a href='<%# Link.ToProduct(Eval("ProductID")+"") %>' class="shopBtn">GÖZ AT</a>
                    </div>
                </form>
            </div>
        </div>
        <hr class="soften">
    </ItemTemplate>
</asp:ListView>


<uc1:Pager runat="server" ID="bottomPager" />