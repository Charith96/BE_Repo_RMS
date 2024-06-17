using conifs.rms.data.entities;
using FluentValidation;

namespace conifs.rms.business.validators
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(c => c.CompanyCode)
                .NotEmpty().WithMessage("Company Code is required.")
                .MaximumLength(50).WithMessage("Company Code must be 8 characters long.");

            RuleFor(c => c.CompanyName)
                .NotEmpty().WithMessage("Company Name is required.")
                .MaximumLength(50).WithMessage("Company Name cannot exceed 50 characters.");

            RuleFor(c => c.Description)
                .MaximumLength(50).WithMessage("Description cannot exceed 50 characters.");

            RuleFor(c => c.Country)
                .NotEmpty().WithMessage("Country is required.")
                .MaximumLength(50).WithMessage("Country cannot exceed 50 characters.");

            RuleFor(c => c.Currency)
                .NotEmpty().WithMessage("Currency is required.")
                .Length(3).WithMessage("Currency must be 3 characters long.");

            RuleFor(c => c.Address01)
                .NotEmpty().WithMessage("Address Line 1 is required.")
                .MaximumLength(50).WithMessage("Address Line 1 cannot exceed 50 characters.");

            RuleFor(c => c.Address02)
                .MaximumLength(50).WithMessage("Address Line 2 cannot exceed 50 characters.");
        }
    }
}