using conifs.rms.dto.Role;
using conifs.rms.data.entities;

namespace conifs.rms.business.Mappers
{
    public class RoleMapper
    {
        public Role Map(RoleDto input)
        {
            return new Role()
            {
                RoleCode = input?.RoleCode ?? Guid.Empty,
                RoleID = input?.RoleID,
                RoleName = input?.RoleName
            };
        }

        public RoleDto Map(Role input)
        {
            return new RoleDto()
            {
                RoleCode = input?.RoleCode ?? Guid.Empty,
                RoleID = input?.RoleID,
                RoleName = input?.RoleName
            };
        }
    }
}
