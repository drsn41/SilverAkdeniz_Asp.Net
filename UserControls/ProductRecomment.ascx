<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductRecomment.ascx.cs" Inherits="UserControls_ProductRecomment" %>
<asp:DataList ShowHeader="false" CssClass="row-fluid" ID="list" runat="server">
    <HeaderTemplate>
        <h4>Önerilen Ürünler</h4>
    </HeaderTemplate>
    <ItemTemplate>

        <hr class="soften" />
        <div class="row-fluid" style="height: 30x;">
            <div class="span2">
                <a href='<%#Link.ToProduct(Eval("ProductID").ToString()) %>'>
                    <img src='<%#Eval("Thumbnail").ToString()%>' alt="" />
                </a>

            </div>
            <div class="span6">
                <a href='<%#Link.ToProduct(Eval("ProductID").ToString()) %>'>
                    <h5><%#Eval("Name").ToString() %></h5>
                </a>
                <p>
                    <%#Eval("Description").ToString() %>
                </p>
            </div>
            <div class="span4 alignR">
                <form class="form-horizontal qtyFrm">
                    <h3><%# Eval("Price","{0:c}") %> </h3>
                    <br />
                    <div class="btn-group">
                        <!--
                        <button runat="server" id="btnAddtoCart" class="defaultBtn"><span class=" icon-shopping-cart"></span>Sepete Ekle</button>
                        <button runat="server" id="btnGoToProd" onclick="a123" class="shopBtn">Ürüne Git</button>


                         <a href='<%#Link.ToProduct(Eval("ProductID").ToString()) %>' class="defaultBtn"><span class=" icon-shopping-cart"></span>Sepete Ekle</a>
-->
                        <a href='<%#Link.ToProduct(Eval("ProductID").ToString()) %>' class="shopBtn">Ürüne Git</a>






                    </div>
                </form>
            </div>
        </div>

    </ItemTemplate>

</asp:DataList>