using DatabaseAccessLayer.Entities;
using EmlakTakipUI.Identity;
using EmlakTakipUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using PagedList;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace EmlakTakipUI.Controllers
{
    public class UserController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        private UserManager<ApplicationUsers> userManager;
        public UserController()
        {
            var userStore = new UserStore<ApplicationUsers>(new DataContext());
            userManager = new UserManager<ApplicationUsers>(userStore);
        }
        // GET: User
        public ActionResult Index(PropertySearchModel m, int?_pageNo)
        {
           
            ViewBag.PropertyTypeId = new SelectList(db.PropertyTypes, "Id", "Ad");
            //return RedirectToAction("Action", new { id = 99 });
            if (m == null)
            {
                return View(db.Properties.ToList());
            }
            else {
                int _pageno = _pageNo ?? 1;
                var model = GetProducts(m);
                
                model = model.OrderBy(x => x.Date);
                
                return View(model.ToPagedList(_pageno,2));
            }
            
        }
        public ActionResult Edit(int id) {
            var model = db.Properties.Find(id);
            ViewBag.PropertyTypeId = new SelectList(db.PropertyTypes, "Id", "Ad");
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Property p,HttpPostedFileBase image) {
            if (image != null) {
                p.ImageName = image.FileName;
                var yuklemeYeri = Path.Combine(Server.MapPath("~/Upload"), image.FileName);
                image.SaveAs(yuklemeYeri);
            }

            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();
            return View();
        }
        [Authorize]
        public ActionResult PropertyDetails(int id) {
            var property = db.Properties.Find(id);
            var user = userManager.FindByName(property.Username);
            PropertyDetailsModel model = new PropertyDetailsModel()
            {
                UserName = user.Name + " " + user.Surname,
                Date = property.Date,
                Description = property.Description,
                EMail = user.Email,
                Floor = property.Floor,
                Id = property.Id,
                LivingRoomCount = property.LivingRoomCount,
                NumberOfFloors = property.NumberOfFloors,
                PhoneNumber = user.PhoneNumber,
                PropertyType = property.PropertyType,
                PropertyTypeId = property.PropertyTypeId,
                RoomCount = property.RoomCount,
                SquareMeter = property.SquareMeter,
                State = property.State,
                WarmingType = property.WarmingType,
                ImageName = property.ImageName
             
            };
            return View(model);
        }
        [Authorize]
        public ActionResult AddProperty()
        {
            ViewBag.PropertyTypeId = new SelectList(db.PropertyTypes, "Id", "Ad");
            return View();
        }
        [HttpPost]
        public ActionResult AddProperty(Property property,HttpPostedFileBase image)
        {
            
            if (ModelState.IsValid) {
                if (image != null) {
                    property.ImageName = image.FileName;
                    var yuklemeYeri = Path.Combine(Server.MapPath("~/Upload"), image.FileName);
                    image.SaveAs(yuklemeYeri);
                }
                property.Date = DateTime.Now;
                property.Username = User.Identity.Name;
                db.Properties.Add(property);
                db.SaveChanges();
                return RedirectToAction("Index", "User");
            }
            return View();
        }
        public IQueryable<Property> GetProducts(PropertySearchModel searchModel)
        {
            var result = db.Properties.AsQueryable();
            if (searchModel != null)
            {
                if (searchModel.MinPrice.HasValue)
                    result = result.Where(x => x.Price > searchModel.MinPrice);
                if (searchModel.MaxPrice.HasValue)
                    result = result.Where(x => x.Price < searchModel.MaxPrice);
                if (!String.IsNullOrWhiteSpace(searchModel.Adress))
                    result = result.Where(x => x.Adress.Contains(searchModel.Adress));
                if (searchModel.SquareMeter.HasValue)
                    result = result.Where(x => x.SquareMeter == searchModel.SquareMeter);
                if (searchModel.LivingRoomCount.HasValue)
                    result = result.Where(x => x.LivingRoomCount == searchModel.LivingRoomCount);
                if (searchModel.NumberOfFloors.HasValue)
                    result = result.Where(x => x.NumberOfFloors == searchModel.NumberOfFloors);
                if (searchModel.PropertyTypeId.HasValue)
                    result = result.Where(x => x.PropertyTypeId ==searchModel.PropertyTypeId);
                if (searchModel.RoomCount.HasValue)
                    result = result.Where(x => x.RoomCount == searchModel.RoomCount);
                if (searchModel.State!=State.Empty)
                    result = result.Where(x => x.State == searchModel.State);
                if (searchModel.WarmingType != WarmingType.Empty)
                    result = result.Where(x => x.WarmingType == searchModel.WarmingType);
                if (searchModel.Floor != searchModel.Floor)
                    result = result.Where(x => x.Floor == searchModel.Floor);

            }
            return result;
        }

    }
}