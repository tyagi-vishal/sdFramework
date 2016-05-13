using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Allevasoft
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("elmah.axd");

            routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               "elmah",
               "elmah",
               new { action = "Index", controller = "Elmah" });

            routes.MapRoute(
                "elmahdetail",
                "elmah/detail/{type}",
                new { action = "Index", controller = "Elmah", type = UrlParameter.Optional }
        );
            routes.MapRoute(
                            "elmahabout",
                            "elmah/about/{type}",
                            new { action = "Index", controller = "Elmah", type = UrlParameter.Optional }
                    );
            routes.MapRoute(
                "elmahdetailabout",
                "elmah/detail/about/{type}",
                new { action = "Index", controller = "Elmah", type = UrlParameter.Optional }
        );


        }
    }
}
