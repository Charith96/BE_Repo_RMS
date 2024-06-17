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

        public async Task<IEnumerable<CurrencyDto>> GetAllCurrencies()
        {
            var currency = await _currencyRepository.GetAllCurrencies();
            return _mapper.Map<List<CurrencyDto>>(currency);
        }

        public async Task<CurrencyDto> GetCurrencyById(int currencyID)
        {
            var currency = await _currencyRepository.GetCurrencyById(currencyID);
            return _mapper.Map<CurrencyDto>(currency) ?? new CurrencyDto();
        }

        public async Task<CurrencyDto> AddCurrency(CurrencyDto newCurrencyDto)
        {
            Currency newCurrency = _mapper.Map<Currency>(newCurrencyDto);

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

            existingCurrency.CurrencyName = updatedCurrency.CurrencyName;

            var updatedCurrencyEntity = await _currencyRepository.UpdateCurrency(existingCurrency);
            return _mapper.Map<CurrencyDto>(updatedCurrencyEntity);
        }

        public async Task DeleteCurrency(int currencyID)
        {
            await _currencyRepository.DeleteCurrency(currencyID);
        }
    }
}
