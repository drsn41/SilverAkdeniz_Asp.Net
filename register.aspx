<%@ Page Title="" Language="C#" MasterPageFile="~/Other.master" AutoEventWireup="true" CodeFile="register.aspx.cs" Inherits="register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <ul class="breadcrumb">
        <li><a href="index.aspx">Anasayfa</a> <span class="divider">/</span></li>
        <li class="active">Kayıt Ol</li>
    </ul>
    <div class="well well-small">
        <div>
            <h1>Kayıt İşlemleri</h1>
        </div>
        <hr class="soften" />
        <div class="row">
            <div class="span8">
                <asp:LoginView ID="LoginView1" runat="server">
                    <LoggedInTemplate>
                        Zaten Kayıtlı Kullanıcısınız ...
                    </LoggedInTemplate>
                    <AnonymousTemplate>

                        <asp:CreateUserWizard
                            CancelDestinationPageUrl="index.aspx"
                            ContinueDestinationPageUrl="user_info.aspx"
                            ID="CreateUserWizard1" runat="server"
                            OnCreatedUser="CreateUserWizard1_CreatedUser">
                            <WizardSteps>
                                <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                                </asp:CreateUserWizardStep>
                                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                                </asp:CompleteWizardStep>
                            </WizardSteps>
                        </asp:CreateUserWizard>

                    </AnonymousTemplate>
                </asp:LoginView>
            </div>
        </div>
    </div>
</asp:Content>

