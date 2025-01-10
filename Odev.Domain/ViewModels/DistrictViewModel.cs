using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class DistrictViewModel : BaseViewModel
    {
        private ICollection<StreetViewModel> districtStreets;
        public virtual CountyViewModel DistrictCounty { get; set; }
        public Guid DistrictCountyId { get; set; }
        public string DistrictLatitude { get; set; }
        public string DistrictLongtitude { get; set; }
        public string DistrictName { get; set; }

        [Display(Name = "Görüntüleme Sırası : ")]
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the district streets.
        /// </summary>
        public virtual ICollection<StreetViewModel> DistrictStreets
        {
            get
            {
                return this.districtStreets ?? (this.districtStreets = new Collection<StreetViewModel>());
            }

            set
            {
                this.districtStreets = value;
            }
        }
    }
}
