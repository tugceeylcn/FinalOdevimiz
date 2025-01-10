using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.DAL.Models
{
    public class BlogComment : BaseModel
    {
        public string FirstLastName { get; set; }

        public string Email { get; set; }

        public string CommentDetail { get; set; }

        public Guid BlogId { get; set; }

        public Guid? CustomerId { get; set; }

        public Blog Blog { get; set; }
    }
}
