using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_ProductsOfCategory2 : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            DegerleriYukle();
    }

    public void DegerleriYukle()
    {
        string page = Request.QueryString["Page"];
        string categoryID = Request.QueryString["CategoryID"];

        if (page == null)
        {
            page = "1";
        }

        int howManyPages = 1;
        string firstPageUrl = "";
        string pagerFormat = "";


        if (categoryID == null || categoryID == "")
        {
            ListViewProductsOfCategory.DataSource = CatalogAccess.GetAllProducts(page, out howManyPages);
            ListViewProductsOfCategory.DataBind();

            int currentPage = Int32.Parse(page);
            firstPageUrl = Link.ToAllProducts(page);
            pagerFormat = Link.ToAllProducts("{0}");
        }
        else if (categoryID != null)
        {
            ListViewProductsOfCategory.DataSource = CatalogAccess.GetAllProductsInCategory(categoryID, page, out howManyPages);
            ListViewProductsOfCategory.DataBind();

            int currentPage = Int32.Parse(page);
            firstPageUrl = Link.ToCategory(categoryID, "1");
            pagerFormat = Link.ToCategory(categoryID, "{0}");

        }
        else
        {
            Response.Redirect("404.aspx");
        }
        topPager.Show(int.Parse(page), howManyPages, firstPageUrl, pagerFormat, true);
        bottomPager.Show(int.Parse(page), howManyPages, firstPageUrl, pagerFormat, true);
    }

    protected void ListViewProductsOfCategory_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        DataRowView dataRow = (DataRowView) e.Item.DataItem;
        string productID = dataRow["ProductID"].ToString();
        DataTable attrTable = CatalogAccess.GetProductAttributeValues(productID);

        PlaceHolder attrPalceHolder = (PlaceHolder)e.Item.FindControl("attrPlaceHolder");

        string prevAttributeValue = "";
        string attributeName, attributeValue, attributeValueID;
        
        Label attributeNameLabel;
        DropDownList attributeValuesDropDown = new DropDownList();

        foreach (DataRow r in attrTable.Rows)
        {
            attributeName = r["AttributeName"].ToString();
            attributeValue = r["AttributeValue"].ToString();
            attributeValueID = r["AttributeValueID"].ToString();

            if (attributeName != prevAttributeValue)
            {
                prevAttributeValue = attributeName;
                attributeNameLabel = new Label();
                attributeNameLabel.Text = attributeName + ":";
                attributeValuesDropDown = new DropDownList();

                attrPalceHolder.Controls.Add(attributeNameLabel);
                attrPalceHolder.Controls.Add(attributeValuesDropDown);

            }
            attributeValuesDropDown.Items.Add(new ListItem(attributeValue,attributeValueID));
        }


    }
}