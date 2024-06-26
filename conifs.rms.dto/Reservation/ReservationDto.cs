using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace conifs.rms.dto.Reservation
{
    public class ReservationDto
    {
        public Guid ReservationCode { get; set; }
        public string ReservationID { get; set; }

        [ForeignKey("Customer")]
        public Guid CustomerID { get; set; }
  

        [ForeignKey("ReservationGroup")]
        public Guid GroupId { get; set; }

        [ForeignKey("ReservationItem")]
        public Guid ItemId { get; set; }

        public DateTime? date { get; set; }

        public int NoOfPeople { get; set; }

        public DateTime Time1 { get; set; }

        public DateTime Time2 { get; set; }
    }
}
