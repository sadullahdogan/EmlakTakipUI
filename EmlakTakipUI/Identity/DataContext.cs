
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmlakTakipUI.Identity
{
    public class DataContext : IdentityDbContext<ApplicationUsers>
    {
        public DataContext() : base("MSSQL")
        {

            
        }

        
    }
        
}