using conifs.rms.data.entities;

namespace conifs.rms.data.repositories.User;

public interface IUserRepository
{
    Task<ICollection<GetUserDto>> GetAllUsers();

    GetUserDto GetUserById(string userCode);

    bool IfExistUser(string userCode);

    void AddUser(UserTable newUser);

    void UpdateUser(UserTable user);

    void DeleteUser(string userCode);


    void CreateUser(CreateUserDto UserCreateDto);
    IEnumerable<UserCompany> GetUserCompanies(string userCode);
    IEnumerable<UserRoles> GetUserRoles(string userCode);
  
}
