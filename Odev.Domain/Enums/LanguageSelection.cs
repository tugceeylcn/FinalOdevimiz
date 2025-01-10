using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.Enums
{
    public enum LanguageSelection : byte
    {
        [Display(Name = "Türkçe")]
        TR = 1,
        [Display(Name = "İngilizce")]
        EN = 2
    }
}
