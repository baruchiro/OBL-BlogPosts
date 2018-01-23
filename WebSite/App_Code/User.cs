using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for User
/// </summary>
public class User
{ 

    public int Id { get; set; }
    public string name { get; set; }
    public string username { get; set; }
    public string zipcode { get; set; }
    public string phone { get; set; }
    public decimal lat { get; set; }
    public decimal lng { get; set; }

    public virtual ICollection<Post> Posts { get; set; }
}