﻿using conifs.rms.data.entities;
using conifs.rms.dto.Users;
using conifs.rms.dto;


namespace conifs.rms.business.managers;

public interface IUserManager
{
    Task<ICollection<GetUserDto>> GetAllUsers();

    GetUserDto GetUserById(string userCode);

    bool IfExistUser(string userCode);

    void AddUser(UserTable newUser);

    void UpdateUser(PutUserDto user, string userid);

    void DeleteUser(string userCode);


    void CreateUser(CreateUserDto UserCreateDto);
    void CreateUserCompany(CreateUserCompanyDto userCompany);
    IEnumerable<UserCompany> GetUserCompanies(string userCode);
    IEnumerable<UserRoles> GetUserRoles(string userCode);

}
