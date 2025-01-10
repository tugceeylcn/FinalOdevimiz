using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class NewsViewModel : BaseViewModel
    {
        [Display(Name = " Haber Başlığı : ")]
        public string Title { get; set; }

        [Display(Name = " Haber Alt Başlığı : ")]
        public string SubTitle { get; set; }

        [Display(Name = " Haber Metni : ")]
        public string Text { get; set; }

        [Display(Name = " Haber Resmi : ")]
        public string PictureUrl { get; set; }

        [Display(Name = " Haber Tarihi : ")]
        public DateTime NewsDate { get; set; }

        [Display(Name = "Görüntüleme Sırası : ")]
        public int DisplayOrder { get; set; }

        [Display(Name = "Slug : ")]
        public string Slug { get; set; }
    }
}
