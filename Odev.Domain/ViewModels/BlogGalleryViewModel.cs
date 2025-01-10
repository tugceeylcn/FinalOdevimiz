using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class BlogGalleryViewModel : BaseViewModel
    {
        public Guid BlogId { get; set; }

        public string Image { get; set; }

        public string ImageTitle { get; set; }

        public string BlogTitle { get; set; }

        public int DisplayOrder { get; set; }
    }
}
