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
    public class CustOrderDetailsController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: CustOrderDetails

        public PartialViewResult _ConfirmMsg()// a partial view to inform admin of successful actions like an intem has been added to the list
        {

            return PartialView("__ConfirmMsg");
        }
        public PartialViewResult _Menu()
        {

            return PartialView("_Menu");
        }
        public ActionResult Index()
        {
            var m = db.OrderDetails.Include(winesDb => winesDb.Wine)//helps to access wines db to display wines name
                .Include(ordersDb => ordersDb.Order); // include order db to access customer names
           return View(m.ToList());
            
           // return View(db.OrderDetails.ToList());
        }

        // GET: CustOrderDetails/Details/5
        public ActionResult Details(int id)
        {
          /*  if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
           */

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            OrderDetail orderdetails = db.OrderDetails.Find(id);
            if (orderdetails == null)
            {
                return HttpNotFound();
            }

            return View(orderdetails);

             
        }


        // GET: OrderDetails/Edit/5--------------------------------------------------------------------------------------------
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           OrderDetail orderDetail = db.OrderDetails.Find(id);
           if (orderDetail == null)
            {
                return HttpNotFound();
            }
           return View(orderDetail);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderDetailId,OrderId,WineId,Quantity,UnitPrice,OrderStatus")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderDetail).State = EntityState.Modified;
                db.SaveChanges();
                TempData["message"] = string.Format("{0} has been Edited", orderDetail.OrderDetailId, true); //infrom user of changes, message displayed in partail view
                return RedirectToAction("Index");
            }
            return View(orderDetail);
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // GET: OrderDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            if (orderDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderDetail);
        }

        // POST: Wineries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderDetail orderDetail = db.OrderDetails.Find(id);
            db.OrderDetails.Remove(orderDetail);
            db.SaveChanges();
            TempData["message"] = string.Format("{0} has been Deleted", orderDetail.OrderDetailId, true); //infrom user of changes, message displayed in partail view name _AdminLayOut
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
