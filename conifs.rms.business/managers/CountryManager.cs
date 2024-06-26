using AutoMapper;
using conifs.rms.business.managers;
using conifs.rms.business.validators;
using conifs.rms.data.entities;
using conifs.rms.data.repositories;
using conifs.rms.dto.Company;
using FluentValidation;

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

        public async Task<IEnumerable<CountryDto>> GetAllCountries()
        {
            var country = await _countryRepository.GetAllCountries();
            return _mapper.Map<List<CountryDto>>(country);
        }

        public async Task<CountryDto> GetCountryById(Guid countryId)
        {
            var country = await _countryRepository.GetCountryById(countryId);
            return _mapper.Map<CountryDto>(country) ?? new CountryDto();
        }

        public async Task<CountryDto> AddCountry(CountryDto newCountryDto)
        {
           Country newCountry = _mapper.Map<Country>(newCountryDto);

            var validator = new CountryValidator();

            var validationResult = await validator.ValidateAsync(newCountry);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var addedCountry = await _countryRepository.AddCountry(newCountry);
            newCountryDto.CountryID = addedCountry.CountryID;

            return newCountryDto;
        }

        public async Task<CountryDto> UpdateCountry(CountryDto updatedCountryDto)
        {
            var existingCountry = await _countryRepository.GetCountryById(updatedCountryDto.CountryID);
            if (existingCountry == null) {
                throw new Exception($"Company with ID {updatedCountryDto.CountryID} not found.");
            }

            var updatedCountry = _mapper.Map<Country>(updatedCountryDto);

            var validator = new CountryValidator(); ;

            var validationResult = await validator.ValidateAsync(updatedCountry);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            existingCountry.CountryName = updatedCountry.CountryName;
            
            var updatedCountryEntitiy = await _countryRepository.UpdateCountry(existingCountry);

            return _mapper.Map<CountryDto>(updatedCountryEntitiy);
        }

        public async Task DeleteCountry(Guid countryId)
        {
            await _countryRepository.DeleteCountry(countryId);
        }
    }
}
