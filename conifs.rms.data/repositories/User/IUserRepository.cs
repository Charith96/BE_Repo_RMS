using conifs.rms.data.entities;
using conifs.rms.dto;
using conifs.rms.dto.Users;

namespace conifs.rms.data.repositories.User;

public interface IUserRepository
{
    Task<ICollection<GetUserDto>> GetAllUsers();

    GetUserDto GetUserById(string userCode);

    bool IfExistUser(string userCode);

    void AddUser(UserTable newUser);

    void UpdateUser(PutUserDto user,string userid);

    void DeleteUser(string userCode);


    void CreateUser(CreateUserDto UserCreateDto);
    void CreateUserCompany(CreateUserCompanyDto userCompany);
    void CreateUserRole(CreateUserRoleDto userRole);
    IEnumerable<UserCompany> GetUserCompanies(string userCode);
    IEnumerable<UserRoles> GetUserRoles(string userCode);

}
