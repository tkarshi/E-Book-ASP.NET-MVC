using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EBookPvt
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "CustomerDashboard", action = "Index", id = UrlParameter.Optional }
            );

            // Route for admin dashboard
            routes.MapRoute(
                name: "AdminDashboard",
                url: "adminDashboard/{action}/{id}",
                defaults: new { controller = "adminDashboard", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
