using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Product_edit : System.Web.UI.Page
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
        grid.DataSource = CatalogAccess.AdminGetSliders();
        grid.DataBind();
    }

    protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string Id = grid.DataKeys[e.RowIndex].Value.ToString();
        CatalogAccess.AdminMarkSliderPromoFront(Id);
        BindGridView();
    }

    protected void btnAddPhoto_Click(object sender, EventArgs e)
    {
        string path;
        if (FileUpload1.HasFile)
        {
            try
            {
                string gui = Guid.NewGuid().ToString();
                string fileName = FileUpload1.FileName;
                string properFileName = gui + "-" + fileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/ProductImages/") + properFileName);
                path = "/ProductImages/" + properFileName;

                CatalogAccess.AdminAddSlider(path, txtTopText.Text, txtBotText.Text);
            }
            catch (Exception)
            {

                throw;
            }
        }
        BindGridView();
    }
    
    protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = grid.DataKeys[e.RowIndex].Value.ToString();
        CatalogAccess.AdminDeleteSlider(id);
        BindGridView();
    }
}