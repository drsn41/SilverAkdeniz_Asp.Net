using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data;
public partial class UserControls_ProductReviews : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string productID = Request.QueryString["ProductID"];

        DataTable table = CatalogAccess.GetProductReviewsCustomer(productID);

        if (table.Rows.Count > 0)
        {
            DataList1.ShowHeader = true;
            DataList1.DataSource = table;
            DataList1.DataBind();
        }
        addReview.Visible = (HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated);
    }
    protected void btnAddReview_Click(object sender, EventArgs e)
    {
        string customerID = Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString();
        string productID = Request.QueryString["ProductID"];

        CatalogAccess.AddReview(customerID, productID, TextBox1.Text);

        Response.Redirect(HttpContext.Current.Request.RawUrl);
    }
}