using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DreamDegenerator
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Manager", // 路由名称，这个只要保证在路由集合中唯一即可
                url: "Manager/{controller}/{action}/{id}", //路由规则,匹配以Manager开头的url
                defaults: new { controller = "ManagerLogin", action = "Login", id = UrlParameter.Optional } // 
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Visitor", action = "Index", id = UrlParameter.Optional }
            );
            
        }
    }
}