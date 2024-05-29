using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using conifs.rms.data.entities;
using conifs.rms.data.repositories.User;
using Microsoft.EntityFrameworkCore;
using conifs.rms.dto;
using conifs.rms.dto.Users;

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

        public async Task<ICollection<GetUserDto>> GetAllUsers()
        {
            var users = await _context.User
                .Select(u => _mapper.Map<GetUserDto>(u))
                .ToListAsync();

            return users;
        }

        public GetUserDto GetUserById(string Userid)
        {
            var user = _context.User.FirstOrDefault(u => u.Userid.ToString() == Userid);
            return _mapper.Map<GetUserDto>(user);
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

        public void DeleteUser(string Userid)
        {
            var userToDelete = _context.User.FirstOrDefault(u => u.Userid.ToString() == Userid);

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
    }
}
