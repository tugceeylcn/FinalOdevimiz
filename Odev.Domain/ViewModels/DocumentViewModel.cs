using Odev.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class DocumentViewModel : BaseViewModel
    {
        #region -Properties

        [Display(Name = "Başlık : ")]
        public string Title { get; set; }// Başlık

        [Display(Name = "Url : ")]
        public string Url { get; set; }//Url

        [Display(Name = "Tarih : ")]
        public DateTime DocumentDate { get; set; }//Tarihi
        public DocumentCategory DocumentCategory { get; set; }

        #endregion -Properties
    }
}
