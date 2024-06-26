using AutoMapper;
using conifs.rms.data.entities;
using conifs.rms.dto;
using conifs.rms.dto.Role;

namespace conifs.rms.data.profiles
{
    public class RolePrivilegeProfile : Profile
    {
        public RolePrivilegeProfile()
        {
            CreateMap<RolePrivilegeDto, RolePrivilege>()
                
                .ForMember(dest => dest.RolePrivilegeCode, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.RoleCode, opt => opt.MapFrom(src => src.RoleCode))
                .ForMember(dest => dest.PrivilegeCode, opt => opt.MapFrom(src => src.PrivilegeCode))
                
                .ReverseMap()
                .ForMember(dest => dest.RolePrivilegeCode, opt => opt.MapFrom(src => src.RolePrivilegeCode))
                .ForMember(dest => dest.RoleCode, opt => opt.MapFrom(src => src.RoleCode))
                .ForMember(dest => dest.PrivilegeCode, opt => opt.MapFrom(src => src.PrivilegeCode));   
        }
    }
}
