using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class MailSettingViewModel : BaseViewModel
    {
        #region - Properties

        [Display(Name = "Host : ")]
        public string Host { get; set; } //Host-Sunucu

        [Display(Name = "Port : ")]

        public int Port { get; set; } //Sunucu port

        [Display(Name = "Mail : ")]

        public string MailAddress { get; set; }  //Gönderici mail adresi

        [Display(Name = "Şifre : ")]

        public string Password { get; set; } //Gönderici mail şifresi

        [Display(Name = "SSL : ")]

        public bool Ssl { get; set; } //SSL

        [Display(Name = "CC Mail : ")]

        public string CCMail { get; set; } //CCMail

        #endregion
    }
}