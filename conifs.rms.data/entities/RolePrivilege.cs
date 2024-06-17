using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace conifs.rms.data.entities
{
    public class RolePrivilege
    {
        [Key]
        public Guid RolePrivilegeCode { get; set; }

        [ForeignKey("RoleCode")]
        public Guid RoleCode { get; set; }
        public Role Role { get; set; }


        [ForeignKey("PrivilegeCode")]
        public Guid PrivilegeCode { get; set; }
        public Privilege Privilege { get; set; }
    }
}
