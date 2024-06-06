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

            //CreateMap<CompanyDto, Company>()
            //.ForMember(dest => dest.CompanyID, opt => opt.MapFrom(src => src.CompanyID))
            //.ForMember(dest => dest.CompanyCode, opt => opt.MapFrom(src => src.CompanyCode))
            //.ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.CompanyName))
            //.ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            //.ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
            //.ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency))
            //.ForMember(dest => dest.Address01, opt => opt.MapFrom(src => src.Address01))
            //.ForMember(dest => dest.Address02, opt => opt.MapFrom(src => src.Address02))
            //.ForMember(dest => dest.DefaultCompany, opt => opt.MapFrom(src => src.DefaultCompany))
            //.ReverseMap();

        
    }
}