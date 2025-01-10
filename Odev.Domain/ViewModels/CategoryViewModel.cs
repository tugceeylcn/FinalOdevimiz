using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        [Display(Name = "Kategori Adı : ")]
        public string CategoryName { get; set; }

        [Display(Name = "Kategori Resmi : ")]
        public string CategoryImage { get; set; }

        [Display(Name = "Üst Kategori : ")]
        public Guid? TopCategoryId { get; set; }

        [Display(Name = "Görüntüleme Sırası : ")]
        public int DisplayOrder { get; set; }

        [Display(Name = "Popüler: ")]
        public bool IsPopular { get; set; }

        [Display(Name = "Üst Kategori : ")]
        public string UstKategoriAd { get; set; }

        [Display(Name = "Sayı : ")]
        public int Count { get; set; }

        [Display(Name = "Slug : ")]
        public string Slug { get; set; }
    }
}
