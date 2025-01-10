using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class Setting : BaseModel
    {
        public string Currency { get; set; }

        public decimal CargoPrice { get; set; }

        public string CargoName { get; set; }

        public string CargoTrackingUrl { get; set; }

        public int MinEstimatedDate { get; set; }

        public int MaxEstimatedDate { get; set; }

        public bool PaymentCreditCardEnabled { get; set; }

        public bool PaymentOnDeliveryEnabled { get; set; }

        public bool PaymentInstallmentEnabled { get; set; }

        public bool CompayTransferEnabled { get; set; }

        public string CdnPath { get; set; }

        public string DefaultLanguageId { get; set; }

        public string IyzicoBaseUrl { get; set; }

        public string IyzicoSecretKey { get; set; }

        public string IyzicoApiKey { get; set; }

        public string CargoCampaign { get; set; }

        public string SmsGatewayBaseUrl { get; set; }

        public string SmsGatewaySecretKey { get; set; }

        public string SmsGatewayApiKey { get; set; }

        public string SmsSenderName { get; set; }
    }
}
