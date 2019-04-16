<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Orders.aspx.cs" Inherits="Admin_Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="col-md-12 col-sm-4 col-xs-6">
        <div class="panel panel-info">
            <div class="panel-heading">
                Sipariş İşlemleri
            </div>
            <div class="panel-body">
                <div class="form-group">
                    <div style="float: left">
                        <h4>
                            <asp:Label ID="Label1" runat="server" Text="Son Siparişler "></asp:Label></h4>
                    </div>
                    <div style="float: left; margin-left: 5px;">
                        <asp:TextBox CssClass="form-control" Text="20" MaxLength="4" Width="60px" ID="txtRecent" runat="server"></asp:TextBox>
                    </div>
                    <div style="float: left; margin-left: 5px;">
                        <asp:Button CssClass="btn btn-primary" ID="btnByRecent" runat="server" Text="Git!" OnClick="btnByRecent_Click" />
                    </div>
                </div>
                <br />
                <div class="form-group">
                    <div style="float: left">
                        <h4>
                            <asp:Label ID="Label2" runat="server" Text="Tarih Aralığına Göre "></asp:Label></h4>
                    </div>
                    <div style="float: left; margin-left: 5px;">
                        <asp:TextBox CssClass="form-control"  Width="200px" ID="txtStartDate" runat="server"></asp:TextBox>
                        <asp:RangeValidator
                            ID="startDateValid"
                            runat="server"
                            Display="None"
                            MinimumValue="1/1/2018"
                            MaximumValue="1/1/2023"
                            Type="Date"
                            ControlToValidate="txtStartDate"
                            ErrorMessage="Başlangıç Tarihi Hatalı"></asp:RangeValidator>
                    </div>
                    <div style="float: left; margin-left: 5px;">
                        <asp:TextBox CssClass="form-control"  Width="200px" ID="txtEndDate" runat="server"></asp:TextBox>
                        <asp:RangeValidator
                            ID="endDateValid"
                            runat="server"
                            Display="None"
                            MinimumValue="1/1/2018"
                            MaximumValue="1/1/2023"
                            Type="Date"
                            ControlToValidate="txtEndDate"
                            ErrorMessage="Bitiş Tarihi Hatalı"></asp:RangeValidator>
                        <asp:CompareValidator
                            ID="CompareDateValid"
                            runat="server"
                            Display="None"
                            Operator="LessThan"
                            ControlToCompare="txtEndDate"
                            ControlToValidate="txtStartDate"
                            ErrorMessage="Başlagıç Tarihi Daha Erken Olmalı"></asp:CompareValidator>
                        <asp:ValidationSummary
                            ID="validationSummary"
                            HeaderText="Veri Doğrulama Hataları"
                            runat="server" />
                    </div>
                    <div style="float: left; margin-left: 5px;">
                        <asp:Button CssClass="btn btn-primary" ID="btnByDate" runat="server" Text="Git!" OnClick="btnByDate_Click" />
                    </div>
                </div>
                <br />
                <div class="form-group">
                    <div style="float: left; margin-left: 5px;">
                        <h4>
                            <asp:Label ID="Label3" runat="server" Text="Tüm Doğrulanmamış,İptal Edilmemiş Siparişler"></asp:Label></h4>
                    </div>
                    <div style="float: left; margin-left: 5px;">
                        <asp:Button CssClass="btn btn-primary" ID="Unverified" runat="server" Text="Git!" OnClick="Unverified_Click" />
                    </div>
                </div>
                <br />
                <div class="form-group">
                    <div style="float: left; margin-left: 5px;">
                        <h4>
                            <asp:Label ID="Label4" runat="server" Text="Tüm Doğrulanmış,Tamamlanmamış Siparişler"></asp:Label></h4>
                    </div>
                    <div style="float: left; margin-left: 015px;">
                        <asp:Button CssClass="btn btn-primary" ID="btnUncomplated" runat="server" Text="Git!" OnClick="btnUncomplated_Click" />
                    </div>
                </div>
            </div>

        </div>

    </div>



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
                    CssClass="table"
                    Width="100%"
                    DataKeyNames="OrderID"
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
                    OnSelectedIndexChanged="grid_SelectedIndexChanged" OnPageIndexChanging="grid_PageIndexChanging">

                    <Columns>


                        <asp:BoundField DataField="OrderID" HeaderText="Order ID" ReadOnly="True" />
                        <asp:BoundField DataField="DateCreated" HeaderText="Oluşturma Tarihi" ReadOnly="True" />
                        <asp:BoundField DataField="DateShipped" HeaderText="Kargo Tarihi" />
                        <asp:CheckBoxField DataField="Verified" HeaderText="Doğrulanma" ReadOnly="True" />
                        <asp:CheckBoxField DataField="Completed" HeaderText="Tamamlanmış" ReadOnly="True" />
                        <asp:CheckBoxField DataField="Canceled" HeaderText="İptal Edilmiş" ReadOnly="True" />
                        <asp:BoundField DataField="CustomerName" HeaderText="Müşteri Adı" ReadOnly="True" />
                        <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Seç" />


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

