using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Odev.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Product
            routes.MapRoute("Product", "urun-listesi/{categoryId}/{slug}", new { controller = "Product", action = "List", categoryId = UrlParameter.Optional });
            routes.MapRoute("ProductDetail", "urun-detay/{id}/{slug}", new { controller = "Product", action = "Detail", id = UrlParameter.Optional });
            routes.MapRoute("ProductList", "urun-listesi", new { controller = "Product", action = "List" });

            //Home
            routes.MapRoute("Home", "anasayfa", new { controller = "Home", action = "Index" });

            //Page
            routes.MapRoute("Career", "kariyer", new { controller = "Page", action = "Career" });
            routes.MapRoute("DistanceSellingAgreement", "mesafeli-satis-sozlesmesi", new { controller = "Page", action = "DistanceSellingAgreement" });
            routes.MapRoute("Kvkk", "kvkk", new { controller = "Page", action = "Kvkk" });
            routes.MapRoute("PrivacyPolicy", "gizlilik-politikasi", new { controller = "Page", action = "PrivacyPolicy" });
            routes.MapRoute("CancelReturn", "iptal-ve-iade-kosullari", new { controller = "Page", action = "CancelReturn" });
            routes.MapRoute("MembershipAgreement", "uyelik-sozlesmesi", new { controller = "Page", action = "MembershipAgreement" });

            //Blog
            routes.MapRoute("BlogList", "blogs", new { controller = "Blog", action = "Index" });
            routes.MapRoute("BlogDetail", "blog-detail/{id}/{slug}", new { controller = "Blog", action = "Detail", id = UrlParameter.Optional });

            //Default
            routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}/{slug}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, slug = UrlParameter.Optional }
            );
        }
    }
}
