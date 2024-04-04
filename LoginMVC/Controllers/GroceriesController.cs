using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LoginMVC.Models;

namespace LoginMVC.Controllers
{
    public class GroceriesController : Controller
    {
        private UserdataEntities db = new UserdataEntities();

        // GET: Groceries
        public ActionResult Index()
        {
            if (AccountController.isLoggedIn == false || AccountController.isAdmin == false)
            {
                return HttpNotFound();
            }
            return View(db.Groceries.ToList());
        }
        public ActionResult UserView()
        {
            if (AccountController.isLoggedIn == false || AccountController.isUser == false)
                return HttpNotFound();
            return View(db.Groceries.ToList());

        }

        // GET: Groceries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grocery grocery = db.Groceries.Find(id);
            if (grocery == null)
            {
                return HttpNotFound();
            }
            return View(grocery);
        }

        // GET: Groceries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Groceries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroceryId,Name,Description,Price,Discount,Category,Quantity")] Grocery grocery)
        {
            if (ModelState.IsValid)
            {
                db.Groceries.Add(grocery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(grocery);
        }

        // GET: Groceries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grocery grocery = db.Groceries.Find(id);
            if (grocery == null)
            {
                return HttpNotFound();
            }
            return View(grocery);
        }

        // POST: Groceries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroceryId,Name,Description,Price,Discount,Category,Quantity")] Grocery grocery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(grocery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(grocery);
        }

        // GET: Groceries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grocery grocery = db.Groceries.Find(id);
            if (grocery == null)
            {
                return HttpNotFound();
            }
            return View(grocery);
        }

        // POST: Groceries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Grocery grocery = db.Groceries.Find(id);
            db.Groceries.Remove(grocery);
            db.SaveChanges();
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
