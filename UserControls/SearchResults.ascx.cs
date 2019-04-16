using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_SearchResults : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DegerleriYukle();
        }

    }

    public void DegerleriYukle()
    {
        string page = Request.QueryString["Page"];
        string searchText = Request.QueryString["query"];
        if (page == null)
        {
            page = "1";
        }

        int howManyPages = 1;
        string firstPageUrl = "";
        string pagerFormat = "";

        if (searchText != null)
        {
            string allWords = Request.QueryString["AllWords"];
            DataTable dt = CatalogAccess.Search(searchText, allWords, page, out howManyPages);
            if (dt.Rows.Count == 0)
            {
                lblNotFound.Visible = true;
                lblNotFound.Text = "<h3> Hiç Sonuç Bulunamadı :( </h3>";
            }

            ListViewProductsOfCategory.DataSource = dt;
            ListViewProductsOfCategory.DataBind();

            firstPageUrl = Link.ToSearch(searchText, allWords.ToUpper() == "TRUE", "1");
            pagerFormat = Link.ToSearch(searchText, allWords.ToUpper() == "TRUE", "{0}");
        }

        topPager.Show(int.Parse(page), howManyPages, firstPageUrl, pagerFormat, true);
        bottomPager.Show(int.Parse(page), howManyPages, firstPageUrl, pagerFormat, true);
    }

}