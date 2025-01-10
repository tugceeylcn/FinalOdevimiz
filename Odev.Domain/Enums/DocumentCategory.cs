using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.Enums
{
    public enum DocumentCategory : byte
    {
        [Display(Name = "Pdf")]
        Pdf = 1,
        [Display(Name = "Word")]
        Word = 2,
        [Display(Name = "Diğer")]
        Diger = 3
    }
}
