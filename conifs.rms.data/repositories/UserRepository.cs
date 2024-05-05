using conifs.rms.data;
using conifs.rms.data.repositories;
using conifs.rms.data.entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace conifs.rms.data.repositories
{
    public class UserRepository : IUser
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ICollection<UserTable> GetAllUsers()
        {
            return _context.User.ToList();
        }

        public UserTable GetUserById(string id)
        {
            return _context.User.FirstOrDefault(u => u.UserCode.ToString() == id);
        }

        public bool IfExistUser(string id)
        {
            return _context.User.Any(u => u.UserCode.ToString() == id);
        }

        public void AddUser(UserTable newUser)
        {
            _context.User.Add(newUser);
            _context.SaveChanges();
        }

        public void UpdateUser(UserTable user)
        {
            _context.User.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(string id)
        {
            var userToDelete = _context.User.FirstOrDefault(u => u.UserCode.ToString() == id);
            if (userToDelete != null)
            {
                _context.User.Remove(userToDelete);
                _context.SaveChanges();
            }
        }
        public IEnumerable<UserCompany> GetUserCompanies(string userCode)
        {
            
            return _context.UserCompany.Where(uc => uc.UserCode.ToString() == userCode).ToList();
        }
        public IEnumerable<UserRoles> GetUserRoles(string userCode)
        {
            
            return _context.UserRole.Where(uc => uc.UserCode.ToString() == userCode).ToList();
        }
     
    }
}
