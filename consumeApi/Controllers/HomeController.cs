using consumeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace consumeApi.Controllers
{
    public class HomeController : Controller
    {
        [ErrorHandlingByUser()]
        public ActionResult Index()
        {
            int i = 10;
            int j = 2;
            int ans = i / j;
            ViewBag.answer = ans;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}