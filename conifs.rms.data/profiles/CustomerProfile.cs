using AutoMapper;
using conifs.rms.data.entities;
using conifs.rms.dto.Customer;

namespace conifs.rms.data.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerDto, Customer>()
                .ForMember(dest => dest.CustomerCode, opt => opt.Ignore()) // Ignore CustomerCode because it's only for the database
                .ForMember(dest => dest.CustomerID, opt => opt.MapFrom(src => src.CustomerID))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Identifier, opt => opt.MapFrom(src => src.Identifier))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.ContactNo, opt => opt.MapFrom(src => src.ContactNo))
                .ReverseMap();
        }
    }
}
