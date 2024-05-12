using conifs.rms.data.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conifs.rms.data.entities
{
    public class Role

    // columns of the role table
    {
        [Key]
        public int Id { get; set; } //table row id

        [Required]
        public string RoleId { get; set; }

        [Required]
        public string RoleName { get; set; }




        // Navigation property to RolePrivilege
        // public ICollection<RolePrivilege> RolePrivileges { get; set; }
    }
}
