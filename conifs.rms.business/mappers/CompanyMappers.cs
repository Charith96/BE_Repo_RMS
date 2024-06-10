using conifs.rms.data.entities;
using conifs.rms.dto.Company;

namespace conifs.rms.business.mappers
{
    public static class CompanyMappers
    {
        public static Company? Map(CompanyDto? input)
        {

            if (input == null)
            {
                return null;
            }

            return new Company
            {
                CompanyCode = input.CompanyCode ?? string.Empty,
                CompanyName = input.CompanyName ?? string.Empty,
                Description = input.Description ?? string.Empty,
                Country = input.Country ?? string.Empty,
                Currency = input.Currency ?? string.Empty,
                Address01 = input.Address01 ?? string.Empty,
                Address02 = input.Address02 ?? string.Empty,
                DefaultCompany = input.DefaultCompany,
            };
        }

        public static CompanyDto? Map(Company? input)
        {

            if (input == null)
            {
                return null;
            }

            return new CompanyDto
            {
                CompanyCode = input.CompanyCode ?? string.Empty,
                CompanyName = input.CompanyName ?? string.Empty,
                Description = input.Description ?? string.Empty,
                Country = input.Country ?? string.Empty,
                Currency = input.Currency ?? string.Empty,
                Address01 = input.Address01 ?? string.Empty,
                Address02 = input.Address02 ?? string.Empty,
                DefaultCompany = input.DefaultCompany,
            };
        }        
    }
}