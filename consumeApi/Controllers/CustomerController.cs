using consumeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace consumeApi.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer

        static List<CustomerModel> custs = new List<CustomerModel>() {
        new CustomerModel{Custid=1,CustName="Anuja" },
        new CustomerModel{ Custid=2,CustName="Girija"},
        new CustomerModel{Custid=3,CustName="Suma" }
        };
        public ActionResult Index()
        {
            //List of customers
            ViewBag.custList = custs;
            return View();
        }

        public ActionResult Details(string id) {
            

            return RedirectToAction("Index", "Orders", new { customerName = id });
        }


    }
}