using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using conifs.rms.data;
using conifs.rms.data.entities;
using FluentValidation;

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

        public async Task<Role> GetRoleByIdAsync(Guid roleCode)
        {
            return await _roleRepository.GetRoleByIdAsync(roleCode);
        }

        public async Task<Role> AddRoleAsync(Role role)
        {
            var validationResult = _roleValidator.Validate(role);

            if (!validationResult.IsValid)
            {
                // Handle validation failures
                throw new ValidationException(validationResult.Errors);
            }

            return await _roleRepository.AddRoleAsync(role);
        }

        public async Task<Role> UpdateRoleAsync(Role role)
        {
            var validationResult = _roleValidator.Validate(role);

            if (!validationResult.IsValid)
            {
                // Handle validation failures
                throw new ValidationException(validationResult.Errors);
            }

            return await _roleRepository.UpdateRoleAsync(role);
        }

        public async Task<bool> DeleteRoleAsync(Guid roleCode)
        {
            return await _roleRepository.DeleteRoleAsync(roleCode);
        }
    }
}
