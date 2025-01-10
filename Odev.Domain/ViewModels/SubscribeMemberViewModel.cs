using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.ViewModels
{
    public class SubscribeMemberViewModel : BaseViewModel
    {
        [Display(Name = "Email : ")]
        public string Email { get; set; }// E mail
    }
}
