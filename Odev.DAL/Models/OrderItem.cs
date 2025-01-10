using Odev.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class OrderItem : BaseModel
    {
        /// <summary> Gets or sets the order. </summary>
        public virtual Order Order { get; set; }

        /// <summary> Gets or sets the order item discount. </summary>
        public decimal? OrderItemDiscount { get; set; }

        /// <summary> Gets or sets the order item order id. </summary>
        public Guid OrderItemOrderId { get; set; }

        /// <summary>Gets or sets the order ıtem order status ıd.</summary>
        public OrderStatusEnum OrderItemOrderStatusId { get; set; }

        /// <summary> Gets or sets the order item price incl tax. </summary>
        public decimal? OrderItemPriceInclTax { get; set; }

        /// <summary> Gets or sets the order item quantity. </summary>
        public int OrderItemQuantity { get; set; }

        /// <summary> Gets or sets the order item refund amount. </summary>
        public decimal? OrderItemRefundAmount { get; set; }

        /// <summary> Gets or sets the order item tax rate. </summary>
        public int OrderItemTaxRate { get; set; }

        /// <summary> Gets or sets the order ıtem sale price ıncl tax. </summary>
        public decimal? OrderItemSalePriceInclTax { get; set; }

        /// <summary> Gets or sets the order ıtem sale discount. </summary>
        public decimal? OrderItemSaleDiscount { get; set; }

        /// <summary> Gets or sets the order ıtem sale refund amount. </summary>
        public decimal? OrderItemSaleRefundAmount { get; set; }

        /// <summary> Gets or sets the order ıtem sale ınstallment price ıncl tax. </summary>
        public decimal? OrderItemSaleInstallmentPriceInclTax { get; set; }

        /// <summary>Gets or sets the order ıtem first price ıncl tax.</summary>
        public decimal? OrderItemFirstPriceInclTax { get; set; }

        /// <summary>Gets or sets the order item gift card details. </summary>
        public string GiftCardDetails { get; set; }

        /// <summary>Gets or sets the order item shopping cartitem id. </summary>
        public Guid? OrderItemShoppingCartItemId { get; set; }

        /// <summary>Gets or sets the QuantityReturned. </summary>
        public int? QuantityReturned { get; set; }

        /// <summary>Gets or sets the QuantityCancelled. </summary>
        public int? QuantityCancelled { get; set; }

        /// <summary>Gets or sets the UsedGiftClubPointAmount. </summary>
        public decimal? UsedGiftClubPointAmount { get; set; }

        /// <summary>Gets or sets the EarndGiftClubPointAmount. </summary>
        public decimal? EarndGiftClubPointAmount { get; set; }

        public Guid? ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public string TransactionNumber { get; set; }
    }
}
