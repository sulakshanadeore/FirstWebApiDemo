using consumeApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace consumeApi.Controllers
{
    public class OrdersController : Controller
    {

        static List<OrdersModel> ordersData = new List<OrdersModel>() {
        new OrdersModel{Orderid=1,Productid=10,Qty=100,CustName="Anuja" },
        new OrdersModel{Orderid=3,Productid=11,Qty=100,CustName="Anuja" },
        new OrdersModel{Orderid=2,Productid=11,Qty=101,CustName="Girija" },
        new OrdersModel{Orderid=5,Productid=10,Qty=100,CustName="Girija" },
      new OrdersModel{Orderid=4,Productid=11,Qty=100,CustName="Suma" }
              };
        // GET: Orders
        public ActionResult Index(string customerName)
        {
            ViewBag.CName=customerName;
            var custorders= ordersData.Where(c=>c.CustName==customerName).ToList();
            //List<OrdersModel> custorders=new List<OrdersModel>();
            //foreach (var item in ordersData)
            //{
            //    if (item.CustName==customerName)
            //    {
            //        custorders.Add(item);
            //    }
            //}
            ViewBag.ordersData=custorders;
            return View();
        }
    }
}