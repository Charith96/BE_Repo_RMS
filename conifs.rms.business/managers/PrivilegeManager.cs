using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using conifs.rms.data;
using conifs.rms.data.entities;
using FluentValidation;

namespace conifs.rms.business
{
    public class PrivilegeManager : IPrivilegeManager
    {
        private readonly IPrivilegeRepository _privilegeRepository;
        private readonly IValidator<Privilege> _privilegeValidator;

        public PrivilegeManager(IPrivilegeRepository privilegeRepository, IValidator<Privilege> privilegeValidator)
        {
            _privilegeRepository = privilegeRepository;
            _privilegeValidator = privilegeValidator;
        }

        public async Task<IEnumerable<Privilege>> GetAllPrivilegesAsync()
        {
            return await _privilegeRepository.GetAllPrivilegesAsync();
        }

        public async Task<Privilege> GetPrivilegeByIdAsync(Guid privilegeCode)
        {
            return await _privilegeRepository.GetPrivilegeByIdAsync(privilegeCode);
        }

        public async Task<Privilege> AddPrivilegeAsync(Privilege privilege)
        {
            var validationResult = _privilegeValidator.Validate(privilege);

            if (!validationResult.IsValid)
            {
                // Handle validation failures
                throw new ValidationException(validationResult.Errors);
            }

            return await _privilegeRepository.AddPrivilegeAsync(privilege);
        }

        public async Task<Privilege> UpdatePrivilegeAsync(Privilege privilege)
        {
            var validationResult = _privilegeValidator.Validate(privilege);

            if (!validationResult.IsValid)
            {
                // Handle validation failures
                throw new ValidationException(validationResult.Errors);
            }

            return await _privilegeRepository.UpdatePrivilegeAsync(privilege);
        }

        public async Task<bool> DeletePrivilegeAsync(Guid privilegeCode)
        {
            return await _privilegeRepository.DeletePrivilegeAsync(privilegeCode);
        }
    }
}
