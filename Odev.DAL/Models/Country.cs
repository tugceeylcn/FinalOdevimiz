using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class Country : BaseModel
    {
        public string CountryCode { get; set; }
        public string CountryLatitude { get; set; }
        public string CountryLongitude { get; set; }
        public string CountryName { get; set; }
        public string CountryRegexMobilePhone { get; set; }
        public string CountryRegexPostalCode { get; set; }
        public string CountryFlagImageFileName { get; set; }
        public string CountryPhoneCodePrefix { get; set; }

        public int DisplayOrder { get; set; }

        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
    }
}
