using System.Collections.Generic;

namespace conifs.rms.dto
{
    public class RoleWithPrivilegesDto
    {
        public string RoleID { get; set; }
        public string RoleName { get; set; }
        public List<string> PrivilegeNames { get; set; }
    }
}
