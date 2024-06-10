using AutoMapper;
using conifs.rms.data.entities;
using conifs.rms.dto.Company;
//using conifs.rms.api;

namespace conifs.rms.data.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile()
        {
            CreateMap<Country, CountryDto>()
                 .ForMember(dest => dest.CountryID, opt => opt.MapFrom(src => src.CountryID))
                 .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.CountryName));

            CreateMap<CountryDto, Country>()
                .ForMember(dest => dest.CountryID, opt => opt.Ignore()); // Ignore mapping CountryID back
        }
    }
}
