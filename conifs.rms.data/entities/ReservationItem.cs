using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conifs.rms.data.entities
{
    public class ReservationItem
    {
        public Guid id { get; set; }
        public string itemName { get; set; }
        public string timeSlotType { get; set; }
        public string slotDurationType { get; set; }
        public int durationPerSlot { get; set; }
        public int noOfSlots { get; set; }
        public string noOfReservations { get; set; }
        public string capacity { get; set; }

        // Foreign key property
        public Guid groupId { get; set; }

        // Navigation property to represent the relationship
        public ReservationGroup ReservationGroup { get; set; }
    }
}
