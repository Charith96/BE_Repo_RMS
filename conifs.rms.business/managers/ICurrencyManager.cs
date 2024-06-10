using System.Collections.Generic;
using System.Threading.Tasks;
using conifs.rms.dto.Company;

namespace conifs.rms.business.managers
{
    public interface ICurrencyManager
    {
        Task<List<CurrencyDto>> GetAllCurrenciesAsync();
        Task<CurrencyDto> GetCurrencyByIdAsync(int id);
        Task AddCurrencyAsync(CurrencyDto currencyDto);
        Task UpdateCurrencyAsync(CurrencyDto currencyDto);
        Task DeleteCurrencyAsync(int id);
    }
}
