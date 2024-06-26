using System.Collections.Generic;
using System.Threading.Tasks;
using conifs.rms.dto.Company;

namespace conifs.rms.business.managers
{
    public interface ICurrencyManager
    {
        Task<IEnumerable<CurrencyDto>> GetAllCurrencies();
        Task<CurrencyDto> GetCurrencyById(Guid currencyID);
        Task<CurrencyDto> AddCurrency(CurrencyDto newCurrencyDto);
        Task<CurrencyDto> UpdateCurrency(CurrencyDto updatedCurrencyDto);
        Task DeleteCurrency(Guid currencyID);
    }
}
