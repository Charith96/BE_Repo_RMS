using conifs.rms.data.entities;
using conifs.rms.dto.Privilege;

namespace conifs.rms.business.mappers
{
    public static class PrivilegeMappers
    {
        public static PrivilegeDto ToDto(Privilege privilege)
        {
            return new PrivilegeDto
            {
                PrivilegeName = privilege.PrivilegeName
            };
        }

        public static Privilege ToEntity(PrivilegeDto privilegeDto)
        {
            return new Privilege
            {
                PrivilegeName = privilegeDto.PrivilegeName
            };
        }
    }
}
