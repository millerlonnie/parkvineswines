
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WimbledonWines
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(null,
                "",
                new
                {
                    controller = "Home",
                    action = "ProductWines",
                    category = "Red",
                    //category = (string)null,
                    page = 1

                }
             );

            routes.MapRoute(null,
                "Page{page}",

                new { controller = "Home", action = "ProductWines", category = (string)null },

                new { page = @"\d+" }

                );

            routes.MapRoute(null,
                "{category}",
                new { controller = "Home", action = "ProductWines", page = 1 }


                );

            routes.MapRoute(null,
                "{category}/Page{page}",
                new { Controller = "Home", Action = "ProductWines" },
                new { page = @"\d+" }


                );

            routes.MapRoute(null, "{controller}/{action}");



            //////////////
            
            //routes.MapRoute(
   // "Default",
 //   "{controller}/{action}/{id}",
  //  new { controller = "Cart", action = "Index", id = "" }
//);
            

            /*
             / Lists the first page of products from all categories
            /Page2 Lists the chossen page that lists items from all catagories
            /Red ..for Red wine type...shows the first page of items from the sepcified category (in this situation, the red category)
             /Red/Page2 ..shows a specific page (in this circumstance page 2) of items form the speceifed catageory (in this case Red )
             
            */

            /* original code below that was changed:
              routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
             */

        }////////////////
    }////////////////////
}///////////////