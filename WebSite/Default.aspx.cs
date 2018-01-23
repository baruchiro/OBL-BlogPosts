using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    private Uri HOST = new Uri("http://localhost:64703");
    private List<User> users;
    private List<Post> posts;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            RegisterAsyncTask(new PageAsyncTask(RetriveData));
        }
    }

    protected async Task RetriveData()
    {
        try
        {
            users = JsonConvert.DeserializeObject<List<User>>(await HttpRequestsManager.ExecuteRequestAsync(HOST));
            Debug.WriteLine("Success");
        }
        catch (WebException ex)
        {
            //When server is down (only for our test)
            string debug = File.ReadAllText("F:\\Projects\\OBL\\WebSite\\App_LocalResources\\json.json");
            users = JsonConvert.DeserializeObject<List<User>>(debug);
            Debug.WriteLine("ERROR: " + ex.Message + "\nDo you forget to update HOST name or run the server?");
        }
        finally
        {
            posts = users.SelectMany(   //select all posts, but-
                u => u.Posts.Select(p =>p.SetUser(u))   //add user to ach post
                ).ToList();
            RepeaterPosts.DataSource = posts;
            RepeaterJS.DataSource = users;

            RepeaterPosts.DataBind();
            RepeaterJS.DataBind();

            UpdatePanelRepeater.Update();
        }
    }

    protected void UpdateTimer_Tick(object sender, EventArgs e)
    {
        Debug.WriteLine("TICK");
        RegisterAsyncTask(new PageAsyncTask(RetriveData));
    }
}