using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class ProductImageViewModel : BaseViewModel
    {
        public Guid ProductId { get; set; }

        public string ImageUrl { get; set; }

        public int DisplayOrder { get; set; }
    }
}
