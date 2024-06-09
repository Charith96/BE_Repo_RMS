using conifs.rms.data.entities;
using FluentValidation;

namespace conifs.rms.business.validations
{
    public class PrivilegeValidation : AbstractValidator<Privilege>
    {
        public PrivilegeValidation()
        {
            RuleFor(privilege => privilege.PrivilegeName)
                .NotEmpty().WithMessage("Privilege Name is required.")
                .Length(1, 50).WithMessage("Privilege Name must be between 1 and 50 characters.");
        }
    }
}
