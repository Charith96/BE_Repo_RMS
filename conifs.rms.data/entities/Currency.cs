using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace conifs.rms.data.entities
{
    public class Currency
    {
        [Key]
        public Guid CurrencyID { get; set; }

        [Required]
        [StringLength(3) ]
        public string CurrencyName { get; set; } = "";

    }
}
