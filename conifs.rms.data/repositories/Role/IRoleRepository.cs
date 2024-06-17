using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using conifs.rms.data.entities;
using conifs.rms.dto;

namespace conifs.rms.data
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role> GetRoleByIdAsync(Guid roleId);
        Task<Role> AddRoleAsync(Role role);
        Task<Role> UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(Guid roleId);
        Task<IEnumerable<RolePrivilegeDto>> GetAllRolePrivilege();
        Task<RolePrivilegeDto> GetRolePrivilege(Guid id);
        Task AddRolePrivilege(RolePrivilegeDto rolePrivilegeDto);
        Task UpdateRolePrivilege(RolePrivilegeDto updatedRolePrivilege);
        Task DeleteRolePrivilege(Guid id);
    }
}