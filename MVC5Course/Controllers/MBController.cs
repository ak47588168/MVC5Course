using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MBController : BaseController
    {
        // GET: MB
        public ActionResult Index()
        {
            var data = productRepo.All();

            ViewData.Model = data;

            ViewData["PageTitle"] = "商品名稱"; // 一樣的
            ViewBag.PageTitle = "商品名稱";     // 一樣的

            return View();
        }
    }
}