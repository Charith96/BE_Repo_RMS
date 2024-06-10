using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace conifs.rms.dto.Company
{
    public class CountryDto
    {
        // [JsonIgnore]
         [Required]

      //  [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryID { get; set; }
       
        public string CountryName { get; set; } = "";
    }
}
