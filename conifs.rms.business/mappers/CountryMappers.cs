using AutoMapper;
using conifs.rms.data.entities;
//using conifs.rms.api;
using conifs.rms.dto.Company;

namespace conifs.rms.business.mappers
{
    public static class CountryMapper
    {
        public static Country Map(CountryDto input)
        {
            if (input == null)
            {
                return null;
            }

            return new Country
            {
                CountryName = input.CountryName ?? string.Empty
            };
        }

        public static CountryDto Map(Country input)
        {
            if (input == null)
            {
                return null;
            }

            return new CountryDto
            {
                CountryName = input.CountryName ?? string.Empty
            };
        }
    }
}
