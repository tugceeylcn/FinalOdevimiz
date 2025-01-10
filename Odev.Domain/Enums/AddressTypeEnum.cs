using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.Enums
{
    public enum AddressTypeEnum : byte
    {
        [Display(Name = "Bireyel")]
        Individual = 1,
        [Display(Name = "Kurumsal")]
        Institutional = 2,
    }
}
