using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class Category : BaseModel
    {
        public string CategoryName { get; set; }

        public string CategoryImage { get; set; }

        public Guid? TopCategoryId { get; set; }

        public int DisplayOrder { get; set; }

        public string Slug { get; set; }

        public bool IsPopular { get; set; }

        public Category TopCategory { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
