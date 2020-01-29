using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakTakipUI.Identity
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole()
        {

        }
        public ApplicationRole(string roleName, string description)
        {
            this.Decsription = description;
        }
        public string Decsription { get; set; }
    }
}