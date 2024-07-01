using conifs.rms.data;
using conifs.rms.data.entities;
using conifs.rms.data.repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace conifs.rms.business.validators
{
    public class CountryValidator : AbstractValidator<Country>
    {
        private readonly ApplicationDbContext _context;
        public CountryValidator(ApplicationDbContext context) 
        {
             _context = context;


            RuleFor(c => c.CountryName)
                .NotEmpty().WithMessage("Company Name is required.")
                .MaximumLength(100).WithMessage("Counrty Name must be 100 characters long.")
                .MustAsync(BeUniqueCountryName).WithMessage("Country Name must be unique.");
        }

        private async Task<bool> BeUniqueCountryName(Country country, string countryName, CancellationToken cancellationToken)
        {
            return !await _context.Countries.AnyAsync(c => c.CountryName == countryName && c.CountryID != country.CountryID, cancellationToken);
        }
    }
}
