using ShopProductManagement.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopProductManagement.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult User()
        {
            var db = new ShopProductManagementEntities();
            var data = db.Users.ToList();
            return View(data);
        }
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(User cg)
        {
            var db = new ShopProductManagementEntities();
            db.Users.Add(cg);
            db.SaveChanges();
            return RedirectToAction("User");

        }


        public ActionResult Delete(int id)
        {
            var db = new ShopProductManagementEntities();
            var data = db.Users.Find(id);
            db.Users.Remove(data);
            db.SaveChanges();
            return RedirectToAction("User");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            var db = new ShopProductManagementEntities();
            var data = db.Users.Find(Id);
            return View(data);

        }
        [HttpPost]
        public ActionResult Edit(User cg)
        {
            var db = new ShopProductManagementEntities();
            var ex = db.Users.Find(cg.Id);
            ex.Id = cg.Id;
            db.SaveChanges();
            return RedirectToAction("User");
        }

        public ActionResult Details(int id)
        {
            var db = new ShopProductManagementEntities();
            var dept = db.Users.Find(id);

            return View(dept);
        }
    }
}