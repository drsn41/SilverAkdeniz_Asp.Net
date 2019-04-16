using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;


public partial class contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CompanyDetails comp = new CompanyDetails();
            comp = CatalogAccess.GetCompanyDetails();

            lblAddress.Text = comp.siteAddress;
            lblEmail.Text = comp.siteEmail;
            lblPhone.Text = comp.sitePhone;

            DataTable dt = CatalogAccess.GetMapLocations();
            rptMarkers.DataSource = dt;
            rptMarkers.DataBind();
            
        }

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        var encodedResponse = Request.Form["g-Recaptcha-Response"];
        var isCaptchaValid = ReCaptcha.Validate(encodedResponse);

        if (!isCaptchaValid)
        {
            lblStatus.Text = "Lütfen Kodu Doğrulayınız!!";
        }
        else
        {
            string image = "x.jpg";
            if (FileUpload1.HasFile)
            {
                try
                {
                    string gui = Guid.NewGuid().ToString();
                    string fileName = FileUpload1.FileName;
                    string properFileName = gui + "-" + fileName;
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/ProductImages/") + properFileName);
                    image = "/ProductImages/" + properFileName;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            bool stat = CatalogAccess.CustomerSendMessage(txtName.Text, txtSurname.Text, txtEmail.Text, txtSubject.Text, image, txtText.Text);
            Response.Redirect("index.aspx?SendMessage=ok");
        }
    }

}