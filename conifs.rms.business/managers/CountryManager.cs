using AutoMapper;
using conifs.rms.business.managers;
using conifs.rms.business.validators;
using conifs.rms.data;
using conifs.rms.data.entities;
using conifs.rms.data.repositories;
using conifs.rms.dto.Company;
using FluentValidation;
using System.Data;
using FluentValidation.Results;

namespace conifs.rms.business
{
    public class CountryManager : ICountryManager
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public CountryManager(ICountryRepository countryRepository, IMapper mapper, ApplicationDbContext context)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<CountryDto>> GetAllCountries()
        {
            var country = await _countryRepository.GetAllCountries();
            return _mapper.Map<List<CountryDto>>(country);
        }

        public async Task<CountryDto> GetCountryById(Guid countryId)
        {
            try
            {
                var country = await _countryRepository.GetCountryById(countryId);
                return _mapper.Map<CountryDto>(country) ?? new CountryDto();
            }
            catch (KeyNotFoundException ex) 
            {
                return new CountryDto();
            }
            
        }

        public async Task<CountryDto> AddCountry(CountryDto newCountryDto)
        {
           Country newCountry = _mapper.Map<Country>(newCountryDto);
            var validator = new CountryValidator(_context);
            var validationResult = await validator.ValidateAsync(newCountry);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            try
            {
                var addedCountry = await _countryRepository.AddCountry(newCountry);
                // newCountryDto.CountryID = addedCountry.CountryID;
                // return newCountryDto;
                return _mapper.Map<CountryDto>(addedCountry);
            }
            catch (DuplicateNameException ex)
            {
                throw new ValidationException(new[] { new ValidationFailure("CountryName", ex.Message) });
            }
        }

        public async Task<CountryDto> UpdateCountry(CountryDto updatedCountryDto)
        {
            try
            {
                var existingCountry = await _countryRepository.GetCountryById(updatedCountryDto.CountryID);
                var updatedCountry = _mapper.Map<Country>(updatedCountryDto);

                var validator = new CountryValidator(_context);
                var validationResult = await validator.ValidateAsync(updatedCountry);

                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult.Errors);
                }

                //if (existingCountry == null)
                //{
                //    throw new Exception($"Company with ID {updatedCountryDto.CountryID} not found.");
                //}

                existingCountry.CountryName = updatedCountry.CountryName;
                var updatedCountryEntitiy = await _countryRepository.UpdateCountry(existingCountry);
                return _mapper.Map<CountryDto>(updatedCountryEntitiy);
            }
            catch (KeyNotFoundException) 
            {
                throw new Exception($"Country with ID {updatedCountryDto.CountryID} not found.");
            }
            catch (DuplicateNameException ex)
            {
                throw new ValidationException(new[] { new ValidationFailure("CountryName", ex.Message) });
            }
            
        }

        public async Task DeleteCountry(Guid countryId)
        {
            try
            {
                await _countryRepository.DeleteCountry(countryId);
            }
            catch (KeyNotFoundException )
            {

            }

        }
    }
}
