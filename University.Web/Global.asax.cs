using AutoMapper;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using University.BL.DTOs;

namespace University.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        internal static MapperConfiguration MapperConfiguration { get; private set; }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //AutoMapper
            MapperConfiguration = MapperConfig.MapperConfiguration();
        }
    }
}
