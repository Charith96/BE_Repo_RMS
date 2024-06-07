using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace conifs.rms.data.entities
{
    public class TimeSlot
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "StartTime is required.")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "EndTime is required.")]
        public DateTime EndTime { get; set; }

        [ForeignKey("ReservationItem")]
        public Guid ItemId { get; set; }

        // Navigation property
        [JsonIgnore]
        public virtual ReservationItem ReservationItem { get; set; }
    }
}
