using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Link
/// </summary>
public static class Link
{
    private static string BuilAbsolute(string relativeUri)
    {
        Uri uri = HttpContext.Current.Request.Url;
        string app = HttpContext.Current.Request.ApplicationPath;
        if (!app.EndsWith("/"))
            app += "/";
        relativeUri = relativeUri.TrimStart('/');
        return HttpUtility.UrlPathEncode(String.Format("http://{0}:{1}{2}{3}", uri.Host, uri.Port, app, relativeUri));
    }
    public static string ToCategory(string categoryID, string page)
    {
        if (page == "1")
            return BuilAbsolute(string.Format("products.aspx?CategoryID={0}", categoryID));
        else
            return BuilAbsolute(string.Format("products.aspx?CategoryID={0}&Page={1}", categoryID, page));
    }
    public static string ToCategory(string categoryID)
    {
        return ToCategory(categoryID, "1");
    }
    public static string ToProduct(string productID)
    {
        return BuilAbsolute(string.Format("product_details.aspx?ProductID={0}", productID));
    }
    public static string ToProductImage(string fileName)
    {
        return BuilAbsolute("/ProductImages/" + fileName);
    }
    public static string ToFlash(string page)
    {
        if (page != null)
            return BuilAbsolute(string.Format("index.aspx?Page={0}", page));
        else
        {
            return BuilAbsolute(string.Format("index.aspx?Page={0}", "1"));
        }
    }

    public static string ToAllProducts(string page)
    {
        if (page != null)
            return BuilAbsolute(string.Format("products.aspx?Page={0}", page));
        else
        {
            return BuilAbsolute(string.Format("products.aspx?Page={0}", "1"));
        }
    }

    public static string ToSearch(string searchText, bool allWords, string page)
    {
        if (page == "1")
        {
            return BuilAbsolute(String.Format(
                "/search.aspx?query={0}&AllWords={1}", searchText, allWords));
        }
        else
        {
            return BuilAbsolute(String.Format(
                "/search.aspx?query={0}&AllWords={1}&Page={2}", searchText, allWords, page));
        }
    }

    public static string ToSearch(string searchText, bool allWords)
    {
        return ToSearch(searchText, allWords, "1");
    }
}