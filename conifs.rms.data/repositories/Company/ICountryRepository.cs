using conifs.rms.data.entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace conifs.rms.data.repositories
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllCountriesAsync();
        Task<Country> GetCountryByIdAsync(int countryId);
        Task AddCountryAsync(Country country);
        Task UpdateCountryAsync(Country country);
        Task DeleteCountryAsync(int countryId);
    }
}
