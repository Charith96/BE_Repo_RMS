using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using conifs.rms.data;
using conifs.rms.data.entities;
using conifs.rms.dto.Role;
using FluentValidation;

namespace conifs.rms.business
{
    public class PrivilegeManager : IPrivilegeManager
    {
        private readonly IPrivilegeRepository _privilegeRepository;
        private readonly IValidator<Privilege> _privilegeValidator;
        private readonly IMapper _mapper;

        public PrivilegeManager(IPrivilegeRepository privilegeRepository, IValidator<Privilege> privilegeValidator, IMapper mapper)
        {
            _privilegeRepository = privilegeRepository;
            _privilegeValidator = privilegeValidator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PrivilegeDto>> GetAllPrivilegesAsync()
        {
            var privileges = await _privilegeRepository.GetAllPrivilegesAsync();
            return _mapper.Map<IEnumerable<PrivilegeDto>>(privileges);
        }

        public async Task<PrivilegeDto> GetPrivilegeByIdAsync(Guid privilegeCode)
        {
            var privilege = await _privilegeRepository.GetPrivilegeByIdAsync(privilegeCode);
            return _mapper.Map<PrivilegeDto>(privilege);
        }

        public async Task<PrivilegeDto> AddPrivilegeAsync(PrivilegeDto privilegeDto)
        {
            var privilege = _mapper.Map<Privilege>(privilegeDto);
            var validationResult = _privilegeValidator.Validate(privilege);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var addedPrivilege = await _privilegeRepository.AddPrivilegeAsync(privilege);
            return _mapper.Map<PrivilegeDto>(addedPrivilege);
        }

        public async Task<PrivilegeDto> UpdatePrivilegeAsync(PrivilegeDto privilegeDto)
        {
            var privilege = _mapper.Map<Privilege>(privilegeDto);
            var validationResult = _privilegeValidator.Validate(privilege);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var updatedPrivilege = await _privilegeRepository.UpdatePrivilegeAsync(privilege);
            return _mapper.Map<PrivilegeDto>(updatedPrivilege);
        }

        public async Task<bool> DeletePrivilegeAsync(Guid privilegeCode)
        {
            return await _privilegeRepository.DeletePrivilegeAsync(privilegeCode);
        }
    }
}
