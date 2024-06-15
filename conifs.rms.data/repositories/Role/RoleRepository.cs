using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using conifs.rms.data.entities;
using conifs.rms.dto;
using Microsoft.EntityFrameworkCore;

namespace conifs.rms.data
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;

        public RoleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleByIdAsync(Guid roleId)
        {
            return await _context.Roles
                                 .Include(r => r.Privileges) // Ensure Privileges are loaded
                                 .FirstOrDefaultAsync(r => r.RoleID == roleId);
        }


        public async Task<Role> AddRoleAsync(Role role)
        {
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<Role> UpdateRoleAsync(Role role)
        {
            _context.Entry(role).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task DeleteRoleAsync(Guid roleId)
        {
            var role = await _context.Roles.FindAsync(roleId);
            if (role != null)
            {
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<RoleWithPrivilegesDto> GetRoleWithPrivilegesAsync(Guid roleId)
        {
            var role = await _context.Roles
                .Include(r => r.RolePrivileges)
                .ThenInclude(rp => rp.Privilege)
                .FirstOrDefaultAsync(r => r.RoleCode == roleId);

            if (role == null) return null;

            return new RoleWithPrivilegesDto
            {
                RoleID = role.RoleID,
                RoleName = role.RoleName,
                PrivilegeNames = role.RolePrivileges.Select(rp => rp.Privilege.PrivilegeName).ToList()
            };
        }
    }
}
