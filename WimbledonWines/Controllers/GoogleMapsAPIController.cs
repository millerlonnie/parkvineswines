using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WimbledonWines.Models;

namespace WimbledonWines.Controllers
{
    public class GoogleMapsAPIController : Controller
    {
       

        
        // GET: GoogleMapsAPI

        //Index - for return view  where I will show google map

        public ActionResult Index()
        {
            return View();
        }

        //2. Get All Location - for fetch all the location database and show in the view

        //public JsonResult GetAllLocation() //Use JsonResult when you want to return raw JSON data to be consumed by a client (javascript on a web page or a mobile client).
        //{

        //    using (ApplicationDbContext db = new ApplicationDbContext())
        //    {
        //        var v = db.GoogleLocations.OrderBy(a => a.Title).ToList();
        //        return new JsonResult { Data = v, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //    }

        //}

        ////3. GetMarkerInfo -for fetch location details ftom database for show marker in the map

        //public JsonResult GetMarkerInfo(int locationId)
        //{
        //    using (ApplicationDbContext db = new ApplicationDbContext())
        //    {
        //        GoogleLocation loc = null;
        //        loc = db.GoogleLocations.Where(a => a.LocationID.Equals(locationId)).FirstOrDefault();
        //        return new JsonResult { Data = loc, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        //    }

        //}
          
    }
         
}