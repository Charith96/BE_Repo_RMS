using AutoMapper;
using conifs.rms.data;
using conifs.rms.data.entities;
using conifs.rms.data.repositories.TimeSlots;
using conifs.rms.data.repositories.User;
using conifs.rms.dto.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace conifs.rms.business.managers
{
    public class UserManager : IUserManager
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserRepository _UserReopsitory;

        public UserManager(ApplicationDbContext context, IMapper mapper,IUserRepository userRepository)
        {
            _UserReopsitory= userRepository;
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetUserDto> GetUserByIdFull(string userId)
        {
            // Fetch the user entity
            var userEntity = await _UserReopsitory.GetUserByIdFull(userId);

            if (userEntity == null)
            {
                return null;
            }

            // Map user entity to UserTable
            var userResponse = _mapper.Map<GetUserDto>(userEntity);

            // Fetch user companies
            var userCompanies = await _context.UserCompany
                .Where(uc => uc.Userid.ToString() == userId)
                .Select(uc => uc.CompanyId.ToString())
                .ToListAsync();

            // Fetch user roles
            var userRoles = await _context.UserRole
                .Where(ur => ur.Userid.ToString() == userId)
                .Select(ur => ur.RoleId)
                .ToListAsync();

            var userNames = new List<string>();


            foreach (var userCompany in userCompanies)
            {
                var companyName = _context.Companies
                    .Where(c => c.CompanyID.ToString() == userCompany)
                    .Select(c => c.CompanyName)
                    .FirstOrDefault();

                if (companyName != null)
                {
                    userNames.Add(companyName);
                }
            }
            var roleNames = new List<string>();

            foreach (var userRole in userRoles)
            {
                var roleName = await _context.Roles
                    .Where(c => c.RoleCode == userRole) // Ensure RoleID is correctly compared
                    .Select(c => c.RoleName)
                    .FirstOrDefaultAsync();

                if (roleName != null)
                {
                    roleNames.Add(roleName);
                }
            }
            userResponse.Companies = userNames;
            userResponse.Roles = roleNames;

            return userResponse;
        }


        public async Task<ICollection<GetUserDtoList>> GetAllUsers()
        {
            var users = await _UserReopsitory.GetAllUsers();

            return users;
        }


        public bool IfExistUser(string Userid)
        {
            return _UserReopsitory.IfExistUser(Userid);
        }

   
        public void UpdateUser(PutUserDto user, string Userid)
        {
            var userUpdate = _context.User.FirstOrDefault(u => u.Userid.ToString() == Userid);
            if (userUpdate != null)
            {
                var userCompanies = user.Companies;
                var userRoles = user.Roles;
                Guid userId = Guid.Parse(Userid);
                DeleteUserCompany(Userid);
                DeleteUserRole(Userid);
                foreach (var userCompany in userCompanies)
                {
                    var companyID = _context.Companies
                        .Where(c => c.CompanyName == userCompany)
                        .Select(c => c.CompanyID)
                        .First();

                    // Check if the userCompany already exists in the database
                    var existingUserCompany = _context.UserCompany
                        .FirstOrDefault(uc => uc.Userid == userId && uc.CompanyId == companyID);

                    if (existingUserCompany == null)
                    {
                        // If it doesn't exist, create a new UserCompany entity
                        var userCompanyEntity = new CreateUserCompanyDto
                        {
                            id = userId,
                            CompanyId = companyID
                        };
                        var userCompanyUpdate = _mapper.Map<UserCompany>(userCompanyEntity);
                        _context.UserCompany.Add(userCompanyUpdate);
                    }



                }
                foreach (var userRole in userRoles)
                {
                    var RoleID = _context.Roles
                        .Where(c => c.RoleName == userRole)
                        .Select(c => c.RoleCode)
                        .First();

                    // Check if the userCompany already exists in the database
                    var existingUserRole = _context.UserRole
                        .FirstOrDefault(uc => uc.Userid == userId && uc.RoleId == RoleID);

                    if (existingUserRole == null)
                    {


                        // If it doesn't exist, create a new UserCompany entity
                        var userRoleEntity = new CreateUserRoleDto
                        {
                            id = userId,
                            RoleId = RoleID
                        };
                        var userRoleUpdate = _mapper.Map<UserRoles>(userRoleEntity);
                        _context.UserRole.Add(userRoleUpdate);
                    }



                }
                _mapper.Map(user, userUpdate);
                _UserReopsitory.UpdateUser(userUpdate);
            }
        }

        public void DeleteUser(string id)
        {
            _UserReopsitory.DeleteUser(id);
        }
        public IEnumerable<UserCompany> GetUserCompanies(string Userid)
        {

            return _UserReopsitory.GetUserCompanies(Userid);
        }
        public IEnumerable<UserRoles> GetUserRoles(string Userid)
        {

            return _UserReopsitory.GetUserRoles(Userid);
        }
        public void CreateUser(CreateUserDto userCreateDto)
        {

            var userEntity = _mapper.Map<UserTable>(userCreateDto);

            _UserReopsitory.CreateUser(userEntity);
        }

        public void CreateUserCompany(CreateUserCompanyDto userCompany)
        {
            var userCompanyEntity = _mapper.Map<UserCompany>(userCompany);

            _UserReopsitory.CreateUserCompany(userCompanyEntity);
        }
        public void CreateUserRole(CreateUserRoleDto userRole)
        {
            var userRoleEntity = _mapper.Map<UserRoles>(userRole);

            _UserReopsitory.CreateUserRole(userRoleEntity);
        }
        public void DeleteUserCompany(string id)
        {
           

            _UserReopsitory.DeleteUserCompany(id);


        }
        public void DeleteUserRole(string id)
        {
           
            _UserReopsitory.DeleteUserRole(id);
        }
    }
}
