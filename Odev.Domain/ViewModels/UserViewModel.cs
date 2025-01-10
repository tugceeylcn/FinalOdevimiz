using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        [Display(Name = " Ad Soyad : ")]
        public string NameSurname { get; set; }

        [Display(Name = "Email : ")]
        public string Email { get; set; }

        [Display(Name = "Telefon : ")]
        public string Phone { get; set; }

        [Display(Name = "Şifre : ")]
        public string Pwd { get; set; }

        [Display(Name = "Kullanıcı Türü : ")]
        public Guid UserTypeId { get; set; }
    }
}
