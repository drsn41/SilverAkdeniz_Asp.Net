using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_CartSummary : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DenetimleriDoldur();
    }

    protected void Page_Init(object sender, EventArgs e)
    {
        string page = Request.AppRelativeCurrentExecutionFilePath;
        if (String.Compare(page, "~/cart.aspx", true) == 0)
        {
            this.Visible = false;
        }
        else
        {
            this.Visible = true;
        }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        DenetimleriDoldur();
    }
    private void DenetimleriDoldur()
    {
        System.Data.DataTable dt = CartAccess.GetItems();

        if (dt.Rows.Count == 0)
        {

            lbltotalAmount.Text = String.Format("{0:c}", 0);

        }
        else
        {
            //  double amount2 = CartAccess.SepetToplam();
            decimal amount = CartAccess.GetTotalAmount();
            lbltotalAmount.Text = String.Format("{0:c}", amount);
        }
    }
}