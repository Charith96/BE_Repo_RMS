using AutoMapper;
using conifs.rms.data.entities;
using conifs.rms.dto.TimeSlot;

namespace conifs.rms.data.Profiles
{
    public class TimeSlotProfile : Profile
    {
        public TimeSlotProfile()
        {
            // Map from TimeSlot to TimeSlotDto
            CreateMap<TimeSlot, TimeSlotDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime))
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.ItemId));

            // Map from TimeSlotDto to TimeSlot
            CreateMap<TimeSlotDto, TimeSlot>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime))
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.ItemId));
        }
    }
}

