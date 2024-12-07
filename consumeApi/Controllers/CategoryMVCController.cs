using consumeApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace consumeApi.Controllers
{
    public class CategoryMVCController : Controller
    {

        string baseurl = "http://localhost:63706/api/Categories";

        private readonly HttpClient _httpClient;
        public CategoryMVCController()
        {
            _httpClient = new HttpClient();
       //     _httpClient.BaseAddress = new Uri(baseurl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                
        }
        // GET: CategoryMVC
        public async Task<ActionResult> Index()
        {
           var response=await _httpClient.GetAsync(baseurl);
            if (response.IsSuccessStatusCode)
            { 
            
            var data=await response.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<CategoryModel>>(data);
                return View(values);
            }
            return View("Error");
          
        }

        // GET: CategoryMVC/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CategoryMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryMVC/Create
        [HttpPost]
        public async  Task<ActionResult> Create(FormCollection collection)
        {
            try
            {
                string jsondata = null;
                if (ModelState.IsValid)
                {
                    var value = new
                    {
                        CategoryName = collection["CategoryName"],
                        Description = collection["Description"],
                        Picture = collection["Picture"]
                    };

                     jsondata = JsonConvert.SerializeObject(value);
                }
                    HttpContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
                    var response = await _httpClient.PostAsync($"{baseurl}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        return RedirectToAction("Index");
                    }
                
                else
                {
                    return View("Error");
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryMVC/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            var response = await _httpClient.GetAsync($"{baseurl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                CategoryModel foundModel = JsonConvert.DeserializeObject<CategoryModel>(data);
                return View(foundModel);
            }
            else
            {
                return View("Error");
            }
        }

        // POST: CategoryMVC/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                //anonymous type--value is anonymous type
               var value = new {
                   CategoryID = collection["CategoryID"],
                   CategoryName = collection["CategoryName"],
                   Description = collection["Description"],
                   Picture = collection["Picture"]
            };
                //use var or string
                string jsondata=JsonConvert.SerializeObject(value);
                HttpContent content=new StringContent(jsondata,Encoding.UTF8,"application/json");
                
                _httpClient.PutAsync($"{baseurl}/{id}", content);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryMVC/Delete/5
     
        public async Task<ActionResult> Delete(int id)
        {
            var response=await _httpClient.GetAsync($"{baseurl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                CategoryModel foundModel = JsonConvert.DeserializeObject<CategoryModel>(data);
                return View(foundModel);
            }       
            else
            {
                return View("Error");
            }
        }
        // POST: CategoryMVC/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {

                var response = await _httpClient.DeleteAsync($"{baseurl}/{id}");
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
