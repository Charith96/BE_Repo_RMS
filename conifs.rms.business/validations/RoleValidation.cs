using conifs.rms.data.entities;
using FluentValidation;

namespace conifs.rms.business.validations
{
    public class RoleValidation : AbstractValidator<Role>
    {
        public RoleValidation()
        {
            RuleFor(role => role.RoleID)
                .NotEmpty().WithMessage("Role ID is required.")
                .Length(1, 8).WithMessage("Role ID must be between 1 and 8 characters.");

            RuleFor(role => role.RoleName)
                .NotEmpty().WithMessage("Role Name is required.")
                .Length(1, 20).WithMessage("Role Name must be between 1 and 20 characters.");
        }
    }
}