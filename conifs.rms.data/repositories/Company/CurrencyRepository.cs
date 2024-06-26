using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using conifs.rms.data.entities;

namespace conifs.rms.data.repositories
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly CompanyDataContext _context;

        public CurrencyRepository(CompanyDataContext context)
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
            return currency ?? new Currency();
        }

        public async Task<Currency> AddCurrency(Currency newCurrency)
        {
            _context.Currencies.Add(newCurrency);
            await _context.SaveChangesAsync();
            return newCurrency;
        }

        public async Task<Currency> UpdateCurrency(Currency currency)
        {
            _context.Currencies.Update(currency);
            await _context.SaveChangesAsync();
            return currency;
        }

        public async Task DeleteCurrency(Guid currencyID)
        {
            var currency = await _context.Currencies.FindAsync(currencyID);
            if(currency != null)
            {
                _context.Currencies.Remove(currency);
                await _context.SaveChangesAsync();
            }

        }
    }
}
