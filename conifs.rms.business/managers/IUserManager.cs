using conifs.rms.data.entities;
using conifs.rms.dto.Users;
using Microsoft.EntityFrameworkCore;


namespace conifs.rms.business.managers
{

    public interface IUserManager
    {

        public  Task<ICollection<GetUserDtoList>> GetAllUsers();

        public  Task<GetUserDto> GetUserByIdFull(string userId);

        public bool IfExistUser(string Userid);



        public void UpdateUser(PutUserDto user, string Userid);


        public void DeleteUser(string id);

        public IEnumerable<UserCompany> GetUserCompanies(string Userid);

        public IEnumerable<UserRoles> GetUserRoles(string Userid);

        public void CreateUser(CreateUserDto userCreateDto);


        public void CreateUserCompany(CreateUserCompanyDto userCompany);

        public void CreateUserRole(CreateUserRoleDto userRole);

        public void DeleteUserCompany(string id);

        public void DeleteUserRole(string id);

     //   public Task<List<CreateUserCompanyDto>> GetUsersByCompanyId(Guid companyId);
     
    }
}