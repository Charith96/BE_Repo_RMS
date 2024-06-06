using AutoMapper;
using conifs.rms.data.entities;
using conifs.rms.dto.Company;

namespace conifs.rms.data.Profiles
{
    public class CompanyProfile : Profile
    {

        public CompanyProfile()
        {

            CreateMap<CompanyDto, Company>()
                .ForMember(dest => dest.CompanyID, opt => opt.Ignore())
                .ForMember(dest => dest.CompanyCode, opt => opt.MapFrom(src => src.CompanyCode))
                .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.CompanyName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency))
                .ForMember(dest => dest.Address01, opt => opt.MapFrom(src => src.Address01))
                .ForMember(dest => dest.Address02, opt => opt.MapFrom(src => src.Address02))
                .ForMember(dest => dest.DefaultCompany, opt => opt.MapFrom(src => src.DefaultCompany))
                .ReverseMap();


        }
    }
}
