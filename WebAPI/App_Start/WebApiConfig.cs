using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            
            //prevent XML formatter from control
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            JsonMediaTypeFormatter json = config.Formatters.JsonFormatter;
            //no get special attention to references values like "id" and "userId"
            json.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
            //and ignore loops (user.post.user)
            json.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { controller = "Data", id = RouteParameter.Optional }
            );
        }
    }
}
