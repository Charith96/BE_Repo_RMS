using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace conifs.rms.data.entities
{
    public class Role
    {
        [Key]
        public Guid RoleCode { get; set; }

        [Required]
        [StringLength(8)]
        public string RoleID { get; set; }

        [Required]
        [StringLength(20)]
        public string RoleName { get; set; }

        // Navigation property to RolePrivilege
        //public ICollection<RolePrivilege> RolePrivileges { get; set; }
    }
}
