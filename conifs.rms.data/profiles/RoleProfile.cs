using AutoMapper;
using conifs.rms.data.entities;
using conifs.rms.dto.Role;

namespace conifs.rms.data.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleDto, Role>()
                .ForMember(dest => dest.RoleCode, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.RoleID, opt => opt.MapFrom(src => src.RoleID))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.RoleName))
                .ReverseMap()
                .ForMember(dest => dest.RoleCode, opt => opt.MapFrom(src => src.RoleCode))
                .ForMember(dest => dest.RoleID, opt => opt.MapFrom(src => src.RoleID))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.RoleName));
        }
    }
}