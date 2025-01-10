using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class ProductAttribute : BaseModel
    {
        public Guid ProductId { get; set; }

        public Guid AttributeId { get; set; }

        public string AttributeValue { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [ForeignKey("AttributeId")]
        public virtual Attribute Attribute { get; set; }
    }
}
