<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<%@ Register Src="~/UserControls/Slider.ascx" TagPrefix="uc1" TagName="Slider" %>
<%@ Register Src="~/UserControls/FlashProducts.ascx" TagPrefix="uc1" TagName="FlashProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <div class="row">
        <div class="span9">
            <div class="well np">
                <div id="myCarousel" class="carousel slide homCar">
                    <div class="carousel-inner">
                        <!-- Slider-->

                        <uc1:Slider runat="server" ID="Slider" />

                        <!-- Slider-->
                    </div>
                    <a class="left carousel-control" href="#myCarousel" data-slide="prev">&lsaquo;</a>
                    <a class="right carousel-control" href="#myCarousel" data-slide="next">&rsaquo;</a>
                </div>
            </div>
            <!-- Flash Ürünler -->
            <div class="well well-small">
                <h3>Flash Ürünler </h3>
                <div class="row-fluid">
                    <uc1:FlashProducts runat="server" ID="FlashProducts" />
                </div>
                <!-- Flash Ürünler -->
            </div>
        </div>
        </div>
</asp:Content>

