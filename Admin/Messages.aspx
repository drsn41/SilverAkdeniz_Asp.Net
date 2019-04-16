<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Messages.aspx.cs" Inherits="Admin_Messages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="col-md-12 col-sm-12 col-xs-12">
        <div class="panel panel-info">
            <div class="panel-heading">
                Gelen İletişim Mesajları
            </div>
            <div class="panel-body">
                <asp:Label ID="Label1" runat="server" Text="Beklemede"></asp:Label>
                <asp:Label ID="Label2" runat="server"></asp:Label>
                <asp:GridView ID="grid"
                    CssClass="table"
                    Width="100%"
                    DataKeyNames="MessageID"
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
                    OnRowDeleting="grid_RowDeleting"
                    OnRowUpdating="grid_RowUpdating">
                    <Columns>

                        <asp:TemplateField HeaderText="Mesaj ID">
                            <ItemTemplate>
                                <asp:Label ID="lblMesID" runat="server" Text='<%# Bind("MessageID") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Kişi Adı">
                            <ItemTemplate>
                                <asp:Label ID="lblMesName" runat="server" Text='<%# Bind("Name") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Kişi Soyadı">
                            <ItemTemplate>
                                <asp:Label ID="lblMesSurname" runat="server" Text='<%#Bind("Surname") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Kişi Eposta">
                            <ItemTemplate>
                                <asp:Label ID="lblMesEmail" runat="server" Text='<%# Bind("Email") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Konu">
                            <ItemTemplate>
                                <asp:Label ID="lblMesSubject" runat="server" Text='<%# Bind("Subject") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Fotoğraf">
                            <ItemTemplate>
                                <asp:Image ID="ImageMes" Height="40px" Width="40px" ImageUrl='<%# Bind("Image") %>' runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="İçerik">
                            <ItemTemplate>
                                <asp:Label ID="lblMesText" runat="server" Text='<%# Bind("Text") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField HeaderText="Gönderme Tarihi">
                            <ItemTemplate>
                                <asp:Label ID="lblMesDate" runat="server" Text='<%# Bind("DateCreated") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:CheckBoxField
                            DataField="Replyed"
                            HeaderText="Cevaplandı"
                            SortExpression="Replyed" />


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

