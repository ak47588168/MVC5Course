using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MBController : BaseController
    {
        public class MBProductsVM
        {
            public int ProductId { get; set; }

            public decimal Price { get; set; }

            public string ProductName { get; set; }
        }

        //protected ProductRepository productRepo = RepositoryHelper.GetProductRepository();

        // GET: MB
        public ActionResult Index()
        {
            var data = productRepo.GetTop20();

            ViewData.Model = data;

            ViewData["PageTitle"] = "商品名稱"; // 一樣的
            ViewBag.PageTitle = "商品名稱";     // 一樣的

            return View();
        }

        [HttpPost]
        public ActionResult Index(MBProductsVM[] data)
        {
            if(data == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                foreach (var d in data)
                {
                    var prd = productRepo.Find(d.ProductId);

                    prd.ProductName = d.ProductName;
                    prd.Price = d.Price;
                }

                productRepo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            ViewData.Model = productRepo.GetTop20();

            return View();
        }
    }
}