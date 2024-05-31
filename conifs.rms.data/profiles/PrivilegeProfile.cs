using AutoMapper;
using conifs.rms.dto.Role;
using conifs.rms.data.entities;

namespace conifs.rms.data.profiles
{
    public class PrivilegeProfile : Profile
    {
        public PrivilegeProfile()
        {
            CreateMap<PrivilegeDto, Privilege>()
                .ForMember(dest => dest.PrivilegeCode, opt => opt.MapFrom(src => src.PrivilegeCode))
                .ForMember(dest => dest.PrivilegeId, opt => opt.MapFrom(src => src.PrivilegeId))
                .ForMember(dest => dest.PrivilegeName, opt => opt.MapFrom(src => src.PrivilegeName));

            CreateMap<Privilege, PrivilegeDto>()
                .ForMember(dest => dest.PrivilegeCode, opt => opt.MapFrom(src => src.PrivilegeCode))
                .ForMember(dest => dest.PrivilegeId, opt => opt.MapFrom(src => src.PrivilegeId))
                .ForMember(dest => dest.PrivilegeName, opt => opt.MapFrom(src => src.PrivilegeName));
        }
    }
}
