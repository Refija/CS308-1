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
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ProductsController ()
        {
            
        }

        // GET: Products
        public ActionResult Index(string searchString, string product)
        {
            var products = from b in db.Products
                           select b;
            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(b => b.PTitle.Contains(searchString) || b.PColor == searchString);
            }
            //var productsList = new List<string>();
            // var getProducts = from m in db.Products
            //select m.PCategory;

            // productsList.AddRange(getProducts.Distinct());
            // ViewBag.products = new SelectList(productsList);
            //if (!string.IsNullOrEmpty(product))
            //{
            //products = products.Where(b => b.PTitle == searchString);
            //}
            //return View(db.Products.ToList());

            

            //if (!String.IsNullOrEmpty(product))
            //{
            //    product = db.Products.Where(b => b.PTitle == );
            //}

            return View(products);
        }

        //Sorting
        public ActionResult Index3(string sortOrder)
        {

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "PTitle_desc" : "";
            ViewBag.PColorSortParm = sortOrder == "PColor" ? "PColor_desc" : "PColor";
            ViewBag.PSizeSortParm = sortOrder == "PSize" ? "PSize_desc" : "PSize";

            var products = from b in db.Products
                           select b;


            if (sortOrder == ("Product name")) {

             products = from b in db.Products
                           orderby b.PTitle
                           select b ;
            } else if (sortOrder == ("Product color"))
            {
               products = from b in db.Products
                               orderby b.PColor
                               select b;
            }
            else if (sortOrder == ("Product size"))
            {
                products = from b in db.Products
                           orderby b.PSize
                           select b;
            }
            else if (sortOrder == ("Product price"))
            {
                products = from b in db.Products
                           orderby b.PPrice
                           select b;
            }
            else if (sortOrder == ("Product status"))
            {
                products = from b in db.Products
                           orderby b.PStatus
                           select b;
            }
            else if (sortOrder == ("Product category"))
            {
                products = from b in db.Products
                           orderby b.PCategory
                           select b;
            }

            //switch(sortOrder)
            //{
            //    case "PTitle_desc" :
            //            products = products.OrderByDescending(b => b.PTitle);
            //        break;

            //    case "PColor" :
            //            products = products.OrderBy(b => b.PColor);
            //        break;
            //    case "PColor_desc":
            //            products = products.OrderByDescending(b => b.PColor);
            //        break;

            //}


            //var productsList = new List<string>();
            // var getProducts = from m in db.Products
            //select m.PCategory;

            // productsList.AddRange(getProducts.Distinct());
            // ViewBag.products = new SelectList(productsList);
            //if (!string.IsNullOrEmpty(product))
            //{
            //products = products.Where(b => b.PTitle == searchString);
            //}
            //return View(db.Products.ToList());
            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            var Product = new Product();
            return View(Product);
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,PTitle,PDescription,PColor,PSize,PCategory,PStatus,PPrice")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,PTitle,PDescription,PColor,PSize,PCategory,PStatus,PPrice")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
