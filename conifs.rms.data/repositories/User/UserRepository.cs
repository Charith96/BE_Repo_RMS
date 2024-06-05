﻿using AutoMapper;
using conifs.rms.data.entities;
using Microsoft.EntityFrameworkCore;
using conifs.rms.dto;
using System.Linq;


namespace conifs.rms.data.repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetUserDto> GetUserByIdFull(string userId)
        {
            // Fetch the user entity
            var userEntity = await _context.User
                .FirstOrDefaultAsync(u => u.Userid.ToString() == userId);

            if (userEntity == null)
            {
                return null;
            }

            // Map user entity to UserTable
            var userResponse = _mapper.Map<GetUserDto>(userEntity);

            // Fetch user companies
            var userCompanies = await _context.UserCompany
                .Where(uc => uc.Userid.ToString() == userId)
                .Select(uc => uc.CompanyId.ToString()) // Use .ToString() to convert GUID to string if needed
                .ToListAsync();

            // Fetch user roles
            var userRoles = await _context.UserRole
                .Where(ur => ur.Userid.ToString() == userId)
                .Select(ur => ur.RoleId.ToString()) // Use .ToString() to convert GUID to string if needed
                .ToListAsync();

            // Map the results to the response
            userResponse.Companies = userCompanies;
            userResponse.Roles = userRoles;

            return userResponse;
        }

        public async Task<ICollection<GetUserDto>> GetAllUsers()
        {
            var users = await _context.User
                .Select(u => _mapper.Map<GetUserDto>(u))
                .ToListAsync();

            return users;
        }


        public bool IfExistUser(string Userid)
        {
            return _context.User.Any(u => u.Userid.ToString() == Userid);
        }

        public void AddUser(UserTable newUser)
        {
            _context.User.Add(newUser);
            _context.SaveChanges();
        }
       
        public void UpdateUser(PutUserDto user, string Userid)
        {
            var userUpdate = _context.User.FirstOrDefault(u => u.Userid.ToString() == Userid);
            if (userUpdate != null)
            {
                _mapper.Map(user, userUpdate);
                _context.User.Update(userUpdate);
                _context.SaveChanges();
            }
         
        
        }

        public void DeleteUser(string id)
        {
            var userToDelete = _context.User.FirstOrDefault(u => u.Userid.ToString() == id);

            if (userToDelete != null)
            {
                _context.User.Remove(userToDelete);
                _context.SaveChanges();
            }
        }
        public IEnumerable<UserCompany> GetUserCompanies(string Userid)
        {

            return _context.UserCompany.Where(uc => uc.Userid.ToString() == Userid).ToList();
        }
        public IEnumerable<UserRoles> GetUserRoles(string Userid)
        {

            return _context.UserRole.Where(uc => uc.Userid.ToString() == Userid).ToList();
        }
        public void CreateUser(CreateUserDto userCreateDto)
        {

            var userEntity = _mapper.Map<UserTable>(userCreateDto);

       
            _context.User.Add(userEntity);


            _context.SaveChanges();
        }
       
            public void CreateUserCompany(CreateUserCompanyDto userCompany)
        {
            var userCompanyEntity = _mapper.Map<UserCompany>(userCompany);

            _context.UserCompany.Add(userCompanyEntity);
            _context.SaveChanges();
        }
        public void CreateUserRole(CreateUserRoleDto userRole)
        {
            var userRoleEntity = _mapper.Map<UserRoles>(userRole);

            _context.UserRole.Add(userRoleEntity);
            _context.SaveChanges();
        }
        public void DeleteUserCompany(string id)
        {
            var userCompanyToDelete = _context.UserCompany.FirstOrDefault(u => u.Userid.ToString() == id);

            if (userCompanyToDelete != null)
            {
                _context.UserCompany.Remove(userCompanyToDelete);
                _context.SaveChanges();
            }
        }
        public void DeleteUserRole(string id)
        {
            var userRoleToDelete = _context.UserRole.FirstOrDefault(u => u.Userid.ToString() == id);

            if (userRoleToDelete != null)
            {
                _context.UserRole.Remove(userRoleToDelete);
                _context.SaveChanges();
            }
        }
    }
}
