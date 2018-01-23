using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public partial class Users
    {
        public static Users CreateUser(JToken token)
        {
            Users user = token.ToObject<Users>();
            user.zipcode = (string)token["address"]["zipcode"];
            user.lat = (decimal)token["address"]["geo"]["lat"];
            user.lng = (decimal)token["address"]["geo"]["lng"];

            return user;
        }
    }
}