using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using conifs.rms.data;
using conifs.rms.data.entities;
using conifs.rms.business.validations;
using FluentValidation;
using FluentValidation.Results;
using conifs.rms.dto;

namespace conifs.rms.business
{
    public class RoleManager : IRoleManager
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IValidator<Role> _roleValidator;

        public RoleManager(IRoleRepository roleRepository, IValidator<Role> roleValidator)
        {
            _roleRepository = roleRepository;
            _roleValidator = roleValidator;
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _roleRepository.GetAllRolesAsync();
        }

        public async Task<Role> GetRoleByIdAsync(Guid roleId)
        {
            return await _roleRepository.GetRoleByIdAsync(roleId);
        }

        public async Task<Role> AddRoleAsync(Role role)
        {
            role.RoleCode = Guid.NewGuid(); // Ensure RoleCode is set internally
            ValidationResult validationResult = _roleValidator.Validate(role);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join("; ", validationResult.Errors));
            }

            return await _roleRepository.AddRoleAsync(role);
        }

        public async Task<Role> UpdateRoleAsync(Role role)
        {
            ValidationResult validationResult = _roleValidator.Validate(role);
            if (!validationResult.IsValid)
            {
                throw new ArgumentException(string.Join("; ", validationResult.Errors));
            }

            return await _roleRepository.UpdateRoleAsync(role);
        }

        public async Task DeleteRoleAsync(Guid roleId)
        {
            await _roleRepository.DeleteRoleAsync(roleId);
        }

        public Task<IEnumerable<RolePrivilegeDto>> GetAllRolePrivilege()
        {
            try
            {
                return _roleRepository.GetAllRolePrivilege();
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error getting reservation groups", ex);
            }
        }
        public Task<IEnumerable<RolePrivilegeDto>> GetRolePrivilege(Guid id)
        {
            try
            {
                return _roleRepository.GetRolePrivilege(id);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error getting reservation group by id", ex);
            }
        }

        public async Task AddRolePrivilege(RolePrivilegeDto rolePrivilegeDto)
        {

            

            try
            {
                await _roleRepository.AddRolePrivilege(rolePrivilegeDto);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error adding reservation group", ex);
            }
        }

        public async Task UpdateRolePrivilege(RolePrivilegeDto updatedRolePrivilege)
        {

            
            try
            {

                await _roleRepository.UpdateRolePrivilege(updatedRolePrivilege);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error updating reservation group", ex);
            }
        }

        public async Task DeleteRolePrivilege(Guid id)
        {
            try
            {
                await _roleRepository.DeleteRolePrivilege(id);
            }
            catch (Exception ex)
            {
                // Log or handle the exception accordingly
                throw new Exception("Error deleting reservation group", ex);
            }
        }
    }
}