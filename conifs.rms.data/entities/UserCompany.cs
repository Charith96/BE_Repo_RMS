using conifs.rms.data.repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace conifs.rms.data.entities
{
    public class UserCompany
    {
        [Key]
   
        public Guid UserCompanyID { get; set; }

    
        [ForeignKey("User")]
        public Guid Userid { get; set; }
        public virtual UserTable User { get; set; }

      
        [ForeignKey("Company")]
        public Guid CompanyId { get; set; }
        public virtual Company Company { get; set; }
      

        public UserCompany()
        {
           
            UserCompanyID = Guid.NewGuid();
        }

    }
 
}

