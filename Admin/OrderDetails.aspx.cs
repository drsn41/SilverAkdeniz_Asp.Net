using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_OrderDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack && Request.QueryString["OrderID"] != null)
        {
            string orderID = Request.QueryString["OrderID"].ToString();
            SetEditMode(false);
            DenetimlerDoldur(orderID);
        }
    }
    private void SetEditMode(bool status)
    {
        txtShippingAddress.Enabled = status;
        txtDateCreated.Enabled = status;
        txtShippedDate.Enabled = status;
        verifiedCheckBox.Enabled = status;
        completedCheckBox.Enabled = status;
        canceledCheckBox.Enabled = status;
        txtComments.Enabled = status;
        txtCustomerName.Enabled = status;
        txtCustomerEmail.Enabled = status;
        btnEdit.Enabled = status;
        btnUpdate.Enabled = status;
        btnCancel.Enabled = status;

    }
    private void DenetimlerDoldur(string orderID)
    {
        OrderIfo o = OrderAccess.GetOrderInfo(orderID);

        lblTotalAmount.Text = String.Format("{0:c}", o.TotalAmount);
        txtDateCreated.Text = o.DateCreated;
        txtShippedDate.Text = o.DateShipped;
        verifiedCheckBox.Checked = o.Verified;
        completedCheckBox.Checked = o.Completed;
        canceledCheckBox.Checked = o.Canceled;
        txtComments.Text = o.AuthCode;
        txtCustomerName.Text = o.CustomerName;
        txtCustomerEmail.Text = o.CustomeEmail;
        txtShippingAddress.Text = o.ShippingAddress;

        

        btnEdit.Enabled = true;
        btnUpdate.Enabled = false;
        btnCancel.Enabled = false;

        if (canceledCheckBox.Checked || completedCheckBox.Checked)
        {
            btnMarkVerified.Enabled = false;
            btnMarkCompleted.Enabled = false;
            btnMarkCalceled.Enabled = false;
        }
        else if (verifiedCheckBox.Checked)
        {
            btnMarkVerified.Enabled = false;
            btnMarkCompleted.Enabled = true;
            btnMarkCalceled.Enabled = true;
        }
        else
        {
            btnMarkVerified.Enabled = true;
            btnMarkCompleted.Enabled = false;
            btnMarkCalceled.Enabled = true;
        }

        grid.DataSource = OrderAccess.GetOrderDetails(orderID);
        grid.DataBind();

    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        string orderID = GetOrderID();
        DenetimlerDoldur(orderID);
        SetEditMode(true);
    }
    private string GetOrderID()
    {
        return Request.QueryString["OrderID"];
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        OrderIfo order = new OrderIfo();
        string orderID = GetOrderID();

        order.OrderID = Convert.ToInt32(orderID);
        order.DateCreated = txtDateCreated.Text;
        order.DateShipped = txtShippedDate.Text;
        order.Verified = verifiedCheckBox.Checked;
        order.Canceled = canceledCheckBox.Checked;
        order.Completed = completedCheckBox.Checked;
        order.Comments = txtComments.Text;
        order.CustomerName = txtCustomerName.Text;
        order.CustomeEmail = txtCustomerEmail.Text;
        order.ShippingAddress = txtShippingAddress.Text;

        try
        {
            OrderAccess.OrderUpdate(order);
        }
        catch (Exception)
        {
        }
        lblStatus.Text = "İşlem Başarılı!";
        SetEditMode(false);
        DenetimlerDoldur(orderID);
    }
    protected void btnMarkVerified_Click(object sender, EventArgs e)
    {
        string orderID = GetOrderID();
        OrderAccess.OrderMarkVerified(orderID);
        SetEditMode(false);
        lblStatus.Text = "İşlem Başarılı!";
        DenetimlerDoldur(orderID);
    }
    protected void btnMarkCompleted_Click(object sender, EventArgs e)
    {
        string orderID = GetOrderID();
        OrderAccess.OrderMarkCompleted(orderID);
        SetEditMode(false);
        lblStatus.Text = "İşlem Başarılı!";
        DenetimlerDoldur(orderID);
    }
    protected void btnMarkCalceled_Click(object sender, EventArgs e)
    {
        string orderID = GetOrderID();
        OrderAccess.OrderMarkCanceled(orderID);
        SetEditMode(false);
        lblStatus.Text = "İşlem Başarılı!";
        DenetimlerDoldur(orderID);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        string orderID = Request.QueryString["OrderID"].ToString();
        SetEditMode(false);
        lblStatus.Text = "İşlem Başarılı!";
        DenetimlerDoldur(orderID);
    }
   
}