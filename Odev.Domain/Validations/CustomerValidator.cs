using FluentValidation;
using Odev.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.Validations
{
    public class CustomerValidator : BaseValidator<CustomersViewModel>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.CustomerFirstName)
                .NotEmpty().WithMessage("Ad boş Geçilemez.");

            RuleFor(x => x.CustomerLastName)
                .NotEmpty().WithMessage("Soyad boş Geçilemez.");

            RuleFor(x => x.CustomerEmail)
                .NotEmpty().WithMessage("E-Posta boş Geçilemez.");

            RuleFor(x => x.CustomerPassword)
                .NotEmpty().WithMessage("Şifre boş Geçilemez.");

            RuleFor(x => x.CustomerPhone)
                .NotEmpty().WithMessage("Cep Telefonu boş Geçilemez.");
        }
    }
}
