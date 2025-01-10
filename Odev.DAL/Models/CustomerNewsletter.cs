using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class CustomerNewsletter : BaseModel
    {
        public bool EmailEnabled { get; set; }

        public bool SmsEnabled { get; set; }

        public bool CallEnabled { get; set; }

        public Guid CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customers Customers { get; set; }
    }
}
