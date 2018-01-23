using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;


public static class HttpRequestsManager
{
     public static async Task<string> ExecuteRequestAsync(Uri url)
    {
        HttpWebRequest request = WebRequest.CreateHttp(url);
        HttpWebResponse response = (HttpWebResponse) await request.GetResponseAsync();
        StreamReader streamReader = new StreamReader(response.GetResponseStream());
        return streamReader.ReadToEnd();
    }
}