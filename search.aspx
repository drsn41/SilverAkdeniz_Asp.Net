<%@ Page Title="" Language="C#" MasterPageFile="~/Main.master" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="search" EnableEventValidation="false" %>

<%@ Register Src="~/UserControls/SearchResults.ascx" TagPrefix="uc1" TagName="SearchResults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="span9">
        <h3>
            <asp:Label ID="lblDescription" runat="server" />
            <br />
        </h3>
        <div class="well well-small">
            <uc1:SearchResults runat="server" ID="SearchResults" />
        </div>
    </div>





</asp:Content>

