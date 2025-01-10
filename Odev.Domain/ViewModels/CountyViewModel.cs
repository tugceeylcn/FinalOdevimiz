using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class CountyViewModel : BaseViewModel
    {
        public Guid CountyCityId { get; set; }
        public string CountyLatitude { get; set; }
        public string CountyLongtitude { get; set; }
        public string CountyName { get; set; }
        public int CountyCode { get; set; }

        [Display(Name = "Görüntüleme Sırası : ")]
        public int DisplayOrder { get; set; }
    }
}
