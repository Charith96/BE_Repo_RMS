using conifs.rms.data.entities;


namespace conifs.rms.business.managers;

public interface IUserManager
{
    ICollection<UserTable> GetAllUsers();

    UserTable GetUserById(string userCode);

    bool IfExistUser(string userCode);

    void AddUser(UserTable newUser);

    void UpdateUser(UserTable user);

    void DeleteUser(string userCode);

    //void CreateUser(UserCreateDto UserCreateDto);

    IEnumerable<UserCompany> GetUserCompanies(string userCode);
    IEnumerable<UserRoles> GetUserRoles(string userCode);
  
}
