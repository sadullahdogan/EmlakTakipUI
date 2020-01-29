using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmlakTakipUI.Identity
{
    public class IdentityInitalizer:CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            //Roller
            if (!context.Roles.Any(x => x.Name == "admin")) {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "admin", Decsription = "Admin Role" };
                manager.Create(role);
                
            }
            if (!context.Roles.Any(x => x.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "user", Decsription = "User Role" };
                manager.Create(role);

            }
           

            //user

            if (!context.Users.Any(x => x.Email == "sado.doan@gmail.com"))
            {
                var store = new UserStore<ApplicationUsers>(context);
                var manager = new UserManager<ApplicationUsers>(store);
                var user = new ApplicationUsers() { Name = "Sadullah",Surname="Doğan",Email="sado.doan@gmail.com",PhoneNumber="05413713265",EmailConfirmed=true,UserName="sadullah"};
                manager.Create(user, "password");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }

            if (!context.Users.Any(x => x.Email == "deneme@deneme.com"))
            {
                var store = new UserStore<ApplicationUsers>(context);
                var manager = new UserManager<ApplicationUsers>(store);
                var user = new ApplicationUsers() { Name = "Deneme", Surname = "Deneme", Email = "deneme@deneme.com", PhoneNumber = "111111111111", EmailConfirmed = true, UserName = "deneme" };
                manager.Create(user, "password");
              
                manager.AddToRole(user.Id, "user");
            }
            base.Seed(context);
        }
    }
}