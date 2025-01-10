using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class CountryViewModel : BaseViewModel
    {
        public string CountryCode { get; set; }
        public string CountryLatitude { get; set; }
        public string CountryLongitude { get; set; }
        public string CountryName { get; set; }
        public string CountryRegexMobilePhone { get; set; }
        public string CountryRegexPostalCode { get; set; }
        public string CountryFlagImageFileName { get; set; }
        public string CountryPhoneCodePrefix { get; set; }

        [Display(Name = "Görüntüleme Sırası : ")]
        public int DisplayOrder { get; set; }
    }
}
