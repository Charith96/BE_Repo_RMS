using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conifs.rms.dto.Role
{
    public class PrivilegeDto
    {

        [Key]
        public Guid PrivilegeCode { get; set; } // Table row ID

        public string PrivilegeId { get; set; }

        public string PrivilegeName { get; set; }

       
    }
}
