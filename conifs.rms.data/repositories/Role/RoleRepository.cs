using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using conifs.rms.data.entities;
using conifs.rms.dto;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace conifs.rms.data
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RoleRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleByIdAsync(Guid roleId)
        {
            return await _context.Roles.FindAsync(roleId);
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

        // rolePrivilege methods
        public async Task<IEnumerable<RolePrivilegeDto>> GetAllRolePrivilege()
        {
            try
            {
                var privi = await _context.RolePrivileges.ToListAsync();
                return _mapper.Map<List<RolePrivilegeDto>>(privi);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception($"Error getting rolePrivilege: {ex.Message}", ex);
            }
        }

        public async Task<IEnumerable<RolePrivilegeDto>> GetRolePrivilege(Guid id)
        {
            try
            {
                var privi = await _context.RolePrivileges
                    .Where(ts => ts.RoleCode == id)
                .ToListAsync();
                return _mapper.Map<IEnumerable<RolePrivilegeDto>>(privi);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception($"Error getting rolePrivilege by id: {ex.Message}", ex);
            }
        }

        public async Task AddRolePrivilege(RolePrivilegeDto rolePrivilegeDto)
        {
            try
            {
                var privi = _mapper.Map<RolePrivilege>(rolePrivilegeDto);
                _context.RolePrivileges.Add(privi);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception($"Error adding rolePrivilege: {ex.Message}", ex);
            }
        }

        public async Task UpdateRolePrivilege(RolePrivilegeDto updatedRolePrivilege)
        {
            try
            {
                var privi = await _context.RolePrivileges.FindAsync(updatedRolePrivilege.RolePrivilegeCode);
                if (privi == null)
                {
                    throw new KeyNotFoundException("rolePrivilege not found");
                }
                
                privi.RoleCode = updatedRolePrivilege.RoleCode;
                privi.PrivilegeCode = updatedRolePrivilege.PrivilegeCode;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception($"Error updating rolePrivilege: {ex.Message}", ex);
            }
        }

        public async Task DeleteRolePrivilege(Guid id)
        {
            try
            {
                var privi = await _context.RolePrivileges.FindAsync(id);
                if (privi == null)
                {
                    throw new KeyNotFoundException("rolePrivilege not found");
                }
                _context.RolePrivileges.Remove(privi);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception($"Error deleting rolePrivilege: {ex.Message}", ex);
            }
        }
    }
}