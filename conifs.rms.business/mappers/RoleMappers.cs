using conifs.rms.data.entities;
using conifs.rms.dto.Role;

namespace conifs.rms.business.mappers
{
    public static class RoleMappers
    {
        public static RoleDto ToDto(Role role)
        {
            return new RoleDto
            {
                RoleID = role.RoleID,
                RoleName = role.RoleName
            };
        }

        public static Role ToEntity(RoleDto roleDto)
        {
            return new Role
            {
                RoleID = roleDto.RoleID,
                RoleName = roleDto.RoleName
            };
        }
    }
}