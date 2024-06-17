using conifs.rms.data.entities;

namespace conifs.rms.data.repositories
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllCountries();
        Task<Country> GetCountryById(int countryId);
        Task<Country> AddCountry(Country newCountry);
        Task<Country> UpdateCountry(Country country);
        Task DeleteCountry(int countryId);
    }
}
