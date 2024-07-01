using conifs.rms.data.entities;
using conifs.rms.data.repositories.Admin;
using conifs.rms.business.validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using conifs.rms.dto.Admin;
using AutoMapper;
using System.Text.RegularExpressions;

namespace conifs.rms.business.managers
{
    public class AdminManager : IAdminManager
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;

        public AdminManager(IAdminRepository adminRepository, IMapper mapper)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;

        }

        public Task<List<AdminDto>> GetAllAdmins()
        {
            try
            {
                return _adminRepository.GetAllAdmins();
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error getting admins", ex);
            }
        }

        public Task<AdminDto> GetAdminById(Guid id)
        {
            try
            {
                return _adminRepository.GetAdminById(id);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error getting admin by id", ex);
            }
        }

        public async Task AddAdmin(AdminDto admin)
        {

            var validator = new AdminValidator();
            var validationResult = await validator.ValidateAsync(admin);

            if (!validationResult.IsValid)
            {
                // Handle validation errors
                throw new ValidationException(validationResult.Errors);
            }

            try
            {
                await _adminRepository.AddAdmin(admin);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error adding admin", ex);
            }
        }
    }
}
    

        

        

        
  
