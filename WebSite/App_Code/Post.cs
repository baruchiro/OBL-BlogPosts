using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Post
/// </summary>
public class Post
{ 
    public int id { get; set; }
    public int userId { get; set; }
    public string title { get; set; }
    public string body { get; set; }

    public virtual User User { get; set; }

    public Post SetUser(User user)
    {
        User = user;
        return this;
    }
}
