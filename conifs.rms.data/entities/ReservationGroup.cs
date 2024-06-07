using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conifs.rms.data.entities
{
    public class ReservationGroup
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "GroupId is required.")]
        [StringLength(8, ErrorMessage = "GroupId can only be a maximum of 8 characters.")]
        public string GroupId { get; set; }

        [Required(ErrorMessage = "GroupName is required.")]
        [StringLength(20, ErrorMessage = "GroupName can only be a maximum of 20 characters.")]
        public string GroupName { get; set; }

        // Navigation property to ReservationItems (Not mapped to a database column)
        //public virtual ICollection<ReservationItem> ReservationItems { get; set; }
    }
}
