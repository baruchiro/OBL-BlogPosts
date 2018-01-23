using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.Models;

namespace WebAPI.App_Code
{
    /// <summary>
    /// This ahould be the new dbContext for supporting testing and replace this with "FakeContext" in unit test.
    /// </summary>
    public class DataManager : SiteDBEntities, IDataManager
    {

        public IEnumerable<Users> GetUsers()
        {
            return Users;
        }
    }
}