using ShopProductManagement.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopProductManagement.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Order()
        {
            var db = new ShopProductManagementEntities();
            var data = db.Orders.ToList();
            return View(data);
        }
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Order cg)
        {
            var db = new ShopProductManagementEntities();
            db.Orders.Add(cg);
            db.SaveChanges();
            return RedirectToAction("Order");

        }


        public ActionResult Delete(int id)
        {
            var db = new ShopProductManagementEntities();
            var data = db.Orders.Find(id);
            db.Orders.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Order");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var db = new ShopProductManagementEntities();
            var data = db.Orders.Find(Id);
            return View(data);

        }
        [HttpPost]
        public ActionResult Edit(Order cg)
        {
            var db = new ShopProductManagementEntities();
            var ex = db.Orders.Find(cg.Id);
            ex.Id = cg.Id;
            db.SaveChanges();
            return RedirectToAction("Order");
        }

        public ActionResult Details(int id)
        {
            var db = new ShopProductManagementEntities();
            var dept = db.Orders.Find(id);

            return View(dept);
        }
    }
}