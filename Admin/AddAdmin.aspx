<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeFile="AddAdmin.aspx.cs" Inherits="Admin_Account_info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div class="col-md-12 col-sm-12 col-xs-12">
        <div class="panel panel-info">
            <div class="panel-heading">
                Yönetici Ekle
            </div>
            <div class="panel-body">

                <asp:CreateUserWizard ID="CreateUserWizard1"
                    CancelDestinationPageUrl="Default.aspx"
                    ContinueDestinationPageUrl="Default.aspx"
                    CssClass="form-horizontal" runat="server"
                    OnCreatedUser="CreateUserWizard1_CreatedUser">
                    <WizardSteps>
                        <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                        </asp:CreateUserWizardStep>
                        <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                        </asp:CompleteWizardStep>
                    </WizardSteps>
                </asp:CreateUserWizard>

            </div>
        </div>
    </div>
</asp:Content>

