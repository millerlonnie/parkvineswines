using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WimbledonWines.ViewModels;
using WimbledonWines.Models;

namespace WimbledonWines.ViewModels
{
    public class CustomerOrdersViewModel
    {
        //class has 2 properties a list of cart items and a decimal variable to keep the total pirce of the shopping cart items


      
      //  public List<OrderDetail> OrderDetails { get; set; }//new//////////////////////////
        public  Order  Orders { get; set; }
        public    OrderDetail  OrderDetails   { get; set; }
        public  Wine Wines { get; set; }
        public IndexViewModel IndexViewModels { get; set; }
        //------------------------------------------------------------------------------
        public object WineID { get; set; }
        public string WineName { get; set; }


    }
}