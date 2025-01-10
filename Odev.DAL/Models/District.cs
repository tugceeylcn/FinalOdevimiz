using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class District : BaseModel
    {
        private ICollection<Street> districtStreets;
        public virtual County DistrictCounty { get; set; }
        public Guid DistrictCountyId { get; set; }
        public string DistrictLatitude { get; set; }
        public string DistrictLongtitude { get; set; }
        public string DistrictName { get; set; }

        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the district streets.
        /// </summary>
        public virtual ICollection<Street> DistrictStreets
        {
            get
            {
                return this.districtStreets ?? (this.districtStreets = new Collection<Street>());
            }

            set
            {
                this.districtStreets = value;
            }
        }

        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
    }
}
