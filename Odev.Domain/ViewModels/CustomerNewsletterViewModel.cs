using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class CustomerNewsletterViewModel : BaseViewModel
    {
        public bool EmailEnabled { get; set; }

        public bool SmsEnabled { get; set; }

        public bool CallEnabled { get; set; }

        public Guid CustomerId { get; set; }
    }
}
