using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_CustomerDetail : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public bool Editable
    {
        get
        {
            if (ViewState["editable"] != null)
            {
                return (bool)ViewState["editable"];
            }
            else
            {
                return true;
            }
        }
        set
        {
            ViewState["editable"] = value;
        }
    }
    protected override void OnPreRender(EventArgs e)
    {
        Button editButton = FormView1.FindControl("EditButton") as Button;
        if (editButton != null)
        {
            editButton.Visible = Editable;
        }
    }
}