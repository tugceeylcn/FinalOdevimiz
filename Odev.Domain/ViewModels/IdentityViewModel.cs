using Odev.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class IdentityViewModel : BaseViewModel
    {
        #region -Properties

        [Display(Name = "İçerik : ")]
        public string Content { get; set; }//İçerik

        [Display(Name = "Resim : ")]
        public string Image { get; set; }//Resim

        [Display(Name = "Ek Dosya : ")]
        public string UrlDocument { get; set; }//Dosya Yolu

        [Display(Name = "Dosya Tipi : ")]
        public DocumentCategory DocumentCategory { get; set; }//Dosya Tipi

        #endregion -Properties
    }
}
