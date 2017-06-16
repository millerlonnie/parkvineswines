using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WimbledonWines.Models;
using System.Configuration;






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

            var m = db.Wines.Include(wineriesDb => wineriesDb.Winery); //aternative  var m = db.Wines.Include(x => x.Winery); , to include winery foreign key database



            return View(m.ToList());
            // return View(db.Wines.ToList());
        }

        public ActionResult OrderByPrice()
        {
            //LINQ query: means select all wines in db.wines, order by price in ascending order. 
            //it is created as a list view
            var query = from p in db.Wines
                        orderby p.Price ascending
                        select p;

            return View(query);
        }

        public ActionResult OrderByName()
        {
            var query = from p in db.Wines
                        orderby p.WineName ascending
                        select p;

            return View(query);
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



            //   displaying winerires list

            var getWineryList = db.Wineries.ToList();
            SelectList list = new SelectList(getWineryList, "Id", "Name"); //displaying wineris in a dropdown list


            ViewBag.WineriesName = list; // ViewBag property enables you to dynamically share values from the controller to the view eg. @Html.DropDownList("WineryId", ViewBag.WineriesName as SelectList, "Please select Winery name", htmlAttributes: new { @class = "form-control" });



            return View();

           
        }

        // POST: Wines/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        //***************
        public ActionResult Create([Bind(Include = "WineName, Price, YearOfBottling, AlcoholPercentage, Description, WineType, Name, ImagePath")]Wine wine, HttpPostedFileBase ImagePath, int WineryId)
        {                        
            if (ModelState.IsValid)
            {
                // ***image upload******* 
                string FolderPath = Server.MapPath("~/" + ConfigurationManager.AppSettings["Wines_Image"]);

                if(!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }
                var fileName = "";
                if (ImagePath != null)
                {
                    fileName = DateTime.Now.ToString("ddMMMyyyyhhmmss") + "_" +  Path.GetFileName(ImagePath.FileName);
                    var path = Path.Combine(FolderPath, fileName);
                    ImagePath.SaveAs(path);
                }
                wine.ImagePath = fileName;
                // ***image upload******* 
                //***************
                var getWinerList = db.Wineries.ToList();
                SelectList list = new SelectList(getWinerList, "Id", "Name");
                wine.Winery = db.Wineries.Where(x => x.Id == WineryId).FirstOrDefault();
                wine.WineryName = wine.Winery.Name;
                ViewBag.WineriesName = list;
                //***************

                db.Wines.Add(wine);
                db.SaveChanges();
                TempData["message"] = string.Format("{0} has been created", wine.WineName, true); //can be added after db.save changes
                return RedirectToAction("Index");
            }

            ViewBag.Items = new SelectList(db.Wineries, "Id", "Name", wine.Winery.Id);

            return View(wine);
        }
        // GET: Wines/Edit/5
        public ActionResult Edit(int? id)   ///////////////////////////////////////////////////////////////////////////////////////
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //***************
            Wine wine = db.Wines.Include(i => i.Winery).Where(i => i.Id == id).FirstOrDefault();
            //***************
            if (wine == null)
            {
                return HttpNotFound();
            }

            //new code


            var getWinerList = db.Wineries.ToList();
            SelectList list = new SelectList(getWinerList, "Id", "Name", wine.Winery.Id);
            ViewBag.WineriesName = list;
            return View(wine);

            //////////////////

            // ViewBag.Items = new SelectList(db.Wineries, "Id", "Name", wine.WineryID);
            // return View(wine);
        }

        // POST: Wines/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //***************
        public ActionResult Edit([Bind(Include = "Id,WineName,Price,YearOfBottling,AlcoholPercentage,ImagePath,Description,WineType,Name")] Wine wine, int WineryId)
        {
            //***************
            var getWinerList = db.Wineries.ToList();
            SelectList list = new SelectList(getWinerList, "Id", "Name");
            wine.Winery = db.Wineries.Where(x => x.Id == WineryId).FirstOrDefault();
            wine.WineryName = wine.Winery.Name;
            ViewBag.WineriesName = list;
            //***************

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
