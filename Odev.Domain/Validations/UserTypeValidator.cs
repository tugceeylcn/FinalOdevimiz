using FluentValidation;
using Odev.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.Validations
{
    public class UserTypeValidator : BaseValidator<UserTypeViewModel>
    {
        public UserTypeValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Boş Geçilemez.");
        }
    }
}
