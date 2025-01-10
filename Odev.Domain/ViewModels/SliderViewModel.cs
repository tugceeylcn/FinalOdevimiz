using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class SliderViewModel : BaseViewModel
    {
        [Display(Name = "Resim : ")]
        public string Image { get; set; }

        [Display(Name = "Metin 1 : ")]
        public string TextOne { get; set; }

        [Display(Name = "Metin 2 : ")]
        public string TextTwo { get; set; }

        [Display(Name = "Metin 3 : ")]
        public string TextThree { get; set; }

        [Display(Name = "Satın Al Butonu : ")]
        public bool IsSale { get; set; }

        [Display(Name = "Görüntüleme Sırası : ")]
        public int DisplayOrder { get; set; }

        [Display(Name = "Ürün : ")]
        public Guid ProductId { get; set; }
    }
}
