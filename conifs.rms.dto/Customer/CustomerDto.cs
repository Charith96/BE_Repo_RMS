using System.ComponentModel.DataAnnotations;

namespace conifs.rms.dto.Customer
{
    public class CustomerDto
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