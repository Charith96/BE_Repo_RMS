using conifs.rms.dto;
using FluentValidation;
using FluentValidation.Results;


namespace conifs.rms.business.validations;
public class DateRangeValidator : AbstractValidator<object>
{
    public DateRangeValidator()
    {
        When(x => x is CreateUserDto, () =>
        {
            RuleFor(x => ((CreateUserDto)x).ValidFrom)
                .NotEmpty().WithMessage("Start date is required.")
                .LessThan(x => ((CreateUserDto)x).ValidTill).WithMessage("Start date must be before the end date.");

            RuleFor(x => ((CreateUserDto)x).ValidTill)
                .NotEmpty().WithMessage("End date is required.")
                .GreaterThan(x => ((CreateUserDto)x).ValidFrom).WithMessage("End date must be after the start date.");
        });

        When(x => x is PutUserDto, () =>
        {
            RuleFor(x => ((PutUserDto)x).ValidFrom)
                .NotEmpty().WithMessage("Start date is required.")
                .LessThan(x => ((PutUserDto)x).ValidTill).WithMessage("Start date must be before the end date.");

            RuleFor(x => ((PutUserDto)x).ValidTill)
                .NotEmpty().WithMessage("End date is required.")
                .GreaterThan(x => ((PutUserDto)x).ValidFrom).WithMessage("End date must be after the start date.");
        });
    }

    public override ValidationResult Validate(ValidationContext<object> context)
    {
        if (context.InstanceToValidate is CreateUserDto || context.InstanceToValidate is PutUserDto)
        {
            return base.Validate(context);
        }

        return new ValidationResult(new[]
        {
            new ValidationFailure("", "Unsupported object type")
        });
    }
}
