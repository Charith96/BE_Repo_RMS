using System.ComponentModel.DataAnnotations;

namespace conifs.rms.dto.Company
{
    public class CompanyDto
    {
        public Guid CompanyID { get; set; }

        [Required]
        public string? CompanyCode { get; set; }
        public string CompanyName { get; set; } = "";
        public string? Description { get; set; } = "";
        public string Country { get; set; } = "";
        public string Currency { get; set; } = "";
        public string? Address01 { get; set; } = "";
        public string? Address02 { get; set; } = "";
        public bool DefaultCompany { get; set; }
    }
}