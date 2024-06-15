using System;

namespace conifs.rms.dto.Role
{
    public class RoleDto
    {
        public string RoleID { get; set; }
        public string RoleName { get; set; }

        public static implicit operator RoleDto(RoleDto v)
        {
            throw new NotImplementedException();
        }
    }
}
