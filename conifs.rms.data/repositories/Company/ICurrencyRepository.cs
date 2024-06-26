using System.Collections.Generic;
using System.Threading.Tasks;
using conifs.rms.data.entities;

namespace conifs.rms.data.repositories
{
    public interface ICurrencyRepository
    {
        Task<IEnumerable<Currency>> GetAllCurrencies();
        Task<Currency> GetCurrencyById(Guid currencyID);
        Task<Currency> AddCurrency(Currency newCurrency);
        Task<Currency> UpdateCurrency(Currency currency);
        Task DeleteCurrency(Guid currencyID);
    }
}
