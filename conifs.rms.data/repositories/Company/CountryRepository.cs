using conifs.rms.data.entities;
using Microsoft.EntityFrameworkCore;

namespace conifs.rms.data.repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _context;

        public CountryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> GetCountryById(Guid countryId)
        {
            var country = await _context.Countries.FindAsync(countryId);
            return country ?? new Country();
                //throw new KeyNotFoundException($"Country with ID {countryId} not found.");
        }

        public async Task<Country> AddCountry(Country newCountry)
        {
            // Remove any explicit setting of CountryID
           // country.CountryID = 0; // or default(int) if the type is nullable

            _context.Countries.Add(newCountry);
            await _context.SaveChangesAsync();
            return newCountry;
        }

        public async Task<Country> UpdateCountry(Country country)
        {
            _context.Countries.Update(country);
            await _context.SaveChangesAsync();
            return country;
        }

        public async Task DeleteCountry(Guid countryId)
        {
            var country = await _context.Countries.FindAsync(countryId);
            if (country != null)
            {
                _context.Countries.Remove(country);
                await _context.SaveChangesAsync();
            }
        }
    }
}
