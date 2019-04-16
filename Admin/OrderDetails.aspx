<%@ Page Title="" Language="C#"  EnableViewState="false"
    MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="OrderDetails.aspx.cs" Inherits="Admin_OrderDetails" %>

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
                Sipariş Detay İşlemleri
            </div>
            <div class="panel-body">
                <div class="form-group ">
                    <label>Toplam Fiyat:</label><asp:Label ID="lblTotalAmount" runat="server"></asp:Label><br />
                    <label>Oluşturma Tarihi:</label>
                    <asp:TextBox CssClass="form-control" ID="txtDateCreated" runat="server"></asp:TextBox>
                    <label>Kargolama Tarihi:</label>
                    <asp:TextBox CssClass="form-control" ID="txtShippedDate" runat="server"></asp:TextBox>
                    <label>Durum:</label>
                    <asp:CheckBox TextAlign="Left" Text="Onay: " ID="verifiedCheckBox" runat="server" />
                    <asp:CheckBox TextAlign="Left" Text="Tamamlandı: " ID="completedCheckBox" runat="server" />
                    <asp:CheckBox TextAlign="Left" Text="İptal: " ID="canceledCheckBox" runat="server" /><br />
                    <label>Açıklama:</label>
                    <asp:TextBox CssClass="form-control" ID="txtComments" runat="server"></asp:TextBox>
                    <label>Müşteri Ad:</label>
                    <asp:TextBox CssClass="form-control" ID="txtCustomerName" runat="server"></asp:TextBox>
                    <label>Müşteri Eposta:</label>
                    <asp:TextBox CssClass="form-control" ID="txtCustomerEmail" runat="server"></asp:TextBox>
                    <label>Adres:</label>
                    <asp:TextBox CssClass="form-control" ID="txtShippingAddress" runat="server"></asp:TextBox><br />
                    <asp:Button Width="24%" CssClass="btn btn-primary" ID="btnEdit" runat="server" Text="Düzenle" OnClick="btnEdit_Click" />
                    <asp:Button Width="24%" CssClass="btn btn-primary" ID="btnUpdate" runat="server" Text="Güncelle" OnClick="btnUpdate_Click" />
                    <asp:Button Width="24%" CssClass="btn btn-primary" ID="btnCancel" runat="server" Text="İşlem İptal" OnClick="btnCancel_Click" />
                    <br />
                    <br />
                    <asp:Button Width="100%" CssClass="btn btn-success" ID="btnMarkVerified" runat="server" Text="Sipariş Onayla" OnClick="btnMarkVerified_Click" /><br />
                    <asp:Button Width="100%" CssClass="btn btn-primary" ID="btnMarkCompleted" runat="server" Text="Sipariş Tamamla" OnClick="btnMarkCompleted_Click" /><br />
                    <asp:Button Width="100%" CssClass="btn btn-danger" ID="btnMarkCalceled" runat="server" Text="Sipariş İptal Et" OnClick="btnMarkCalceled_Click" /><br />
                </div>
            </div>
        </div>
    </div>


       <div class="col-md-12 col-sm-12 col-xs-12">
        
        <div class="panel panel-info">
            <div class="panel-heading">
                Sipariş Ürünleri
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
                    >

                    <Columns>
                        <asp:BoundField DataField="OrderID" HeaderText="Ürün Numarası" ReadOnly="True" />
                        <asp:BoundField DataField="ProductName" HeaderText="Ürün İsmi" ReadOnly="True" />
                        <asp:BoundField DataField="Qty" HeaderText="Ürün Adet" />
                        <asp:BoundField DataField="UnitPrice" HeaderText="Birim Fiyatı" ReadOnly="True" />
                        <asp:BoundField DataField="Subtotal" HeaderText="Toplam Tutar" ReadOnly="True" />
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

