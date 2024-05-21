using FluentValidation;
using conifs.rms.data.entities;

namespace conifs.rms.business.validations
{
    public class PrivilegeValidation : AbstractValidator<Privilege>
    {
        public PrivilegeValidation()
        {
            RuleFor(privilege => privilege.PrivilegeId)
                .NotEmpty().WithMessage("PrivilegeId is required.")
                .Length(1, 50).WithMessage("PrivilegeId must be between 1 and 50 characters.");

            RuleFor(privilege => privilege.PrivilegeName)
                .NotEmpty().WithMessage("PrivilegeName is required.")
                .Length(1, 20).WithMessage("PrivilegeName must be between 1 and 20 characters.");
        }
    }
}
