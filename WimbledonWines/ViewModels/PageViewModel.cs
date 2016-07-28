using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WimbledonWines.Models;
namespace WimbledonWines.ViewModels
{
    public class PageViewModel
    {
        //class has 2 properties a list of cart items and a decimal variable to keep the total pirce of the shopping cart items


        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }//eneables to group products by category or type


    }
}