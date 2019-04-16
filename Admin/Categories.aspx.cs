using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Categories : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            BindGridView();
        }
    }
    private void BindGridView()
    {
        
        DataTable dt = CatalogAccess.GetCategories();
        if (dt.Rows.Count == 0)
        {
            lblNotFound.Visible = true;
            lblNotFound.Text = "<h3> Hiç Kategori Yok :( </h3>";
        }
        grid.DataSource = dt;
        grid.DataBind();
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string Name = txtAddName.Text;
        string Description = txtAddDescription.Text;
        bool stat = CatalogAccess.AdminAddCategory(Name, Description);
        // lblStatus.Text = Description;
        lblStatus.Text = stat ? "Başarılı" : "Başarısız";
        BindGridView();
    }
    protected void grid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        
        grid.EditIndex = e.NewEditIndex;
        BindGridView();
    }
    protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = grid.DataKeys[e.RowIndex].Value.ToString();
        bool stat = CatalogAccess.AdminDeleteCategory(id);
        grid.EditIndex = -1;
        lblStatus.Text = stat ? "Başarılı" : "Başarısız";
        BindGridView();
    }
    protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string Id = grid.DataKeys[e.RowIndex].Value.ToString();
      
        string name = ((TextBox)grid.Rows[e.RowIndex].FindControl("txtEditName")).Text;
        string description = ((TextBox)grid.Rows[e.RowIndex].FindControl("txtEditDescript")).Text;

        bool stat = CatalogAccess.AdminUpdateCategory(Id, name, description);
        grid.EditIndex = -1;
        lblStatus.Text = stat ? "başarılı" : "Başarısız";
        BindGridView();
    }
    protected void grid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grid.EditIndex = -1;
        BindGridView();
    }
    protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        int newPageIndex = e.NewPageIndex;
        grid.PageIndex = newPageIndex;
        BindGridView();
    }
}