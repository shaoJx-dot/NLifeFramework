using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            
            //文章明细自定义路由
            routes.MapRoute(
                "Topic", // 路由名称  
                "Topic/{id}", // 带有参数的 URL  
                new { controller = "Topic", action = "Index"}, // 参数默认值
                new { id = @"\d+" }
            );
            //评论分页
            routes.MapRoute(
                "TopicComment",
                "Topic/{id}/{page}",
                new { controller = "Topic", action = "Index" },
                new { id = @"\d+", page = @"\d+" }
            );

            //首页文章分页
            routes.MapRoute(
                "PageIndex",
                "{id}",
                new { controller = "Home", action = "Index" },
                new { id = @"\d+" }
            );

            //分类查询
            routes.MapRoute(
                "Category",
                "{enName}/{id}",
                new { controller = "Home", action = "Category" },
                new { enName = @"^[a-zA-Z]+$", id = @"\d+" }
            );

            routes.MapRoute(
                "CategorySearch",
                "dev{enName}",
                new { controller = "Home", action = "Category" },
                new { enName = @"^[a-zA-Z]+$" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "Web.Controllers" }
            );
        }
    }
}
