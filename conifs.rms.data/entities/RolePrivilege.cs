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
    public class RolePrivilege
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Role")]
        public string RoleId { get; set; }
        public Role Role { get; set; }

        [ForeignKey("Privilege")]
        public string PrivilegeId { get; set; }
        public Privilege Privilege { get; set; }
    }

}


