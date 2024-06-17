using System.ComponentModel.DataAnnotations;

namespace conifs.rms.data.entities
{
    public class Currency
    {
        [Key]
        public int CurrencyID { get; set; }

        [StringLength(3) ]
        public string CurrencyName { get; set; } = "";
    }
}
