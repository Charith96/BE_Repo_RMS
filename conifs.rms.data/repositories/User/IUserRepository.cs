using conifs.rms.data.entities;
using conifs.rms.dto.Users;

namespace conifs.rms.data.repositories.User;

public interface IUserRepository
{
    Task<UserTable> GetUserByIdFull(string userId);

    Task<ICollection<GetUserDtoList>> GetAllUsers();

    bool IfExistUser(string userId);



    void UpdateUser(UserTable user);

    void DeleteUser(string id);

    IEnumerable<UserCompany> GetUserCompanies(string userId);

    IEnumerable<UserRoles> GetUserRoles(string userId);

    void CreateUser(UserTable userCreate);

    void CreateUserCompany(UserCompany userCompany);

    void CreateUserRole(UserRoles userRole);

    void DeleteUserCompany(string id);

    void DeleteUserRole(string id);
}
