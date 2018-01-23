using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using WebAPI.App_Code;

namespace WebAPI
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            Trace.TraceInformation("Hello World");

            //AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            Task.Run(async () =>
            {
                Trace.TraceInformation("Start async Task");

                while (true)
                {
                    Trace.TraceInformation("Task going to sleep");
                    await Task.Delay(TimeSpan.FromMinutes(5));
                    Trace.TraceInformation("Task request for fetching");
                    Trace.TraceInformation("Update {0} rows", await Fetch.Fetching());
                }
            });
        }
    }
}