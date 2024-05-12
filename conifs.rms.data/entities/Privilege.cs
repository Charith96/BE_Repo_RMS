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
        public int Id { get; set; } //table row id

        [Required]
        public string PrivilegeId { get; set; }

        [Required]
        public string PrivilegeName { get; set; }



        // Navigation property to RolePrivilege
       // public ICollection<RolePrivilege> RolePrivileges { get; set; }
    }

}
