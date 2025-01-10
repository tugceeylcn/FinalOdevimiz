using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class CustomerWishList : BaseModel
    {
        public Guid CustomerId { get; set; }

        public Guid ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customers Customers { get; set; }
    }
}
