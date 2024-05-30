using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using conifs.rms.dto.Role;

namespace conifs.rms.business
{
    public interface IPrivilegeManager
    {
        Task<IEnumerable<PrivilegeDto>> GetAllPrivilegesAsync();
        Task<PrivilegeDto> GetPrivilegeByIdAsync(Guid privilegeCode);
        Task<PrivilegeDto> AddPrivilegeAsync(PrivilegeDto privilegeDto);
        Task<PrivilegeDto> UpdatePrivilegeAsync(PrivilegeDto privilegeDto);
        Task<bool> DeletePrivilegeAsync(Guid privilegeCode);
    }
}
