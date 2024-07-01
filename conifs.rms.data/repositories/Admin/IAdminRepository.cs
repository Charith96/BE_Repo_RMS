using conifs.rms.dto.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using conifs.rms.data.entities;

namespace conifs.rms.data.repositories.Admin
{
    public interface IAdminRepository
    {
        public Task<List<AdminDto>> GetAllAdmins();
        public Task<AdminDto> GetAdminById(Guid id);
        public Task AddAdmin(AdminDto admin);
    }
}
