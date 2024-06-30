using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace conifs.rms.data.entities
{
    public class Country
    {
        [Key]
        public Guid CountryID { get; set; }

        [Required]
        [StringLength(100)]
        public string CountryName { get; set; } = "";

    }
}
