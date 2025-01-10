using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class StreetViewModel : BaseViewModel
    {
        public virtual DistrictViewModel StreetDistrict { get; set; }
        public Guid StreetDistrictId { get; set; }
        public string StreetLatitude { get; set; }
        public string StreetLongtitude { get; set; }
        public string StreetName { get; set; }

        [Display(Name = "Görüntüleme Sırası : ")]
        public int DisplayOrder { get; set; }
    }
}
