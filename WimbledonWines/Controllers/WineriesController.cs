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

    [Authorize(Roles = "Admin")] //controller is accessible only by the admin
    public class WineriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public PartialViewResult _Menu()
        {

            return PartialView("_Menu");
        }
        public PartialViewResult _ConfirmMsg()// a partial view to inform admin of successful actions like an intem has been added to the list
        {

            return PartialView("__ConfirmMsg");
        }


        // GET: Wineries
        public ActionResult Index()
        {
            return View(db.Wineries.ToList());
        }

        // GET: Wineries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Winery winery = db.Wineries.Find(id);
            if (winery == null)
            {
                return HttpNotFound();
            }
            return View(winery);
        }

        // GET: Wineries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wineries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Country")] Winery winery)
        {
            if (ModelState.IsValid)
            {
                db.Wineries.Add(winery);
                db.SaveChanges();
                TempData["message"] = string.Format("{0} has been created", winery.Name, true); //can be added after db.save changes
                return RedirectToAction("Index");
            }

            return View(winery);
        }

        // GET: Wineries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Winery winery = db.Wineries.Find(id);
            if (winery == null)
            {
                return HttpNotFound();
            }
            return View(winery);
        }

        // POST: Wineries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Country")] Winery winery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(winery).State = EntityState.Modified;
                db.SaveChanges();
                TempData["message"] = string.Format("{0} has been Edited", winery.Name, true); //infrom user of changes, message displayed in partail view
                return RedirectToAction("Index");
            }
            return View(winery);
        }

        // GET: Wineries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Winery winery = db.Wineries.Find(id);
            if (winery == null)
            {
                return HttpNotFound();
            }
            return View(winery);
        }

        // POST: Wineries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Winery winery = db.Wineries.Find(id);
            db.Wineries.Remove(winery);
            db.SaveChanges();
            TempData["message"] = string.Format("{0} has been Deleted", winery.Name, true); //infrom user of changes, message displayed in partail view name _AdminLayOut
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
