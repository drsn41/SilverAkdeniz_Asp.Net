<%@ Page Title="" Language="C#" MasterPageFile="~/Other.master" AutoEventWireup="true" CodeFile="cart.aspx.cs" Inherits="cart" %>

<%@ Register Src="~/UserControls/ProductRecomment.ascx" TagPrefix="uc1" TagName="ProductRecomment" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <ul class="breadcrumb">
        <li><a href="index.aspx">Anasayfa</a> <span class="divider">/</span></li>
        <li class="active">Sepet</li>
    </ul>
    <div class="well well-small">
        <h1>Alışveriş Sepeti <small class="pull-right">
            <asp:Label ID="lblNumberOfProduct" runat="server"></asp:Label>
        </small></h1>
        <hr class="soften" />

        <div class="table table-bordered table-condensed">
            <asp:GridView
                ID="grid"
                GridLines="None"
                runat="server"
                AutoGenerateColumns="False"
                BorderWidth="0px"
                DataKeyNames="ProductID"
                Width="100%"
                OnRowDeleting="grid_RowDeleting">
                <Columns>
                    <asp:TemplateField HeaderText="Ürün"></asp:TemplateField>
                    <asp:BoundField DataField="Name" HeaderText="Ürün Adı" ReadOnly="True"
                        SortExpression="Name"></asp:BoundField>
                    <asp:BoundField DataField="Price" DataFormatString="{0:c}" HeaderText="Birim Fiyatı" ReadOnly="True" SortExpression="Price" />


                    <asp:TemplateField HeaderText="Ürün Özellikleri">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# HttpUtility.HtmlEncode(Eval("Attributes").ToString()) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%-- <asp:BoundField DataField="Attributes" HeaderText="Ürün Özellikleri" ReadOnly="True" />--%>

                    <asp:TemplateField HeaderText="Ürün Adet">
                        <ItemTemplate>
                            <asp:TextBox CssClass="span1" ID="editQty" runat="server" Text='<%#Eval("Amount")%>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Subtotal" DataFormatString="{0:c}" HeaderText="Toplam Tutar" ReadOnly="True" SortExpression="Subtotal" />
                    <asp:ButtonField ControlStyle-CssClass="btn btn-mini btn-danger" ButtonType="Button" CommandName="Delete" Text="Sil" />
                </Columns>
            </asp:GridView>
        </div>

        <table class="table table-bordered table-condensed">
            <tbody>

                <tr style="margin-top: 5px;">
                    <td colspan="6" class="alignR">Toplam Tutar:	</td>
                    <td style="float: right;">
                        <span class="label label-primary">
                            <asp:Label ID="lblTotalAmount" runat="server"></asp:Label>
                        </span>
                    </td>
                    <td style="float: right;">
                        <asp:Label ID="lblStatus" Text="Bekleniyor" runat="server"></asp:Label>
                    </td>
                    <td style="float: right;">
                        <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-mini" Text="Sayı Güncelle" OnClick="btnUpdate_Click" />
                    </td>

                </tr>
            </tbody>
        </table>
        <div class="well well">
           
                <uc1:ProductRecomment runat="server" ID="ProductRecomment" />
        </div>


        <asp:Button PostBackUrl="~/products.aspx" CssClass="shopBtn btn-large" ID="btnContShop" runat="server" Text="Alışverişe Devam Et" />
        <asp:Button CssClass="shopBtn btn-large pull-right" ID="btnCheckOut" runat="server" Text="Ödeme İşlemine Geç " OnClick="btnCheckOut_Click" />

        <%--        <a href="products.aspx" class="shopBtn btn-large"><span class="icon-arrow-left"></span>Alışverişe Devam Et </a>
        <a href="check_out.aspx" class="shopBtn btn-large pull-right">Ödeme İşlemine Geç <span class="icon-arrow-right"></span></a>--%>
    </div>


</asp:Content>

