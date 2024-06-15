using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace conifs.rms.data.entities
{


    public class RoleWithPrivileges
    {
        [Key]
        public Guid RolePrivilegeCode { get; set; }

        public Guid RoleCode { get; set; }
        [ForeignKey("RoleCode")]
        public Role Role { get; set; }

        public Guid PrivilegeCode { get; set; }
        [ForeignKey("PrivilegeCode")]
        public Privilege Privilege { get; set; }
    }
}
