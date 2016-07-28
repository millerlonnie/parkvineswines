using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WimbledonWines.Models;

namespace WimbledonWines.Controllers
{
    public class NavigationController : Controller
    {
        private ApplicationDbContext db;
       //navigation controller for building a navigation menu by wine/product category. 
        //it should appear on all pages  so the child action is supplied in the shared layout page

        public NavigationController(ApplicationDbContext db2)
        {
            db = db2;
        }


       
        /*

        public PartialViewResult _Menu()
        {
            IEnumerable<string> categories = db.Wines.Select(w => w.WineType.ToString()).Distinct().OrderBy(w => w);
            return PartialView(categories);
            
        }
         */
        //////////////////////////////

        
         

        
    }
}