using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class BlogCommentViewModel : BaseViewModel
    {
        [Display(Name = "Ad Soyad : ")]
        public string FirstLastName { get; set; }

        [Display(Name = "Email : ")]
        public string Email { get; set; }

        [Display(Name = "Yorum Detay : ")]
        public string CommentDetail { get; set; }

        public Guid? CustomerId { get; set; }

        [Display(Name = "Blog Id : ")]
        public Guid BlogId { get; set; }
    }
}
