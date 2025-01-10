using FluentValidation;
using Odev.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.Validations
{
    public class UserValidator : BaseValidator<UserViewModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Boş Geçilemez.");

            RuleFor(x => x.NameSurname)
                .NotEmpty().WithMessage("Boş Geçilemez.");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Boş Geçilemez.");

            RuleFor(x => x.Pwd)
                .NotEmpty().WithMessage("Boş Geçilemez.");

            RuleFor(x => x.UserTypeId)
                .NotEmpty().WithMessage("Boş Geçilemez.");
        }
    }
}