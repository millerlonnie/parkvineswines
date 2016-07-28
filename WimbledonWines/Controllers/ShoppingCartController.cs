using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WimbledonWines.ViewModels;
using WimbledonWines.Models;

namespace WimbledonWines.Controllers
{
    public class ShoppingCartController : Controller
    {
        //functions of shopping cart controller: adding, removing and vieiwing items in cart. 

        ApplicationDbContext storeDB = new ApplicationDbContext();
        //
        // GET: /ShoppingCart/
        public PartialViewResult _Menu()
        {

            return PartialView("_Menu");
        }

        public ActionResult Index()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
                
            };
            // Return the view
            return View(viewModel);
        }
        //
        // GET: /Store/AddToCart/5
       
         
        public ActionResult AddToCart(int id)
        {
            // Retrieve the album from the database


                var addedWine = storeDB.Wines
                    .Single(wine => wine.Id == id);

                // Add it to the shopping cart
                var cart = ShoppingCart.GetCart(this.HttpContext);

                cart.AddToCart(addedWine);

                // Go back to the main store page for more shopping
                //return RedirectToAction("Index");
             
             return RedirectToAction("Index","ShoppingCart");

            
            
        }
        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the wine to display confirmation
            string wineName = storeDB.Carts
                .Single(item => item.RecordId == id).Wine.WineName;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(wineName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
        //
        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}