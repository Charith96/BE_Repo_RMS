using conifs.rms.data.entities;

namespace conifs.rms.data.repositories
{
    public interface IUser
    {
        ICollection<UserTable> GetAllUsers();

        UserTable GetUserById(string userCode);

        bool IfExistUser(string userCode);

        void AddUser(UserTable newUser);

        void UpdateUser(UserTable user);

        void DeleteUser(string userCode);

        IEnumerable<UserCompany> GetUserCompanies(string userCode);
        IEnumerable<UserRoles> GetUserRoles(string userCode);
      
    }
}
