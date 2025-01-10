using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class BlogViewModel : BaseViewModel
    {
        [Display(Name = "Başlık : ")]
        public string BlogTitle { get; set; }

        [Display(Name = "İçerik : ")]
        public string BlogContent { get; set; }

        [Display(Name = "Blog Resim : ")]
        public string BlogImage { get; set; }

        [Display(Name = "Etiketler : ")]
        public string BlogTicket { get; set; }

        [Display(Name = "Kategori : ")]
        public Guid? CategoryId { get; set; }

        [Display(Name = "Görüntüleme Sırası : ")]
        public int DisplayOrder { get; set; }

        [Display(Name = "Kategori Adı : ")]
        public string CategoryName { get; set; }

        [Display(Name = "Beğeni : ")]
        public int? LikeCount { get; set; }

        [Display(Name = "Kısa Url : ")]
        public string ShortUrl { get; set; }

        [Display(Name = "Slug : ")]
        public string Slug { get; set; }
    }
}
