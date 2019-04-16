<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserInfo.ascx.cs" Inherits="UserControls_UserInfo" %>


<table class="table table-bordered table-condensed">
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            <tr>
                <td>Hoşgeldiniz..
                </td>
            </tr>
            <tr>
                <td>Sayın Misafir
                    <br />
                    Lütfen
                   <b>
                       <asp:LoginStatus runat="server" />
                   </b>
                    <br />
                    Yada
                   <b>
                       <asp:HyperLink ID="HyperLink1" NavigateUrl="../register.aspx" runat="server">Kayıt Ol</asp:HyperLink></b>
                </td>
            </tr>
        </AnonymousTemplate>
        <RoleGroups>
            <asp:RoleGroup Roles="Admin">
                <ContentTemplate>
                    <tr>
                        <td>
                            <b>
                                <asp:LoginName ID="LoginName1" FormatString="Merhaba Sayın, <b>{0}<b>" runat="server" />
                            </b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:LoginStatus ID="LoginStatus3" runat="server" />
                            <br />
                            <b><a href="../Admin/Default.aspx">Yönetim Sayfasına Git</a></b>
                        </td>
                    </tr>
                </ContentTemplate>
            </asp:RoleGroup>

            <asp:RoleGroup Roles="User">
                <ContentTemplate>
                    <tr>
                        <td>
                            <asp:LoginName ID="LoginName1" FormatString="Merhaba Sayın, <b>{0}<b>" runat="server" />
                        
                        </td>
                    </tr>
                    <tr>
                        <td><b>
                            <asp:LoginStatus ID="LoginStatus3" runat="server" />
                            <br />
                            <a href="user_info.aspx">Profil Bilgilerine Gidin</a>
                            <br />
                           <%-- <a href="user_orders.aspx">Siparişlerinize Gidin</a></b>--%>
                        </td>
                    </tr>
                </ContentTemplate>
            </asp:RoleGroup>

        </RoleGroups>
    </asp:LoginView>
</table>


