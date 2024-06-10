using System.Collections.Generic;
using System.Threading.Tasks;
//using conifs.rms.api;  // Add this line to include the namespace for CountryDto
using conifs.rms.data.entities;
using conifs.rms.dto.Company;

namespace conifs.rms.business.managers
{
    public interface ICountryManager
    {
        Task<IEnumerable<CountryDto>> GetAllCountriesAsync();
        Task<CountryDto> GetCountryByIdAsync(int countryId);
        Task AddCountryAsync(CountryDto countryDto);
        Task UpdateCountryAsync(CountryDto countryDto);
        Task DeleteCountryAsync(int countryId);
    }
}
