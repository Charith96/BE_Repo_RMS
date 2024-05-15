using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using conifs.rms.data.entities;

namespace conifs.rms.data
{
    public class PrivilegeRepository : IPrivilegeRepository
    {
        private readonly ApplicationDbContext _context;

        public PrivilegeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Privilege>> GetAllPrivilegesAsync()
        {
            return await _context.Privileges.ToListAsync();
        }

        public async Task<Privilege> GetPrivilegeByIdAsync(string privilegeId)
        {
            return await _context.Privileges.FirstOrDefaultAsync(p => p.PrivilegeId == privilegeId);
        }

        public async Task<Privilege> AddPrivilegeAsync(Privilege privilege)
        {
            await _context.Privileges.AddAsync(privilege);
            await _context.SaveChangesAsync();
            return privilege;
        }

        public async Task<Privilege> UpdatePrivilegeAsync(Privilege privilege)
        {
            _context.Privileges.Update(privilege);
            await _context.SaveChangesAsync();
            return privilege;
        }

        public async Task<bool> DeletePrivilegeAsync(string privilegeId)
        {
            var privilege = await _context.Privileges.FirstOrDefaultAsync(p => p.PrivilegeId == privilegeId);
            if (privilege == null)
            {
                return false;
            }

            _context.Privileges.Remove(privilege);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
