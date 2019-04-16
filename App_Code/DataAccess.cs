using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.IO;
using System.Xml;
/// <summary>
/// Summary description for DataAccess
/// </summary>
public static class DataAccess
{
    public static DataTable ExecuteSelectedCommand(DbCommand command)
    {
        DataTable dt = new DataTable();
        try
        {
            command.Connection.Open();
            DbDataReader reader = command.ExecuteReader();

            dt.Load(reader);
            reader.Close();
        }
        catch (Exception ex)
        {
            Utilities.LogError(ex);
        }
        finally
        {
            command.Connection.Close();
        }
        return dt;
    }
    public static DbCommand CreateCommand()
    {
        string providerName = Configuration.Provider;
        string connectionString = Configuration.ConnectionString;
        DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
        DbConnection con = factory.CreateConnection();
        con.ConnectionString = connectionString;
        DbCommand command = factory.CreateCommand();
        command.Connection = con;
        command.CommandType = CommandType.StoredProcedure;
        return command;

    }
    public static int ExecuteNonQuery(DbCommand command)
    {
        int affectedRows = -1;

        try
        {
            command.Connection.Open();
            affectedRows = command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Utilities.LogError(ex);
        }
        finally
        {
            command.Connection.Close();
        }
        return affectedRows;
    }
    public static string ExecuteScalar(DbCommand command)
    {
        string value = "";

        try
        {
            command.Connection.Open();
            value = command.ExecuteScalar().ToString();
        }
        catch (Exception ex)
        {
            Utilities.LogError(ex);
        }
        finally
        {
            command.Connection.Close();
        }
        return value;
    }


}




