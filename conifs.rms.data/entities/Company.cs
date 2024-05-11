//new
using System.ComponentModel.DataAnnotations;
//new

namespace conifs.rms.data.entities
{
    public class Company
    {
        [Key]
        [Required]
        [StringLength(50)]
        public Guid? CompanyID { get; set; }

        [Required]
        [StringLength(50)]
        public string CompanyName { get; set;} = "";

        [StringLength(50)]
        public string Description { get; set;} = "";

         [Required]
        [StringLength(50)]
        public string Country { get; set; } = "";

     //   public int Country { get; set; } // Foreign key property

        // Navigation property
      //  public CountryDto? Country { get; set; }


        [Required]
        [StringLength(3)]
        public string Currency { get; set; } = "";

        [Required]
        [StringLength(50)]
        public string Address01 { get; set; } = "";

        [StringLength(50)]
        public string Address02 { get; set; } = "";

        //[Required]
        public bool DefaultCompany { get; set; }

    }
}
