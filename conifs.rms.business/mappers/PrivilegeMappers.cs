using conifs.rms.dto.Role;
using conifs.rms.data.entities;

namespace conifs.rms.business.Mappers
{
    public class PrivilegeMapper
    {
        public Privilege Map(PrivilegeDto input)
        {
            return new Privilege()
            {
                PrivilegeCode = input?.PrivilegeCode ?? Guid.Empty,
                PrivilegeId = input?.PrivilegeId,
                PrivilegeName = input?.PrivilegeName
            };
        }

        public PrivilegeDto Map(Privilege input)
        {
            return new PrivilegeDto()
            {
                PrivilegeCode = input?.PrivilegeCode ?? Guid.Empty,
                PrivilegeId = input?.PrivilegeId,
                PrivilegeName = input?.PrivilegeName
            };
        }
    }
}
