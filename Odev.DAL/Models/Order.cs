using Odev.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class Order : BaseModel
    {
        /// <summary>
        /// Gets or sets the billing address.
        /// </summary>
        public virtual CustomerAddress BillingAddress { get; set; }

        /// <summary>
        /// Gets or sets the shipping address.
        /// </summary>
        public virtual CustomerAddress ShippingAddress { get; set; }

        /// <summary>
        /// Gets or sets the cargo.
        /// </summary>
        public virtual Cargo Cargo { get; set; }

        /// <summary>
        /// Gets or sets the order payment status.
        /// </summary>
        //public virtual PaymentStatus OrderPaymentStatus { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        public virtual Customers Customer { get; set; }

        /// <summary>
        /// Gets or sets the cargo firm name.
        /// </summary>
        public string CargoFirmName { get; set; }

        /// <summary>
        /// Gets or sets the cargo on delivery incl tax.
        /// </summary>
        public decimal? CargoOnDeliveryInclTax { get; set; }

        /// <summary>
        /// Gets or sets the cargo shipping incl tax.
        /// </summary>
        public decimal? CargoShippingInclTax { get; set; }

        /// <summary>Gets or sets the gift card message.</summary>
        public string GiftCardMessage { get; set; }

        /// <summary>
        /// Gets or sets the order affiliate id.
        /// </summary>
        public int? OrderAffiliateId { get; set; }

        /// <summary>
        /// Gets or sets the order billing address id.
        /// </summary>
        public Guid OrderBillingAddressId { get; set; }

        /// <summary>
        /// Gets or sets the order cargo id.
        /// </summary>
        public Guid OrderCargoId { get; set; }

        /// <summary>
        /// Gets or sets the order customer id.
        /// </summary>
        public Guid OrderCustomerId { get; set; }

        /// <summary>
        /// Gets or sets the order customer ip.
        /// </summary>
        public string OrderCustomerIp { get; set; }

        /// <summary>
        /// Gets or sets OrderErrorMessage.
        /// </summary>
        public string OrderErrorMessage { get; set; }

        /// <summary>
        /// Gets or sets the order ındex.
        /// </summary>
        public int? OrderIndex { get; set; }

        /// <summary>
        /// Gets or sets OrderInstallment.
        /// </summary>
        public int? OrderInstallmentCount { get; set; }

        /// <summary>
        /// Gets or sets OrderCardNumber.
        /// </summary>
        public string OrderMaskedCardNumber { get; set; }

        /// <summary>
        /// Gets or sets the order order payment status id.
        /// </summary>
        public int OrderOrderPaymentStatusId { get; set; }

        /// <summary>
        /// Gets or sets the order order status id.
        /// </summary>
        public OrderStatusEnum OrderOrderStatusId { get; set; }

        /// <summary>
        /// Gets or sets the order refunded amount.
        /// </summary>
        public decimal? OrderRefundedAmount { get; set; }

        /// <summary>
        /// Gets or sets the order shipping address id.
        /// </summary>
        public Guid OrderShippingAddressId { get; set; }

        /// <summary>
        /// Gets or sets the order total.
        /// </summary>
        public decimal OrderTotal { get; set; }

        /// <summary>
        /// Gets or sets the order discount.
        /// </summary>
        public decimal OrderTotalDiscount { get; set; }

        /// <summary> Gets or sets the OrderUsedGiftCardAmount. </summary>
        public decimal? OrderUsedGiftCardAmount { get; set; }

        /// <summary>Gets or sets the gift wrapping incl tax.</summary>
        public decimal? GiftWrappingInclTax { get; set; }

        /// <summary> Gets or sets the gift wrapping detail </summary>
        public string GiftWrappingDetail { get; set; }

        /// <summary>Gets or sets a value indicating whether is three d secure payment.</summary>
        public bool? IsThreeDSecurePayment { get; set; }

        /// <summary>Gets or sets the order shopping cart id. </summary>
        public Guid? OrderShoppingCartId { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public DateTime? RefundAmountDate { get; set; }

        public string EstimatedDate { get; set; }

        public string TrackingNumber { get; set; }

        public string InvoiceUrl { get; set; }

        public string CustomerFullName { get; set; }

        public string CustomerEmail { get; set; }

        public bool? CargoCampaign { get; set; }

        public string TransactionNumber { get; set; }

        public Guid? ConversationId { get; set; }
    }
}
