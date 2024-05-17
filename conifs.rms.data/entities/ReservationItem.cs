using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conifs.rms.data.entities
{
    public class ReservationItem
    {
        public Guid Id { get; set; }
        public string ItemName { get; set; }
        public string TimeSlotType { get; set; }
        public string SlotDurationType { get; set; }
        public int DurationPerSlot { get; set; }
        public int NoOfSlots { get; set; }
        public string NoOfReservations { get; set; }
        public string Capacity { get; set; }

        // Foreign key property
        public Guid GroupId { get; set; }

        // Navigation property to represent the relationship
        //public ReservationGroup ReservationGroup { get; set; }
    }
}
