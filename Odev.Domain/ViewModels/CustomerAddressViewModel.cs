using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class CustomerAddressViewModel : BaseViewModel
    {
        [Display(Name = "Müşteri : ")]
        public Guid CustomerId { get; set; }

        [Display(Name = "Ülke : ")]
        public Guid CountryId { get; set; }

        [Display(Name = "İl : ")]
        public string CountryName { get; set; }

        public Guid CityId { get; set; }

        [Display(Name = "İl : ")]
        public string CityName { get; set; }

        [Display(Name = "İlçe : ")]
        public Guid CountyId { get; set; }

        [Display(Name = "İlçe : ")]
        public string CountyName { get; set; }

        [Display(Name = "Mahalle : ")]
        public Guid DistrictId { get; set; }

        [Display(Name = "Mahalle : ")]
        public string DistrictName { get; set; }

        [Display(Name = "Adres : ")]
        public string AddressText { get; set; }

        [Display(Name = "Adres Adı : ")]
        public string AddressName { get; set; }

        [Display(Name = "Adres Tipi : ")]
        public Guid AddressTypeId { get; set; }

        [Display(Name = "Adres Tipi : ")]
        public string AddressTypeName { get; set; }

        [Display(Name = "Ad : ")]
        public string FirstName { get; set; }

        [Display(Name = "Soyad : ")]
        public string LastName { get; set; }

        [Display(Name = "Telefon : ")]
        public string MobilePhone { get; set; }

        [Display(Name = "Posta Kodu : ")]
        public string ZipCode { get; set; }
    }
}
