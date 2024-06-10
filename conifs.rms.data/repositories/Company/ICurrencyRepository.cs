using System.Collections.Generic;
using System.Threading.Tasks;
using conifs.rms.data.entities;

namespace conifs.rms.data.repositories
{
    public interface ICurrencyRepository
    {
        Task<List<Currency>> GetAllCurrenciesAsync();
        Task<Currency> GetCurrencyByIdAsync(int id);
        Task AddCurrencyAsync(Currency currency);
        Task UpdateCurrencyAsync(Currency currency);
        Task DeleteCurrencyAsync(int id);
    }
}
