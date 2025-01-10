using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class CityViewModel : BaseViewModel
    {
        public int CityCode { get; set; }
        public virtual CountryViewModel CityCountry { get; set; }
        public Guid CityCountryId { get; set; }
        public string CityLatitude { get; set; }
        public string CityLongtitude { get; set; }
        public string CityName { get; set; }

        [Display(Name = "Görüntüleme Sırası : ")]
        public int DisplayOrder { get; set; }
    }
}