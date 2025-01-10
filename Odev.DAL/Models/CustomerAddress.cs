using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class CustomerAddress : BaseModel
    {
        public Guid CustomerId { get; set; }

        public Guid CountryId { get; set; }

        public Guid CityId { get; set; }

        public Guid CountyId { get; set; }

        public Guid DistrictId { get; set; }

        public string AddressText { get; set; }

        public string AddressName { get; set; }

        public Guid AddressTypeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MobilePhone { get; set; }

        public string ZipCode { get; set; }

        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }

        [ForeignKey("CountyId")]
        public virtual County County { get; set; }

        [ForeignKey("DistrictId")]
        public virtual District District { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customers Customers { get; set; }
    }
}
