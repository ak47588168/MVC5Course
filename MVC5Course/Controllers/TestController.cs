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
        //FabricsEntities db = new FabricsEntities();
        ProductRepository productRepo = RepositoryHelper.GetProductRepository();

        public ActionResult Index()
        {
            var data = productRepo.All().OrderBy(p => p.ProductName);

            //var data = from p in db.Product
            //           where p.IsDeleted != true
            //           orderby p.ProductName
            //           select p;

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
                productRepo.Add(data);
                productRepo.UnitOfWork.Commit();
                //db.Product.Add(data);
                //db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(data);
        }

        public ActionResult Edit(int? id)
        {
            //var p = db.Product.Find(id);
            var p = productRepo.Find(id);

            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(int? id, Product data)
        {
            if (ModelState.IsValid)
            {
                //var p = db.Product.Find(data.ProductId);
                var p = productRepo.Find(id);

                p.ProductName = data.ProductName;
                p.Stock = data.Stock;
                p.Price = data.Price;
                p.Active = data.Active;
                //db.SaveChanges();
                productRepo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            return View(data);
        }

        public ActionResult Delete(int? id)
        {
            //var p = db.Product.Find(id);
            var p = productRepo.Find(id);

            return View(p);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            //var p = db.Product.Find(id);
            var p = productRepo.Find(id);

            //db.OrderLine.RemoveRange(p.OrderLine);
            //db.Product.Remove(p);
            //db.SaveChanges();
            p.IsDeleted = true;
            //db.SaveChanges();
            productRepo.UnitOfWork.Commit();

            return RedirectToAction("Index");
        }
    }
}