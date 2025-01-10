using FluentValidation;
using Odev.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Odev.Domain.Validations
{
    public class DocumentValidator : BaseValidator<DocumentViewModel>
    {
        public DocumentValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Boş Geçilemez.");

            RuleFor(x => x.DocumentDate)
                .NotEmpty().WithMessage("Boş Geçilemez.");

            RuleFor(x => x.DocumentCategory)
                .NotEmpty().WithMessage("Boş Geçilemez.");
        }
    }
}