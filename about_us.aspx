<%@ Page Title="" Language="C#" MasterPageFile="~/Other.master" AutoEventWireup="true" CodeFile="about_us.aspx.cs" Inherits="about_us" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <ul class="breadcrumb">
        <li><a href="index.aspx">Anasayfa</a> <span class="divider">/</span></li>
        <li class="active">Hakkımızda</li>
    </ul>
    <div class="well well-small">
        <div>
            <h1>Biz Kimiz</h1>
        </div>

        <hr class="soften" />
        <div class="row">
            <div class="span8" style="float: left">
                <p>
                    <asp:Image ID="Image1" runat="server" />
                </p>
                <h6>
                    <asp:Label ID="parag1" runat="server"></asp:Label>
                </h6>
                <p>
                    <asp:Label ID="parag2" runat="server"></asp:Label><br />
                    <br />
                    <asp:Label ID="parag3" runat="server"></asp:Label>
                    <br />
                    <br />

                </p>
            </div>
            <div class="span3" style="float: left">
                Hafta İçi Çalışma Saatleri<br />
                <b>
                    <asp:Label ID="weekDay" runat="server"></asp:Label>
                </b>
                <br />
                Hafta Sonu Çalışma Saatleri<br />
                <b>
                    <asp:Label ID="weekEnd" runat="server"></asp:Label></b><br />
            </div>
        </div>
    </div>
</asp:Content>

