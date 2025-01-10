using FluentValidation;
using Odev.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.Validations
{
    public class NewsValidator : BaseValidator<NewsViewModel>
    {
        public NewsValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Boş Geçilemez.");

            RuleFor(x => x.Language)
                .NotEmpty().WithMessage("Boş Geçilemez.");

            RuleFor(x => x.SubTitle)
                .NotEmpty().WithMessage("Boş Geçilemez.");

            RuleFor(x => x.Text)
                .NotEmpty().WithMessage("Boş Geçilemez.");
        }
    }
}
