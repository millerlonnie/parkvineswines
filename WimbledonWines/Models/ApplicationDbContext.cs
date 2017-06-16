using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
using WimbledonWines.Models;
using WimbledonWines.WebUI.Infrastructure;
using WimbledonWines.WebUI;
using WimbledonWines.HtmlHelpers;
using WimbledonWines.Controllers;
using WimbledonWines.Abstract;
using WimbledonWines.Infrastructure;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WimbledonWines.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> //Db conetxt It is a bridge between your domain or 
        //entity classes and the database. DbContext is the primary class that is
        //responsible for interacting with data as object. ..class name is used instead of 
    //ApplicationDbConext at the top of the class. in this case its:  ProductsListViewModel storeDB = new ProductsListViewModel();
    {
        public ApplicationDbContext()
             
        {
        }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public DbSet<Wine> MyWines { get; set; } ///
        public DbSet<Wine> Wines { get; set; }
        public DbSet<Winery> Wineries { get; set; }
        //public DbSet<Wine> Wines { get;set; }
        
         public DbSet<Cart>       Carts { get; set; }
       public DbSet<Order>       Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        
       // public DbSet<Location> Locations { get; set; } //for google maps API
       //public ICollection<CartItem> ShoppingCartItems { get; set; }
///---------------------------------------------------------------------------------------------------------------------
         
        
    }//////////////////////

     


}//////////////////////////////////////
