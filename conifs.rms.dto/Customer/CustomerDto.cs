namespace conifs.rms.dto.Customer
{
    public class CustomerDto
    {
        public string CustomerID { get; set; }

        public string FullName { get; set; }

        public string Identifier { get; set; }

        public string Address { get; set; }

        public string Email { get; set; } = string.Empty;

        public string ContactNo { get; set; }
    }
}