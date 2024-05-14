using System.Collections.Generic;
using System.Threading.Tasks;
using conifs.rms.data;
using conifs.rms.data.entities;

namespace conifs.rms.business
{
    public class PrivilegeManager : IPrivilegeManager
    {
        private readonly IPrivilegeRepository _privilegeRepository;

        public PrivilegeManager(IPrivilegeRepository privilegeRepository)
        {
            _privilegeRepository = privilegeRepository;
        }

        public async Task<IEnumerable<Privilege>> GetAllPrivilegesAsync()
        {
            return await _privilegeRepository.GetAllPrivilegesAsync();
        }

        public async Task<Privilege> GetPrivilegeByIdAsync(string privilegeId)
        {
            return await _privilegeRepository.GetPrivilegeByIdAsync(privilegeId);
        }

        public async Task<Privilege> AddPrivilegeAsync(Privilege privilege)
        {
            return await _privilegeRepository.AddPrivilegeAsync(privilege);
        }

        public async Task<Privilege> UpdatePrivilegeAsync(Privilege privilege)
        {
            return await _privilegeRepository.UpdatePrivilegeAsync(privilege);
        }

        public async Task DeletePrivilegeAsync(string privilegeId)
        {
            await _privilegeRepository.DeletePrivilegeAsync(privilegeId);
        }
    }
}
