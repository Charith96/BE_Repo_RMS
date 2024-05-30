using AutoMapper;
using conifs.rms.dto.Role;
using conifs.rms.data.entities;

namespace conifs.rms.data.Profile
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleDto, Role>()
                .ForMember(dest => dest.RoleCode, opt => opt.MapFrom(src => src.RoleCode))
                .ForMember(dest => dest.RoleID, opt => opt.MapFrom(src => src.RoleID))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.RoleName));

            CreateMap<Role, RoleDto>()
                .ForMember(dest => dest.RoleCode, opt => opt.MapFrom(src => src.RoleCode))
                .ForMember(dest => dest.RoleID, opt => opt.MapFrom(src => src.RoleID))
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.RoleName));
        }
    }
}
