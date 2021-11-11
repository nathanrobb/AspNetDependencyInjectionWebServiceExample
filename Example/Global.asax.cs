using System;
using System.Diagnostics;
using System.Web;
using System.Web.Http;
using Example.App_Data;

namespace Example
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(c =>
            {
                c.MapHttpAttributeRoutes();
            });
        }

        protected void Application_BeginRequest()
        {
            var o = AppStartDependencyInjection.GetService<TestObject>();
            Debugger.Log(1, "log", $"Global [{o.Get()}]{Environment.NewLine}");
        }
    }
}
