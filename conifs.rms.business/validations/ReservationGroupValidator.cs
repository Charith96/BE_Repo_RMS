using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using conifs.rms.data.entities;

namespace conifs.rms.business.validations
{
    public class ReservationGroupValidator : AbstractValidator<ReservationGroup>
    {
        public ReservationGroupValidator() {
            RuleFor(rg => rg.GroupId)
                .NotEmpty().WithMessage("Group ID is required.")
                .Length(8).WithMessage("Group ID must be 8 characters long.");

            RuleFor(rg => rg.GroupName)
                .NotEmpty().WithMessage("Group Name is required.")
                .MaximumLength(20).WithMessage("Group Name cannot exceed 20 characters.");
        }
    }
}
