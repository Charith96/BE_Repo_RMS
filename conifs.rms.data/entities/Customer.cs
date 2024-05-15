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
        public string CustomerID { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Identifier { get; set; }

        [Required]
        public string Address { get; set; }

        public string Email { get; set; } = string.Empty;

        [Required]
        public string ContactNo { get; set; }
    }
}
