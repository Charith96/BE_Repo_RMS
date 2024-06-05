﻿using conifs.rms.data.entities;
using conifs.rms.dto;

namespace conifs.rms.data.repositories.User;

public interface IUserRepository
{
    Task<ICollection<GetUserDto>> GetAllUsers();

 

    bool IfExistUser(string userCode);

    void AddUser(UserTable newUser);

    void UpdateUser(PutUserDto user,string userid);

    void DeleteUser(string userCode);
    Task<GetUserDto> GetUserByIdFull(string userId);
    void CreateUser(CreateUserDto UserCreateDto);
    void CreateUserCompany(CreateUserCompanyDto userCompany);
    void CreateUserRole(CreateUserRoleDto userRole);
    IEnumerable<UserCompany> GetUserCompanies(string userCode);
    IEnumerable<UserRoles> GetUserRoles(string userCode);

    void DeleteUserCompany(string id);
    void DeleteUserRole(string id);
}
