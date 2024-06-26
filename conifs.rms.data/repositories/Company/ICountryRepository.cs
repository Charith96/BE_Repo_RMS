using conifs.rms.data.entities;

namespace conifs.rms.data.repositories
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllCountries();
        Task<Country> GetCountryById(Guid countryId);
        Task<Country> AddCountry(Country newCountry);
        Task<Country> UpdateCountry(Country country);
        Task DeleteCountry(Guid countryId);
    }
}
