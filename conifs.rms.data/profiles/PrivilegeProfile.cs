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
                .ForMember(dest => dest.PrivilegeName, opt => opt.MapFrom(src => src.PrivilegeName))
                .ReverseMap()
                .ForMember(dest => dest.PrivilegeName, opt => opt.MapFrom(src => src.PrivilegeName));
        }
    }
}