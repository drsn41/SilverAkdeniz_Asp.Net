using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProfileDataSource
/// </summary>
public class ProfileDataSource
{
	public ProfileDataSource()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public List<ProfileWrapper> GetData()
    {
        List<ProfileWrapper> data = new List<ProfileWrapper>();
        data.Add(new ProfileWrapper());
        return data;
    }
    public void UpdateDate(ProfileWrapper newData)
    {
        newData.UpdateProfile();
    }
}