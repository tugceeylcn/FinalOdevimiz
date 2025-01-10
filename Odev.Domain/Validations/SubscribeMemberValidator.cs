using FluentValidation;
using Odev.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.Validations
{
    public class SubscribeMemberValidator : BaseValidator<SubscribeMemberViewModel>
    {
        public SubscribeMemberValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Boş Geçilemez.");
        }
    }
}
