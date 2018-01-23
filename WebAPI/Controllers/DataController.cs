using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.App_Code;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class DataController : ApiController
    {
        private SiteDBEntities db = new SiteDBEntities();

        public List<Users> GetPosts()
        {
            return db.Users.ToList();
        }
    }
}
