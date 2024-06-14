
using conifs.rms.data.entities;
using conifs.rms.data.repositories.User;
using conifs.rms.dto.Users;
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

        void IUserManager.AddUser(UserTable newUser)
        {
            throw new NotImplementedException();
        }

        void IUserManager.CreateUser(CreateUserDto UserCreateDto)
        {
            throw new NotImplementedException();
        }

        void IUserManager.CreateUserCompany(CreateUserCompanyDto userCompany)
        {
            throw new NotImplementedException();
        }

        void IUserManager.DeleteUser(string userCode)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<GetUserDto>> IUserManager.GetAllUsers()
        {
            throw new NotImplementedException();
        }

        GetUserDto IUserManager.GetUserById(string userCode)
        {
            throw new NotImplementedException();
        }

        IEnumerable<UserCompany> IUserManager.GetUserCompanies(string userCode)
        {
            throw new NotImplementedException();
        }

        IEnumerable<UserRoles> IUserManager.GetUserRoles(string userCode)
        {
            throw new NotImplementedException();
        }

        bool IUserManager.IfExistUser(string userCode)
        {
            throw new NotImplementedException();
        }

        void IUserManager.UpdateUser(PutUserDto user, string userid)
        {
            throw new NotImplementedException();
        }
    
    }
}
