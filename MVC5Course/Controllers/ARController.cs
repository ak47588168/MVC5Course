using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : BaseController
    {
        // GET: AR
        public ActionResult Index(string dl)
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

        public ActionResult FileTest(string dl)
        {
            if (string.IsNullOrWhiteSpace(dl))
            {
                return File(Server.MapPath("~/App_Data/broken_window.png"), "image/jpeg");
            }
            else
            {
                return File(Server.MapPath("~/App_Data/broken_window.png"), "image/jpeg", "windows.jpg");
            }
        }

        public ActionResult JsonTest()
        {
            var data = from p in productRepo.All()
                       select new
                       {
                           p.ProductId,
                           p.ProductName,
                           p.Price
                       };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RedirectTest()
        {
            return RedirectToAction("FileTest", new { dl = 1 });
        }
    }
}