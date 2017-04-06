using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                null,
                "",
                new { controller = "Items", action = "List", Type = (string)null, page = 1 }
            );

            routes.MapRoute(
                name: null,
                url: "Page{page}",
                defaults: new { controller = "items", action = "List", Type = (string)null },
                constraints: new { page = @"\d+" }
            );

            routes.MapRoute(
                null,
                "{genre}",
                new { controller = "items", action = "List", page = 1 }
            );

            routes.MapRoute(
                null,
                "{genre}/Page{page}",
                new { controller = "items", action = "List" },
                new { page = @"\d+" }
            );

            routes.MapRoute(
                null,
                "{controller}/{action}"
            );
        }
    }
}
