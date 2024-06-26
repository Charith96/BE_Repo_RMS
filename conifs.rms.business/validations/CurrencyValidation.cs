using FluentValidation;
using conifs.rms.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conifs.rms.business.validators
{
    public class CurrencyValidator : AbstractValidator<Currency>
    {
        public CurrencyValidator()
        {
            RuleFor(c => c.CurrencyName)
                .NotEmpty().WithMessage("Currecy Name is required.")
                .MaximumLength(3).WithMessage("Currency Name must be 3 characters long.");
        }
    }
}
