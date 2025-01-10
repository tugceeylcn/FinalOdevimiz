using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Display(Name = "Mevcut Şifre : ")]
        public string Password { get; set; }

        [Display(Name = "Yeni Şifre : ")]
        public string NewPassword { get; set; }

        [Display(Name = "Yeni Şifre (Tekrar) : ")]
        public string NewPasswordRepeat { get; set; }
    }
}
