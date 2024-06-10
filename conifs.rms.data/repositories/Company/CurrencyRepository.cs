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

        public async Task<List<Currency>> GetAllCurrenciesAsync()
        {
            return await _context.Currencies.ToListAsync();
        }

        public async Task<Currency> GetCurrencyByIdAsync(int id)
        {
            return await _context.Currencies.FindAsync(id);
        }

        public async Task AddCurrencyAsync(Currency currency)
        {
            _context.Currencies.Add(currency);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCurrencyAsync(Currency currency)
        {
            _context.Entry(currency).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCurrencyAsync(int id)
        {
            var currency = await _context.Currencies.FindAsync(id);
            _context.Currencies.Remove(currency);
            await _context.SaveChangesAsync();
        }
    }
}
