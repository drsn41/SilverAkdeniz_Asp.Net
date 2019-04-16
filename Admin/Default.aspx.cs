using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DenetimleriDoldur();
        }
    }

    public void DenetimleriDoldur()
    {
        CompanyDetails cm = new CompanyDetails();
        cm = CatalogAccess.GetCompanyDetails();

        txtAboutUs1.Text = cm.parag1;
        txtAboutUs2.Text = cm.parag2;
        txtAboutUs3.Text = cm.parag3;
        txtAddress.Text = cm.siteAddress;
        txtCompName.Text = cm.siteName;
        txtFbAccount.Text = cm.fbAccount;
        txtInstaAccount.Text = cm.instaAccount;
        txtMail.Text = cm.siteEmail;
        txtEnlem.Text = cm.enlem;
        txtBoylam.Text = cm.boylam;
        txtPhone.Text = cm.sitePhone;
        txtTwAccount.Text = cm.twAccount;
        txtWeekDay.Text = cm.weekDay;
        txtWeekEnd.Text = cm.weekEnd;
        txtYoutAccount.Text = cm.youtAccount;
        lblAboutUs.Text = cm.image;
        lblLogo.Text = cm.siteLogo;
    }

    protected void btnUpdateInfo_Click(object sender, EventArgs e)
    {
        CompanyDetails cm = new CompanyDetails();
        cm.fbAccount = txtFbAccount.Text;
        cm.image = lblAboutUs.Text;
        cm.instaAccount = txtInstaAccount.Text;
        cm.parag1 = txtAboutUs1.Text;
        cm.parag2 = txtAboutUs2.Text;
        cm.parag3 = txtAboutUs3.Text;
        cm.siteAddress = txtAddress.Text;
        cm.siteEmail = txtMail.Text;
        cm.enlem = txtEnlem.Text;
        cm.boylam = txtBoylam.Text;
        cm.siteLogo = lblLogo.Text;
        cm.siteName = txtCompName.Text;
        cm.sitePhone = txtPhone.Text;
        cm.twAccount = txtTwAccount.Text;
        cm.weekDay = txtWeekDay.Text;
        cm.weekEnd = txtWeekEnd.Text;
        cm.youtAccount = txtYoutAccount.Text;

        if (logoUpload.HasFile )
        {

            try
            {
                string gui = Guid.NewGuid().ToString();
                string fileName = logoUpload.FileName;
                string properFileName = gui + "-" + fileName;
                logoUpload.PostedFile.SaveAs(Server.MapPath("~/ProductImages/") + properFileName);
                cm.siteLogo = "/ProductImages/" + properFileName;



            }
            catch (Exception)
            {

                throw;
            }
        }

        else if (aboutImgUpload.HasFile)
        {
            try
            {
                string gui = Guid.NewGuid().ToString();
                string fileName = aboutImgUpload.FileName;
                string properFileName = gui + "-" + fileName;
                aboutImgUpload.PostedFile.SaveAs(Server.MapPath("~/ProductImages/") + properFileName);
               cm.image = "/ProductImages/" + properFileName;
            }
            catch (Exception)
            {

                throw;
            }
        }

        CatalogAccess.UpdateCompanyDetails(cm.siteEmail, cm.siteAddress, cm.sitePhone, cm.siteLogo,
                                 cm.siteName, cm.parag1, cm.parag2, cm.parag3, cm.image, cm.weekDay,
                                 cm.weekEnd, cm.fbAccount, cm.twAccount, cm.instaAccount, cm.youtAccount, cm.enlem,cm.boylam);

        Response.Redirect("Default.aspx");

    }
}