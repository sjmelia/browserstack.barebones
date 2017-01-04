﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BrowserStack.Barebones
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            RouteTable.Routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            GlobalFilters.Filters.Add(new HandleErrorAttribute());
        }
    }
}
