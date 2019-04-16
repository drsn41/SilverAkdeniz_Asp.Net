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
        string id = Request.QueryString["ProductID"];
        if (id == null)
        {
            Response.Redirect("Products.aspx");
        }

        grid2.DataSource = CatalogAccess.GetProductPhotos(id);
        grid2.DataBind();
        grid.DataSource = CatalogAccess.GetOneProductDataTable(id);
        grid.DataBind();
    }

    protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string Id = grid.DataKeys[e.RowIndex].Value.ToString();

        string name = ((TextBox)grid.Rows[e.RowIndex].FindControl("txtEditName")).Text;
        string description = ((TextBox)grid.Rows[e.RowIndex].FindControl("txtEditDescript")).Text;
        string price = ((TextBox)grid.Rows[e.RowIndex].FindControl("txtEditPrice")).Text;
        string categoryId = ((TextBox)grid.Rows[e.RowIndex].FindControl("txtEditCategory")).Text;
        string thumbnail = ((Label)grid.Rows[e.RowIndex].FindControl("lblEditThumbnail")).Text;
        FileUpload fu = (FileUpload)grid.Rows[e.RowIndex].FindControl("FileUpload1");
        string isFlash = ((CheckBox)grid.Rows[e.RowIndex].Cells[6].Controls[0]).Checked.ToString().ToUpper();
        if (fu.HasFile)
        {
            try
            {
                string gui = Guid.NewGuid().ToString();
                string fileName = fu.FileName;
                string properFileName = gui + "-" + fileName;
                fu.PostedFile.SaveAs(Server.MapPath("~/ProductImages/") + properFileName);
                thumbnail = "/ProductImages/" + properFileName;
            }
            catch (Exception)
            {

                throw;
            }
        }
        bool stat = CatalogAccess.AdminUpdateProduct(Id, name, description, price, categoryId, thumbnail, isFlash);
        grid.EditIndex = -1;
        lblCategory.Text = stat ? "başarılı" : "Başarısız";

        BindGridView();


    }
    protected void grid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grid.EditIndex = e.NewEditIndex;
        BindGridView();
    }

    protected void grid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grid.EditIndex = -1;
        BindGridView();
    }
    protected void btnAddPhoto_Click(object sender, EventArgs e)
    {
        string id = Request.QueryString["ProductID"];
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

                CatalogAccess.AdminAddProductImage(id, path);
            }
            catch (Exception)
            {

                throw;
            }
        }
        BindGridView();
    }
    protected void grid2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string imgId = grid2.DataKeys[e.RowIndex].Value.ToString();

        lblNotFound.Text = imgId;

        bool stat = CatalogAccess.AdminDeleteProductImage(imgId);
        grid.EditIndex = -1;
        BindGridView();
    }
}