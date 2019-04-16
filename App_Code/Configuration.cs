using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Configuration
/// </summary>
public static class Configuration
{

    private static string _Provider;
    private static string _ConnectionString;
    private readonly static int _ProductsPerPage;
    private readonly static int _ProductDescriptionLenght;
    private readonly static string _SiteName;
    static Configuration()
    {
        _Provider = ConfigurationManager.AppSettings["Provider"];
        _ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
        _ProductDescriptionLenght = Convert.ToInt32(ConfigurationManager.AppSettings["ProductDescriptionLenght"]);
        _ProductsPerPage = Convert.ToInt32(ConfigurationManager.AppSettings["ProductsPerPage"]);
        _SiteName = ConfigurationManager.AppSettings["SiteName"];

    }
    public static string Provider
    {
        get { return _Provider; }
    }
    public static string ConnectionString
    {
        get { return _ConnectionString; }
    }
    public static string MailServerHost
    {
        get { return ConfigurationManager.AppSettings["MailServerHost"]; }
    }
    public static string MailUserName
    {
        get { return ConfigurationManager.AppSettings["MailUserName"]; }
    }
    public static string MailUserPassword
    {
        get { return ConfigurationManager.AppSettings["MailUserPassword"]; }
    }
    public static int MailServerPort
    {
        get { return Convert.ToInt32(ConfigurationManager.AppSettings["MailServerPort"]); }
    }
    public static string ErrorMail
    {
        get { return ConfigurationManager.AppSettings["ErrorMail"]; }
    }
    public static string SiteName
    {
        get { return _SiteName; }
    }
    public static int ProductsPerPage
    {
        get { return _ProductsPerPage; }
    }
    public static int ProductDescriptionLenght
    {
        get { return _ProductDescriptionLenght; }
    }
    public static int CartPersistDay
    {
        get { return Convert.ToInt32(ConfigurationManager.AppSettings["CartPersistDay"].ToString()); }
    }
}