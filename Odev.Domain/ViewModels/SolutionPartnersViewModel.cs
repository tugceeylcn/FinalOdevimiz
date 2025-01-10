using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class SolutionPartnersViewModel : BaseViewModel
    {

        [Display(Name = "Çözüm Ortağı : ")]
        public string PartnerName { get; set; }


        [Display(Name = "Çözüm Ortağı Logo : ")]
        public string PartnerImage { get; set; }


        [Display(Name = "Görüntüleme Sırası : ")]
        public int DisplayOrder { get; set; }

        [Display(Name = "Slug : ")]
        public string Slug { get; set; }
    }
}
