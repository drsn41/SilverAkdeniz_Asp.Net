using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_FlashProducts : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            DegerleriYukle();
    }

    public void DegerleriYukle()
    {
        string page = Request.QueryString["Page"];

        if (page == null)
        {
            page = "1";
        }
        int howManyPages = 1;
        string firstPageUrl = "1";
        string pagerFormat = "";

        if (page != null)
        {
            list.DataSource = CatalogAccess.GetFlashProducts(page, out howManyPages);
            list.DataBind();
            int currentPage = Int32.Parse(page);
            firstPageUrl = Link.ToFlash(page);
            pagerFormat = Link.ToFlash("{0}");
        }
        topPager.Show(int.Parse(page), howManyPages, firstPageUrl, pagerFormat, true);
        bottomPager.Show(int.Parse(page), howManyPages, firstPageUrl, pagerFormat, true);

    }
}