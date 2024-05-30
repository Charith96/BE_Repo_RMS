using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using conifs.rms.dto.Role;

namespace conifs.rms.business
{
    public interface IRoleManager
    {
        Task<IEnumerable<RoleDto>> GetAllRolesAsync();
        Task<RoleDto> GetRoleByIdAsync(Guid roleCode);
        Task<RoleDto> AddRoleAsync(RoleDto role);
        Task<RoleDto> UpdateRoleAsync(RoleDto role);
        Task<bool> DeleteRoleAsync(Guid roleCode);
    }
}
