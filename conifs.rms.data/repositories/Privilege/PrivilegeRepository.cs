using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using conifs.rms.data.entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Privilege> GetPrivilegeByIdAsync(Guid privilegeId)
        {
            return await _context.Privileges.FindAsync(privilegeId);
        }

        public async Task<Privilege> AddPrivilegeAsync(Privilege privilege)
        {
            _context.Privileges.Add(privilege);
            await _context.SaveChangesAsync();
            return privilege;
        }

        public async Task<Privilege> UpdatePrivilegeAsync(Privilege privilege)
        {
            _context.Entry(privilege).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return privilege;
        }

        public async Task DeletePrivilegeAsync(Guid privilegeId)
        {
            var privilege = await _context.Privileges.FindAsync(privilegeId);
            if (privilege != null)
            {
                _context.Privileges.Remove(privilege);
                await _context.SaveChangesAsync();
            }
        }
    }
}
