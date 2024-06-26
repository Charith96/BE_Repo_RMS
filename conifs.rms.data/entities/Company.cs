using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace conifs.rms.data.entities
{
    public class Company
    {
        [Key]
       // [StringLength(8)]
        public Guid CompanyID { get; set; }

        [Required]
        [StringLength(8)]
        public string? CompanyCode { get; set; }

        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; } = "";

        [StringLength(50)]
        public string Description { get; set; } = "";

        [ForeignKey("Country")]
        public Guid CountryID { get; set; }

        [JsonIgnore]
        public virtual Country Country { get; set; }

        [ForeignKey("Currency")]
        public Guid CurrencyID { get; set; }

        [JsonIgnore]
        public virtual Currency Currency { get; set; }

        [Required]
        [StringLength(50)]
        public string Address01 { get; set; } = "";

        [StringLength(50)]
        public string Address02 { get; set; } = "";

        public bool DefaultCompany { get; set; }

        public Company()
        {
            CompanyID = Guid.NewGuid(); // Initialize CompanyID with a new Guid
        }   
    }
}


