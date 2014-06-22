using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace StevesHeadlines
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("story", "{year}/{month}/{day}/{title}/",
               new { controller = "Story", action = "Details" },
               new { year = @"\d{4}", month = @"\d{2}", day = @"\d{2}"});


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Story", action = "Index", id = UrlParameter.Optional }


            );
        }
    }
}