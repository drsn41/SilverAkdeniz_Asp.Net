using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Carts : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCountCarts_Click(object sender, EventArgs e)
    {
        byte days = byte.Parse(dayDropDown.SelectedItem.Value);
        int oldItems = CartAccess.CountOldCarts(days);
        if (oldItems == -1)
        {
            lblStat.Text = "Sepet Verileri Sayılamadı!";
        }
        else if (oldItems == 0)
        {
            lblStat.Text = "Sepet Verisi Bulunamadı !";
        }
        else
        {
            lblStat.Text = "Toplam : " + oldItems + " Sepet Bulundu";
        }
    }
    protected void btnDeleteOldCarts_Click(object sender, EventArgs e)
    {
        byte days = byte.Parse(dayDropDown.SelectedItem.Value);

        bool stat = CartAccess.DeleteOldCarts(days);
        if (stat)
            lblStat.Text = "Sepetler Silindi !";
        else
            lblStat.Text = "Sepetler Silinemedi!";
    }
}