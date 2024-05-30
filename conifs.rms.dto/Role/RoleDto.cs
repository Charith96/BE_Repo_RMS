using System;
using System.ComponentModel.DataAnnotations;

namespace conifs.rms.dto.Role
{
    public class RoleDto
    {
        [Key]
        public Guid RoleCode { get; set; }

        public string RoleID { get; set; }

        public string RoleName { get; set; }
    }
}
