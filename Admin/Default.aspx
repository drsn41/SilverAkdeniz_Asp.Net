<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="col-md-12 col-sm-12 col-xs-12">
        <div class="form-group">
            <label>Durum: </label>
            <asp:Label ID="lblStatus" runat="server" Text="Beklemede"></asp:Label>
        </div>
        <div class="panel panel-info">
            <div class="panel-heading">
                Bilgileriniz
            </div>
            <div class="panel-body">
                <div class="form-group ">
                    <label>Şirket E-mail:</label>
                    <asp:TextBox CssClass="form-control" ID="txtMail" runat="server"></asp:TextBox>
                    <label>Şirket Adresiniz:</label>
                    <asp:TextBox CssClass="form-control" ID="txtAddress" runat="server"></asp:TextBox>
                    <label>Şirket Telefonu:</label>
                    <asp:TextBox CssClass="form-control" ID="txtPhone" runat="server"></asp:TextBox>
                    <label>Logo:</label>
                    <asp:Label ID="lblLogo" runat="server" Text="Label"></asp:Label>
                    <asp:FileUpload CssClass="form-control" ID="logoUpload" runat="server" />
                    <label>Şirket Adı:</label>
                    <asp:TextBox CssClass="form-control" ID="txtCompName" runat="server"></asp:TextBox>
                    <label>Hakkımızda Parağraf 1:</label>
                    <asp:TextBox CssClass="form-control" ID="txtAboutUs1" runat="server"></asp:TextBox>
                    <label>Hakkımızda Parağraf 2:</label>
                    <asp:TextBox CssClass="form-control" ID="txtAboutUs2" runat="server"></asp:TextBox>
                    <label>Hakkımızda Parağraf 3:</label>
                    <asp:TextBox CssClass="form-control" ID="txtAboutUs3" runat="server"></asp:TextBox>
                    <label>Hakkımızda Fotoğrafı:</label>
                    <asp:Label ID="lblAboutUs" runat="server" Text="Label"></asp:Label>
                    <asp:FileUpload CssClass="form-control" ID="aboutImgUpload" runat="server" />
                    <label>Hafta İçi Çalışma Saatleri:</label>
                    <asp:TextBox CssClass="form-control" ID="txtWeekDay" runat="server"></asp:TextBox><br />
                    <label>Hafta Sonu Çalışma Saatleri:</label>
                    <asp:TextBox CssClass="form-control" ID="txtWeekEnd" runat="server"></asp:TextBox>
                    <label>Facebook Hesabı:</label>
                    <asp:TextBox CssClass="form-control" ID="txtFbAccount" runat="server"></asp:TextBox>
                    <label>Twitter Hesabı:</label>
                    <asp:TextBox CssClass="form-control" ID="txtTwAccount" runat="server"></asp:TextBox>
                    <label>İnstagram Hesabı:</label>
                    <asp:TextBox CssClass="form-control" ID="txtInstaAccount" runat="server"></asp:TextBox>
                    <label>Youtube Hesabı:</label>
                    <asp:TextBox CssClass="form-control" ID="txtYoutAccount" runat="server"></asp:TextBox>
                    <label>Şirket Konum Enlem</label>
                    <asp:TextBox CssClass="form-control" Width="45%" ID="txtEnlem" runat="server"></asp:TextBox>
                    <label>Şirket Konum Boylam</label>
                    <asp:TextBox CssClass="form-control" Width="45%" ID="txtBoylam" runat="server"></asp:TextBox><br />
                    <br />

                    <asp:Button Width="100%" CssClass="btn btn-success" ID="btnUpdateInfo" runat="server" Text="Bilgileri Güncelle" OnClick="btnUpdateInfo_Click" /><br />

                </div>
            </div>
        </div>
    </div>

</asp:Content>

