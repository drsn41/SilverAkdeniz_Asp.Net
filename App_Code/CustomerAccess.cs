using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;


public class CustomerLibGetOrderDetailInfo
{
    public int orderID;
    public int productID;
    public string productName;
    public int qty;
    public double unitPrice;
    public string itemsAsString;

    public double Subtotal
    {
        get
        {
            return qty * unitPrice;
        }
    }
    public CustomerLibGetOrderDetailInfo(DataRow orderDetailRow)
    {
        orderID = Int32.Parse(orderDetailRow["OrderID"].ToString());
        productID = Int32.Parse(orderDetailRow["ProductID"].ToString());
        productName = orderDetailRow["ProductName"].ToString();
        qty = Int32.Parse(orderDetailRow["Qty"].ToString());
        unitPrice = Double.Parse(orderDetailRow["UnitPrice"].ToString());
        orderID = Int32.Parse(orderDetailRow["OrderID"].ToString());
        Refresh();
    }

    public void Refresh()
    {
        itemsAsString = qty.ToString() + " " + productName + ", " + unitPrice + "TL. Toplam Fiyat : " + Subtotal;
    }

}
public class CustomerLibAccess
{
    public static List<CustomerLibGetOrderDetailInfo> GetOrderDetails(string orderID)
    {
        DataTable dt = OrderAccess.GetOrderDetails(orderID);

        List<CustomerLibGetOrderDetailInfo> orderDetails = new List<CustomerLibGetOrderDetailInfo>(dt.Rows.Count);

        foreach (DataRow od in dt.Rows)
        {
            orderDetails.Add(new CustomerLibGetOrderDetailInfo(od));
        }
        return orderDetails;
    }

    public static CustomersLibOrderInfo GetOrder(string orderID)
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "CustomerLibGetOrderInfo";
        command.Parameters.Add(CatalogAccess.NewParameter("@OrderID", orderID, DbType.Int32, -1, command));

        DataTable dt = DataAccess.ExecuteSelectedCommand(command);
        DataRow dr = dt.Rows[0];

        CustomersLibOrderInfo orderInfo = new CustomersLibOrderInfo(dr);
        return orderInfo;
    }
}
public class CustomersLibOrderInfo
{
    public int orderID;
    public string dateCreated;
    public string dateShipped;
    public string comments;
    public int status;
    public string authCode;
    public string reference;

    public MembershipUser Customer;
    public ProfileCommon customerProfile;
    public double totalCost;
    public string orderAsString;
    public string customerAddress;

    public List<CustomerLibGetOrderDetailInfo> orderDetails;

    public CustomersLibOrderInfo(DataRow orderRow)
    {
        orderID = orderRow["OrderID"].ToString().Integer();
        dateCreated = orderRow["DateCreated"].ToString();
        dateShipped = orderRow["DateShipped"].ToString();
        comments = orderRow["Comments"].ToString();
        authCode = orderRow["AuthCode"].ToString();
        
        Customer = Membership.GetUser(new Guid(orderRow["CustomerID"].ToString()));
        customerProfile = (HttpContext.Current.Profile as ProfileCommon).GetProfile(Customer.UserName);
        orderDetails = CustomerLibAccess.GetOrderDetails(orderID.ToString());

        Refresh();
    }

    public void Refresh()
    {
        StringBuilder sb = new StringBuilder();
        totalCost = 0.0;

        foreach (CustomerLibGetOrderDetailInfo item in orderDetails)
        {
            sb.Append(item.itemsAsString);
            totalCost += item.Subtotal;
        }
        sb.AppendLine();
        sb.Append("Toplam Sipariş Ücreti : " + totalCost.ToString() + " TL");
        orderAsString = sb.ToString();

        sb = new StringBuilder();
        sb.AppendLine(Customer.UserName);
        sb.AppendLine(customerProfile.Address);

        if (customerProfile.Address != "")
        {
            sb.Append(customerProfile.Address);
        }
        sb.Append(customerProfile.IBAN);
        sb.Append(customerProfile.TCKN);
        sb.Append(customerProfile.Phone);
    }

}