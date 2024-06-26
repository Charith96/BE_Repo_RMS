using System.ComponentModel.DataAnnotations;

namespace conifs.rms.dto.Company
{
    public class CountryDto
    {
        public Guid CountryID { get; set; }
        public string CountryName { get; set; } = "";
      //  public string CountryCode { get; set; } = "";

      //  public ICollection<CompanyDto> Companies { get; set; } = new List<CompanyDto>();
    }
}
