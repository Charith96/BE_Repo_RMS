using conifs.rms.data.entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

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
            return country ?? throw new KeyNotFoundException($"Country with ID {countryId} not found.");
            //throw new KeyNotFoundException($"Country with ID {countryId} not found.");
        }

        //public async Task<Country> GetCountryByName(string countryName)
        //{
        //    return await _context.Countries.FirstOrDefaultAsync(c => c.CountryName == countryName);
        //}

        public async Task<Country> AddCountry(Country newCountry)
        {
            try
            {
                _context.Countries.Add(newCountry);
                await _context.SaveChangesAsync();
                return newCountry;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlEx &&
                   (sqlEx.Number == 2601 || sqlEx.Number == 2627))
                {
                    throw new DuplicateNameException("A country with this name already exists.", ex);
                }
                throw;
            }
        }
           

        public async Task<Country> UpdateCountry(Country country)
        {
            try
            {
                _context.Countries.Update(country);
                await _context.SaveChangesAsync();
                return country;
            }
            catch(DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlEx &&
                   (sqlEx.Number == 2601 || sqlEx.Number == 2627))
                {
                    throw new DuplicateNameException("A country with this name already exists.", ex);
                }
                throw;
            }
            
        }

        public async Task DeleteCountry(Guid countryId)
        {
            var country = await _context.Countries.FindAsync(countryId);
            if (country != null)
            {
                _context.Countries.Remove(country);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Country with ID {countryId} not found.");
            }
        }
    }
}
