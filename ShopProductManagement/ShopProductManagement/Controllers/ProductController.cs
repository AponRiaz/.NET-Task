using ShopProductManagement.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopProductManagement.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Product()
        {
            var db = new ShopProductManagementEntities();
            var data = db.Products.ToList();
            return View(data);
        }
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Product cg)
        {
            var db = new ShopProductManagementEntities();
            db.Products.Add(cg);
            db.SaveChanges();
            return RedirectToAction("Product");

        }


        public ActionResult Delete(int id)
        {
            var db = new ShopProductManagementEntities();
            var data = db.Products.Find(id);
            db.Products.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Product");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var db = new ShopProductManagementEntities();
            var data = db.Products.Find(Id);
            return View(data);

        }
        [HttpPost]
        public ActionResult Edit(Product cg)
        {
            var db = new ShopProductManagementEntities();
            var ex = db.Products.Find(cg.Id);
            ex.Id = cg.Id;
            db.SaveChanges();
            return RedirectToAction("Product");
        }

        public ActionResult Details(int id)
        {
            var db = new ShopProductManagementEntities();
            var dept = db.Products.Find(id);

            return View(dept);
        }
    }
}