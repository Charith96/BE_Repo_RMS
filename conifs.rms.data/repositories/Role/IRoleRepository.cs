using conifs.rms.data.entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace conifs.rms.data
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllRolesAsync();
        Task<Role> GetRoleByIdAsync(string roleId);
        Task<Role> AddRoleAsync(Role role);
        Task<Role> UpdateRoleAsync(Role role);
        Task<bool> DeleteRoleAsync(string roleId);
    }
}
