﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FPTBookStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            //Add new
            routes.MapRoute(
                name: "Login",
                url: "Admin/{controller}/{action}/{id}",
                defaults: new
                {
                    controler = "Login",
                    action = "Login",
                    id = UrlParameter.Optional
                }
                );
        }
    }
}
