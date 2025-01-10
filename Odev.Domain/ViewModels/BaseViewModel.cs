using Odev.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class BaseViewModel
    {
        [Display(Name = "Id : ")]
        public Guid Id { get; set; }

        [Display(Name = "Durum : ")]
        public bool IsActive { get; set; }

        [Display(Name = "Silindi mi : ")]
        public bool IsDeleted { get; set; }

        [Display(Name = "Oluşturulma Tarihi : ")]
        public DateTime? CreatedDateTime { get; set; }

        [Display(Name = "Oluşturun Kişi : ")]
        public Guid? CreatedUserId { get; set; }

        [Display(Name = "Güncellenme Tarihi : ")]
        public DateTime? UpdatedDateTime { get; set; }

        [Display(Name = "Son Güncelleme Yapan Kişi : ")]
        public Guid? UpdatedUserId { get; set; }

        [Display(Name = "Dil : ")]
        public LanguageSelection Language { get; set; }
    }
}
