using System.ComponentModel.DataAnnotations;

namespace conifs.rms.dto.Company
{
    public class CurrencyDto
    {
        public Guid CurrencyID { get; set; }
        public string CurrencyName { get; set; } = "";
       // public string CurrencyCode { get; set; } = "";

      //  public ICollection<CompanyDto> Companies { get; set; } = new List<CompanyDto>();
    }
}
