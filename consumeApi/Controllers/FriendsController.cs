using consumeApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace consumeApi.Controllers
{
    public class FriendsController : Controller
    {
        // GET: Friends
        static List<string> strs = new List<string>() {"Anita","Kamal","Vimal" };

        static List<CategoryModel> categories = new List<CategoryModel>() {
            new CategoryModel {CategoryID=1,CategoryName="Beverages",Description="Tea,Coffee",Picture=null },
            new CategoryModel { CategoryID = 2, CategoryName = "Medicines", Description = "All Medicines", Picture = null },
            new CategoryModel {CategoryID = 3, CategoryName = "Lunch", Description = "Food items", Picture = null },
            new CategoryModel {CategoryID=4,CategoryName="Snacks",Description="Lays,Chips etc",Picture=null }
            };
        public ActionResult Index()
        {
            string data = "Hello";
            ViewBag.greetings = data;
            ViewData["user"] = "Admin";

            ViewBag.names = strs;
            ViewData["usernames"] = strs;

            ViewBag.catList = categories;
            ViewData["categoryList"]=categories;
            return View();
        }

        public ActionResult EditCategory()
        { 
        return View();
        }
        [HttpPost]
        public ActionResult EditCategory(int id)
        { 
        CategoryModel m=categories.Find(c=>c.CategoryID==id);
            return RedirectToAction("Details", new { catname= m.CategoryName,d=m.Description });
                   
        }
        public ActionResult Details(string catname,string d) 
        { 
        ViewBag.categoryName=String.Concat(catname, d);
        return View();  
        }

        [ErrorHandlingByUser()]
        public ActionResult A1(int id)
        {
            if (id>1000)
            {
                throw new Exception("Invalid");
            }
            return Content("Hello " + id);
        }




    }
}









