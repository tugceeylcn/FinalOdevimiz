using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class City : BaseModel
    {
        public int CityCode { get; set; }
        public virtual Country CityCountry { get; set; }
        public Guid CityCountryId { get; set; }
        public string CityLatitude { get; set; }
        public string CityLongtitude { get; set; }
        public string CityName { get; set; }

        public int DisplayOrder { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
    }
}
