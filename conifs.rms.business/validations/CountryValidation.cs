using FluentValidation;
using conifs.rms.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conifs.rms.business.validators
{
    public class CountryValidator : AbstractValidator<Country>
    {
        public CountryValidator() 
        {
            RuleFor(c => c.CountryName)
                .NotEmpty().WithMessage("Company Name is required.")
                .MaximumLength(100).WithMessage("Counrty Name must be 100 characters long.");
        }
    }
}
