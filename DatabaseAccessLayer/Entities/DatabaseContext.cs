using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DatabaseAccessLayer.Entities
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext() : base("MSSQL")
        {
            
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<Property> Properties { get; set; }

        
    }
}