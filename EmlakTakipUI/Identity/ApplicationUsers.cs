using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakTakipUI.Identity
{
    public class ApplicationUsers:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        

    }
}