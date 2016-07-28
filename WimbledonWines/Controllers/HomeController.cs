﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WimbledonWines.Models;
using PagedList;
 

 
using Ninject;
using WimbledonWines.ViewModels;


namespace WimbledonWines.Controllers
{
    public class HomeController : Controller
    {

       // private ApplicationDbContext respository;
        private ApplicationDbContext db = new ApplicationDbContext();
        public int PageSize = 2; // adding pagnation of  5 items per page.

        /*
        public HomeController(ApplicationDbContext productRespository)
        {
            this.respository = productRespository;
        }

         */

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact page.";

            return View();
        }

        public PartialViewResult _initialPartial()
        {

            return PartialView("_initialPartial");
        }

        
        public PartialViewResult _Menu()
        {

            return PartialView("_Menu");
        }

        
 
        public ActionResult ProductWines( string category, int page = 1  )
        {
            //passing a ProductsListviewModel object as the model data to the view

            //return View(db.Wines.ToList().OrderBy(m => m.Price).Skip((page-1)*PageSize).Take(PageSize));

           // return View(respository.Wines.OrderBy(m => m.Price).Skip((page - 1) * PageSize).Take(PageSize));



            ProductsListViewModel model = new ProductsListViewModel
           {
               
               Wines = db.Wines
              .Where(w => w.WineType.ToString() == category) //enables filtering products by catagory of winetype
               .OrderBy(w =>w.Price)
               .Skip((page -1) * PageSize)
               .Take(PageSize).ToList(),
               
               PagingInfo = new PagingInfo
               {
                   CurrentPage = page,
                   ItemsPerPage = PageSize,
                   TotalItems = db.Wines.Count()

               },
               CurrentCategory = category
           };
            return View(model);

               }



        ////////////////////////////////////////////////////////////////////////////////////

        


        //////////////////////////////////////////////////////////////////////////////////////

           }
             
        }

       
        
       
       
             

       
        

    