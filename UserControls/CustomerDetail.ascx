<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CustomerDetail.ascx.cs" Inherits="UserControls_CustomerDetail" %>
<asp:ObjectDataSource
    ID="ObjectDataSource1"
    runat="server"
    DataObjectTypeName="ProfileWrapper"
    SelectMethod="GetData"
    TypeName="ProfileDataSource"
    UpdateMethod="UpdateDate"></asp:ObjectDataSource>
<asp:FormView ID="FormView1"
    runat="server"
    DataSourceID="ObjectDataSource1">
    <EditItemTemplate>

        <table class="table table-bordered table-condensed">
            <tr>
                <td>Address:
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Address") %>' />
                </td>
            </tr>
            <tr>
                <td>Tckn:
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("Tckn") %>' />
                </td>
            </tr>

            <tr>
                <td>Iban:
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Iban") %>' />
                </td>
            </tr>

            <tr>
                <td>Phone:
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("Phone") %>' />
                </td>
            </tr>

            <tr>
                <td>Email:
                </td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Email") %>' />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                </td>
                <td>
                    <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
                <td>
            </tr>
        </table>

    </EditItemTemplate>

    <ItemTemplate>

        <table class="table table-bordered table-condensed">
            <tr>
                <td>Adres:
                </td>
                <td>
                    <asp:Label ID="AddressLabel" runat="server" Text='<%# Bind("Address") %>' />
                </td>
            </tr>
            <tr>
                <td>Tckn:
                </td>
                <td>
                    <asp:Label ID="TcknLabel" runat="server" Text='<%# Bind("Tckn") %>' />
                </td>
            </tr>

            <tr>
                <td>Iban:
                </td>
                <td>
                    <asp:Label ID="IbanLabel" runat="server" Text='<%# Bind("Iban") %>' />
                </td>
            </tr>

            <tr>
                <td>Telefon:
                </td>
                <td>
                    <asp:Label ID="PhoneLabel" runat="server" Text='<%# Bind("Phone") %>' />
                </td>
            </tr>

            <tr>
                <td>Eposta:
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("Email") %>' />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
                </td>

            </tr>
        </table>
       
    </ItemTemplate>
</asp:FormView>
