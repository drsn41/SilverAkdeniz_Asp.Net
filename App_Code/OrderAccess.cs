using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
/// <summary>
/// Summary description for OrderAccess
/// </summary>
public class OrderAccess
{
    public OrderAccess()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static DataTable GetOrdersByRecent(int cout)
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "AdminGetOrdersByRecent";

        command.Parameters.Add(CatalogAccess.NewParameter("@Count", cout.ToString(), DbType.Int32, -1, command));

        return DataAccess.ExecuteSelectedCommand(command);
    }
    public static DataTable GetOrdersByDate(string startDate, string endDate)
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "AdminGetOrdersByDate";

        command.Parameters.Add(CatalogAccess.NewParameter("@StartDate", startDate, DbType.Date, -1, command));
        command.Parameters.Add(CatalogAccess.NewParameter("@EndDate", endDate, DbType.Date, -1, command));


        return DataAccess.ExecuteSelectedCommand(command);
    }
    public static DataTable GetOrdersUnverifiedCanceled()
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "AdminGetOrdersUnverifiedCanceled";

        return DataAccess.ExecuteSelectedCommand(command);
    }
    public static DataTable GetOrdersVerifiedUncompleted()
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "AdminGetOrdersVerifiedUncompleted";

        return DataAccess.ExecuteSelectedCommand(command);
    }
    public static OrderIfo GetOrderInfo(string orderID)
    {
        DbCommand cmd = DataAccess.CreateCommand();
        cmd.CommandText = "AdminGetOrderInfo";

        cmd.Parameters.Add(CatalogAccess.NewParameter("@OrderID", orderID, DbType.Int32, -1, cmd));

        DataTable dt = DataAccess.ExecuteSelectedCommand(cmd);
        DataRow dr = dt.Rows[0];

        OrderIfo ord = new OrderIfo();
        ord.OrderID = Int32.Parse(dr["OrderID"].ToString());
        ord.TotalAmount = Decimal.Parse(dr["TotalAmount"].ToString());
        ord.DateCreated = dr["DateCreated"].ToString();
        ord.DateShipped = dr["DateShipped"].ToString();
        ord.Verified = bool.Parse(dr["Verified"].ToString());
        ord.Canceled = bool.Parse(dr["Canceled"].ToString());
        ord.Completed = bool.Parse(dr["Completed"].ToString());
        ord.Comments = dr["Comments"].ToString();
        ord.CustomerName = dr["CustomerName"].ToString();
        ord.CustomeEmail = dr["CustomerEmail"].ToString();
        ord.ShippingAddress = dr["ShippingAddress"].ToString();
        ord.AuthCode = dr["AuthCode"].ToString();

        return ord;
    }
    public static DataTable GetOrderDetails(string orderID)
    {
        DbCommand cmd = DataAccess.CreateCommand();
        cmd.CommandText = "AdminGetOrderDetails";

        cmd.Parameters.Add(CatalogAccess.NewParameter("@OrderID", orderID, DbType.Int32, -1, cmd));

        return DataAccess.ExecuteSelectedCommand(cmd);
    }
    public static void OrderUpdate(OrderIfo o)
    {
        DbCommand cmd = DataAccess.CreateCommand();
        cmd.CommandText = "AdminOrderUpdate";

        cmd.Parameters.Add(CatalogAccess.NewParameter("@OrderID", o.OrderID.ToString(), DbType.Int32, -1, cmd));
        cmd.Parameters.Add(CatalogAccess.NewParameter("@DateCreated", o.DateCreated, DbType.DateTime, -1, cmd));
        if (o.DateShipped.Trim() != "")
            cmd.Parameters.Add(CatalogAccess.NewParameter("@DateShipped", o.DateShipped, DbType.DateTime, -1, cmd));
        cmd.Parameters.Add(CatalogAccess.NewParameter("@Verified", o.Verified, DbType.Byte, -1, cmd));
        cmd.Parameters.Add(CatalogAccess.NewParameter("@Complated", o.Completed, DbType.Byte, -1, cmd));
        cmd.Parameters.Add(CatalogAccess.NewParameter("@Canceled", o.Canceled, DbType.Byte, -1, cmd));
        cmd.Parameters.Add(CatalogAccess.NewParameter("@Comments", o.Comments, DbType.String, -1, cmd));
        cmd.Parameters.Add(CatalogAccess.NewParameter("@CustomerName", o.CustomerName, DbType.String, -1, cmd));
        cmd.Parameters.Add(CatalogAccess.NewParameter("@ShippingAddress", o.ShippingAddress, DbType.String, -1, cmd));
        cmd.Parameters.Add(CatalogAccess.NewParameter("@CustomerEmail", o.CustomeEmail, DbType.String, -1, cmd));

        DataAccess.ExecuteNonQuery(cmd);

    }
    public static void OrderMarkVerified(string orderID)
    {
        DbCommand cmd = DataAccess.CreateCommand();
        cmd.CommandText = "AdminOrderMarkVerified";

        cmd.Parameters.Add(CatalogAccess.NewParameter("@OrderID", orderID, DbType.Int32, -1, cmd));

        DataAccess.ExecuteNonQuery(cmd);
    }
    public static void OrderMarkCompleted(string orderID)
    {
        DbCommand cmd = DataAccess.CreateCommand();
        cmd.CommandText = "AdminOrderMarkCompleted";

        cmd.Parameters.Add(CatalogAccess.NewParameter("@OrderID", orderID, DbType.Int32, -1, cmd));

        DataAccess.ExecuteNonQuery(cmd);
    }
    public static void OrderMarkCanceled(string orderID)
    {
        DbCommand cmd = DataAccess.CreateCommand();
        cmd.CommandText = "AdminOrderMarkCanceled";

        cmd.Parameters.Add(CatalogAccess.NewParameter("@OrderID", orderID, DbType.Int32, -1, cmd));

        DataAccess.ExecuteNonQuery(cmd);
    }

}
public struct OrderIfo
{
    public int OrderID { get; set; }
    public decimal TotalAmount { get; set; }
    public string DateCreated { get; set; }
    public string DateShipped { get; set; }
    public bool Verified { get; set; }
    public bool Completed { get; set; }
    public bool Canceled { get; set; }
    public string Comments { get; set; }
    public string CustomerName { get; set; }
    public string CustomeEmail { get; set; }
    public string ShippingAddress { get; set; }
    public string AuthCode { get; set; }

}