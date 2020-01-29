using DatabaseAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmlakTakipUI.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        DatabaseAccessLayer.Entities.DatabaseContext db = new DatabaseAccessLayer.Entities.DatabaseContext();
        // GET: Admin
        public ActionResult Index()
        {
            var company = db.Companies.Find(1);
            return View(company);
        }
        public ActionResult Edit() {
            var company=db.Companies.Find(1);
            return View(company);
        }
        [HttpPost]
        public ActionResult Edit(Company company,HttpPostedFileBase logo)
        {
            if (logo != null) {
                var yuklemeYeri = Path.Combine(Server.MapPath("~/Logo"), "logo.jpg");
                logo.SaveAs(yuklemeYeri);
            }
            db.Entry(company).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AddPropertyType() {
            return View();
        }
        [HttpPost]
        public ActionResult AddPropertyType(PropertyType propertyType)
        {
            if (ModelState.IsValid) {
                db.PropertyTypes.Add(propertyType);
                db.SaveChanges();
                return RedirectToAction("Index", "User");
            }
            return View();
        }
    }
}