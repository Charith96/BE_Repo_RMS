using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using conifs.rms.data.entities;
using conifs.rms.dto.ReservationItem;
using FluentValidation;

namespace conifs.rms.business.validators
{
    public class ReservationItemValidator : AbstractValidator<ReservationItemDto>
    {
        public ReservationItemValidator()
        {
            RuleFor(ri => ri.ItemId)
                .NotEmpty().WithMessage("Item ID is required.")
                .MaximumLength(8).WithMessage("Item ID cannot be longer than 8 characters.");

            RuleFor(ri => ri.ItemName)
                .NotEmpty().WithMessage("Item Name is required.")
                .MaximumLength(20).WithMessage("Item Name cannot exceed 20 characters.");

            RuleFor(ri => ri.TimeSlotType)
                .NotEmpty().WithMessage("Time Slot Type is required.");

            RuleFor(ri => ri.NoOfSlots)
                .InclusiveBetween(0, 20).WithMessage("No of Slots must be between 0 and 20.");

            RuleFor(ri => ri.NoOfReservations)
                .NotEmpty().WithMessage("No of Reservations is required.");

            RuleFor(ri => ri.Capacity)
                .NotEmpty().WithMessage("Capacity is required.");


        }
    }
}
