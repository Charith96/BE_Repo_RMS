using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using conifs.rms.data.entities;
using conifs.rms.data.repositories;
using conifs.rms.dto.Company;

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

        public async Task<List<CurrencyDto>> GetAllCurrenciesAsync()
        {
            var currencies = await _currencyRepository.GetAllCurrenciesAsync();
            return _mapper.Map<List<CurrencyDto>>(currencies);
        }

        public async Task<CurrencyDto> GetCurrencyByIdAsync(int id)
        {
            var currency = await _currencyRepository.GetCurrencyByIdAsync(id);
            return _mapper.Map<CurrencyDto>(currency);
        }

        public async Task AddCurrencyAsync(CurrencyDto currencyDto)
        {
            var currency = _mapper.Map<Currency>(currencyDto);
            await _currencyRepository.AddCurrencyAsync(currency);
        }

        public async Task UpdateCurrencyAsync(CurrencyDto currencyDto)
        {
            var currency = _mapper.Map<Currency>(currencyDto);
            await _currencyRepository.UpdateCurrencyAsync(currency);
        }

        public async Task DeleteCurrencyAsync(int id)
        {
            await _currencyRepository.DeleteCurrencyAsync(id);
        }
    }
}
