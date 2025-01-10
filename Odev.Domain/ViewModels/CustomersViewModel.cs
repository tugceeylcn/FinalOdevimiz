using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class CustomersViewModel : BaseViewModel
    {
        #region - Properties

        [Display(Name = "Doğum Tarihi : ")]
        public DateTime? CustomerBirthDate { get; set; }

        [Display(Name = "Email : ")]
        public string CustomerEmail { get; set; }

        [Display(Name = "Ad : ")]
        public string CustomerFirstName { get; set; }

        [Display(Name = "Soyad : ")]
        public string CustomerLastName { get; set; }

        [Display(Name = "Cinsiyet : ")]
        public Guid CustomerGenderId { get; set; }

        [Display(Name = "T.C. Kimlik Numarası : ")]
        public string CustomerIdentityNumber { get; set; }

        [Display(Name = "Son Sipariş Adresi : ")]
        public Guid? CustomerLastBillingAddressId { get; set; }

        [Display(Name = "Son Fatura Adresi : ")]
        public Guid? CustomerLastShippingAddressId { get; set; }

        [Display(Name = "Son Ip Adresi : ")]
        public string CustomerLastIpAddress { get; set; }

        [Display(Name = "Şifre : ")]
        public string CustomerPassword { get; set; }

        [Display(Name = "Şifre Salt : ")]
        public string CustomerPasswordSalt { get; set; }

        [Display(Name = "Telefon : ")]
        public string CustomerPhone { get; set; }

        [Display(Name = "Kayıt Tarihi : ")]
        public DateTime? CustomerRegisterDate { get; set; }

        [Display(Name = "Son Şifre Değiştirme Tarihi : ")]
        public DateTime? LastChangePasswordDate { get; set; }

        [Display(Name = "Kullanıcı Tipi : ")]
        public Guid? CustomerTypeId { get; set; }

        [Display(Name = "İlk Sipariş Tarihi : ")]
        public DateTime? CustomerFirstOrderDate { get; set; }

        [Display(Name = "Email Onay : ")]
        public bool CustomerEmailIsValidated { get; set; }

        [Display(Name = "Email Onay Tarihi : ")]
        public DateTime? CustomerEmailValidatedDate { get; set; }

        [Display(Name = "Toplam Sipariş Tutarı : ")]
        public decimal? CustomerOrderTotal { get; set; }

        [Display(Name = "Telefon Onay : ")]
        public bool CustomerPhoneIsValidated { get; set; }

        [Display(Name = "Telefon Onay Tarihi : ")]
        public DateTime? CustomerPhoneValidatedDate { get; set; }

        #endregion
    }
}