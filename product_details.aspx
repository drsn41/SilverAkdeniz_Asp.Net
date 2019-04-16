<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="product_details.aspx.cs" Inherits="product_details" %>

<%@ Register Src="~/UserControls/ProductsOfCategory.ascx" TagPrefix="uc1" TagName="ProductsOfCategory" %>
<%@ Register Src="~/UserControls/ProductRecomment.ascx" TagPrefix="uc1" TagName="ProductRecomment" %>
<%@ Register Src="~/UserControls/ProductReviews.ascx" TagPrefix="uc1" TagName="ProductReviews" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="span9">
        <ul class="breadcrumb">
            <li><a href="index.aspx">Anasayfa</a> <span class="divider">/</span></li>
            <li><a href="products.aspx">Ürünler</a> <span class="divider">/</span></li>
            <li class="active">
                <asp:Label ID="lblActiveProd" runat="server" Text="Label"></asp:Label>
            </li>
        </ul>
        <div class="well well-small">
            <div class="row-fluid">
                <div class="span5">
                    <div id="myCarousel" class="carousel slide cntr">
                        <div class="carousel-inner">
                            <asp:Repeater ID="ProdSlider" runat="server">
                                <ItemTemplate>
                                    <div class="item">
                                        <a href="#">
                                            <img src='<%# Eval("Path").ToString() %>' alt="" style="width: 100%" /></a>

                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <a class="left carousel-control" href="#myCarousel" data-slide="prev">‹</a>
                        <a class="right carousel-control" href="#myCarousel" data-slide="next">›</a>
                    </div>
                </div>
                <div class="span7">
                    <h3>
                        <asp:Label ID="lblProdName" runat="server"></asp:Label>
                    </h3>
                    <hr class="soft" />
                    <div class="form-horizontal qtyFrm">
                        <div class="control-group">
                            <label class="control-label">
                                <span>
                                    <asp:Label ID="lblProdPrice" runat="server"></asp:Label>
                                </span>
                            </label>
                            <%--<div class="controls">
                                Adet:
                                <asp:TextBox ID="txtProdQty" CssClass="span6" Type="number" palceholder="Adet" runat="server"></asp:TextBox>
                            </div>--%>
                        </div>
                        <div style="text-align: left;" class="control-group">
                            <asp:PlaceHolder ID="attrPlaceHolder" runat="server"></asp:PlaceHolder>
                        </div>
                        <h5>Yapım Süresi:</h5>
                        <p>
                            <asp:Label ID="lblProdTakeTime" runat="server" Text="10 Gün"></asp:Label><br />
                            <h5>Açıklama:</h5>
                            <asp:Label ID="lblProdDescription" runat="server" />
                        </p>

                        <asp:Button ID="btnAddToCart" runat="server" CssClass="shopBtn" Text="Sepete Ekle" OnClick="btnAddToCart_Clik"></asp:Button>

                    </div>
                </div>
            </div>
            <hr class="softn clr" />

            <!-- Ürün Yorum ve Benzerlerinin Gösterildigi Yer -->
            <ul id="productDetail" class="nav nav-tabs">
                <li class=""><a href="#productComment" data-toggle="tab">Ürün Yorumları </a></li>
                <li class=""><a href="#productSimilar" data-toggle="tab">Önerilen Ürünler </a></li>
            </ul>
            <!-- Ürün Yorum ve Benzerlerinin Gösterildigi Yer -->
            <div id="myTabContent" class="tab-content tabWrapper">

                <div class="tab-pane fade active in" id="productComment">

                    <!-- Repeater joinli store procedur -->
                    <uc1:ProductReviews runat="server" id="ProductReviews" />
                    <!-- Repeater joinli store procedur -->
                </div>




                <div class="tab-pane fade" id="productSimilar">
                    <!-- Repeater joinli store procedur -->

                    <uc1:ProductRecomment runat="server" ID="ProductRecomment" />
                    <hr class="soft" />
                    <!-- Repeater joinli store procedur -->
                </div>
            </div>
        </div>
    </div>
</asp:Content>

