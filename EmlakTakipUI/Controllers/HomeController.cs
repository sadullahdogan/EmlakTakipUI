using DatabaseAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmlakTakipUI.Controllers
{
    public class HomeController : Controller
    {
        DatabaseAccessLayer.Entities.DatabaseContext db = new DatabaseAccessLayer.Entities.DatabaseContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AboutUs() {
            var model = db.Companies.Find(1);
            if (model == null) {
                model = new Company();
                model.Adress = "CompanyAdress";
                model.EMail = "company.company@company.com";
                model.Fax = "11111111111";
                model.Logo = "logo.png";
                model.ManagerName = "Manager";
                model.ManagerSurname = "ManagerLAstname";
                model.Phone = "222222222222";
                db.Companies.Add(model);
                db.SaveChanges();
            }
            return PartialView(model);
        }
    }
}