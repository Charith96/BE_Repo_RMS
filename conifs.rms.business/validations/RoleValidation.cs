using FluentValidation;
using conifs.rms.data.entities;

namespace conifs.rms.business.validations
{
    public class RoleValidation : AbstractValidator<Role>
    {
        public RoleValidation()
        {
            RuleFor(role => role.RoleID)
                .NotEmpty().WithMessage("RoleID is required.")
                .Length(1, 8).WithMessage("RoleID must be between 1 and 8 characters.");

            RuleFor(role => role.RoleName)
                .NotEmpty().WithMessage("RoleName is required.")
                .Length(1, 20).WithMessage("RoleName must be between 1 and 20 characters.");
        }
    }
}
