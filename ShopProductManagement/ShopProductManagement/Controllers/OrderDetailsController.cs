using ShopProductManagement.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopProductManagement.Controllers
{
    public class OrderDetailsController : Controller
    {
        // GET: OrderDetails
        public ActionResult OrderDetails()
        {
            var db = new ShopProductManagementEntities();
            var data = db.OrderDetails.ToList();
            return View(data);
        }
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(OrderDetail cg)
        {
            var db = new ShopProductManagementEntities();
            db.OrderDetails.Add(cg);
            db.SaveChanges();
            return RedirectToAction("OrderDetails");

        }


        public ActionResult Delete(int id)
        {
            var db = new ShopProductManagementEntities();
            var data = db.OrderDetails.Find(id);
            db.OrderDetails.Remove(data);
            db.SaveChanges();
            return RedirectToAction("OrderDetails");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var db = new ShopProductManagementEntities();
            var data = db.OrderDetails.Find(Id);
            return View(data);

        }
        [HttpPost]
        public ActionResult Edit(OrderDetail cg)
        {
            var db = new ShopProductManagementEntities();
            var ex = db.OrderDetails.Find(cg.Id);
            ex.Id = cg.Id;
            db.SaveChanges();
            return RedirectToAction("OrderDetails");
        }

        public ActionResult Details(int id)
        {
            var db = new ShopProductManagementEntities();
            var dept = db.OrderDetails.Find(id);

            return View(dept);
        }
    }
}