using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.App_Code;
using WebAPI.Models;

namespace WebAPI.Tests
{
    class FakeDBContext : IDataManager
    {
        public IEnumerable<Users> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}
