using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using conifs.rms.data.repositories;
using conifs.rms.data.entities;
using conifs.rms.dto.Company;
using conifs.rms.business.managers;

namespace conifs.rms.business
{
    public class CountryManager : ICountryManager
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryManager(ICountryRepository countryRepository, IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CountryDto>> GetAllCountriesAsync()
        {
            var countries = await _countryRepository.GetAllCountriesAsync();
            return _mapper.Map<IEnumerable<CountryDto>>(countries);
        }

        public async Task<CountryDto> GetCountryByIdAsync(int countryId)
        {
            var country = await _countryRepository.GetCountryByIdAsync(countryId);
            return _mapper.Map<CountryDto>(country);
        }

        public async Task AddCountryAsync(CountryDto countryDto)
        {
            // Ensure that the CountryID is not set before mapping
           // countryDto.CountryID = 0; // or default(int) if the type is nullable

            var country = _mapper.Map<Country>(countryDto);
            await _countryRepository.AddCountryAsync(country);
        }

        public async Task UpdateCountryAsync(CountryDto countryDto)
        {
            // Ensure that the CountryID is not set before mapping
          //  countryDto.CountryID = 0; // or default(int) if the type is nullable

            var country = _mapper.Map<Country>(countryDto);
            await _countryRepository.UpdateCountryAsync(country);
        }

        public async Task DeleteCountryAsync(int countryId)
        {
            await _countryRepository.DeleteCountryAsync(countryId);
        }
    }
}
