using conifs.rms.data.repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace conifs.rms.data.entities
{
    public class UserRoles
    {
        [Key]
     
        public Guid UserRoleID { get; set; }

        [ForeignKey("User")]
       
        public Guid Userid { get; set; }
        public virtual UserTable User { get; set; }




        [ForeignKey("Role")]
        public Guid RoleId { get; set; }
        public virtual Roles Role { get; set; }
        public UserRoles()
        {
          
            UserRoleID = Guid.NewGuid();
        }
    }

}
