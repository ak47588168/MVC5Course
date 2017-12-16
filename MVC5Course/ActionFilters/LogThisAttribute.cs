using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.ActionFilters
{
    public class LogThisAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // filterContext.Controller.ViewBag.Message = "Your application description page.";
            // 
            // do something
            // 
            // 

            base.OnActionExecuting(filterContext);
        }
    }
}