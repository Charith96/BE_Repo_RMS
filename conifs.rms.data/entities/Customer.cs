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

        public string CustomerID { get; set; }

        public string FullName { get; set; }

        public string Identifier { get; set; }

        public string Address { get; set; }

        public string Email { get; set; } = string.Empty;

        public string ContactNo { get; set; }
    }
}
