using conifs.rms.dto;
using conifs.rms.data.entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace conifs.rms.business
{
    public interface IRoleManager
    {
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role> GetRoleByIdAsync(Guid roleId);
        Task<Role> AddRoleAsync(Role role);
        Task<Role> UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(Guid roleId);
        Task<RoleWithPrivilegesDto> GetRoleWithPrivilegesAsync(Guid roleId);
    }
}
