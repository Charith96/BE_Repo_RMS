using System.ComponentModel.DataAnnotations;

namespace conifs.rms.dto.Company
{
    public class CountryDto
    {
        // [JsonIgnore]
         [Required]

      // [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryID { get; set; }
       
        public string CountryName { get; set; } = "";
    }
}
