using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class ShoppingCartItemViewModel : BaseViewModel
    {
        public Guid ShoppingCartId { get; set; }

        public string CampaignCodeKey { get; set; }

        public decimal UsedGiftCardPointPriceAmount { get; set; }

        public Guid ProductId { get; set; }

        public string ProductTitle { get; set; }

        public string ProductCategoryTitle { get; set; }

        public string PictureImage { get; set; }

        public Guid ColorId { get; set; }

        public int Quantity { get; set; }

        public decimal? OrderItemPriceInclTax { get; set; }

        public decimal? OrderItemDiscount { get; set; }

        public string ProductSlug { get; set; }
    }
}
