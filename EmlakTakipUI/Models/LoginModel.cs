using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakTakipUI.Models
{
   public  class LoginModel
    {
        public int Id { get; set; }
        [Required, DisplayName("Username")]
        public string Username { get; set; }
        [Required, DisplayName("Şifre"),DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Beni Hatırla")]
        public bool RememberMe { get; set; }

    }
}
