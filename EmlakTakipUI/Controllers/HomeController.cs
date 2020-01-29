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
          
            return PartialView(model);
        }
    }
}