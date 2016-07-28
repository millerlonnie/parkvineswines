using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WimbledonWines.Models;
namespace WimbledonWines.ViewModels
{
    public class ShoppingCartViewModel
    {
        //class has 2 properties a list of cart items and a decimal variable to keep the total pirce of the shopping cart items


        public List<Cart> CartItems { get; set; } //Provides methods to search, sort, and manipulate lists
        public List<OrderDetail> OrderDetails { get; set; }//new//////////////////////////
        public decimal CartTotal { get; set; }

    }
}