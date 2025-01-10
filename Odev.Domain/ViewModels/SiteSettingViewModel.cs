using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class SiteSettingViewModel : BaseViewModel
    {
        [Display(Name = "Email : ")]
        public string Email { get; set; }

        [Display(Name = "Telefon : ")]
        public string Phone { get; set; }

        [Display(Name = "Fax : ")]
        public string Fax { get; set; }

        [Display(Name = "Adres : ")]
        public string Adres { get; set; }

        [Display(Name = "Logo : ")]
        public string Logo { get; set; }

        [Display(Name = "Facebook URL : ")]
        public string Facebook { get; set; }

        [Display(Name = "Twitter URL : ")]
        public string Twitter { get; set; }

        [Display(Name = "Instagram URL : ")]
        public string Instagram { get; set; }

        [Display(Name = "Youtube URL : ")]
        public string Youtube { get; set; }

        [Display(Name = "Harita URL : ")]
        public string Maps { get; set; }
    }
}
