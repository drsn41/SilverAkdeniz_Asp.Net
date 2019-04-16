<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Carts.aspx.cs" Inherits="Admin_Carts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="col-md-12 col-sm-12 col-xs-12">
        <div class="panel panel-info">
            <div class="panel-heading">
                Sepet İşlemleri
            </div>
            <div class="panel-body">
                <div class="form-group ">
                    <label>Ne Kadar Eski Sepetler :</label>
                    <asp:DropDownList ID="dayDropDown" Width="200px" CssClass="form-control" runat="server">
                        <asp:ListItem Text="Bütün Sepetler" Value="0" />
                        <asp:ListItem Text="1 Günlük Sepetler" Value="1" />
                        <asp:ListItem Text="10 Günlük Sepetler" Value="10" />
                        <asp:ListItem Text="20 Günlük Sepetler" Value="20" />
                        <asp:ListItem Text="30 Günlük Sepetler" Value="30" />
                        <asp:ListItem Text="90 Günlük Sepetler" Value="90" />
                    </asp:DropDownList>
                    
                    <asp:Label ID="lblStat" runat="server"></asp:Label><br />
                    <asp:Button Width="49%" CssClass="btn btn-primary" ID="btnCountCarts" runat="server" Text="Sepet Sayısını Getir" OnClick="btnCountCarts_Click"  />
                    <asp:Button Width="49%" CssClass="btn btn-danger" ID="btnDeleteOldCarts" runat="server" Text="Sepetleri Sil" OnClick="btnDeleteOldCarts_Click" /><br />

                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>

