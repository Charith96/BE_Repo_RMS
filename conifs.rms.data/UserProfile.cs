using AutoMapper;
using conifs.rms.data.entities;
using static System.Runtime.InteropServices.JavaScript.JSType;
using conifs.rms.dto;

namespace conifs.rms.data
{

    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserTable, GetUserDto>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PrimaryRole, opt => opt.MapFrom(src => src.PrimaryRole))
                .ForMember(dest => dest.Designation, opt => opt.MapFrom(src => src.Designation))
                .ForMember(dest => dest.DefaultCompany, opt => opt.MapFrom(src => src.DefaultCompany))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName));

            CreateMap<CreateUserDto,UserTable>()
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.PrimaryRole, opt => opt.MapFrom(src => src.PrimaryRole))
               .ForMember(dest => dest.Designation, opt => opt.MapFrom(src => src.Designation))
               .ForMember(dest => dest.DefaultCompany, opt => opt.MapFrom(src => src.DefaultCompany))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.ValidFrom, opt => opt.MapFrom(src => src.ValidFrom))
               .ForMember(dest => dest.ValidTill, opt => opt.MapFrom(src => src.ValidTill))
               .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
               .ForMember(dest => dest.Userid, opt => opt.MapFrom(src => Guid.NewGuid()))
               .ForMember(dest => dest.UserCompanies, opt => opt.Ignore())
               .ForMember(dest => dest.UserRoles, opt => opt.Ignore())
               .ForMember(dest => dest.ImageData, opt => opt.Ignore());

        }
    }
}