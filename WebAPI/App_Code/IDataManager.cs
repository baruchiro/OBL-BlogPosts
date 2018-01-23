using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.App_Code
{
    /// <summary>
    /// Should be replace with dbContext for the code support testing
    /// </summary>
    public interface IDataManager 
    {
        IEnumerable<Users> GetUsers();
    }
}
