using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WimbledonWines.Models;

namespace WimbledonWines.Controllers
{
    public class PayPalController : Controller
    {
        // GET: PayPal
        [HttpGet] //Requests data from a specified resource
        public ActionResult Index()
        {

            if (Session["cart"] == null)
            {
                return RedirectToAction("ProductWines","Home");
            }

            var Is = Session["cart"] as List<Wine>;
            return View(Is);
        }

        [HttpPost] //Submits data to be processed to a specified resource
        public ActionResult GetDataPayPal()
        {
            return View();
        }



    }
}