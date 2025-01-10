using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class Blog : BaseModel
    {
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }

        public string BlogImage { get; set; }

        public string BlogTicket { get; set; }

        public Guid? CategoryId { get; set; }

        public int DisplayOrder { get; set; }

        public int? LikeCount { get; set; }

        public string ShortUrl { get; set; }

        public string Slug { get; set; }

        public Category CategoryInfo { get; set; }

        public List<BlogComment> BlogComment { get; set; }

        public List<BlogGallery> BlogGallery { get; set; }
    }
}
