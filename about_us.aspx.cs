using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class about_us : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CompanyDetails comp = new CompanyDetails();
            comp = CatalogAccess.GetCompanyDetails();
            Image1.ImageUrl = comp.image;
            parag1.Text = comp.parag1;
            parag2.Text = comp.parag2;
            parag3.Text = comp.parag3;
            weekDay.Text = comp.weekDay;
            weekEnd.Text = comp.weekEnd;
        }

    }
}