using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace conifs.rms.data.entities
{
    public class Role
    {
        public Guid RoleID { get; set; }
        public string RoleName { get; set; }
        public ICollection<Privilege> Privileges { get; set; } // Navigation property
        public Guid RoleCode { get; set; }
    }


}
