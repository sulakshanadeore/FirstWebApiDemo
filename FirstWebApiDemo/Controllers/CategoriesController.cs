using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using FirstWebApiDemo;
using FirstWebApiDemo.Areas.HelpPage.ModelDescriptions;
using FirstWebApiDemo.Models;

namespace FirstWebApiDemo.Controllers
{
    [EnableCors(origins:"*",methods:"*",headers:"*")]
    public class CategoriesController : ApiController
    {
        private northwindEntities db = new northwindEntities();

        // GET: api/Categories
        public List<CategoryModel> GetCategories()
        {
            List<Category> catlist = db.Categories.ToList();
            List<CategoryModel> modelList = new List<CategoryModel>();
            foreach (var item in catlist)
            {
                modelList.Add(new CategoryModel { CategoryID = item.CategoryID, CategoryName = item.CategoryName, Description = item.Description, Picture = item.Picture });
            }
            return modelList;
        }

        // GET: api/Categories/5
        [ResponseType(typeof(CategoryModel))]
        public IHttpActionResult GetCategory(int id)
        {
            Category category = db.Categories.Find(id);
            CategoryModel model = new CategoryModel();
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                    
                model.CategoryID = category.CategoryID;
                model.CategoryName = category.CategoryName;
                model.Description = category.Description;
                model.Picture = category.Picture;
            }

            return Ok(model);
        }

        // PUT: api/Categories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCategory(int id, [FromBody] CategoryModel category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != category.CategoryID)
            {
                return BadRequest();
            }
            Category cat = db.Categories.Find(id);
            try
            {
               cat.CategoryName = category.CategoryName;
                cat.Description = category.Description;
                cat.Picture = category.Picture;
                db.Entry(cat).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Categories
        [ResponseType(typeof(CategoryModel))]
        public IHttpActionResult PostCategory([FromBody]CategoryModel category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Category cat=new Category();   
            cat.CategoryName= category.CategoryName;
            cat.Description= category.Description;
            cat.Picture = category.Picture;
            db.Categories.Add(cat);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = category.CategoryID }, cat);
        }

        // DELETE: api/Categories/5
        [ResponseType(typeof(CategoryModel))]
        public IHttpActionResult DeleteCategory(int id)
        {
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }

            db.Categories.Remove(category);
            db.SaveChanges();
            Category catmodel = new Category();
            catmodel.CategoryName = category.CategoryName;
            catmodel.Description = category.Description;
            catmodel.Picture = category.Picture;

            return StatusCode(HttpStatusCode.OK);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(int id)
        {
            return db.Categories.Count(e => e.CategoryID == id) > 0;
        }
    }
}