<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProductReviews.ascx.cs" Inherits="UserControls_ProductReviews" %>
<div class="row-fluid">
    <asp:DataList ID="DataList1" ShowHeader="false" runat="server">
        <HeaderTemplate>
            <h4>Ürün Yorumları</h4>
        </HeaderTemplate>
        <ItemTemplate>
             <hr class="soften" />
            <div class="row-fluid">
                <h5><%#Eval("CustomerName").ToString() %> </h5>
                <h6><%# String.Format("{0:D}",Eval("ReviewDate")) %></h6>
               
                <div style="float:left">
                    <%#Eval("ProductReview").ToString() %>
                </div>
            </div>
            
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:DataList>
</div>
<asp:Panel ID="addReview" runat="server">
    <p>
        <h5>Yorumunuzu Yazınız</h5>
    </p>
    <p>
        <asp:TextBox
            ID="TextBox1"
            runat="server"
            Rows="3"
            Width="100%"
            Columns="88"
            TextMode="MultiLine"></asp:TextBox>
    </p>
    <asp:LinkButton
        ID="btnAddReview"
        runat="server"
        Text="Yorum Ekle" OnClick="btnAddReview_Click"></asp:LinkButton>
</asp:Panel>

<asp:LoginView ID="LoginView1" runat="server">
    <AnonymousTemplate>
        <p>Yorum Yapmak İçin Üye Olunuz!</p>
    </AnonymousTemplate>
    <LoggedInTemplate></LoggedInTemplate>
</asp:LoginView>
