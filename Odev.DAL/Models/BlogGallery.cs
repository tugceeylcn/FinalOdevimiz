using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class BlogGallery : BaseModel
    {
        public Guid BlogId { get; set; }

        public string Image { get; set; }

        public string ImageTitle { get; set; }

        public int DisplayOrder { get; set; }

        [ForeignKey("BlogId")]
        public virtual Blog Blog { get; set; }
    }
}
