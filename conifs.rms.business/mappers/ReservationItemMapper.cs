using conifs.rms.data.entities;
using conifs.rms.dto.ReservationItem;

namespace conifs.rms.business.mappers
{
    public static class ReservationItemMapper
    {
        public static ReservationItem Map(ReservationItemDto input)
        {
            if (input == null)
            {
                return null;
            }

            return new ReservationItem
            {
                ItemId = input.ItemId,
                ItemName = input.ItemName,
                TimeSlotType = input.TimeSlotType,
                NoOfSlots = input.NoOfSlots,
                NoOfReservations = input.NoOfReservations,
                Capacity = input.Capacity
            };
        }

        public static ReservationItemDto Map(ReservationItem input)
        {
            if (input == null)
            {
                return null;
            }

            return new ReservationItemDto
            {
                ItemId = input.ItemId,
                ItemName = input.ItemName,
                TimeSlotType = input.TimeSlotType,
                NoOfSlots = input.NoOfSlots,
                NoOfReservations = input.NoOfReservations,
                Capacity = input.Capacity
            };
        }
    }
}
