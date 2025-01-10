using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class Attribute : BaseModel
    {
        public string AttributeName { get; set; }

        public int DisplayOrder { get; set; }

        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }
    }
}
