using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace WebAPI.App_Code
{
    public class HttpRequestsManager
    {
         public static async Task<string> ExecuteRequestAsync(string url)
        {
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());
            return streamReader.ReadToEnd();
        }
    }
}