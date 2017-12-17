using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.ActionFilters
{
    public class PriceDDLAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // filterContext.Controller.ViewBag.Message = "Your application description page.";
            // 
            // do something
            // 
            // 

            var priceList = (from p in new FabricsEntities().Product
                             select new
                             {
                                 Text = "$" + p.Price,
                                 Value = p.Price
                             }).Distinct().OrderBy(p => p.Value);

            filterContext.Controller.ViewBag.Price = new SelectList(priceList, "Value", "Text");

            base.OnActionExecuting(filterContext);
        }
    }
}