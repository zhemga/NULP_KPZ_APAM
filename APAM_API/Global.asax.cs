using Swashbuckle.Application;
using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace APAM_API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Environment.SetEnvironmentVariable("JWT_SECRET_KEY", "mymegakeydfmsakdsakldklamskdlmalmksdklaskdaksdlamsdklmaskldmaklsmdklamsdklmaksldmkalsdaskldmlasmdaslk");
            Environment.SetEnvironmentVariable("JWT_ISSUE", "http://localhost");
        }
    }
}
