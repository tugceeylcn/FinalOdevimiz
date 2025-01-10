using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class CustomerWishListViewModel : BaseViewModel
    {
        public Guid CustomerId { get; set; }

        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductCategoryName { get; set; }

        public decimal ProductPrice { get; set; }

        public string ProductImage { get; set; }
    }
}
