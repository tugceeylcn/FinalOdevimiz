using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class Product : BaseModel
    {
        public string ProductName { get; set; }

        public string ProductDetail { get; set; }

        public string ProductCoverImage { get; set; }

        public decimal ProductFirstPrice { get; set; }

        public decimal ProductPrice { get; set; }

        public Guid ColorId { get; set; }

        public Guid CategoryId { get; set; }

        public string SkuId { get; set; }

        public string ProductTickets { get; set; }

        public int ProductStock { get; set; }

        public int TotalSaleCount { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsPopular { get; set; }

        public string Slug { get; set; }

        [ForeignKey("CategoryId")]

        // Navigation Property
        public virtual Category CategoryInfo { get; set; }

        [ForeignKey("ColorId")]
        public virtual Color ColorInfo { get; set; }

        public virtual ICollection<ProductAttribute> ProductAttributes { get; set; }

        public virtual ICollection<ProductImage> ProductImages { get; set; }

        public Guid AttributeFirst { get; set; }

        public Guid AttributeTwo { get; set; }
    }
}
