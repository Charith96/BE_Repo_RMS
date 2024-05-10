using conifs.rms.data.repositories;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace conifs.rms.data.entities
{
    public class UserRoles
    {
        [Key]
     
        public Guid UserRoleID { get; set; }

        [ForeignKey("User")]
       
        public Guid UserCode { get; set; }
        


        [ForeignKey("Role")]
        public Guid RoleID { get; set; }
     
        public UserRoles()
        {
          
            UserRoleID = Guid.NewGuid();
        }
    }
    //has to complete after integration
}
