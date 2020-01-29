using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DatabaseAccessLayer.Entities
{
    public class PropertyType
    {
        public int Id { get; set; }
        [Required, DisplayName("Emlak Türü")]
        public string Ad { get; set; }
    }
}