using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace conifs.rms.data.entities
{


    public class Privilege
    {
        public Guid PrivilegeID { get; set; }
        public string PrivilegeName { get; set; }
        public ICollection<Role> Roles { get; set; } // Navigation propert
        public object PrivilegeCode { get; set; }
    }


}
