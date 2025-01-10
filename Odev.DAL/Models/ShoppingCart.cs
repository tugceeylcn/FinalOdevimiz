using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class ShoppingCart : BaseModel
    {
        public virtual Customers CustomerInfo { get; set; }

        public Guid CustomerId { get; set; }

        public string UsedCodeOrCoupon { get; set; }

        public decimal BasketTaxTotal { get; set; }

        public decimal? GetCargoOnDeliveryInclTax { get; set; }

        public int GetShoppingCartItemTotalQuantity { get; set; }

        public Guid OrderOrderTypeId { get; set; }

        public Guid PaymentTypeId { get; set; }

        public bool IsCodeOrCopunEnabled { get; set; }

        public decimal UsedGiftCardAmount { get; set; }

        public bool IsGiftCardEnabled { get; set; }

        public Guid CargoId { get; set; }

        public Guid AddressId { get; set; }

        [ForeignKey("CargoId")]
        public virtual Cargo Cargo { get; set; }

        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }

        public bool? CargoCampaign { get; set; }
    }
}
