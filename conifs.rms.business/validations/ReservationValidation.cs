using FluentValidation;
using conifs.rms.data.entities;
using conifs.rms.dto.Reservation;
using FluentValidation.Results;
using FluentValidation.Validators;

namespace conifs.rms.business.validations
{
    namespace conifs.rms.business.validations
    {
        public class GetReservationValidator : AbstractValidator<GetReservation>
        {
            public GetReservationValidator()
            {
                RuleFor(x => x.Time1)
                    .NotEmpty().WithMessage("Start date is required.")
                    .LessThan(x => x.Time2).WithMessage("Start date must be before the end date.");

                RuleFor(x => x.Time2)
                    .NotEmpty().WithMessage("End date is required.")
                    .GreaterThan(x => x.Time1).WithMessage("End date must be after the start date.");

                RuleFor(x => x.ReservationID)
                    .NotEmpty().WithMessage("Reservation ID is required.");

                RuleFor(x => x.CustomerID)
                    .NotEmpty().WithMessage("Customer ID is required.");

                RuleFor(x => x.GroupId)
                    .NotEmpty().WithMessage("Group ID is required.");

                RuleFor(x => x.ItemId)
                    .NotEmpty().WithMessage("Item ID is required.");

                RuleFor(x => x.NoOfPeople)
                    .GreaterThan(0).WithMessage("Number of people must be greater than 0.");
            }
        }
    }
}

