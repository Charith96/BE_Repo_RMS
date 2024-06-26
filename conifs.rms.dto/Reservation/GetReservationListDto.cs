using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace conifs.rms.dto.Reservation
{
    public class GetReservationListDto
    {


        public Guid ReservationCode { get; set; }
        public string ReservationID { get; set; }

        [ForeignKey("Customer")]
        public String CustomerID { get; set; }

        [ForeignKey("ReservationGroup")]
        public String GroupId { get; set; }

        [ForeignKey("ReservationItem")]
        public String ItemId { get; set; }

        public DateTime? date { get; set; }

        public int NoOfPeople { get; set; }

        public DateTime Time1 { get; set; }

        public DateTime Time2 { get; set; }
    }
}
