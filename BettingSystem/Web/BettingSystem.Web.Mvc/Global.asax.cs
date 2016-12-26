namespace BettingSystem.Web.Mvc
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using DataBaseUpdateService;
    using System.Threading;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Thread newThread = new Thread(s =>
            {
                DataBaseUpdateService.Start();
            });
            newThread.Start();
        }
    }
}
