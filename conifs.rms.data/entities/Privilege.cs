using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace conifs.rms.data.entities
{
    public class Privilege
    {
        [Key]
        public Guid PrivilegeCode { get; set; } // Table row ID

        public string PrivilegeId { get; set; }

        public string PrivilegeName { get; set; }

        // Navigation property to RolePrivilege
        // public ICollection<RolePrivilege> RolePrivileges { get; set; }
    }
}
