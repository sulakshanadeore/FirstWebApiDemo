using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace consumeApi.Controllers
{
    public class ProductsController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            Exception ex=filterContext.Exception;
            filterContext.ExceptionHandled=true;
            var model = new HandleErrorInfo(filterContext.Exception, "Controller", "Action");
            filterContext.Result = new ViewResult() { ViewName = "Error", ViewData = new ViewDataDictionary(model) };
            //base.OnException(filterContext);
        }
        // GET: Products
        public ActionResult Index()
        {
            int i = 10;
            int j = 0;
            int ans = i / j;
            ViewBag.answer = ans;
            return View();
        }
    }
}