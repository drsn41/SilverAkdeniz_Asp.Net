using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Orders : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void grid_SelectedIndexChanged(object sender, EventArgs e)
    {
        string dest = String.Format("OrderDetails.aspx?OrderID={0}",
            grid.DataKeys[grid.SelectedIndex].Value.ToString());
        Response.Redirect(dest);
    }
    protected void btnByRecent_Click(object sender, EventArgs e)
    {
        //
        int recordCount;

        if (int.TryParse(txtRecent.Text, out recordCount))
        {
            grid.DataSource = OrderAccess.GetOrdersByRecent(recordCount);

        }
        else
        {
            lblStatus.Text = "Lütfen İşleminizi Kontrol Ediniz!";
        } grid.DataBind();

    }
    protected void btnByDate_Click(object sender, EventArgs e)
    {
        if ((Page.IsValid) && (txtStartDate.Text + txtStartDate.Text != ""))
        {
            string stDate = txtStartDate.Text;
            string endDate = txtEndDate.Text;
            grid.DataSource = OrderAccess.GetOrdersByDate(stDate, endDate);

        }
        else
        {
            lblStatus.Text = "Lütfen İşleminizi Kontrol Ediniz!";
        } grid.DataBind();
    }
    protected void Unverified_Click(object sender, EventArgs e)
    {
        grid.DataSource = OrderAccess.GetOrdersUnverifiedCanceled();
        grid.DataBind();
    }
    protected void btnUncomplated_Click(object sender, EventArgs e)
    {
        grid.DataSource = OrderAccess.GetOrdersVerifiedUncompleted();
        grid.DataBind();
    }
    protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        int newPageIndex = e.NewPageIndex;
        grid.PageIndex = newPageIndex;
        //BindGridView();
    }
}