using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for ProfileWrapper
/// </summary>
public class ProfileWrapper
{

    private string address;
    private string tckn;
    private string iban;
    private string phone;
    private string email;
    public string Address
    {
        get { return address; }
        set { address = value; }
    }
    public string Tckn
    {
        get { return tckn; }
        set { tckn = value; }
    }
    public string Iban
    {
        get { return iban; }
        set { iban = value; }
    }
    public string Phone
    {
        get { return phone; }
        set { phone = value; }
    }
    public string Email
    {
        get { return email; }
        set { email = value; }
    }
    public ProfileWrapper()
    {
        ProfileCommon profile = HttpContext.Current.Profile as ProfileCommon;
        address = profile.Address;
        tckn = profile.TCKN;
        iban = profile.IBAN;
        phone = profile.Phone;
        email = Membership.GetUser(profile.UserName).Email;

    }
    public void UpdateProfile()
    {
        ProfileCommon profile = HttpContext.Current.Profile as ProfileCommon;

        profile.Address = address;
        profile.IBAN = iban;
        profile.TCKN = tckn;
        profile.Phone = phone;
        MembershipUser user = Membership.GetUser(profile.UserName);
        user.Email = email;
        Membership.UpdateUser(user);


    }
}