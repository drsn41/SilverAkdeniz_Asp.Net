using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControls_Search : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!Page.IsPostBack)
        {
            string allWords = Request.QueryString["AllWords"];
            string query = Request.QueryString["query"];

            if (allWords != null)
            {
                AllWordsCheckBox.Checked = (allWords.ToUpper() == "TRUE");
            }

            if (query != null)
            {
                txtSearchText.Text = query;
            }
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
       
            StartSearch();
    }

    private void StartSearch()
    {
        string query = txtSearchText.Text;
        bool allWords = AllWordsCheckBox.Checked;

        if (txtSearchText.Text.Trim() != "")
        {
            Response.Redirect(Link.ToSearch(query, allWords));
        }


    }
}