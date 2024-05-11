using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conifs.rms.data.entities
{
     public class Country
    {
        [Key]
        public int CountryID { get; set; }

        [StringLength(100)]
        public string CountryName { get; set; } = "";

        //public virtual ICollection<CreateCompanyDto>? Companies { get; set; }

    }
}
