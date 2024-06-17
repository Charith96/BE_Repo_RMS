using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using conifs.rms.data;
using conifs.rms.data.entities;
using conifs.rms.business.validations;
using FluentValidation;
using FluentValidation.Results;
using conifs.rms.dto.Privilege;

namespace conifs.rms.business
{
    public class PrivilegeManager : IPrivilegeManager
    {
        private readonly IPrivilegeRepository _privilegeRepository;
        private readonly IValidator<Privilege> _privilegeValidator;

        public PrivilegeManager(IPrivilegeRepository privilegeRepository)
        {
            _privilegeRepository = privilegeRepository;
            _privilegeValidator = new PrivilegeValidation(); // Initialize the validator
        }

        public async Task<IEnumerable<Privilege>> GetAllPrivilegesAsync()
        {
            return await _privilegeRepository.GetAllPrivilegesAsync();
        }

        public async Task<Privilege> GetPrivilegeByIdAsync(Guid privilegeId)
        {
            return await _privilegeRepository.GetPrivilegeByIdAsync(privilegeId);
        }

        public async Task<Privilege> AddPrivilegeAsync(Privilege privilege)
        {
            privilege.PrivilegeCode = Guid.NewGuid(); // Generate a new PrivilegeCode internally
            ValidationResult result = _privilegeValidator.Validate(privilege);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            return await _privilegeRepository.AddPrivilegeAsync(privilege);
        }

        public async Task<Privilege> UpdatePrivilegeAsync(Privilege privilege)
        {
            ValidationResult result = _privilegeValidator.Validate(privilege);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

            return await _privilegeRepository.UpdatePrivilegeAsync(privilege);
        }

        public async Task DeletePrivilegeAsync(Guid privilegeId)
        {
            await _privilegeRepository.DeletePrivilegeAsync(privilegeId);
        }
    }
}