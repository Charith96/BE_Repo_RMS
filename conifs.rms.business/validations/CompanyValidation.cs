using conifs.rms.data;
using conifs.rms.data.entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace conifs.rms.business.validators
{
    public class CompanyValidator : AbstractValidator<Company>
    {

        private readonly ApplicationDbContext _context;
        public CompanyValidator(ApplicationDbContext context, bool isNew)
        {

            _context = context;

            RuleFor(c => c.CompanyCode)
                .NotEmpty().WithMessage("Company Code is required.")
                .MaximumLength(8).WithMessage("Company Code must be 8 characters long.");
            
            if (isNew)
            { 
                RuleFor(c => c.CompanyCode)
                .MustAsync(async (code, cancellation) =>
                 {
                     return !await _context.Companies.AnyAsync(c => c.CompanyCode == code, cancellation);
                 }).WithMessage("Company Code must be unique.");
            }

            RuleFor(c => c.CompanyName)
                .NotEmpty().WithMessage("Company Name is required.")
                .MaximumLength(50).WithMessage("Company Name cannot exceed 50 characters.");

            RuleFor(c => c.Description)
                .MaximumLength(50).WithMessage("Description cannot exceed 50 characters.");

            RuleFor(c => c.CountryID)
                .NotEmpty().WithMessage("Country is required.");

            RuleFor(c => c.CurrencyID)
                .NotEmpty().WithMessage("Currency is required.");

            RuleFor(c => c.Address01)
                .NotEmpty().WithMessage("Address Line 1 is required.")
                .MaximumLength(50).WithMessage("Address Line 1 cannot exceed 50 characters.");

            RuleFor(c => c.Address02)
                .MaximumLength(50).WithMessage("Address Line 2 cannot exceed 50 characters.");
        }
    }
}