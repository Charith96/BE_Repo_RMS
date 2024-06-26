using System;

namespace conifs.rms.dto.ReservationItem
{
    public class ReservationItemDto
    {
        public Guid Id { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public Guid GroupId { get; set; }
        public string TimeSlotType { get; set; }
        public string SlotDurationType { get; set; }
        public string DurationPerSlot { get; set; }
        public int NoOfSlots { get; set; }
        public string NoOfReservations { get; set; }
        public string Capacity { get; set; }
    }
}
