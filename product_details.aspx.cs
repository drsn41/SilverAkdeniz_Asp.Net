using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class product_details : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string productID = Request.QueryString["ProductID"];
        ProductDetail prod = CatalogAccess.GetOneProduct(productID);
        lblActiveProd.Text = prod.Name;


        if (prod.Name != null)
        {
            DenetimleriYukle(prod);
        }
    }
    public void DenetimleriYukle(ProductDetail prod)
    {
        ProductRecomment.LoadProductRecomment(prod.ProductID.ToString());

        lblProdName.Text = prod.Name;
        lblProdPrice.Text = String.Format("{0:c}", prod.Price);
        lblProdDescription.Text = prod.Description;
        lblProdTakeTime.Text = prod.TakeTime;
        this.Title = Configuration.SiteName + " -> " + prod.Name;

        DataTable slider = CatalogAccess.GetProductPhotos(prod.ProductID.ToString());
        ProdSlider.DataSource = slider;
        ProdSlider.DataBind();

        string prevAttributeValue = "";
        string attributeName, attributeValue, attributeValueID;


        Label attributeNameLabel;
        DropDownList attributeValuesDropDown = new DropDownList();

        DataTable attrTable = CatalogAccess.GetProductAttributeValues(prod.ProductID.ToString());

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

                attrPlaceHolder.Controls.Add(attributeNameLabel);
                attrPlaceHolder.Controls.Add(attributeValuesDropDown);


            }
            attributeValuesDropDown.Items.Add(new ListItem(attributeValue, attributeValueID));
        }
    }

    protected void btnAddToCart_Clik(object sender, EventArgs e)
    {
        string productID = Request.QueryString["ProductID"];

        ProductDetail pd = CatalogAccess.GetOneProduct(productID);

        string options = "";
        foreach (Control cnt in attrPlaceHolder.Controls)
        {
            if (cnt is Label)
            {
                Label attrLabel = (Label)cnt;
                options += attrLabel.Text;
            }
            if (cnt is DropDownList)
            {
                DropDownList attrDropDowm = (DropDownList)cnt;
                options += attrDropDowm.Items[attrDropDowm.SelectedIndex] + "; ";
            }
        }

        // CartAccess.AddItem2(productID);
        CartAccess.AddItem(productID, options);
    }
}