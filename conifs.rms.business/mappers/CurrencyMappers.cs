using AutoMapper;
using conifs.rms.data.entities;
using conifs.rms.dto.Company;

namespace conifs.rms.business.mappers
{
    public static class CurrencyMapper
    {
        public static Currency Map(CurrencyDto input)
        {
            if (input == null)
            {
                return null;
            }

            return new Currency
            {
                CurrencyName = input.CurrencyName ?? string.Empty
            };
        }

        public static CurrencyDto Map(Currency input)
        {
            if (input == null)
            {
                return null;
            }

            return new CurrencyDto
            {
                CurrencyName = input.CurrencyName ?? string.Empty
            };
        }
    }
}
