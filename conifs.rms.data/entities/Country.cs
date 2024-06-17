using System.ComponentModel.DataAnnotations;

namespace conifs.rms.data.entities
{
    public class Country
    {
        [Key]
      //  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CountryID { get; set; }

        [StringLength(100)]
        public string CountryName { get; set; } = "";

        //public virtual ICollection<CreateCompanyDto>? Companies { get; set; }

    }
}
