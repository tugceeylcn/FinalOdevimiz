using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class ProductAttributeViewModel : BaseViewModel
    {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public Guid AttributeId { get; set; }

        public string AttributeName { get; set; }

        public string AttributeValue { get; set; }
    }
}
