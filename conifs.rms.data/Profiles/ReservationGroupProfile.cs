using AutoMapper;
using conifs.rms.data.entities;
using conifs.rms.dto.ReservationGroup;

namespace conifs.rms.data.Profiles
{
    public class ReservationGroupProfile : Profile
{
        public ReservationGroupProfile()
        {
            CreateMap<ReservationGroup, ReservationGroupDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.GroupId))
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.GroupName));

            CreateMap<ReservationGroupDto, ReservationGroup>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.GroupId))
                .ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.GroupName));
        }
    }
}
