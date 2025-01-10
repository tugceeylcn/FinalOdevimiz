using FluentValidation;
using Odev.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.Validations
{
    public class MailSettingValidator : BaseValidator<MailSettingViewModel>
    {
        public MailSettingValidator()
        {
            RuleFor(x => x.CCMail)
                .NotEmpty().WithMessage("Boş Geçilemez.");

            RuleFor(x => x.Host)
                .NotEmpty().WithMessage("Boş Geçilemez.");

            RuleFor(x => x.MailAddress)
                .NotEmpty().WithMessage("Boş Geçilemez.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Boş Geçilemez.");

            RuleFor(x => x.Port)
                .NotEmpty().WithMessage("Boş Geçilemez.");

            RuleFor(x => x.Ssl)
                .NotEmpty().WithMessage("Boş Geçilemez.");
        }
    }
}
