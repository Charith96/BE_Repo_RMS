using AutoMapper;
using conifs.rms.data.entities;
using conifs.rms.dto.Privilege;

namespace conifs.rms.data.Profiles
{
    public class PrivilegeProfile : Profile
    {
        public PrivilegeProfile()
        {
            CreateMap<PrivilegeDto, Privilege>()
                .ForMember(dest => dest.PrivilegeCode, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.PrivilegeName, opt => opt.MapFrom(src => src.PrivilegeName))
                .ReverseMap()
                .ForMember(dest => dest.PrivilegeCode, opt => opt.MapFrom(src => src.PrivilegeCode))
                .ForMember(dest => dest.PrivilegeName, opt => opt.MapFrom(src => src.PrivilegeName));
        }
    }
}