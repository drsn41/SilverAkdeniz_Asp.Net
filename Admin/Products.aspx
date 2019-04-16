<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Products.aspx.cs" Inherits="Admin_Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="col-md-12 col-sm-12 col-xs-12">
        <div class="form-group">
            <label>Durum: </label>
            <asp:Label ID="lblStatus" runat="server" Text="Beklemede"></asp:Label>
        </div>
        <div class="panel panel-info">
            <div class="panel-heading">
                Ürünler
            </div>
            <div class="panel-body">

                <asp:Label ID="lblCategory" runat="server" Text="Beklemede"></asp:Label>
                <asp:Label ID="lblNotFound" runat="server"></asp:Label>
                <asp:GridView ID="grid"
                    CssClass="table table-bordered table-condensed"
                    Width="100%"
                    DataKeyNames="ProductID"
                    HeaderStyle-CssClass="header"
                    RowStyle-CssClass="rows"
                    PagerStyle-CssClass="pager"
                    runat="server"
                    AutoGenerateColumns="False"
                    AllowPaging="True"
                    BackColor="White"
                    BorderColor="White"
                    BorderStyle="Ridge"
                    BorderWidth="2px"
                    CellPadding="4"
                    CellSpacing="1"
                    PageSize="8"
                    GridLines="None"
                    OnPageIndexChanging="grid_PageIndexChanging"
                    OnRowDeleting="grid_RowDeleting">

                    <Columns>

                        <asp:TemplateField HeaderText="Ürün Id">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("ProductID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Ürün Thumbnail">
                            <ItemTemplate>
                                <asp:Image Width="40px" Height="40px" ID="Image1" ImageUrl='<%#Bind("Thumbnail") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        
                        <asp:TemplateField HeaderText="Ürün Ad">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEditName" CssClass="form-control" runat="server" Text='<%# Bind("Name") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Ürün Açıklama">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEditDescript" CssClass="form-control" Rows="3" TextMode="MultiLine" runat="server" Text='<%# Bind("Description") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDescript" runat="server" Text='<%# Bind("Description") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>




                        <asp:CheckBoxField DataField="isFlash"
                            HeaderText="Flaş Ürün"
                            SortExpression="isFlash" />

                        <asp:HyperLinkField
                            DataNavigateUrlFields="ProductID"
                            HeaderText="Ürün Yorumları"
                            DataNavigateUrlFormatString="Reviews.aspx?ProductID={0}"
                            Text="Yorumları" />

                        <asp:CommandField ButtonType="Button"
                            ControlStyle-CssClass="btn btn-default"
                            ShowDeleteButton="true">

                            <ControlStyle CssClass="btn btn-default"></ControlStyle>

                        </asp:CommandField>

                        <asp:HyperLinkField
                            DataNavigateUrlFields="ProductID"
                            DataNavigateUrlFormatString="ProductDetails.aspx?ProductID={0}"
                            ControlStyle-CssClass="btn btn-default"
                            Text="Düzenle">
                            <ControlStyle CssClass="btn btn-default"></ControlStyle>
                        </asp:HyperLinkField>

                    </Columns>

                    <FooterStyle CssClass="panel-footer" />
                    <HeaderStyle CssClass="panel-heading" />
                    <PagerStyle CssClass="panel-primary" />
                    <RowStyle CssClass="info" />
                    <SelectedRowStyle CssClass="danger" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#594B9C" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#33276A" />
                </asp:GridView>
            </div>
        </div>
    </div>

    <div class="col-md-12 col-sm-12 col-xs-12">
        <div class="panel panel-info">
            <div class="panel-heading">
                Ürün Ekle
            </div>
            <div class="panel-body">
                <div class="form-group ">
                    <label>Kategori Adı</label>
                    <asp:DropDownList ID="CatgDropList" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CatgDropList_SelectedIndexChanged"></asp:DropDownList>

                </div>
                <div class="form-group ">
                    <label>Ürün Adı</label>
                    <asp:TextBox CssClass="form-control" ID="txtName" runat="server"></asp:TextBox>
                </div>

                <div class="form-group ">
                    <label>Ürün Yapım Süresi</label>
                    <asp:TextBox CssClass="form-control" ID="txtTakeTime" runat="server"></asp:TextBox>

                </div>

                <div class="form-group ">
                    <label>Ürün Açıklama</label>
                    <asp:TextBox CssClass="form-control" TextMode="MultiLine" ID="txtDescription" runat="server"></asp:TextBox>

                </div>
                <div class="form-group ">
                    <label>Ürün Fiyatı</label>
                    <asp:TextBox CssClass="form-control" ID="txtPrice" runat="server"></asp:TextBox>

                </div>


                <div class="form-group ">
                    <label>Ürün Thumbnail</label>
                    <asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" />

                </div>

              

                <div class="form-group ">
                    <label>Flash Ürün</label>
                    <asp:CheckBox CssClass="form-control" ID="CheckBox1" runat="server" />

                </div>

                <asp:Button Text="Ürün Ekle" ID="btnAdd" CssClass="btn btn-info" Width="100%" runat="server" OnClick="btnAdd_Click" />
            </div>
        </div>
    </div>
</asp:Content>

