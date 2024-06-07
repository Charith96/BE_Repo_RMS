using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using conifs.rms.data.entities;
using conifs.rms.dto.ReservationGroup;

namespace conifs.rms.business.validators
{
    public class ReservationGroupValidator : AbstractValidator<ReservationGroupDto>
    {
        public ReservationGroupValidator()
        {
            RuleFor(rg => rg.GroupId)
                .NotEmpty().WithMessage("Group ID is required.")
                .MaximumLength(8).WithMessage("Group ID cannot be longer than 8 characters.");

            RuleFor(rg => rg.GroupName)
                .NotEmpty().WithMessage("Group Name is required.")
                .MaximumLength(20).WithMessage("Group Name cannot exceed 20 characters.");
        }
    }
}
