using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmlakTakipUI.Models
{
    public class RegisterModel
    {
        public int Id { get; set; }
        [Required, DisplayName("Adınız")]
        public string Name { get; set; }
        [Required, DisplayName("Soy Adınız")]
        public string Surname { get; set; }
        [Required, DisplayName("E-Posta Adresi"), DataType(DataType.EmailAddress,ErrorMessage ="Mail Adresi Hatalı")]
        public string Email { get; set; }
        [Required, DisplayName("Telefon Numarası"), DataType(DataType.PhoneNumber,ErrorMessage ="Telefon Numarası Hatalı")]
        public string PhoneNumber { get; set; }
        [Required, DisplayName("Kullanıcı Adı")]
        public string Username { get; set; }
        [Required, DisplayName("Şifre"),DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DisplayName("Şifre (Tekrar)"),Compare("Password",ErrorMessage ="Şifreler uyuşmuyor"), DataType(DataType.Password)]
        public string RePassword { get; set; }




    }
}
