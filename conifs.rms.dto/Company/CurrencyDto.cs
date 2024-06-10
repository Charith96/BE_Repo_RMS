using System.ComponentModel.DataAnnotations;

namespace conifs.rms.dto.Company
{
    public class CurrencyDto
    {
        public int CurrencyID { get; set; }
        public string CurrencyName { get; set; } = "";
    }
}
