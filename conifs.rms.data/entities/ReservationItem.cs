using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace conifs.rms.data.entities
{
    public class ReservationItem
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "ItemId is required.")]
        [StringLength(8, ErrorMessage = "ItemId can only be a maximum of 8 characters.")]
        public string ItemId { get; set; }

        [Required(ErrorMessage = "ItemName is required.")]
        [StringLength(20, ErrorMessage = "ItemName can only be a maximum of 20 characters.")]
        public string ItemName { get; set; }

        [Required(ErrorMessage = "TimeSlotType is required.")]
        public string TimeSlotType { get; set; }

        public string SlotDurationType { get; set; }

        
        public string DurationPerSlot { get; set; }

        [Range(0, 20, ErrorMessage = "NoOfSlots must be between 0 and 20.")]
        public int NoOfSlots { get; set; }

        [Required(ErrorMessage = "NoOfReservations is required.")]
        public string NoOfReservations { get; set; }

        [Required(ErrorMessage = "Capacity is required.")]
        public string Capacity { get; set; }

        [ForeignKey("ReservationGroup")]
        public Guid GroupId { get; set; }

        // Navigation property
        [JsonIgnore]
        public virtual ReservationGroup ReservationGroup { get; set; }

        
    }
}
