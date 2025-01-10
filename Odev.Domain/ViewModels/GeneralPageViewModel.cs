using Odev.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class GeneralPageViewModel : BaseViewModel
    {
        [Display(Name = "Başlık : ")]
        public string Title { get; set; }// Başlık

        [Display(Name = "İçerik : ")]
        public string Content { get; set; }//İçerik

        [Display(Name = "Resim : ")]
        public string Image { get; set; }//Resim

        public PageName Page { get; set; } // Sayfa İsmi
    }
}
