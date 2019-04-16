using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class check_out : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DenetimleriDoldur();
    }

    private void DenetimleriDoldur()
    {
        BankAccounts bnk = CatalogAccess.GetBankAccount();
        lblBankName.Text = bnk.bankName;
        lblBankNumber.Text = bnk.iban;
        lblAccountOwner.Text = bnk.owner;
        lblDecription.Text = bnk.description;
        lblPaymentID.Text = Request.QueryString["CartID"];
        lblCost.Text = String.Format("{0:c}", CartAccess.GetTotalAmount());


    }
    protected void btnPay_Click(object sender, EventArgs e)
    {
        if (Profile.Address == "" || Profile.IBAN == "" || Profile.UserName == "" || Profile.Phone == "")
        {
            lblStatus.Text = "Lütfen Profil Bilgilerinde Boş Bırakmayınız";
        }
        else
        {
            string OrderID = CartAccess.CreateCustomerOrder();
            lblStatus.Text = OrderID;
        }

    }
}