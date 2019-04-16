using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CategoriesUC : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Repeater1.DataSource = CatalogAccess.GetCategories();
            Repeater1.DataBind();
        }
        //DataList1.DataSource = CatalogAccess.GetCatagories();
        //DataList1.DataBind();
    }
}