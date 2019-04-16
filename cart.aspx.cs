using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class cart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DenetimleriDoldur();
        }
    }
    public void DenetimleriDoldur()
    {
        ProductRecomment.LoadCartRecomment();


        DataTable dt = CartAccess.GetItems();

        if (dt.Rows.Count == 0)
        {
            btnUpdate.Enabled = false;
            btnCheckOut.Enabled = false;
            lblNumberOfProduct.Text = "Sepetinizde Ürün Bulunmamaktadır";
            grid.Visible = false;
            lblTotalAmount.Text = String.Format("{0:c}", 0);
        }
        else
        {
            grid.Visible = true;
            grid.DataSource = dt;
            grid.DataBind();

            //string numberOfProduct = "6";
            //lblNumberOfProduct.Text = "Toplam " + numberOfProduct + " ürün seçtiniz.";
            decimal amount = CartAccess.GetTotalAmount();
            lblTotalAmount.Text = String.Format("{0:c}", amount);
        }
    }
    protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //Seçili Satır numasını almak
        int rowIndex = e.RowIndex;
        //
        string productID = grid.DataKeys[rowIndex].Value.ToString();
        //Ürün Sil
        bool stat = CartAccess.RemoveItem(productID);
        lblStatus.Text = stat ? "Silme Başarılı" : "Silme Başarısız";
        DenetimleriDoldur();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        int rowsCount = grid.Rows.Count;
        GridViewRow gridRow;

        TextBox qtyTextBox;

        string productID;
        int qty;

        bool stat = true;

        for (int i = 0; i < rowsCount; i++)
        {
            gridRow = grid.Rows[i];
            productID = grid.DataKeys[i].Value.ToString();

            qtyTextBox = (TextBox)gridRow.FindControl("editQty");

            if (Int32.TryParse(qtyTextBox.Text, out qty))
            {
                stat = stat && CartAccess.UpdateItem(productID, qty);
            }
            else
            {
                stat = false;
            }
            lblStatus.Text = stat ? "Güncelleme Başarılı" : "Güncelleme Başarısız";
        }

        DenetimleriDoldur();
    }
    protected void btnCheckOut_Click(object sender, EventArgs e)
    {
        Response.Redirect("check_out.aspx?CartID=" + CartAccess.cartID.ToString());
    }
}