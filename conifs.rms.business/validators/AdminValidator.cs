using conifs.rms.dto.Admin;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conifs.rms.business.validators
{
    public class AdminValidator : AbstractValidator<AdminDto>
    {
        public AdminValidator()
        {
            RuleFor(a => a.FirstName)
                .NotEmpty().WithMessage("First Name is required.")
                .MaximumLength(20).WithMessage("First Name cannot exceed 20 characters.");

            RuleFor(a => a.LastName)
                .MaximumLength(20).WithMessage("Last Name cannot exceed 20 characters.");

            RuleFor(a => a.Email)
                .NotEmpty().WithMessage("Email is required.")
                .MaximumLength(50).WithMessage("Email cannot exceed 50 characters.")
                .EmailAddress().WithMessage("Email is not valid.");

            RuleFor(a => a.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.");
        }
    }
}
