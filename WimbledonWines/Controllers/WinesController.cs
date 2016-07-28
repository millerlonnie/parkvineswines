using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WimbledonWines.Models;
 



 


namespace WimbledonWines.Controllers
{



    [Authorize(Roles = "Admin")] //controller is accessible only by the admin role
    public class WinesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public PartialViewResult _ConfirmMsg()// a partial view to inform admin of successful actions like an intem has been added to the list
        {

            return PartialView("__ConfirmMsg");
        }
        public PartialViewResult _Menu()
        {

            return PartialView("_Menu");
        }
        // GET: Wines
        public ActionResult Index()
        {
           
            var m = db.Wines.Include(w=>w.Winery);
            return View( m.ToList());
           // return View(db.Wines.ToList());
        }

        // GET: Wines/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wine wine = db.Wines.Find(id);
            if (wine == null)
            {
                return HttpNotFound();
            }
            return View(wine);
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // GET: Wines/Create
        public ActionResult Create()
        {

              

           // new working displaying winerires list
          
         var getWinerList = db.Wineries.ToList();
          SelectList list = new SelectList(getWinerList, "Id", "Name");
          

          ViewBag.WineriesName = list;
             
          
              
          return View();

          //  new working ^^^^displaying winerires list


          //  ViewBag.Items = new SelectList(db.Wineries, "Id", "Name");
           
           //return View();
        }

        // POST: Wines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WineName, Price, YearOfBottling, AlcoholPercentage, Description, WineType, Name, ImagePath  ")]Wine wine, HttpPostedFileBase upload)
        {
           

            if(ModelState.IsValid)
            {



                db.Wines.Add(wine);
                db.SaveChanges();
                TempData["message"] = string.Format("{0} has been created", wine.WineName, true); //can be added after db.save changes
                return RedirectToAction("Index");
            }
            
            ViewBag.Items = new SelectList(db.Wineries, "Id", "Name", wine.Name);
           
            return View(wine);
        }
        // GET: Wines/Edit/5
        public ActionResult Edit(int? id)   ///////////////////////////////////////////////////////////////////////////////////////
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wine wine = db.Wines.Find(id);
            if (wine == null)
            {
                return HttpNotFound();
            }

            //new code
             
           
           var getWinerList = db.Wineries.ToList();
           SelectList list = new SelectList(getWinerList, "Id", "Name");
           ViewBag.WineriesName = list;
           return View();

            //////////////////

           // ViewBag.Items = new SelectList(db.Wineries, "Id", "Name", wine.WineryID);
           // return View(wine);
        }

        // POST: Wines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,WineName,Price,YearOfBottling,AlcoholPercentage,ImagePath,Description,WineType,Name")] Wine wine)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wine).State = EntityState.Modified;
                db.SaveChanges();
                TempData["message"] = string.Format("{0} has been edited", wine.WineName, true); //informing that wine has been created with the help of a prtail view thaht uses bootstrap classes
                return RedirectToAction("Index");
            }
            return View(wine);
        }

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // GET: Wines/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wine wine = db.Wines.Find(id);
            if (wine == null)
            {
                return HttpNotFound();
            }
            return View(wine);
        }

        // POST: Wines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wine wine = db.Wines.Find(id);
            db.Wines.Remove(wine);
            db.SaveChanges();
            TempData["message"] = string.Format("{0} has been deleted", wine.WineName, true); //informing that wine has been created with the help of a prtail view thaht uses bootstrap classes
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
