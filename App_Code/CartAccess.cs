using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data;
using System.Web.Security;
/// <summary>
/// Summary description for CartAccess
/// </summary>
public class CartAccess
{
    public CartAccess()
    {
        // 
        // TODO: Add constructor logic here
        //
    }
    public static string cartID
    {
        get
        {
            HttpContext context = HttpContext.Current;
            string cartID = "";

            if (context.Request.Cookies["AkdenizSilver_CartId"] != null)
            {
                return context.Request.Cookies["AkdenizSilver_CartId"].Value;
            }
            else
            {
                cartID = Guid.NewGuid().ToString();
                HttpCookie cookie = new HttpCookie("AkdenizSilver_CartId", cartID);

                int howManyDays = Configuration.CartPersistDay;

                DateTime currDate = DateTime.Now;
                TimeSpan timeSpan = new TimeSpan(howManyDays, 0, 0, 0);
                DateTime expDate = currDate.Add(timeSpan);

                context.Response.Cookies.Add(cookie);
                return cartID.ToString();
            }
        }
    }
    public static bool AddItem(string productID, string attributes)
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "CartAddItem";

        command.Parameters.Add(CatalogAccess.NewParameter("@CartID", cartID, DbType.String, 36, command));
        command.Parameters.Add(CatalogAccess.NewParameter("@ProductID", productID, DbType.Int32, -1, command));
        command.Parameters.Add(CatalogAccess.NewParameter("@Attributes", attributes, DbType.String, -1, command));

        return CatalogAccess.ExecuteNoneQuery(command);
    }
    public static bool UpdateItem(string productID, int amount)
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "CartUpdateItem";

        command.Parameters.Add(CatalogAccess.NewParameter("@CartID", cartID, DbType.String, 36, command));
        command.Parameters.Add(CatalogAccess.NewParameter("@ProductID", productID, DbType.Int32, -1, command));
        command.Parameters.Add(CatalogAccess.NewParameter("@Amount", amount.ToString(), DbType.Int32, -1, command));

        return CatalogAccess.ExecuteNoneQuery(command);
    }
    public static bool RemoveItem(string productID)
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "CartRemoveItem";

        command.Parameters.Add(CatalogAccess.NewParameter("@CartID", cartID, DbType.String, 36, command));
        command.Parameters.Add(CatalogAccess.NewParameter("@ProductID", productID, DbType.Int32, -1, command));

        return CatalogAccess.ExecuteNoneQuery(command);
    }
    public static DataTable GetItems()
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "CartGetItems";

        command.Parameters.Add(CatalogAccess.NewParameter("@CartID", cartID, DbType.String, 36, command));

        return DataAccess.ExecuteSelectedCommand(command);
    }
    public static decimal GetTotalAmount()
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "CartGetTotalAmount";

        command.Parameters.Add(CatalogAccess.NewParameter("@CartID", cartID, DbType.String, 36, command));

        return Convert.ToDecimal(DataAccess.ExecuteScalar(command));
    }
    public static int CountOldCarts(byte days)
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "CountOldCarts";

        command.Parameters.Add(CatalogAccess.NewParameter("@Days", days.ToString(), DbType.Byte, -1, command));

        try
        {
            return Byte.Parse(DataAccess.ExecuteScalar(command));
        }
        catch (Exception)
        {
            return -1;
        }
    }
    public static bool DeleteOldCarts(byte days)
    {
        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "DeleteOldCarts";

        command.Parameters.Add(CatalogAccess.NewParameter("@Days", days.ToString(), DbType.Byte, -1, command));

        try
        {
            return CatalogAccess.ExecuteNoneQuery(command);
        }
        catch (Exception)
        {
            return false;
        }
    }
    public static string CreateCustomerOrder()
    {

        DbCommand command = DataAccess.CreateCommand();
        command.CommandText = "CreateCustomerOrder";
        command.Parameters.Add(CatalogAccess.NewParameter("@CartID", cartID, DbType.String, 36, command));
        command.Parameters.Add(CatalogAccess.NewParameter("@CustomerID", Membership.GetUser(HttpContext.Current.User.Identity.Name).ProviderUserKey.ToString(), DbType.String, 36, command));
        command.Parameters.Add(CatalogAccess.NewParameter("@CustomerName", Membership.GetUser(HttpContext.Current.User.Identity.Name).ToString(), DbType.String, 150, command));
        command.Parameters.Add(CatalogAccess.NewParameter("@CustomerEmail", Membership.GetUser(HttpContext.Current.User.Identity.Name).Email.ToString(), DbType.String, 150, command));
        command.Parameters.Add(CatalogAccess.NewParameter("@ShippingAddress", (HttpContext.Current.Profile as ProfileCommon).Address.ToString(), DbType.String, 500, command));
        command.Parameters.Add(CatalogAccess.NewParameter("@AuthCode", cartID, DbType.String, -1, command));


        return DataAccess.ExecuteScalar(command);
    }
    public static DataTable GetCartRecomment()
    {
        DbCommand commad = DataAccess.CreateCommand();
        commad.CommandText = "GetCartRecomment";

        commad.Parameters.Add(CatalogAccess.NewParameter("@CartID", cartID, DbType.String, 36, commad));
        commad.Parameters.Add(CatalogAccess.NewParameter("@DescriptionLenght", Configuration.ProductDescriptionLenght.ToString(), DbType.Int32, -1, commad));

        return DataAccess.ExecuteSelectedCommand(commad);

    }

    //public static void AddItem2(string productID)
    //{
    //    ProductDetail p = new ProductDetail();
    //    p = CatalogAccess.GetOneProduct(productID);
    //    Ekle(p.ProductID, p.Name, 1, Convert.ToDouble(p.Price));
    //}
    //public static void Ekle(int id, string isim, int adet, double fiyat)
    //{
    //    try
    //    {
    //        DataTable dt = new DataTable(); // sepeti tutacağımız bir datatable oluşturuyoruz
    //        if (HttpContext.Current.Session["sepet"] != null)//daha önceden sepet oluşturulmuş mu diye sessiona bakıyoruz
    //        {
    //            dt = (DataTable)HttpContext.Current.Session["sepet"];//session varsa  sessionu datatbale ye cast edip datatablemizi elde ediyoruz
    //        }
    //        else//session yok ise yani sepet daha önce oluşturulup sessiona atılmamış ise dataTableyi oluşturuyoruz
    //        {
    //            dt.Columns.Add("id");// DataTableye id colonunu ekliyoruz
    //            dt.Columns.Add("isim");//DataTableye isim colonunu ekliyoruz
    //            dt.Columns.Add("fiyat");//DataTableye fiyat colonunu ekliyoruz
    //            dt.Columns.Add("adet");//DataTableye adet colonunu ekliyoruz
    //            dt.Columns.Add("tutar");//DataTableye tutar colonunu ekliyoruz
    //        }

    //        bool varmi = Kontrol(id.ToString());//Kontrol adındaki methoda gelen id  değerini gönderiyoruz
    //        // böylece aynı id ye sahip ürün daha önce eklendiyse aynı ürünü birdaha eklemek yerine sadece ürünnün sepeteki adetini artıracağız
    //        // Kontrol methodu ürün varsa true yoks false değer döndürüyor
    //        if (varmi == false)//ürün daha önce eklenmemiş ise            
    //        {

    //            DataRow drow = dt.NewRow();//yeni bir row (satır) oluşturuluyor.
    //            drow["id"] = id;//satırın id colonuna gelen id yazılıyor.
    //            drow["isim"] = isim;//satırın isim colonuna gelen isim yazılıyor.
    //            drow["fiyat"] = fiyat;//satırın fiyat colonuna gelen fiyat yazılıyor.
    //            drow["adet"] = adet;//satırın adet colonuna gelen adet yazılıyor.
    //            drow["tutar"] = (fiyat * adet).ToString();//satırın tutar alanına gelen fiyat ile adet çarpımı  yazılıyor.
    //            dt.Rows.Add(drow);//oluşturulan satır tabloya ekleniyor. 
    //        }

    //        else//eğer ürün tabloya daha önce eklenmiş ise
    //        {
    //            Artir(id, 1, fiyat);//Artir methoduna gelen id fiyat ve adet değerleri gönderiliyor. Fiyata gerek yok aslında ama neyse :)
    //            //artir metoduna giddip bakalım şimdi
    //        }
    //        HttpContext.Current.Session["sepet"] = dt;//en son olarak olşturulan DataTable nin sayfa postback olduğunda kaybolmaması için
    //        // sessiona atılıyor. artık birdaki sefere session olduğu için tablo bu sessiondan alınıp üzerine yazılcak
    //    }
    //    catch
    //    {
    //    }

    //}
    //public static double SepetToplam()
    //{
    //    double toplam = 0;//toplam değişkeni tanımlanıyor
    //    if (HttpContext.Current.Session["sepet"] != null)//sessiomn kontolü yapılıyor
    //    {
    //        DataTable dt = new DataTable();//tablo oluşturuluyor
    //        dt = (DataTable)HttpContext.Current.Session["sepet"];//sessiondaki sepet alınıyor tabloya aktarılıyor
    //        for (int i = 0; i < dt.Rows.Count; i++)//yine tablonun tüm alanlarında dönecek döngü başlatılıyor
    //        {
    //            toplam += Convert.ToDouble(dt.Rows[i]["tutar"].ToString());//her satırdaki tutar miktarı toplam değişkenine aktarılıyor
    //        }
    //    }
    //    return toplam; //toplam değeri döndürülüyor.

    //}
    //public static void Sil(string id)//silinecek olan ürünün id değeri alınıyor
    //{
    //    DataTable dt = new DataTable();//tablo örneği oluşturuluyor
    //    if (HttpContext.Current.Session["sepet"] != null)//sessin  kontrolü yapılıyor
    //    {
    //        dt = (DataTable)HttpContext.Current.Session["sepet"];//sessiondaki tablo alınıyor
    //        for (int i = 0; i < dt.Rows.Count; i++)//tablonun satır sayısı kadar yine bir döngü oluşturuluyor
    //        {
    //            if (dt.Rows[i]["id"].ToString() == id)//o naki satırın id alanı ile gelen id alanı eşit ise
    //            {
    //                dt.Rows[i].Delete();//tablonun o satırı siliniyor. 
    //                HttpContext.Current.Session["sepet"] = dt;//tablonun son hali sessiona aktarılıyor
    //                break;//dögüden çıkılıyor
    //            }
    //        }
    //    }
    //}
    //private static bool Kontrol(string id)//gelen ürün id si alınıyor
    //{
    //    bool r = false;//dönüş değeri tanımlanıyor
    //    DataTable dt = new DataTable();//tablo luşturutuluyor
    //    if (HttpContext.Current.Session["sepet"] != null)//session boş değilse işleme başlanıyor
    //    {
    //        dt = (DataTable)HttpContext.Current.Session["sepet"];//sessiondaki bilgiler tabloya alınıyor

    //        for (int i = 0; i < dt.Rows.Count; i++)//tablonun içindeki satırlara tek tek dönügü ile bakıloyor
    //        {
    //            if (dt.Rows[i]["id"].ToString() == id)//eğer o anki satırın id alanı ile gelen id alanı eşit ise
    //            {
    //                r = true;// dömüş değeri true yapılıyor ve dmngüden çıkılıyor.
    //                break;
    //            }
    //        }
    //    }
    //    return r;//geri değer dönürülüyor ürün varsa true yoksa false dönecek

    //}
    //private static void Artir(int id, int adet, double fiyat)//değerler alınıyor
    //{
    //    try
    //    {
    //        DataTable dt = new DataTable();//tablo oluşturuluyor
    //        dt = (DataTable)HttpContext.Current.Session["sepet"];//sessiondaki tablo alınıyor
    //        for (int i = 0; i < dt.Rows.Count; i++)//tablonun tüm satırlarında dönülüyor
    //        {
    //            if (dt.Rows[i]["id"].ToString() == id.ToString())//eğer gelen id ile o anki satırın id değeri eşit ise
    //            {
    //                int adet1 = Convert.ToInt32(dt.Rows[i]["adet"].ToString());//o anfdaki ürün adeti geçici bir değişkene atanıyor
    //                adet1 += adet;//eski adete yeni gelen adet ekleniyor.
    //                dt.Rows[i]["adet"] = adet1.ToString();//ve o tablonun adet alanına toplam adet ekleniyor
    //                double tutar1 = Convert.ToDouble(dt.Rows[i]["tutar"].ToString());//tutar alanı geçici değişkene atanıyor.
    //                tutar1 = (adet * Convert.ToDouble(dt.Rows[i]["fiyat"])) + tutar1;//yeni tutar yeni adete göre hesaplanıyor
    //                dt.Rows[i]["tutar"] = tutar1.ToString();//yeni tutar tabloya ekleniyor
    //                HttpContext.Current.Session["sepet"] = dt;//tablonun son hali sessiona atılıyor
    //                break;//döngüden çıkılıyor.
    //            }
    //        }
    //    }
    //    catch
    //    {
    //    }
    //}
    //public static DataTable SepetGetir()
    //{
    //    if (HttpContext.Current.Session["sepet"] != null)
    //    {
    //        DataTable dt = new DataTable();
    //        dt = (DataTable)HttpContext.Current.Session["sepet"];
    //        return dt;
    //    }
    //    return null;
    //}
    ////protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    ////{
    ////    if (e.CommandName.ToString() == "sil")//command name sil ise
    ////    {
    ////        Sil(e.CommandArgument.ToString());//yazdığımız sil methoduna o anki ürünün id değerini gönderiyoruz
    ////        SepetGetir();// sepetin son halini birdaha ekrana getiriyoruz
    ////    }
    ////}
}