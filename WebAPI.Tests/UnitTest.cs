using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAPI.App_Code;
using WebAPI.Controllers;
using WebAPI.Models;

namespace WebAPI.Tests
{
    [TestClass]
    public class UnitTest
    {
        string jsonResponse;
        [TestMethod]
        public void TestFetch()
        {
            jsonResponse = HttpRequestsManager.ExecuteRequestAsync(Fetch.USERS_URL).Result;
            Assert.IsTrue(jsonResponse.Length > 0 || !jsonResponse.Equals(""), "Response empty");
        }

        [TestMethod]
        public void TestFetchUsers()
        {
            /*
             * I do not write the test, it's too complicated.
             * In order to perform the test we need to replace dbContext with an interface that represents the functions we need,
             * so that we use the code.
             * And in the test we will write another class that inherits the interface and simulates data.
             * 
             * Because I've given myself time to finish the server because I need more time for the client,
             * I'll leave it that way and get back to it if I have time.
             *

            DataController controller = new DataController()
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            List<Users> users = controller.GetPosts();
            int posts = users.SelectMany(u => u.Posts).Count();
            int user = users.Count();
            */

        }
    }
}
