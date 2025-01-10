using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class AddressViewModel : BaseViewModel
    {
        public Guid AddressCustomerId { get; set; }

        public Guid? AddressCountryId { get; set; }

        public string AddressCountryName { get; set; }

        public Guid? AddressCityId { get; set; }

        public string AddressCityName { get; set; }

        public Guid? AddressCountyId { get; set; }

        public string AddressCountyName { get; set; }

        public Guid? AddressDistrictId { get; set; }

        public string AddressDistrictName { get; set; }

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
    }
}
