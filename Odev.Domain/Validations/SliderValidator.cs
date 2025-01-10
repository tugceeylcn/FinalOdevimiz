using FluentValidation;
using Odev.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.Validations
{
    public class SliderValidator : BaseValidator<SliderViewModel>
    {
        public SliderValidator()
        {
            RuleFor(x => x.Language)
                .NotEmpty().WithMessage("Boş Geçilemez.");

            RuleFor(x => x.TextOne)
                .NotEmpty().WithMessage("Boş Geçilemez.");

            RuleFor(x => x.TextTwo)
                .NotEmpty().WithMessage("Boş Geçilemez.");

            RuleFor(x => x.TextThree)
                .NotEmpty().WithMessage("Boş Geçilemez.");
        }
    }
}
