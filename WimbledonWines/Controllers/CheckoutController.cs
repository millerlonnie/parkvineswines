using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WimbledonWines.Models;

namespace WimbledonWines.Controllers
{
     [Authorize] //means users are required to login before they can checkout
    public class CheckoutController : Controller
    {

         ApplicationDbContext db = new ApplicationDbContext();

        

         /*the check out controller must have 2 actions namely AddressAndPayment  a (GET method)for showing a
          form to enable the customers  to enter their information.

           the AddressAndPayment (POST method) validates  inputs and processes orders */
         public PartialViewResult _Menu()
         {

             return PartialView("_Menu");
         }

        public ActionResult AddressAndPayment(string msg) //controller action that shows the checkout out form, dosent require any model information 
        {
            if(!string.IsNullOrEmpty(msg))
            {
                ViewBag.message = msg;
            }
            return View();
        }

        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);

            try
            {
               
              
                order.Email = User.Identity.Name; //for identify user by email
                order.OrderDate = DateTime.Now;

                order.PaymentType = "PayPal";
                order.PaypalStatus = false;

                //this save the customer's order to the database
                db.Orders.Add(order);
                db.SaveChanges();
                //this processes the customer's order
                var cart = ShoppingCart.GetCart(this.HttpContext);
                cart.CreateOrder(order);

                //assign sessions to customer's shopping cart & order + link them to PayPal
                HttpContext.Session["PayPal_Order"] = order;
                HttpContext.Session["PayPal_Cart"] = cart.GetCartItems();

                //redirect to paypal process page
                return RedirectToAction("ProcessPaypal");
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
            Order order =  db.Orders.Where(
                o => o.OrderId == id &&
                      o.Email == User.Identity.Name).FirstOrDefault();
              // o.Email == User.Identity.Name;

            if (order != null)
            {
                return View(order);
            }
            else
            {
                return View("Error");
            }
        }

         //////////////////////////////////////////PayPalSection///////////////////////////////////////////////////////

        

         public ActionResult ProcessPaypal()
         {            
             if(HttpContext.Session["PayPal_Order"]  != null &&   HttpContext.Session["PayPal_Cart"] != null)
             {
                 PaypalProcessViewModel model = new PaypalProcessViewModel();
                 model.order = (Order)HttpContext.Session["PayPal_Order"];        //transfer cust order details to PayPal
                 model.lst_cart = (List<Cart>)HttpContext.Session["PayPal_Cart"];  //transfer all shopping cart contents to PayPal
                 string paypal_code = Guid.NewGuid().ToString();
                 HttpContext.Session["PayPal_Code"] = paypal_code;
                 model.Invoice_id = DateTime.Now.ToString("ddMMyyyyhhmmss") + "_" + model.order.OrderId;
                 HttpContext.Session["PayPal_Invoice_id"] = model.Invoice_id;
                 model.paypal_email = ConfigurationManager.AppSettings["PayPal_Email"].ToString();
                 model.currency_code = ConfigurationManager.AppSettings["PayPal_Currency"].ToString();
                 model.language_code = ConfigurationManager.AppSettings["PayPal_Language_Code"].ToString();
                 model.return_url = ConfigurationManager.AppSettings["PayPal_Return_url"].ToString() + paypal_code;
                 model.cancel_url = ConfigurationManager.AppSettings["PayPal_Cancel_url"].ToString() + paypal_code;
                 return View(model);
             }
             return RedirectToAction("Index", "ShoppingCart");
         }
         public ActionResult PayPalVerification(bool status, string code)
         {
             if (HttpContext.Session["PayPal_Code"] != null && HttpContext.Session["PayPal_Order"] != null && HttpContext.Session["PayPal_Invoice_id"] != null && HttpContext.Session["PayPal_Code"].ToString() == code)
             {
                 string paypal_invoice_id = HttpContext.Session["PayPal_Invoice_id"].ToString();
                 Order order_session = (Order)HttpContext.Session["PayPal_Order"];

                 Order order = db.Orders.Where(x => x.OrderId == order_session.OrderId).FirstOrDefault();
                 if(status)
                 {
                     order.PaypalStatus = true;
                     order.Paypal_Response = "Payment done for invoice : " + paypal_invoice_id + ". paypal_code : " + code;
                 }
                 else
                 {
                     order.PaypalStatus = false;
                     order.Paypal_Response = "Paypal return payment status fail for invoice : " + ". paypal_code : " + code;
                 }
                  db.SaveChanges();
                 var cart = ShoppingCart.GetCart(this.HttpContext);

                 if (status)
                 {
                     cart.EmptyCart();
                     HttpContext.Session.Remove("PayPal_Code");
                     HttpContext.Session.Remove("PayPal_Order");
                     HttpContext.Session.Remove("PayPal_Cart");
                     HttpContext.Session.Remove("PayPal_Invoice_id");
                     return RedirectToAction("Complete", "Checkout", new { id = order.OrderId });
                 }
                 else
                 {
                     return RedirectToAction("AddressAndPayment", "Checkout", new { msg = "Paypal return fail payment status for invoice : " + paypal_invoice_id + ".Try again or contact administrator." }); 
                 }
             }
             return RedirectToAction("AddressAndPayment", "Checkout", new { msg = "Paypal return payment status" + (status == true ? "Complete" : "fail") + ". You session is expire so you order not successfully update at our system. Please contact administrator." }); 
         }



////////////////////////////////////////////////////PayPalSection///////////////////////////////////////////////////////

    }
}