using EmlakTakipUI.Identity;
using EmlakTakipUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmlakTakipUI.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUsers> userManager;
        private RoleManager<ApplicationRole> roleManager;
        public AccountController()
        {
            var userStore = new UserStore<ApplicationUsers>(new DataContext());
            userManager = new UserManager<ApplicationUsers>(userStore);
            var roleStore = new RoleStore<ApplicationRole>(new DataContext());
            roleManager = new RoleManager<ApplicationRole>(roleStore);
        }
        // GET: Account
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            var user = new ApplicationUsers();
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.UserName = model.Username;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;

            var result = userManager.Create(user, model.Password);
            if (result.Succeeded)
            {
                //User created 
                //asign role to user
                if (roleManager.RoleExists("User"))
                {
                    userManager.AddToRole(user.Id, "User");
                }
                return RedirectToAction("Login", "Account");
            }

            return View(model);
            
        }
        public ActionResult Login(string returnUrl)
        {
            if (!String.IsNullOrEmpty(returnUrl))
            {
                ViewBag.ReturnUrl = returnUrl;
            }
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "User");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.Find(model.Username, model.Password);
                if (user != null)
                {
                    //sistemem kullanıcıyı at //++//ApplicationCookie oluşur sisteme at//
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityClaims = userManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                    authProperties.IsPersistent = model.RememberMe;
                    authManager.SignIn(authProperties, identityClaims);

                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Böyle bir kullanıcı bulunamadı");
                }
            }

            return View(model);
        }
        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "User");
        }
    }
}