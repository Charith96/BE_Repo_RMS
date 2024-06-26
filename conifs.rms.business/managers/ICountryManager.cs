using conifs.rms.dto.Company;

namespace conifs.rms.business.managers
{
    public interface ICountryManager
    {
        Task<IEnumerable<CountryDto>> GetAllCountries();
        Task<CountryDto> GetCountryById(Guid countryId);
        Task<CountryDto> AddCountry(CountryDto newCountryDto);
        Task<CountryDto> UpdateCountry(CountryDto updatedCountryDto);
        Task DeleteCountry(Guid countryId);
    }
}
