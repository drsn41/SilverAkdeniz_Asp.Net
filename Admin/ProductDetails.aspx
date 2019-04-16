<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="Admin_Product_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="col-md-12 col-sm-12 col-xs-12">
        <div class="panel panel-info">
            <div class="panel-heading">
                Ürün Bilgileri
            </div>
            <div class="panel-body">
                <asp:Label ID="lblCategory" runat="server" Text="Beklemede"></asp:Label>
                <asp:Label ID="lblNotFound" runat="server"></asp:Label>
                <asp:GridView ID="grid"
                    CssClass="table"
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
                    OnRowEditing="grid_RowEditing"
                    OnRowUpdating="grid_RowUpdating"
                    OnRowCancelingEdit="grid_RowCancelingEdit">

                    <Columns>

                        <asp:TemplateField HeaderText="Ürün Id">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("ProductID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Ürün Kategori Id">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEditCategory" CssClass="form-control" runat="server" Text='<%# Bind("Category") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblCategory" runat="server" Text='<%# Bind("Category") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Ürün Thumbnail">
                            <ItemTemplate>
                                <asp:Label ID="lblThumbnail" runat="server" Text='<%#Bind("Thumbnail") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lblEditThumbnail" runat="server" Text='<%#Bind("Thumbnail") %>'></asp:Label><br />
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            </EditItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Ürün Ad">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEditName" TextMode="MultiLine" CssClass="form-control" runat="server" Text='<%# Bind("Name") %>' />
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

                        <asp:TemplateField HeaderText="Ürün Fiyat">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEditPrice" CssClass="form-control" runat="server" Text='<%# Bind("Price") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblPrice" runat="server" Text='<%# Bind("Price") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:CheckBoxField
                            DataField="isFlash"
                            HeaderText="Flaş Ürün"
                            SortExpression="isFlash" />


                        <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ControlStyle-CssClass="btn btn-default" ShowEditButton="True" />



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
    <br />
    <br />
     <div class="col-md-12 col-sm-12 col-xs-12">
        <div class="panel panel-info">
            <div class="panel-heading">
                Ürün Fotoğrafları
            </div>
            <div class="panel-body">
                <asp:Label ID="Label1" runat="server" Text="Beklemede"></asp:Label>
                <asp:Label ID="Label2" runat="server"></asp:Label>
                <asp:GridView ID="grid2"
                    CssClass="table"
                    Width="100%"
                    DataKeyNames="ImageID"
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
                    GridLines="None" OnRowDeleting="grid2_RowDeleting"
                    >
                    <Columns>

                        <asp:TemplateField HeaderText="Fotograf ID">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("ImageID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Fotoğraf">
                            <ItemTemplate>
                                <asp:Image ID="Image1" Height="40px" Width="40px" ImageUrl='<%#Bind("Path") %>'  runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Fotograf Url">
                            <ItemTemplate>
                                <asp:Label ID="lblImageUrl" runat="server" Text='<%#Bind("Path") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Ürün ID">
                            <ItemTemplate>
                                <asp:Label ID="lblProductID" runat="server" Text='<%# Bind("ProductID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ControlStyle-CssClass="btn btn-default" />



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
    </div><br />
    <br />

    <div class="col-md-12 col-sm-12 col-xs-12">
        <div class="panel panel-info">
            <div class="panel-heading">
                Ürüne Fotograf Ekle
            </div>
            <div class="panel-body">

                <div class="form-group ">
                    <label>Ürün Fotograf</label>
                    <asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" />

                </div>

                <asp:Button Text="Fotograf Ekle" ID="btnAddPhoto" CssClass="btn btn-info" Width="100%" runat="server" OnClick="btnAddPhoto_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

