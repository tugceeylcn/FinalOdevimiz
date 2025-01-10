using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class PostalCodeViewModel : BaseViewModel
    {
        public int? RegionId { get; set; }
        public Guid? CountryId { get; set; }
        public Guid? CityId { get; set; }
        public Guid? CountyId { get; set; }
        public Guid? DistrictId { get; set; }
        public string PostCode { get; set; }
        public string MaxPostCode { get; set; }

        [Display(Name = "Görüntüleme Sırası : ")]
        public int DisplayOrder { get; set; }
    }
}
