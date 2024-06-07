using AutoMapper;
using conifs.rms.data.entities;

using conifs.rms.dto.ReservationItem;

namespace conifs.rms.data.Profiles
{
    public class ReservationItemProfile : Profile
{
        public ReservationItemProfile()
        {
            // Map from ReservationItem entity to ReservationItemDto
            CreateMap<ReservationItem, ReservationItemDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.ItemId))
                .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.ItemName))
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.GroupId))
                .ForMember(dest => dest.TimeSlotType, opt => opt.MapFrom(src => src.TimeSlotType))
                .ForMember(dest => dest.SlotDurationType, opt => opt.MapFrom(src => src.SlotDurationType))
                .ForMember(dest => dest.DurationPerSlot, opt => opt.MapFrom(src => src.DurationPerSlot))
                .ForMember(dest => dest.NoOfSlots, opt => opt.MapFrom(src => src.NoOfSlots))
                .ForMember(dest => dest.NoOfReservations, opt => opt.MapFrom(src => src.NoOfReservations))
                .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity));

            // Map from ReservationItemDto to ReservationItem entity
            CreateMap<ReservationItemDto, ReservationItem>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.ItemId))
                .ForMember(dest => dest.ItemName, opt => opt.MapFrom(src => src.ItemName))
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.GroupId))
                .ForMember(dest => dest.TimeSlotType, opt => opt.MapFrom(src => src.TimeSlotType))
                .ForMember(dest => dest.SlotDurationType, opt => opt.MapFrom(src => src.SlotDurationType))
                .ForMember(dest => dest.DurationPerSlot, opt => opt.MapFrom(src => src.DurationPerSlot))
                .ForMember(dest => dest.NoOfSlots, opt => opt.MapFrom(src => src.NoOfSlots))
                .ForMember(dest => dest.NoOfReservations, opt => opt.MapFrom(src => src.NoOfReservations))
                .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity));
        }
}
}
