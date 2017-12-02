using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    public class TestController : Controller
    {
        FabricsEntities db = new FabricsEntities();

        public ActionResult Index()
        {
            var data = from p in db.Product
                       select p;

            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product data)
        {
            if (ModelState.IsValid)
            {
                db.Product.Add(data);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(data);
        }

        public ActionResult Edit(int id)
        {
            var p = db.Product.Find(id);

            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(Product data)
        {
            if (ModelState.IsValid)
            {
                var p = db.Product.Find(data.ProductId);

                p.ProductName = data.ProductName;
                p.Stock = data.Stock;
                p.Price = data.Price;
                p.Active = data.Active;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var p = db.Product.Find(id);

            return View(p);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var p = db.Product.Find(id);

            db.Product.Remove(p);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}