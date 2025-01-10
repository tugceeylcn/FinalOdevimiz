using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class Address : BaseModel
    {
        public Guid AddressCustomerId { get; set; }

        public Guid? AddressCountryId { get; set; }
        public Guid? AddressCityId { get; set; }
        public Guid? AddressCountyId { get; set; }
        public Guid? AddressDistrictId { get; set; }
        public Guid? AddressStreetId { get; set; }
        public Guid? AddressCountryRegionId { get; set; }
        public Guid? AddressTypeId { get; set; }
        public Guid? AddressInvoiceTypeId { get; set; }
        public string AddressInvoiceFirmName { get; set; }
        public string AddressInvoiceTaxOffice { get; set; }
        public string AddressInvoiceTaxNumber { get; set; }
        public string AddressName { get; set; }
        public string AddressFirstName { get; set; }
        public string AddressLastName { get; set; }
        public string AddressText { get; set; }
        public string AddressPostalCode { get; set; }
        public string AddressPhone { get; set; }
        public string AddressMobilePhone { get; set; }
        public string AddressIdentityNumber { get; set; }
        public string AddressStreetText { get; set; }
        public string ZipCode { get; set; }
        public virtual Country Country { get; set; }
        public virtual County County { get; set; }
        public virtual City City { get; set; }
        public virtual District District { get; set; }
    }
}
