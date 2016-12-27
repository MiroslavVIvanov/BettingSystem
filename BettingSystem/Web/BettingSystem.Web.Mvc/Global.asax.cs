namespace BettingSystem.Web.Mvc
{
    using System.Threading;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using DataBaseUpdateService;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Thread newThread = new Thread(s =>
            {
                DataBaseUpdateService.Start();
            });
            newThread.Start();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
