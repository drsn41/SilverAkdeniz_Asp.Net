using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Messages : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            grid.DataSource = CatalogAccess.GetAllMessages();
            grid.DataBind();
        }
            
    }
    protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = grid.DataKeys[e.RowIndex].Value.ToString();
        CatalogAccess.AdminDeleteMessage(id);
        grid.EditIndex = -1;
        Response.Redirect("Messages.aspx");
    }
    protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string Id = grid.DataKeys[e.RowIndex].Value.ToString();
        CatalogAccess.AdminMarkMessageReplyed(Id);
        Response.Redirect("Messages.aspx");
    }
}