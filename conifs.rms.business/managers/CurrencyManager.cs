using AutoMapper;
using conifs.rms.business.validators;
using conifs.rms.data;
using conifs.rms.data.entities;
using conifs.rms.data.repositories;
using conifs.rms.dto.Company;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace conifs.rms.business.managers
{
    public class CurrencyManager : ICurrencyManager
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public CurrencyManager(ICurrencyRepository currencyRepository, IMapper mapper, ApplicationDbContext context)
        {
            _currencyRepository = currencyRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<CurrencyDto>> GetAllCurrencies()
        {
            var currency = await _currencyRepository.GetAllCurrencies();
            return _mapper.Map<List<CurrencyDto>>(currency);
        }

        public async Task<CurrencyDto> GetCurrencyById(Guid currencyID)
        {
            try
            {
                var currency = await _currencyRepository.GetCurrencyById(currencyID);
            return _mapper.Map<CurrencyDto>(currency) ?? new CurrencyDto();
            }
            catch (KeyNotFoundException ex)
            {
                return new CurrencyDto();
            }
        }

        public async Task<CurrencyDto> AddCurrency(CurrencyDto newCurrencyDto)
        {
            Currency newCurrency = _mapper.Map<Currency>(newCurrencyDto);
            var validator = new CurrencyValidator(_context);
            var validationResult = await validator.ValidateAsync(newCurrency);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            try
            {
                var addedCurrency = await _currencyRepository.AddCurrency(newCurrency);
           // newCurrencyDto.CurrencyID = addedCurrency.CurrencyID;
           // return newCurrencyDto;
                return _mapper.Map<CurrencyDto>(addedCurrency);
            }
            catch (DuplicateNameException ex)
            {
                throw new ValidationException(new[] { new ValidationFailure("CurrencyName", ex.Message) });
            }

        }

        public async Task<CurrencyDto> UpdateCurrency(CurrencyDto updatedCurrencyDto)
        {
            try
            {
                var existingCurrency = await _currencyRepository.GetCurrencyById(updatedCurrencyDto.CurrencyID);
                var updatedCurrency = _mapper.Map<Currency>(updatedCurrencyDto);

                var validator = new CurrencyValidator(_context);
                var validationResult = await validator.ValidateAsync(updatedCurrency);

                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult.Errors);
                }

                 existingCurrency.CurrencyName = updatedCurrency.CurrencyName;

            //if (existingCurrency == null)
            //{
            //    throw new Exception($"Currency with ID {updatedCurrencyDto.CurrencyID} not found.");
            //}
                var updatedCurrencyEntity = await _currencyRepository.UpdateCurrency(existingCurrency);
                return _mapper.Map<CurrencyDto>(updatedCurrencyEntity);
            }
            catch (KeyNotFoundException)
            {
                throw new Exception($"Currency with ID {updatedCurrencyDto.CurrencyID} not found.");
            }
            catch (DuplicateNameException ex)
            {
                throw new ValidationException(new[] { new ValidationFailure("CurrencyName", ex.Message) });
            }

        }

        public async Task DeleteCurrency(Guid currencyID)
        {
            try
            {
                await _currencyRepository.DeleteCurrency(currencyID);
            }
            catch (KeyNotFoundException)
            {

            }
        }
    }
}
