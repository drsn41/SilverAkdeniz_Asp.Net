using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Reviews : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            DenetimleriDoldur();
    }

    public void DenetimleriDoldur()
    {
        string id = Request.QueryString["ProductID"];
        if (id == null)
        {
            Response.Redirect("Products.aspx");
        }

        grid.DataSource = CatalogAccess.GetProductReviews(id);
        grid.DataBind();
    }
    protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string Id = grid.DataKeys[e.RowIndex].Value.ToString();
        CatalogAccess.AdminProductReviewMarkVerified(Id);
        DenetimleriDoldur();
    }
    protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = grid.DataKeys[e.RowIndex].Value.ToString();
        CatalogAccess.AdminDeleteProductReview(id);
        grid.EditIndex = -1;
        DenetimleriDoldur();
    }
}