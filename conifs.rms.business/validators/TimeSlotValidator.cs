using System;
using System.Linq;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using conifs.rms.data.entities;
using conifs.rms.data;
namespace conifs.rms.business.validators
{
    public class TimeSlotValidator : AbstractValidator<TimeSlot>
    {
        private readonly DbContext _context;

        public TimeSlotValidator(DbContext context)
        {
            _context = context;

            RuleFor(ts => ts.StartTime)
                .NotEmpty().WithMessage("Start Time is required.");

            RuleFor(ts => ts.EndTime)
                .NotEmpty().WithMessage("End Time is required.")
                .NotEqual(ts => ts.StartTime).WithMessage("End Time cannot be equal to Start Time.");

        }

        
    }
}
