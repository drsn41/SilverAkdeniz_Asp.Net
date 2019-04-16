using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_ProductRecomment : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void LoadProductRecomment(string productID)
    {

        DataTable dt = new DataTable();
        dt = CatalogAccess.GetProductRecomment(productID);

        if (dt.Rows.Count > 0)
        {
            list.ShowHeader = true;
            list.DataSource = dt;
            list.DataBind();
        }
        
    }
    public void LoadCartRecomment()
    {
        DataTable dt = new DataTable();
        dt = CartAccess.GetCartRecomment();

        if (dt.Rows.Count > 0)
        {
            list.ShowHeader = true;
            list.DataSource = dt;
            list.DataBind();
        }

    }

   
   
}