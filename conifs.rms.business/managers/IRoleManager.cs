using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using conifs.rms.data.entities;

namespace conifs.rms.business
{
    public interface IRoleManager
    {
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role> GetRoleByIdAsync(string roleId);
        Task<Role> AddRoleAsync(Role role);
        Task<Role> UpdateRoleAsync(Role role);
        Task<bool> DeleteRoleAsync(string roleId);
    }
}
