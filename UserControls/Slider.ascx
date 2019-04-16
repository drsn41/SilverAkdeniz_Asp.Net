<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Slider.ascx.cs" Inherits="UserControls_Slider" %>
<asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
        <div class="item">
            <img style="width: 100%" src='<%#Eval("Image").ToString() %>' alt='<%#HttpUtility.HtmlEncode(Eval("TopText").ToString()) %>' />
            <div class="carousel-caption">
                <h4><%#HttpUtility.HtmlEncode(Eval("TopText").ToString()) %></h4>
                <p><span><%#HttpUtility.HtmlEncode(Eval("BotText").ToString()) %></span></p>
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
