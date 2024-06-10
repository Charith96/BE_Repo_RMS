using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using conifs.rms.data.entities;

namespace conifs.rms.data.repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly CompanyDataContext _context;

        public CountryRepository(CompanyDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> GetCountryByIdAsync(int countryId)
        {
            var country = await _context.Countries.FindAsync(countryId);
            return country ?? throw new KeyNotFoundException($"Country with ID {countryId} not found.");
        }

        public async Task AddCountryAsync(Country country)
        {
            // Remove any explicit setting of CountryID
           // country.CountryID = 0; // or default(int) if the type is nullable

            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
        }



        public async Task UpdateCountryAsync(Country country)
        {
            _context.Entry(country).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCountryAsync(int countryId)
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
