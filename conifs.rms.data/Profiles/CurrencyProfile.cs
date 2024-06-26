using AutoMapper;
using conifs.rms.data.entities;
using conifs.rms.dto.Company;
//using conifs.rms.api;

namespace conifs.rms.data.Profiles
{
    public class CurrencyProfile : Profile
    {
        public CurrencyProfile()
        {
            CreateMap<Currency, CurrencyDto>()
                 .ForMember(dest => dest.CurrencyID, opt => opt.MapFrom(src => src.CurrencyID))
                 .ForMember(dest => dest.CurrencyName, opt => opt.MapFrom(src => src.CurrencyName))
               //  .ForMember(dest => dest.CurrencyCode, opt => opt.MapFrom(src => src.CurrencyCode))
            .ReverseMap();
           // CreateMap<CurrencyDto, Currency>()
               // .ForMember(dest => dest.CurrencyID, opt => opt.Ignore());
        }
    }
}
