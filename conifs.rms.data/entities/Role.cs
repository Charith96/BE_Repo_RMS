using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace conifs.rms.data.entities
{
    public class Role
    {
        [Key]
        public Guid RoleCode { get; set; }

        public string RoleID { get; set; }

        public string RoleName { get; set; }

        // Navigation property to RolePrivilege
        // public ICollection<RolePrivilege> RolePrivileges { get; set; }
    }
}
