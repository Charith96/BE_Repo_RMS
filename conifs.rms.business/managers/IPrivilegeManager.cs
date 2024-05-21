using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using conifs.rms.data.entities;

namespace conifs.rms.business
{
    public interface IPrivilegeManager
    {
        Task<IEnumerable<Privilege>> GetAllPrivilegesAsync();
        Task<Privilege> GetPrivilegeByIdAsync(Guid privilegeCode);
        Task<Privilege> AddPrivilegeAsync(Privilege privilege);
        Task<Privilege> UpdatePrivilegeAsync(Privilege privilege);
        Task<bool> DeletePrivilegeAsync(Guid privilegeCode);
    }
}
