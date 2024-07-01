using conifs.rms.data.entities;
using conifs.rms.dto.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conifs.rms.business.managers
{
    public interface IAdminManager
    {
        public Task<List<AdminDto>> GetAllAdmins();
        public Task<AdminDto> GetAdminById(Guid id);
        public Task AddAdmin(AdminDto admin);
    }
}
