using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class ShoppingCartViewModel : BaseViewModel
    {
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

        public string CargoName { get; set; }

        public ICollection<ShoppingCartItemViewModel> ShoppingCartItems { get; set; }

        public bool? CargoCampaign { get; set; }
    }
}
