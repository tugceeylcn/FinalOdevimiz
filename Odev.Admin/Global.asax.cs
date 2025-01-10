using Odev.Services.AutoMapper;
using System.Web.Mvc;
using System.Web.Routing;

namespace Odev.Admin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            AutoMapperConfig.Configure();
        }
    }
}
