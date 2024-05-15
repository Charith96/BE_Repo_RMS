using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using conifs.rms.data;
using conifs.rms.data.entities;

namespace conifs.rms.business
{
    public class RoleManager : IRoleManager
    {
        private readonly IRoleRepository _roleRepository;

        public RoleManager(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _roleRepository.GetAllRolesAsync();
        }

        public async Task<Role> GetRoleByIdAsync(string roleId)
        {
            return await _roleRepository.GetRoleByIdAsync(roleId);
        }

        public async Task<Role> AddRoleAsync(Role role)
        {
            return await _roleRepository.AddRoleAsync(role);
        }

        public async Task<Role> UpdateRoleAsync(Role role)
        {
            return await _roleRepository.UpdateRoleAsync(role);
        }

        public async Task<bool> DeleteRoleAsync(string roleId)
        {
            return await _roleRepository.DeleteRoleAsync(roleId);
        }
    }
}
