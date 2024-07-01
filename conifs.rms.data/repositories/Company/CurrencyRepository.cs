using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using conifs.rms.data.entities;
using Microsoft.Data.SqlClient;
using System.Data;

namespace conifs.rms.data.repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly ApplicationDbContext _context;

        public CurrencyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Currency>> GetAllCurrencies()
        {
            return await _context.Currencies.ToListAsync();
        }

        public async Task<Currency> GetCurrencyById(Guid currencyID)
        {
            var currency = await _context.Currencies.FindAsync(currencyID);
            return currency ?? throw new KeyNotFoundException($"Currency with ID {currencyID} not found.");
        }

        //public async Task<Currency> GetCurrencyByName(string currencyName)
        //{
        //    return await _context.Currencies.FirstOrDefaultAsync(c => c.CurrencyName == currencyName);
        //}

        public async Task<Currency> AddCurrency(Currency newCurrency)
        {
            try
            {
                _context.Currencies.Add(newCurrency);
                await _context.SaveChangesAsync();
                return newCurrency;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlEx &&
                   (sqlEx.Number == 2601 || sqlEx.Number == 2627))
                {
                    throw new DuplicateNameException("A currency with this name already exists.", ex);
                }
                throw;
            }
        }

        public async Task<Currency> UpdateCurrency(Currency currency)
        {
            try
            {
                _context.Currencies.Update(currency);
                await _context.SaveChangesAsync();
                return currency;
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlEx &&
                   (sqlEx.Number == 2601 || sqlEx.Number == 2627))
                {
                    throw new DuplicateNameException("A currency with this name already exists.", ex);
                }
                throw;
            }
        }

        public async Task DeleteCurrency(Guid currencyID)
        {
            var currency = await _context.Currencies.FindAsync(currencyID);
            if(currency != null)
            {
                _context.Currencies.Remove(currency);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"Currency with ID {currencyID} not found.");
            }
        }
    }
}
