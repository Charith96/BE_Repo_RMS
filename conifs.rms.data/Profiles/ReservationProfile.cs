using AutoMapper;
using conifs.rms.data.entities;
using conifs.rms.dto.Reservation;

namespace conifs.rms.data.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<ReservationDto, Reservation>()
                .ForMember(dest => dest.ReservationCode, opt => opt.Ignore()) // Ignore ReservationCode because it's only for the database
                .ForMember(dest => dest.ReservationID, opt => opt.MapFrom(src => src.ReservationID))
                .ForMember(dest => dest.CustomerID, opt => opt.MapFrom(src => src.CustomerID))
                .ForMember(dest => dest.GroupId, opt => opt.MapFrom(src => src.GroupId))
                .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.ItemId))
                .ForMember(dest => dest.date, opt => opt.MapFrom(src => src.date))
                .ForMember(dest => dest.NoOfPeople, opt => opt.MapFrom(src => src.NoOfPeople))
                .ForMember(dest => dest.Time1, opt => opt.MapFrom(src => src.Time1))
                .ForMember(dest => dest.Time2, opt => opt.MapFrom(src => src.Time2))
                .ReverseMap();

            CreateMap<GetReservation, Reservation>()
               .ForMember(dest => dest.ReservationCode, opt => opt.Ignore()) 
               .ForMember(dest => dest.ReservationID, opt => opt.MapFrom(src => src.ReservationID))
               .ForMember(dest => dest.CustomerID, opt => opt.Ignore())
               .ForMember(dest => dest.GroupId, opt => opt.Ignore())
               .ForMember(dest => dest.ItemId, opt => opt.Ignore())
               .ForMember(dest => dest.date, opt => opt.MapFrom(src => src.date))
               .ForMember(dest => dest.NoOfPeople, opt => opt.MapFrom(src => src.NoOfPeople))
               .ForMember(dest => dest.Time1, opt => opt.MapFrom(src => src.Time1))
               .ForMember(dest => dest.Time2, opt => opt.MapFrom(src => src.Time2));
        }
    }
}