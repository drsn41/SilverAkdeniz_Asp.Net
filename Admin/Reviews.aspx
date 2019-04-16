<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Reviews.aspx.cs" Inherits="Admin_Reviews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">

    <div class="col-md-12 col-sm-12 col-xs-12">
        <div class="panel panel-info">
            <div class="panel-heading">
                Ürün Yorumları
            </div>
            <div class="panel-body">
                <asp:Label ID="Label1" runat="server" Text="Beklemede"></asp:Label>
                <asp:Label ID="Label2" runat="server"></asp:Label>
                <asp:GridView ID="grid"
                    CssClass="table"
                    Width="100%"
                    DataKeyNames="ReviewID"
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
                    GridLines="None" OnRowDeleting="grid_RowDeleting" OnRowUpdating="grid_RowUpdating">
                    <Columns>

                        <asp:TemplateField HeaderText="Yorum ID">
                            <ItemTemplate>
                                <asp:Label ID="lblRevID" runat="server" Text='<%# Bind("ReviewID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Müşteri Adı">
                            <ItemTemplate>
                                <asp:Label ID="lblRevCustID" runat="server" Text='<%# Bind("CustomerName") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Ürün ID">
                            <ItemTemplate>
                                <asp:Label ID="lblRevProduct" runat="server" Text='<%#Bind("ProductID") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Yorum">
                            <ItemTemplate>
                                <asp:Label ID="lblRevText" runat="server" Text='<%# Bind("ProductReview") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText=" Yorum Tarihi">
                            <ItemTemplate>
                                <asp:Label ID="lblRevDate" runat="server" Text='<%# Bind("ReviewDate") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:CheckBoxField
                            DataField="Status"
                            HeaderText="Onay"
                            SortExpression="Status" />


                        <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ControlStyle-CssClass="btn btn-default">
                            <ControlStyle CssClass="btn btn-default"></ControlStyle>
                        </asp:CommandField>


                        <asp:ButtonField
                            ButtonType="Button"
                            ControlStyle-CssClass="btn btn-default"
                            CommandName="Update" Text="Onayla" />

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


</asp:Content>

