using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conifs.rms.data.entities
{
    public class Customer
    {
        [Key]
        public Guid CustomerCode { get; set; }

        [Required]
        [StringLength(8)]
        public string CustomerID { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required]
        [StringLength (20)]
        public string Identifier { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(15)]
        public string ContactNo { get; set; }
    }
}
