using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using conifs.rms.data;
using conifs.rms.data.entities;
using conifs.rms.business.validations;
using FluentValidation;
using FluentValidation.Results;

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
    }
}