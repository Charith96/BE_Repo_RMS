using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conifs.rms.data.entities
{
    public class Privilege
    {
        //columns of the privilege table

        [Key]
        public string PrivilegeId { get; set; } //table row id


        [Required]
        public string PrivilegeName { get; set; }



        // Navigation property to RolePrivilege
        // public ICollection<RolePrivilege> RolePrivileges { get; set; }
        // Navigation property if you have a relationship with another entity (e.g., UserPrivilege)
       // public ICollection<UserPrivilege> UserPrivileges { get; set; }
    }

}
