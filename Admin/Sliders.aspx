<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Sliders.aspx.cs" Inherits="Admin_Product_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="col-md-12 col-sm-12 col-xs-12">
        <div class="panel panel-info">
            <div class="panel-heading">
                Sliders Bilgileri
            </div>
            <div class="panel-body">
                <asp:Label ID="lblCategory" runat="server" Text="Beklemede"></asp:Label>
                <asp:Label ID="lblNotFound" runat="server"></asp:Label>
                <asp:GridView ID="grid"
                    CssClass="table"
                    Width="100%"
                    DataKeyNames="SliderID"
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
                    OnRowUpdating="grid_RowUpdating"
                    OnRowDeleting="grid_RowDeleting">

                    <Columns>

                        <asp:TemplateField HeaderText="Slider Id">
                            <ItemTemplate>
                                <asp:Label ID="lblId" runat="server" Text='<%# Bind("SliderID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Sldier Resim">
                            <ItemTemplate>
                                <asp:Image ID="Image1" Width="40px" Height="40px" ImageUrl='<%#Bind("Image") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Üst Yazı">
                            <ItemTemplate>
                                <asp:Label ID="lblTopText" runat="server" Text='<%#Bind("TopText") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Alt Yazı">
                            <ItemTemplate>
                                <asp:Label ID="lblBotText" runat="server" Text='<%# Bind("BotText") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Ekleme Tarihi">
                            <ItemTemplate>
                                <asp:Label ID="lblDateCreated" runat="server" Text='<%# Bind("DateCreated") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:CheckBoxField
                            DataField="PromoFront"
                            HeaderText="Sitede Göster"
                            SortExpression="PromoFront" />


                        <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ControlStyle-CssClass="btn btn-default">



                            <ControlStyle CssClass="btn btn-default"></ControlStyle>
                        </asp:CommandField>
                        <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn btn-default" CommandName="Update" Text="Sitede Göster" />



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
                Slider Fotograf Ekle
            </div>
            <div class="panel-body">

                <div class="form-group ">
                    <label>Üst Yazı:</label>
                    <asp:TextBox CssClass="form-control" ID="txtTopText" runat="server"></asp:TextBox>
                    <label>Alt Yazı:</label>
                    <asp:TextBox CssClass="form-control" ID="txtBotText" runat="server"></asp:TextBox>
                    <label>Slider Ekle</label>
                    <asp:FileUpload ID="FileUpload1" CssClass="form-control" runat="server" />

                </div>

                <asp:Button Text="Slider Ekle" ID="btnAddPhoto" CssClass="btn btn-info" Width="100%" runat="server" OnClick="btnAddPhoto_Click" />
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

