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
        public Guid UserCode { get; set; }
        public virtual UserTable User { get; set; }

      
        [ForeignKey("Company")]
        public Guid CompanyID { get; set; }
       
        
        public UserCompany()
        {
           
            UserCompanyID = Guid.NewGuid();
        }

    }
    //has to complete after integration
}

