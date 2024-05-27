using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel.DataAnnotations;
namespace conifs.rms.data.entities
{
    public class Roles
    {
        [Key]
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }

        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
