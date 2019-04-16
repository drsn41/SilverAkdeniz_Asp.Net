using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Products : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.QueryString["CategoryID"];
        if (!Page.IsPostBack)
        {
            if (id == null)
            {
                DataTable catg = CatalogAccess.GetCategories();
                CatgDropList.DataSource = catg;
                CatgDropList.DataTextField = catg.Columns["Name"].ToString();
                CatgDropList.DataValueField = catg.Columns["CategoryID"].ToString();
                CatgDropList.DataBind();
            }
            else
            {
                CategoryDetails cd = CatalogAccess.GetOneCategory(id);
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("Name"));
                dt.Columns.Add(new DataColumn("CategoryID"));
                dt.Rows.Add(cd.Name, cd.CategoryID);
                CatgDropList.DataSource = dt;
                CatgDropList.DataTextField = dt.Columns["Name"].ToString();
                CatgDropList.DataValueField = dt.Columns["CategoryID"].ToString();
                CatgDropList.DataBind();

            }
            BindGridView();
        }
    }
    private void BindGridView()
    {
        string id = Request.QueryString["CategoryID"];

        if (id == null)
        {
            DataTable dt = CatalogAccess.AdminGetAllProducts();
            lblNotFound.Visible = true;
            lblNotFound.Text = "<h3> Tüm Ürünler Görüntüleniyor..  </h3>";


            grid.DataSource = dt;
            grid.DataBind();
        }
        else
        {
            CategoryDetails cd = CatalogAccess.GetOneCategory(id);

            DataTable dt = CatalogAccess.AdminGetAllProductsInCategory(id);
            if (dt.Rows.Count == 0)
            {
                lblNotFound.Visible = true;
                lblNotFound.Text = "<h3> Bu Kategoride Hiç Ürün Yok :( </h3>";
            }

            lblCategory.Visible = true;
            lblCategory.Text = "<h4> Kagori: " + cd.Name + "</h4> ";

            grid.DataSource = dt;
            grid.DataBind();
        }

    }

    protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string id = grid.DataKeys[e.RowIndex].Value.ToString();
        bool stat = CatalogAccess.AdminDeleteProduct(id);
        grid.EditIndex = -1;
        lblStatus.Text = stat ? "Başarılı" : "Başarısız";
        BindGridView();
    }

    protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        int newPageIndex = e.NewPageIndex;
        grid.PageIndex = newPageIndex;
        BindGridView();
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string category = CatgDropList.SelectedItem.Value.ToString();
        string name = txtName.Text;
        string description = txtDescription.Text;
        string price = txtPrice.Text;
        string isFlash = CheckBox1.Checked.ToString();
        string thumbnail;
   
        string takeTime = txtTakeTime.Text;
        if (FileUpload1.HasFile )
        {
            try
            {
                string gui = Guid.NewGuid().ToString();
               
                string fileName = FileUpload1.FileName;
              
                string properFileName = gui + "-" + fileName;
                
                
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/ProductImages/") + properFileName);
              
                thumbnail = "/ProductImages/" + properFileName;

                bool stat = CatalogAccess.AdminAddProduct(name, description, price, category, thumbnail,takeTime, "", isFlash);
                lblStatus.Text = stat ? "Başarılı" : "Başarısız";
            }
            catch (Exception)
            {

                throw;
            }
        }
        else
        {
            lblStatus.Text = "Lütfen İki Tane Fotograf Seçiniz!";
        }

        BindGridView();
    }
    protected void CatgDropList_SelectedIndexChanged(object sender, EventArgs e)
    {
        string categoryID = CatgDropList.SelectedItem.Value.ToString();
        Response.Redirect("Products.aspx?CategoryID=" + categoryID);
    }
}