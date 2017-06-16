using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WimbledonWines.ViewModels;
using WimbledonWines.Models;
 

namespace WimbledonWines.Controllers
{

    [Authorize(Roles = "Admin")] //controller is accessible only by the admin
    public class ManageCustomerOrdersController : Controller
    {
        //functions of shopping cart controller: adding, removing and vieiwing items in cart. 

        ApplicationDbContext db = new ApplicationDbContext();
        // GET: ManageCustomerOrders
        public ViewResult Index()
        {
 
            /////////////////////////////////////////
            return View(db.OrderDetails.ToList());
        }

        public ViewResult Odrers()
        {

            /////////////////////////////////////////
            return View(db.Orders.ToList());
        }



    }
}