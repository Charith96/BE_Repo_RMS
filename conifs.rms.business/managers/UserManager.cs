
using conifs.rms.data.entities;
using conifs.rms.data.repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;

namespace conifs.rms.business.managers
{
    public class UserManager : IUserManager
    {
        public void AddUser(UserTable newUser)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(string Userid)
        {
            throw new NotImplementedException();
        }

        public ICollection<UserTable> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public UserTable GetUserById(string Userid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserCompany> GetUserCompanies(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserRoles> GetUserRoles(string id)
        {
            throw new NotImplementedException();
        }

        public bool IfExistUser(string Userid)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(UserTable user)
        {
            throw new NotImplementedException();
        }
        //public void CreateUser(UserCreateDto UserCreateDto)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
