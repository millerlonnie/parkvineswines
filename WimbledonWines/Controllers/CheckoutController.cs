using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WimbledonWines.Models;

namespace WimbledonWines.Controllers
{
     [Authorize] //means users are required to login before they can checkout
    public class CheckoutController : Controller
    {

         ApplicationDbContext storeDB = new ApplicationDbContext();

         //---------------------------------------------------------------------------------------------------------
         const string PromoCode = "FREE";  //here users check out with a promocode, it will latter be changed to paypal. 

         //--------------------------------------------------------------------------------------------------------------
        // GET: Checkout

         /*check out controller will have 2 actions AddressAndPayment (GET method)for displaying a
          form to allow the user to enter their information.

           AddressAndPayment (POST method) for validating  the input and process the order */
         public PartialViewResult _Menu()
         {

             return PartialView("_Menu");
         }

        public ActionResult AddressAndPayment() //controller action that shows the checkout out form, dosent require any model information 
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {
                //if (string.Equals(values["PromoCode"], PromoCode,
                //   StringComparison.OrdinalIgnoreCase) == false)
                //  {
                //     return View(order);
                order.Email = User.Identity.Name; //possibly change to email to match the account controller
                order.OrderDate = DateTime.Now;

                //Save Order
                storeDB.Orders.Add(order);
                storeDB.SaveChanges();
                //Process the order
                var cart = ShoppingCart.GetCart(this.HttpContext);
                cart.CreateOrder(order);

                return RedirectToAction("Complete",
                    new { id = order.OrderId });
                // }
            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }

         //
        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = storeDB.Orders.Any(
                o => o.OrderId == id &&
                o.Username == User.Identity.Name);
 
            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }

    }
}