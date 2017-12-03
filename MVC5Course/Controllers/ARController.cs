using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : Controller
    {
        // GET: AR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PartaiViewIndex()
        {
            return PartialView("Index");
        }

        public ActionResult ContentTest()
        {
            return PartialView("JsAlert", "修改成功");
        }
    }
}