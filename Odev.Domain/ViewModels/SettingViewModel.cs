using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class SettingViewModel : BaseViewModel
    {

        [Display(Name = "Para Birimi Sembolü : ")]
        public string Currency { get; set; }

        [Display(Name = "Kargo Ücreti : ")]
        public decimal CargoPrice { get; set; }

        [Display(Name = "Kargo Adı : ")]
        public string CargoName { get; set; }

        [Display(Name = "Kargo Takip URL : ")]
        public string CargoTrackingUrl { get; set; }

        [Display(Name = "Min. Teslim Süresi : ")]
        public int MinEstimatedDate { get; set; }

        [Display(Name = "Max. Teslim Süresi : ")]
        public int MaxEstimatedDate { get; set; }

        [Display(Name = "Kredi Kartı Ödeme : ")]
        public bool PaymentCreditCardEnabled { get; set; }

        [Display(Name = "Kapıda Ödeme : ")]
        public bool PaymentOnDeliveryEnabled { get; set; }

        [Display(Name = "Taksit Durumu : ")]
        public bool PaymentInstallmentEnabled { get; set; }

        [Display(Name = "Havale/EFT : ")]
        public bool CompayTransferEnabled { get; set; }

        [Display(Name = "Cdn Path : ")]
        public string CdnPath { get; set; }

        [Display(Name = "Default Language Id : ")]
        public string DefaultLanguageId { get; set; }

        [Display(Name = "İyzico Base Url : ")]
        public string IyzicoBaseUrl { get; set; }

        [Display(Name = "İyzico Secret Key : ")]
        public string IyzicoSecretKey { get; set; }

        [Display(Name = "İyzico Api Key : ")]
        public string IyzicoApiKey { get; set; }

        [Display(Name = "Kargo Kampanyası : ")]
        public string CargoCampaign { get; set; }

        [Display(Name = "Sms Gateway Base Url : ")]
        public string SmsGatewayBaseUrl { get; set; }

        [Display(Name = "Sms Gateway Secret Key : ")]
        public string SmsGatewaySecretKey { get; set; }

        [Display(Name = "Sms Gateway Api Key : ")]
        public string SmsGatewayApiKey { get; set; }

        [Display(Name = "Sms Gateway Başlık : ")]
        public string SmsSenderName { get; set; }
    }
}
