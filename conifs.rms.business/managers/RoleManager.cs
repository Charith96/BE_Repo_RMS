using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using conifs.rms.data;
using conifs.rms.data.entities;
using conifs.rms.dto.Role;
using FluentValidation;
using AutoMapper;

namespace conifs.rms.business
{
    public class RoleManager : IRoleManager
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IValidator<RoleDto> _roleDtoValidator;
        private readonly IMapper _mapper;

        public RoleManager(IRoleRepository roleRepository, IValidator<RoleDto> roleDtoValidator, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _roleDtoValidator = roleDtoValidator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoleDto>> GetAllRolesAsync()
        {
            var roles = await _roleRepository.GetAllRolesAsync();
            return _mapper.Map<IEnumerable<RoleDto>>(roles);
        }

        public async Task<RoleDto> GetRoleByIdAsync(Guid roleCode)
        {
            var role = await _roleRepository.GetRoleByIdAsync(roleCode);
            return _mapper.Map<RoleDto>(role);
        }

        public async Task<RoleDto> AddRoleAsync(RoleDto roleDto)
        {
            var validationResult = _roleDtoValidator.Validate(roleDto);

            if (!validationResult.IsValid)
            {
                // Handle validation failures
                throw new ValidationException(validationResult.Errors);
            }

            var role = _mapper.Map<Role>(roleDto);
            var addedRole = await _roleRepository.AddRoleAsync(role);
            return _mapper.Map<RoleDto>(addedRole);
        }

        public async Task<RoleDto> UpdateRoleAsync(RoleDto roleDto)
        {
            var validationResult = _roleDtoValidator.Validate(roleDto);

            if (!validationResult.IsValid)
            {
                // Handle validation failures
                throw new ValidationException(validationResult.Errors);
            }

            var role = _mapper.Map<Role>(roleDto);
            var updatedRole = await _roleRepository.UpdateRoleAsync(role);
            return _mapper.Map<RoleDto>(updatedRole);
        }

        public async Task<bool> DeleteRoleAsync(Guid roleCode)
        {
            return await _roleRepository.DeleteRoleAsync(roleCode);
        }
    }
}
