using FluentValidation;
using conifs.rms.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using conifs.rms.data;
using Microsoft.EntityFrameworkCore;

namespace conifs.rms.business.validators
{
    public class CurrencyValidator : AbstractValidator<Currency>
    {

        private readonly ApplicationDbContext _context;
        public CurrencyValidator(ApplicationDbContext context)
        {
            _context = context;

            RuleFor(c => c.CurrencyName)
                .NotEmpty().WithMessage("Currecy Name is required.")
                .MaximumLength(3).WithMessage("Currency Name must be 3 characters long.")
                .MustAsync(BeUniqueCurrencyName).WithMessage("Currency Name must be unique.");
        }

        private async Task<bool> BeUniqueCurrencyName(Currency currency, string currencyName, CancellationToken cancellationToken)
        {
            return !await _context.Currencies.AnyAsync(c => c.CurrencyName == currencyName && c.CurrencyID != currency.CurrencyID, cancellationToken);
        }
    }
}
