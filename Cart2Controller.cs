using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppProject1.Models;

namespace WebAppProject1.Controllers
{
    public class Cart2Controller : Controller
    {
        private WebAppProject1Context db = new WebAppProject1Context();

        // GET: Cart2
        public ActionResult Index()
        {
            return View(db.Cart2.ToList());
        }

        // GET: Cart2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart2 cart2 = db.Cart2.Find(id);
            if (cart2 == null)
            {
                return HttpNotFound();
            }
            return View(cart2);
        }

        // GET: Cart2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cart2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cart2ID,ItemID,ItemName,ItemColor,ItemSize,ItemQuantity")] Cart2 cart2)
        {
            if (ModelState.IsValid)
            {
                db.Cart2.Add(cart2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cart2);
        }

        // GET: Cart2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart2 cart2 = db.Cart2.Find(id);
            if (cart2 == null)
            {
                return HttpNotFound();
            }
            return View(cart2);
        }

        // POST: Cart2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cart2ID,ItemID,ItemName,ItemColor,ItemSize,ItemQuantity")] Cart2 cart2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cart2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cart2);
        }

        // GET: Cart2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart2 cart2 = db.Cart2.Find(id);
            if (cart2 == null)
            {
                return HttpNotFound();
            }
            return View(cart2);
        }

        // POST: Cart2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cart2 cart2 = db.Cart2.Find(id);
            db.Cart2.Remove(cart2);
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
