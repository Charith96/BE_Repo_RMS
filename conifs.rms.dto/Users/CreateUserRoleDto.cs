using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conifs.rms.dto.Users
{
    public class CreateUserRoleDto
    {
       
        [ForeignKey("User")]

        public Guid Userid { get; set; }



        [ForeignKey("Role")]
        public Guid RoleId { get; set; }

    }
}
