using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class AttributeViewModel : BaseViewModel
    {
        public string AttributeName { get; set; }

        public int DisplayOrder { get; set; }
    }
}
