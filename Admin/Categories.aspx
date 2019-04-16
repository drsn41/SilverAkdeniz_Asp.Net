<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Categories.aspx.cs" Inherits="Admin_Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="col-md-12 col-sm-12 col-xs-12">
        <div class="form-group">
            <label>Durum: </label>
            <asp:Label ID="lblStatus" runat="server" Text="Beklemede"></asp:Label>
        </div>
        <div class="panel panel-info">
            <div class="panel-heading">
                Karegoriler
            </div>
            <div class="panel-body">
                 <asp:Label ID="lblNotFound" runat="server"></asp:Label>
                <asp:GridView ID="grid"
                    CssClass="table"
                    Width="100%"
                    DataKeyNames="CategoryID"
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
                    OnRowCancelingEdit="grid_RowCancelingEdit"
                    OnRowDeleting="grid_RowDeleting"
                    OnRowEditing="grid_RowEditing"
                    OnRowUpdating="grid_RowUpdating">

                    <Columns>

                        <asp:TemplateField HeaderText="Kategori Id">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("CategoryID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Kategori Ad">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEditName" CssClass="form-control" runat="server" Text='<%# Bind("Name") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblName" runat="server" Text='<%# Bind("Name") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Kategori Açıklama">
                            <EditItemTemplate>
                                <asp:TextBox ID="txtEditDescript" CssClass="form-control" Rows="3" TextMode="MultiLine" runat="server" Text='<%# Bind("Description") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="lblDescript" runat="server" Text='<%# Bind("Description") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:HyperLinkField HeaderText="Kategori Ürünleri"
                            DataNavigateUrlFields="CategoryID"
                            DataNavigateUrlFormatString="Products.aspx?CategoryID={0}"
                            Text="Ürünlerini Göster" />

                        <asp:CommandField ShowEditButton="True" ControlStyle-CssClass="btn btn-default"
                            ShowDeleteButton="true" ButtonType="Button" />

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
                Karegori Ekle
            </div>
            <div class="panel-body">
                <div class="form-group">
                    <label>Kategori Adı</label>
                    <asp:TextBox CssClass="form-control" ID="txtAddName" runat="server"></asp:TextBox>
                    <p class="help-block">Kategori Adını Buraya Yazınız.</p>
                </div>
                <div class="form-group">
                    <label>Kategori Açıklaması</label>
                    <asp:TextBox TextMode="MultiLine" Width="100%" Height="100px" CssClass="form-control" ID="txtAddDescription" runat="server"></asp:TextBox>
                </div>
                <asp:Button Text="Kategori Ekle" ID="btnAdd" CssClass="btn btn-info" Width="100%" runat="server" OnClick="btnAdd_Click" />
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

