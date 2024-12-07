using consumeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace consumeApi.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index()
        {
           return View();
        }
        [HttpPost]
        public ActionResult Index(int i, int j)
        {
            string msg = null;
            try
            {
                int ans = i / j;
                ViewBag.answer = ans;
            }
            catch (Exception ex)
            {
                msg=ex.Message;
                ViewBag.MessagetoUser = msg;
            }
            
            return View();

        }

        public ActionResult Find()
        {
            return View();
        }

        [HandleError(ExceptionType =typeof(EmployeeNotFoundException),View ="MyErrorPage")]
        [HandleError(ExceptionType=typeof(NotImplementedException),View="Error")]
        [HttpPost]
        public ActionResult Find(int id)
        {
            if (id == 0)
            {

                throw new EmployeeNotFoundException("Invalid EmployeeID");//myerror page
            }
            else if (id > 100 || id<200)
            {
                throw new Exception("Not allowed");//error page
            }
            else
            {
                ViewBag.Msg = "Trying to find......";

            }
            return View();
        }







    }
}