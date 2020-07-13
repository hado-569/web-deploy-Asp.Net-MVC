using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Store
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
          name: "About",
          url: "about-us",
          defaults: new { controller = "About", action = "Index", id = UrlParameter.Optional },
          namespaces: new[] { "Store.Controllers" }
      );

            routes.MapRoute(
           name: "News",
           url: "tin-tuc",
           defaults: new { controller = "ContentNews", action = "News", id = UrlParameter.Optional },
           namespaces: new[] { "Store.Controllers" }
       );
            routes.MapRoute(
             name: "Category News",
             url: "tin-tuc/{metatitle}-{id}",
             defaults: new { controller = "ContentNews", action = "NewsByCategory", id = UrlParameter.Optional },
             namespaces: new[] { "Store.Controllers" }
         );
            routes.MapRoute(
              name: "News Detail",
              url: "tin-tuc-chi-tiet/{metatitle}-{newsid}",
              defaults: new { controller = "ContentNews", action = "NewsDetail", id = UrlParameter.Optional },
              namespaces: new[] { "Store.Controllers" }
          );

            routes.MapRoute(
          name: "Search",
          url: "tim-kiem",
          defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
          namespaces: new[] { "Store.Controllers" }
      );
            routes.MapRoute(
            name: "Product ",
            url: "san-pham",
            defaults: new { controller = "Product", action = "AllProduct", id = UrlParameter.Optional },
            namespaces: new[] { "Store.Controllers" }
        );


            routes.MapRoute(
             name: "Product Category",
             url: "san-pham/{metatitle}-{cateid}",
             defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
             namespaces: new[] { "Store.Controllers" }
         );

            routes.MapRoute(
               name: "Product Detail",
               url: "chi-tiet/{metatitle}-{productid}",
               defaults: new { controller = "Product", action = "ProductDetail", id = UrlParameter.Optional },
               namespaces: new[] { "Store.Controllers" }
           );
            routes.MapRoute(
               name: "Add to Cart ",
               url: "them-gio-hang",
               defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
               namespaces: new[] { "Store.Controllers" }
           );
         
            routes.MapRoute(
               name: "Cart ",
               url: "gio-hang",
               defaults: new { controller = "Cart", action = "Index", id = UrlParameter.Optional },
               namespaces: new[] { "Store.Controllers" }
           );

            routes.MapRoute(
               name: "Order ",
               url: "dat-hang",
               defaults: new { controller = "Cart", action = "OrderItem", id = UrlParameter.Optional },
               namespaces: new[] { "Store.Controllers" }
           );
            routes.MapRoute(
              name: "Order Success ",
              url: "hoan-thanh",
              defaults: new { controller = "Cart", action = "Sucess", id = UrlParameter.Optional },
              namespaces: new[] { "Store.Controllers" }
          );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces : new[] { "Store.Controllers"}
            );
        }
    }
}
