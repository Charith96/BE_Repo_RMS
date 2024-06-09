using conifs.rms.data.entities;
using FluentValidation;

namespace conifs.rms.business.validations
{
    public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            RuleFor(customer => customer.CustomerID)
                .NotEmpty().WithMessage("Customer ID is required.")
                .Length(1, 8).WithMessage("Customer ID must be between 1 and 8 characters.");

            RuleFor(customer => customer.FullName)
                .NotEmpty().WithMessage("Full name is required.")
                .Length(1, 50).WithMessage("Full name must be between 1 and 50 characters.");

            RuleFor(customer => customer.Identifier)
                .NotEmpty().WithMessage("Identifier is required.")
                .Length(1, 20).WithMessage("Identifier must be between 1 and 20 characters.");

            RuleFor(customer => customer.Address)
                .NotEmpty().WithMessage("Address is required.")
                .Length(1, 50).WithMessage("Address must be between 1 and 50 characters.");

            RuleFor(customer => customer.Email)
                .Length(0, 50).WithMessage("Email must be up to 50 characters.")
                .EmailAddress().WithMessage("A valid email address is required.")
                .When(customer => !string.IsNullOrEmpty(customer.Email));

            RuleFor(customer => customer.ContactNo)
                .NotEmpty().WithMessage("Contact number is required.")
                .Length(1, 15).WithMessage("Contact number must be between 1 and 15 characters.");
        }
    }
}