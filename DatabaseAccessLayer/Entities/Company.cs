
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatabaseAccessLayer.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string ManagerName { get; set; }
        public string EMail { get; set; }
        public string ManagerSurname { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Logo { get; set; }




    }
}