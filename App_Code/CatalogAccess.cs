using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;


public struct CompanyDetails
{
    public string siteEmail;
    public string siteAddress;
    public string sitePhone;
    public string siteLogo;
    public string siteName;
    public string parag1;
    public string parag2;
    public string parag3;
    public string image;
    public string weekDay;
    public string weekEnd;
    public string fbAccount;
    public string twAccount;
    public string youtAccount;
    public string instaAccount;
    public string enlem;
    public string boylam;

}
public struct CategoryDetails
{
    public string CategoryID;
    public string Name;
    public string Description;
}
public struct BankAccounts
{
    public string bankName;
    public string iban;
    public string owner;
    public string description;

}
public struct ProductDetail
{
    public int ProductID;
    public string Name;
    public string Description;
    public decimal Price;
    public int Category;
    public string Thumbnail;
    public string BigImage;
    public int Image;
    public string TakeTime;
    public bool isFlash;

}

public static class CatalogAccess
{
    public static bool AdminDeleteProduct(string id)
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "AdminDeleteProduct";

        DbParameter param = command.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = id;
        param.DbType = DbType.Int32;
        command.Parameters.Add(param);

        int result = -1;
        try
        {
            result = DataAccess.ExecuteNonQuery(command);
        }
        catch (Exception ex)
        {
            Utilities.LogError(ex);
        }
        return (result != -1);

    }
    public static DataTable AdminGetAllProducts()
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "AdminGetAllProducts";

        DataTable dt = DataAccess.ExecuteSelectedCommand(command);
        return dt;

    }
    public static DataTable AdminGetAllProductsInCategory(string categoryID)
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "AdminGetAllProductsInCategory";

        DbParameter param = command.CreateParameter();
        param.ParameterName = "@CategoryID";
        param.Value = categoryID;
        param.DbType = DbType.Int32;
        command.Parameters.Add(param);

        DataTable dt = DataAccess.ExecuteSelectedCommand(command);

        return dt;
    }
    public static bool AdminAddProduct(string Name, string Description, string Price, string Category, string Thumbnail, string TakeTime, string BigImage, string isFlash)
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "AdminAddProduct";


        command.Parameters.Add(NewParameter("@Name", Name, DbType.String, 150, command));
        command.Parameters.Add(NewParameter("@Description", Description, DbType.String, -1, command));
        command.Parameters.Add(NewParameter("@Price", Price, DbType.Decimal, -1, command));
        command.Parameters.Add(NewParameter("@Category", Category, DbType.Int32, -1, command));
        command.Parameters.Add(NewParameter("@Thumbnail", Thumbnail, DbType.String, 500, command));
        command.Parameters.Add(NewParameter("@TakeTime", TakeTime, DbType.String, 150, command));
        command.Parameters.Add(NewParameter("@BigImage", BigImage, DbType.String, 500, command));
        command.Parameters.Add(NewParameter("@isFlash", isFlash, DbType.Boolean, -1, command));


        int result = -1;
        try
        {
            result = DataAccess.ExecuteNonQuery(command);
        }
        catch (Exception ex)
        {
            Utilities.LogError(ex);
        }
        return (result != -1);
    }
    public static bool AdminAddProductImage(string productId, string path)
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "AdminAddProductImage";

        command.Parameters.Add(NewParameter("@ProductID", productId, DbType.Int32, -1, command));
        command.Parameters.Add(NewParameter("@Path", path, DbType.String, 500, command));

        int result = -1;
        try
        {
            result = DataAccess.ExecuteNonQuery(command);
        }
        catch (Exception ex)
        {
            Utilities.LogError(ex);
        }
        return (result != -1);
    }
    public static bool AdminDeleteProductImage(string imgID)
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "AdminDeleteProductImage";

        command.Parameters.Add(NewParameter("@ImageID", imgID, DbType.Int32, -1, command));

        int result = -1;
        try
        {
            result = DataAccess.ExecuteNonQuery(command);
        }
        catch (Exception ex)
        {
            Utilities.LogError(ex);
        }
        return (result != -1);
    }
    public static bool AdminUpdateProduct(string productId, string name, string Description, string Price, string Category, string Thumbnail, string isFlash)
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "AdminUpdateProduct";

        command.Parameters.Add(NewParameter("@ProductID", productId, DbType.Int32, -1, command));
        command.Parameters.Add(NewParameter("@Category", Category, DbType.Int32, -1, command));
        command.Parameters.Add(NewParameter("@Name", name, DbType.String, 150, command));
        command.Parameters.Add(NewParameter("@Description", Description, DbType.String, -1, command));
        command.Parameters.Add(NewParameter("@Price", Price, DbType.Decimal, -1, command));
        command.Parameters.Add(NewParameter("@Thumbnail", Thumbnail, DbType.String, 500, command));
        // command.Parameters.Add(NewParameter("BigImage", BigImage, DbType.String, 500, command));
        if (isFlash == "TRUE")
            isFlash = "1";
        else
            isFlash = "0";
        command.Parameters.Add(NewParameter("isFlash", isFlash, DbType.Byte, -1, command));


        int result = -1;
        try
        {
            result = DataAccess.ExecuteNonQuery(command);
        }
        catch (Exception ex)
        {
            Utilities.LogError(ex);
        }
        return (result != -1);
    }
    public static DbParameter NewParameter(string paramName, string paramValue, DbType dbType, int size, DbCommand cmd)
    {
        DbParameter param = cmd.CreateParameter();
        param.ParameterName = paramName;
        param.Value = paramValue;
        param.DbType = dbType;
        if (size != -1)
        {
            param.Size = size;
        }
        return param;
    }
    public static bool AdminAddCategory(string name, string description)
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "AdminAddCategory";


        DbParameter param = command.CreateParameter();
        param.ParameterName = "@Name";
        param.Value = name;
        param.Size = 150;
        param.DbType = DbType.String;
        command.Parameters.Add(param);

        param = command.CreateParameter();
        param.ParameterName = "@Description";
        param.Value = description;
        param.Size = 1000;
        param.DbType = DbType.String;
        command.Parameters.Add(param);

        int result = -1;
        try
        {
            result = DataAccess.ExecuteNonQuery(command);
        }
        catch (Exception ex)
        {
            Utilities.LogError(ex);
        }
        return (result != -1);

    }
    public static bool AdminDeleteCategory(string id)
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "AdminDeleteCategory";

        DbParameter param = command.CreateParameter();
        param.ParameterName = "@CategoryId";
        param.Value = id;
        param.DbType = DbType.Int32;
        command.Parameters.Add(param);

        int result = -1;
        try
        {
            result = DataAccess.ExecuteNonQuery(command);
        }
        catch (Exception ex)
        {
            Utilities.LogError(ex);
        }
        return (result != -1);

    }
    public static bool AdminUpdateCategory(string id, string name, string description)
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "AdminUpdateCategory";

        DbParameter param = command.CreateParameter();
        param.ParameterName = "@CategoryId";
        param.Value = id;
        param.DbType = DbType.Int32;
        command.Parameters.Add(param);

        param = command.CreateParameter();
        param.ParameterName = "@Name";
        param.Value = name;
        param.DbType = DbType.String;
        command.Parameters.Add(param);

        param = command.CreateParameter();
        param.ParameterName = "@Description";
        param.Value = description;
        param.DbType = DbType.String;
        command.Parameters.Add(param);

        int result = -1;
        try
        {
            result = DataAccess.ExecuteNonQuery(command);
        }
        catch (Exception ex)
        {
            Utilities.LogError(ex);
        }
        return (result != -1);

    }
    public static DataTable GetProductPhotos(string id)
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "GetProductPhotos";

        DbParameter param = command.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = id;
        param.DbType = DbType.Int32;
        command.Parameters.Add(param);

        DataTable dt = DataAccess.ExecuteSelectedCommand(command);
        return dt;
    }
    public static DataTable GetProductSimilars(string id)
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "GetProductSimilars";

        DbParameter param = command.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = id;
        param.DbType = DbType.Int32;
        command.Parameters.Add(param);

        DataTable dt = DataAccess.ExecuteSelectedCommand(command);
        return dt;
    }
    public static DataTable GetProductComments(string id)
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "GetProductComments";

        DbParameter param = command.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = id;
        param.DbType = DbType.Int32;
        command.Parameters.Add(param);

        DataTable dt = DataAccess.ExecuteSelectedCommand(command);
        return dt;
    }
    public static DataTable GetCategories()
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "GetCategories";
        return DataAccess.ExecuteSelectedCommand(command);
    }
    public static CategoryDetails GetOneCategory(string categoryID)
    {
        // Command nesnesi olustur
        DbCommand command = DataAccess.CreateCommand();
        // Prosedur Cagır
        command.CommandText = "GetOneCategory";
        // prosedur için parametre oluştur
        DbParameter param = command.CreateParameter();
        param.ParameterName = "@CategoryID";
        param.Value = categoryID;
        param.DbType = DbType.Int32;
        command.Parameters.Add(param);
        //prosedur calıştır
        DataTable dt = DataAccess.ExecuteSelectedCommand(command);

        CategoryDetails category = new CategoryDetails();

        if (dt.Rows.Count > 0)
        {
            category.CategoryID = dt.Rows[0]["CategoryID"].ToString();
            category.Name = dt.Rows[0]["Name"].ToString();
            category.Description = dt.Rows[0]["Description"].ToString();

        }
        return category;

    }
    public static DataTable GetFlashProducts(string page, out int howManyPages)
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "GetFlashProducts";

        DbParameter param = command.CreateParameter();
        param.ParameterName = "@DescriptionLengt";
        param.Value = Configuration.ProductDescriptionLenght;
        param.DbType = DbType.Int32;
        command.Parameters.Add(param);

        param = command.CreateParameter();
        param.ParameterName = "@PageNumber";
        param.Value = page;
        param.DbType = DbType.Int32;
        command.Parameters.Add(param);


        param = command.CreateParameter();
        param.ParameterName = "@ProductsPerPage";
        param.Value = Configuration.ProductsPerPage;
        param.DbType = DbType.Int32;
        command.Parameters.Add(param);

        param = command.CreateParameter();
        param.ParameterName = "@HowManyProducts";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        command.Parameters.Add(param);

        DataTable dt = DataAccess.ExecuteSelectedCommand(command);
        int numberOfProduct = Int32.Parse(command.Parameters["@HowManyProducts"].Value.ToString());
        howManyPages = (int)Math.Ceiling((double)numberOfProduct / (double)Configuration.ProductsPerPage);
        return dt;
    }
    public static DataTable GetAllProductsInCategory(string categoryID, string page, out int howManyPages)
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "GetAllProductsInCategory";

        DbParameter param = command.CreateParameter();
        param.ParameterName = "@CategoryID";
        param.Value = categoryID;
        param.DbType = DbType.Int32;
        command.Parameters.Add(param);

        param = command.CreateParameter();
        param.ParameterName = "@DescriptionLengt";
        param.Value = Configuration.ProductDescriptionLenght;
        param.DbType = DbType.Int32;
        command.Parameters.Add(param);

        param = command.CreateParameter();
        param.ParameterName = "@PageNumber";
        param.Value = page;
        param.DbType = DbType.Int32;
        command.Parameters.Add(param);

        param = command.CreateParameter();
        param.ParameterName = "@ProductsPerPage";
        param.Value = Configuration.ProductsPerPage;
        param.DbType = DbType.Int32;
        command.Parameters.Add(param);

        param = command.CreateParameter();
        param.ParameterName = "@HowManyProducts";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        command.Parameters.Add(param);

        DataTable dt = DataAccess.ExecuteSelectedCommand(command);
        int numberOfProduct = Int32.Parse(command.Parameters["@HowManyProducts"].Value.ToString());
        howManyPages = (int)Math.Ceiling((double)numberOfProduct / (double)Configuration.ProductsPerPage);

        return dt;
    }
    public static DataTable GetAllProducts(string page, out int howManyPages)
    {

        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "GetAllProducts";
        DbParameter param;

        param = command.CreateParameter();
        param.ParameterName = "@DescriptionLenght";
        param.Value = Configuration.ProductDescriptionLenght;
        param.DbType = DbType.Int32;
        command.Parameters.Add(param);

        param = command.CreateParameter();
        param.ParameterName = "@PageNumber";
        param.Value = page;
        param.DbType = DbType.Int32;
        command.Parameters.Add(param);

        param = command.CreateParameter();
        param.ParameterName = "@ProductsPerPage";
        param.Value = Configuration.ProductsPerPage;
        param.DbType = DbType.Int32;
        command.Parameters.Add(param);

        param = command.CreateParameter();
        param.ParameterName = "@HowManyProducts";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        command.Parameters.Add(param);

        DataTable dt = DataAccess.ExecuteSelectedCommand(command);
        int numberOfProduct = Int32.Parse(command.Parameters["@HowManyProducts"].Value.ToString());
        howManyPages = (int)Math.Ceiling((double)numberOfProduct / (double)Configuration.ProductsPerPage);

        return dt;
    }
    public static ProductDetail GetOneProduct(string productID)
    {
        // Command nesnesi olustur
        DbCommand command = DataAccess.CreateCommand();
        // Prosedur Cagır
        command.CommandText = "GetOneProduct";
        // prosedur için parametre oluştur
        DbParameter param = command.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = productID;
        param.DbType = DbType.Int32;
        command.Parameters.Add(param);
        //prosedur calıştır
        DataTable dt = DataAccess.ExecuteSelectedCommand(command);

        ProductDetail product = new ProductDetail();
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            product.ProductID = Convert.ToInt32(dr["ProductID"].ToString());
            product.Name = dr["Name"].ToString();
            product.Description = dr["Description"].ToString();
            product.Price = Convert.ToDecimal(dr["Price"].ToString());
            product.Category = Convert.ToInt32(dr["Category"].ToString());
            product.Thumbnail = dr["Thumbnail"].ToString();
            product.BigImage = dr["BigImage"].ToString();
            product.TakeTime = dr["TakeTime"].ToString();
            product.isFlash = Convert.ToBoolean(dr["isFlash"].ToString());

        }
        return product;

    }
    public static DataTable GetOneProductDataTable(string productID)
    {
        // Command nesnesi olustur
        DbCommand command = DataAccess.CreateCommand();
        // Prosedur Cagır
        command.CommandText = "GetOneProduct";
        // prosedur için parametre oluştur
        DbParameter param = command.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = productID;
        param.DbType = DbType.Int32;
        command.Parameters.Add(param);
        //prosedur calıştır
        DataTable dt = DataAccess.ExecuteSelectedCommand(command);

        //ProductDetail product = new ProductDetail();
        //if (dt.Rows.Count > 0)
        //{
        //    DataRow dr = dt.Rows[0];
        //    product.ProductID = Convert.ToInt32(dr["ProductID"].ToString());
        //    product.Name = dr["Name"].ToString();
        //    product.Description = dr["Description"].ToString();
        //    product.Price = Convert.ToDecimal(dr["Price"].ToString());
        //    product.Category = Convert.ToInt32(dr["Category"].ToString());
        //    product.Similar = Convert.ToInt32(dr["Similar"].ToString());
        //    product.Thumbnail = dr["Thumbnail"].ToString();
        //    product.Image = Convert.ToInt32(dr["Image"].ToString());
        //    product.Comment = Convert.ToInt32(dr["Comment"].ToString());
        //    product.isFlash = Convert.ToBoolean(dr["isFlash"].ToString());

        //}
        //return product;

        return dt;

    }
    public static DataTable CustomersGetSliders()
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "CustomersGetSliders";
        return DataAccess.ExecuteSelectedCommand(command);
    }
    public static DataTable AdminGetSliders()
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "AdminGetSliders";
        return DataAccess.ExecuteSelectedCommand(command);
    }

    public static DataTable Search(string serachText, string allWords, string pageNumber, out int howManyPages)
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "SearchCatalog";

        DbParameter param = command.CreateParameter();
        param.ParameterName = "@DescriptionLenght";
        param.Value = Configuration.ProductDescriptionLenght;
        param.DbType = DbType.Int16;
        command.Parameters.Add(param);

        param = command.CreateParameter();
        param.ParameterName = "@AllWords";
        param.Value = allWords.ToUpper() == "TRUE" ? "1" : "0";
        param.DbType = DbType.Byte;
        command.Parameters.Add(param);

        param = command.CreateParameter();
        param.ParameterName = "@PageNumber";
        param.Value = pageNumber;
        param.DbType = DbType.Int32;
        command.Parameters.Add(param);

        param = command.CreateParameter();
        param.ParameterName = "@HowManyResults";
        param.Direction = ParameterDirection.Output;
        param.DbType = DbType.Int32;
        command.Parameters.Add(param);

        param = command.CreateParameter();
        param.ParameterName = "@ProductsPerPage";
        param.Value = Configuration.ProductsPerPage;
        param.DbType = DbType.Int32;
        command.Parameters.Add(param);



        int howManyWords = 5;
        string[] words = Regex.Split(serachText, "[^a-zA-Z0-9ğĞüÜşŞöÖçÇİ]+");

        int index = 1;
        for (int i = 0; i <= words.GetUpperBound(0) && index <= howManyWords; i++)
        {
            if (words[i].Length > 2)
            {
                param = command.CreateParameter();
                param.ParameterName = "@Word" + index.ToString();
                param.Value = words[i];
                command.Parameters.Add(param);
                index++;
            }
        }

        DataTable dt = DataAccess.ExecuteSelectedCommand(command);
        int numberOfProducts = Int32.Parse(command.Parameters["@HowManyResults"].Value.ToString());
        howManyPages = (int)Math.Ceiling((double)numberOfProducts / (double)Configuration.ProductsPerPage);

        return dt;
    }
    public static DataTable GetProductAttributeValues(string productID)
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "GetProductAttributeValues";

        DbParameter param = command.CreateParameter();
        param.ParameterName = "@ProductID";
        param.Value = productID;
        param.DbType = DbType.Int32;
        command.Parameters.Add(param);

        return DataAccess.ExecuteSelectedCommand(command);
    }
    public static BankAccounts GetBankAccount()
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "GetBankAccounts";

        BankAccounts bnk = new BankAccounts();
        DataTable dt = DataAccess.ExecuteSelectedCommand(command);

        if (dt.Rows.Count > 0)
        {
            bnk.bankName = dt.Rows[0]["Name"].ToString();
            bnk.iban = dt.Rows[0]["IBAN"].ToString();
            bnk.description = dt.Rows[0]["Description"].ToString();
            bnk.owner = dt.Rows[0]["Owner"].ToString();
        }
        return bnk;

    }
    public static DataTable GetProductRecomment(string productID)
    {
        DbCommand commad = DataAccess.CreateCommand();
        commad.CommandText = "GetProductRecomment";

        commad.Parameters.Add(NewParameter("@ProductID", productID, DbType.Int32, -1, commad));
        commad.Parameters.Add(NewParameter("@DescriptionLenght", Configuration.ProductDescriptionLenght.ToString(), DbType.Int32, -1, commad));

        return DataAccess.ExecuteSelectedCommand(commad);
    }
    public static DataTable GetProductReviews(string productID)
    {
        DbCommand commad = DataAccess.CreateCommand();
        commad.CommandText = "GetProductReviews";

        commad.Parameters.Add(NewParameter("@ProductID", productID, DbType.Int32, -1, commad));

        return DataAccess.ExecuteSelectedCommand(commad);
    }
    
    
    public static bool AddReview(string customerID, string productID, string review)
    {
        DbCommand commad = DataAccess.CreateCommand();
        commad.CommandText = "AddProductReview";

        commad.Parameters.Add(NewParameter("@CustomerID", new Guid(customerID), DbType.Guid, -1, commad));
        commad.Parameters.Add(NewParameter("@ProductID", productID, DbType.Int32, -1, commad));
        commad.Parameters.Add(NewParameter("@Review", review, DbType.String, 500, commad));

        try
        {
            return CatalogAccess.ExecuteNoneQuery(commad);
        }
        catch
        {
            return false;
        }
    }
    private static object NewParameter(string paramName, Guid paramValue, DbType dbType, int size, DbCommand cmd)
    {
        DbParameter param = cmd.CreateParameter();
        param.ParameterName = paramName;
        param.Value = paramValue;
        param.DbType = dbType;
        if (size != -1)
        {
            param.Size = size;
        }
        return param;
    }
    internal static object NewParameter(string paramName, bool paramValue, DbType dbType, int size, DbCommand cmd)
    {
        DbParameter param = cmd.CreateParameter();
        param.ParameterName = paramName;
        param.Value = paramValue;
        param.DbType = dbType;
        if (size != -1)
        {
            param.Size = size;
        }
        return param;
    }
    public static bool ExecuteNoneQuery(DbCommand command)
    {
        int result = -1;
        try
        {
            result = DataAccess.ExecuteNonQuery(command);
        }
        catch (Exception ex)
        {
            Utilities.LogError(ex);
        }
        return (result != -1);
    }
    public static void AdminProductReviewMarkVerified(string reviewID)
    {
        DbCommand cmd = DataAccess.CreateCommand();
        cmd.CommandText = "AdminProductReviewMarkVerified";

        cmd.Parameters.Add(CatalogAccess.NewParameter("@ReviewID", reviewID, DbType.Int32, -1, cmd));

        DataAccess.ExecuteNonQuery(cmd);
    }
    public static bool AdminDeleteProductReview(string reviewID)
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "AdminDeleteProductReview";

        command.Parameters.Add(NewParameter("@ReviewID", reviewID, DbType.Int32, -1, command));

        int result = -1;
        try
        {
            result = DataAccess.ExecuteNonQuery(command);
        }
        catch (Exception ex)
        {
            Utilities.LogError(ex);
        }
        return (result != -1);
    }
    public static CompanyDetails GetCompanyDetails()
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "GetCompanyDetails";

        CompanyDetails comp = new CompanyDetails();

        DataTable dt = DataAccess.ExecuteSelectedCommand(command);

        if (dt.Rows.Count > 0)
        {
            comp.siteEmail = dt.Rows[0]["SiteMail"].ToString();
            comp.siteAddress = dt.Rows[0]["SiteAddress"].ToString();
            comp.sitePhone = dt.Rows[0]["SitePhone"].ToString();
            comp.siteLogo = dt.Rows[0]["SiteLogo"].ToString();
            comp.siteName = dt.Rows[0]["SiteName"].ToString();
            comp.parag1 = dt.Rows[0]["Parag1"].ToString();
            comp.parag2 = dt.Rows[0]["Parag2"].ToString();
            comp.parag3 = dt.Rows[0]["Parag3"].ToString();
            comp.image = dt.Rows[0]["Image"].ToString();
            comp.weekDay = dt.Rows[0]["weekDay"].ToString();
            comp.weekEnd = dt.Rows[0]["weekEnd"].ToString();
            comp.fbAccount = dt.Rows[0]["fbAccount"].ToString();
            comp.twAccount = dt.Rows[0]["twAccount"].ToString();
            comp.instaAccount = dt.Rows[0]["instAccount"].ToString();
            comp.youtAccount = dt.Rows[0]["yutbAccoun"].ToString();
            comp.enlem = dt.Rows[0]["enlem"].ToString();
            comp.boylam = dt.Rows[0]["boylam"].ToString();

        }
        return comp;

    }
    public static bool UpdateCompanyDetails(string mail, string address, string phone, string logo,
        string name, string parag1, string parag2, string parag3, string image, string weekDay,
        string weekEnd, string fbAcc, string twAcc, string instAcc, string youtAcc, string enlem,
        string boylam)
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "UpdateCompanyDetails";

        command.Parameters.Add(NewParameter("@SiteMail", mail, DbType.String, 150, command));
        command.Parameters.Add(NewParameter("@SiteAddress", address, DbType.String, 150, command));
        command.Parameters.Add(NewParameter("@SitePhone", phone, DbType.String, 150, command));
        command.Parameters.Add(NewParameter("@SiteLogo", logo, DbType.String, 500, command));
        command.Parameters.Add(NewParameter("@SiteName", name, DbType.String, 150, command));
        command.Parameters.Add(NewParameter("@Parag1", parag1, DbType.String, -1, command));
        command.Parameters.Add(NewParameter("@Parag2", parag2, DbType.String, -1, command));
        command.Parameters.Add(NewParameter("@Parag3", parag3, DbType.String, -1, command));
        command.Parameters.Add(NewParameter("@Image", image, DbType.String, 500, command));
        command.Parameters.Add(NewParameter("@weekDay", weekDay, DbType.String, 150, command));
        command.Parameters.Add(NewParameter("@weekEnd", weekEnd, DbType.String, 150, command));
        command.Parameters.Add(NewParameter("@fbAccount", fbAcc, DbType.String, 500, command));
        command.Parameters.Add(NewParameter("@twAccount", twAcc, DbType.String, 500, command));
        command.Parameters.Add(NewParameter("@instAccount", instAcc, DbType.String, 500, command));
        command.Parameters.Add(NewParameter("@yutbAccount", youtAcc, DbType.String, 500, command));
        command.Parameters.Add(NewParameter("@enlem", enlem, DbType.String, -1, command));
        command.Parameters.Add(NewParameter("@boylam", boylam, DbType.String, -1, command));

        return CatalogAccess.ExecuteNoneQuery(command);

    }
    public static DataTable GetProductReviewsCustomer(string productID)
    {
        DbCommand commad = DataAccess.CreateCommand();
        commad.CommandText = "GetProductReviewsCustomer";

        commad.Parameters.Add(NewParameter("@ProductID", productID, DbType.Int32, -1, commad));

        return DataAccess.ExecuteSelectedCommand(commad);
    }
    public static DataTable GetAllMessages()
    {
        DbCommand commad = DataAccess.CreateCommand();
        commad.CommandText = "GetAllMessages";

        return DataAccess.ExecuteSelectedCommand(commad);
    }
    public static bool CustomerSendMessage(string name, string surname, string email, string subject, string image, string text)
    {
        DbCommand commad = DataAccess.CreateCommand();
        commad.CommandText = "CustomerSendMessage";

        commad.Parameters.Add(NewParameter("@Name", name, DbType.String, 50, commad));
        commad.Parameters.Add(NewParameter("@Surname", surname, DbType.String, 50, commad));
        commad.Parameters.Add(NewParameter("@Email", email, DbType.String, 50, commad));
        commad.Parameters.Add(NewParameter("@Subject", subject, DbType.String, 50, commad));
        commad.Parameters.Add(NewParameter("@Image", image, DbType.String, 500, commad));
        commad.Parameters.Add(NewParameter("@Text", text, DbType.String, 500, commad));

        try
        {
            return CatalogAccess.ExecuteNoneQuery(commad);
        }
        catch
        {
            return false;
        }

    }
    public static void AdminMarkMessageReplyed(string messageID)
    {
        DbCommand commad = DataAccess.CreateCommand();
        commad.CommandText = "AdminMarkMessageReplyed";

        commad.Parameters.Add(NewParameter("@MessageID", messageID, DbType.Int32, -1, commad));

        DataAccess.ExecuteNonQuery(commad);
    }
    public static void AdminDeleteMessage(string id)
    {
        DbCommand commad = DataAccess.CreateCommand();
        commad.CommandText = "AdminDeleteMessage";

        commad.Parameters.Add(NewParameter("@MessageID", id, DbType.Int32, -1, commad));

        DataAccess.ExecuteNonQuery(commad);
    }
    public static void AdminMarkSliderPromoFront(string sliderID)
    {
        DbCommand commad = DataAccess.CreateCommand();
        commad.CommandText = "AdminMarkSliderPromoFront";

        commad.Parameters.Add(NewParameter("@SliderID", sliderID, DbType.Int32, -1, commad));

        DataAccess.ExecuteNonQuery(commad);
    }
    public static void AdminDeleteSlider(string id)
    {
        DbCommand commad = DataAccess.CreateCommand();
        commad.CommandText = "AdminDeleteSlider";

        commad.Parameters.Add(NewParameter("@SliderID", id, DbType.Int32, -1, commad));

        DataAccess.ExecuteNonQuery(commad);
    }
    public static bool AdminAddSlider(string image, string topText, string botText)
    {
        DbCommand commad = DataAccess.CreateCommand();
        commad.CommandText = "AdminAddSlider";

        commad.Parameters.Add(NewParameter("@Image", image, DbType.String, 500, commad));
        commad.Parameters.Add(NewParameter("@TopText", topText, DbType.String, 200, commad));
        commad.Parameters.Add(NewParameter("@BotText", botText, DbType.String, 200, commad));

        try
        {
            return CatalogAccess.ExecuteNoneQuery(commad);
        }
        catch
        {
            return false;
        }
    }

    public static DataTable GetMapLocations()
    {
        DbCommand commad = DataAccess.CreateCommand();
        commad.CommandText = "GetMapLocations";

        return DataAccess.ExecuteSelectedCommand(commad);
    }
}