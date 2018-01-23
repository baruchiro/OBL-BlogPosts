using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.App_Code
{
    public static class Fetch
    {

        public const string USERS_URL = "https://jsonplaceholder.typicode.com/users";
        public const string POSTS_URL = "https://jsonplaceholder.typicode.com/posts";

        /// <summary>
        /// Fetch Users from server to our SQL DB
        /// </summary>
        /// <returns>
        /// Number of rows that changed
        /// </returns>
         private static async Task<int> FetchUsers()
        {
            List<JToken> tokens = JArray.Parse(await HttpRequestsManager.ExecuteRequestAsync(USERS_URL)).ToList();

            using (SiteDBEntities db = new SiteDBEntities())
            {
                foreach (JToken token in tokens)
                {
                    int id = (int)token["id"];
                    if (!db.Users.Any(u => u.Id == id))
                    {
                        db.Users.Add(Users.CreateUser(token));
                    }
                }

                return db.SaveChanges();
            }
        }

        /// <summary>
        /// Fetch Posts from server to our SQL DB
        /// </summary>
        /// <returns>
        /// Number of rows that changed
        /// </returns>
         private static async Task<int> FetchPosts()
        {
            List<Posts> posts = JsonConvert.DeserializeObject<List<Posts>>(await HttpRequestsManager.ExecuteRequestAsync(POSTS_URL));


            using (SiteDBEntities db = new SiteDBEntities())
            {
                foreach (Posts post in posts)
                {
                    if (!db.Posts.Any(u => u.id == post.id))
                    {
                        db.Posts.Add(post);
                    }
                }
                return db.SaveChanges();
            }
        }

        async public static Task<int> Fetching()
        {
            Trace.TraceInformation("Fetching");
            int users = await FetchUsers();
            Trace.TraceInformation("Fetched {0} Users", users);
            int posts = await FetchPosts();
            Trace.TraceInformation("Fetched {0} Posts", posts);

            return users + posts;
        }
    }
}
