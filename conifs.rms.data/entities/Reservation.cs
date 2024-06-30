using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace conifs.rms.data.entities
{
    public class Reservation
    {
        [Key]
        public Guid ReservationCode { get; set; }
        [Required(ErrorMessage = "ReservationID is required")]
        public string ReservationID { get; set; }

        [ForeignKey("Customer")]
        [Required(ErrorMessage = " CustomerID is required")]
        public Guid CustomerID { get; set; }

        [ForeignKey("ReservationGroup")]
        [Required(ErrorMessage = "GroupId is required")]
        public Guid GroupId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ReservationGroup ReservationGroup { get; set; }

        public virtual ReservationItem ReservationItem{ get; set; }


        [ForeignKey("ReservationItem")]
        [Required(ErrorMessage = "ItemId is required")]
        public Guid ItemId { get; set; }
     
        public DateTime? date { get; set; }
        [Required(ErrorMessage = "NoOfPeople  is required")]
        public int NoOfPeople { get; set; }
        [Required(ErrorMessage = "First Time1 is required")]
        public DateTime Time1 { get; set; }
        [Required(ErrorMessage = "First  Time2 is required")]
        public DateTime Time2 { get; set; }


    }
}