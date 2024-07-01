using AutoMapper;
using conifs.rms.data.entities;
using conifs.rms.dto.Admin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conifs.rms.data.repositories.Admin
{
    public class AdminRepository : IAdminRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AdminRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AdminDto>> GetAllAdmins()
        {
            try
            {
                var admins = await _context.Admins.ToListAsync();
                return _mapper.Map<List<AdminDto>>(admins);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception($"Error getting admins: {ex.Message}", ex);
            }
        }

        public async Task<AdminDto> GetAdminById(Guid id)
        {
            try
            {
                var admin = await _context.Admins.FindAsync(id);
                return _mapper.Map<AdminDto>(admin);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception($"Error getting admin by id: {ex.Message}", ex);
            }
        }

        public async Task AddAdmin(AdminDto admin)
        {
            try
            {
                var adminNew = _mapper.Map<conifs.rms.data.entities.Admin>(admin);
                _context.Admins.Add(adminNew);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception($"Error adding admin: {ex.Message}", ex);
            }
        }

    }
}
