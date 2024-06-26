using AutoMapper;
using conifs.rms.business.validators;
using conifs.rms.data.entities;
using conifs.rms.data.repositories;
using conifs.rms.dto.Company;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace conifs.rms.business.managers
{
    public class CurrencyManager : ICurrencyManager
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IMapper _mapper;

        public CurrencyManager(ICurrencyRepository currencyRepository, IMapper mapper)
        {
            _currencyRepository = currencyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CurrencyDto>> GetAllCurrencies()
        {
            var currency = await _currencyRepository.GetAllCurrencies();
            return _mapper.Map<List<CurrencyDto>>(currency);
        }

        public async Task<CurrencyDto> GetCurrencyById(Guid currencyID)
        {
            var currency = await _currencyRepository.GetCurrencyById(currencyID);
            return _mapper.Map<CurrencyDto>(currency) ?? new CurrencyDto();
        }

        public async Task<CurrencyDto> AddCurrency(CurrencyDto newCurrencyDto)
        {
            Currency newCurrency = _mapper.Map<Currency>(newCurrencyDto);

            var validator = new CurrencyValidator();

            var validationResult = await validator.ValidateAsync(newCurrency);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var addedCurrency = await _currencyRepository.AddCurrency(newCurrency);

            newCurrencyDto.CurrencyID = addedCurrency.CurrencyID;

            return newCurrencyDto;

        }

        public async Task<CurrencyDto> UpdateCurrency(CurrencyDto updatedCurrencyDto)
        {
            var existingCurrency = await _currencyRepository.GetCurrencyById(updatedCurrencyDto.CurrencyID);

            if (existingCurrency == null)
            {
                throw new Exception($"Currency with ID {updatedCurrencyDto.CurrencyID} not found.");
            }

            var updatedCurrency = _mapper.Map<Currency>(updatedCurrencyDto);
            var validator = new CurrencyValidator();
            var validationResult = await validator.ValidateAsync(updatedCurrency);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            existingCurrency.CurrencyName = updatedCurrency.CurrencyName;

            var updatedCurrencyEntity = await _currencyRepository.UpdateCurrency(existingCurrency);
            return _mapper.Map<CurrencyDto>(updatedCurrencyEntity);
        }

        public async Task DeleteCurrency(Guid currencyID)
        {
            await _currencyRepository.DeleteCurrency(currencyID);
        }
    }
}
