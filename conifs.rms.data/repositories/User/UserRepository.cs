using AutoMapper;
using conifs.rms.data.entities;
using Microsoft.EntityFrameworkCore;
using conifs.rms.dto.Users;
using System.Linq;


namespace conifs.rms.data.repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserTable> GetUserByIdFull(string userId)
        {
            // Fetch the user entity
            var userEntity = await _context.User
                .FirstOrDefaultAsync(u => u.Userid.ToString() == userId);

            return userEntity;
        }


        public async Task<ICollection<GetUserDtoList>> GetAllUsers()
        {
            var users = await _context.User
                .Select(u => _mapper.Map<GetUserDtoList>(u))
                .ToListAsync();

            return users;
        }


        public bool IfExistUser(string Userid)
        {
            return _context.User.Any(u => u.Userid.ToString() == Userid);
        }



        public void UpdateUser(UserTable user)
        {
        
                _context.User.Update(user);
                _context.SaveChanges();

            
        }

        public void DeleteUser(string id)
        {
            var userToDelete = _context.User.FirstOrDefault(u => u.Userid.ToString() == id);

            if (userToDelete != null)
            {
                _context.User.Remove(userToDelete);
                _context.SaveChanges();
            }
        }
        public IEnumerable<UserCompany> GetUserCompanies(string Userid)
        {

            return _context.UserCompany.Where(uc => uc.Userid.ToString() == Userid).ToList();
        }
        public IEnumerable<UserRoles> GetUserRoles(string Userid)
        {

            return _context.UserRole.Where(uc => uc.Userid.ToString() == Userid).ToList();
        }
        public void CreateUser(UserTable userCreate)
        {

            _context.User.Add(userCreate);
            _context.SaveChanges();
        }

        public void CreateUserCompany(UserCompany userCompany)
        {
         
            _context.UserCompany.Add(userCompany);
            _context.SaveChanges();
        }
        public void CreateUserRole(UserRoles userRole)
        {
  

            _context.UserRole.Add(userRole);
            _context.SaveChanges();
        }
        public void DeleteUserCompany(string id)
        {
            var userCompanyToDelete = _context.UserCompany.Where(u => u.Userid.ToString() == id).ToList();


            _context.UserCompany.RemoveRange(userCompanyToDelete);
            _context.SaveChanges();

        }
        public void DeleteUserRole(string id)
        {
            var userGuid = Guid.Parse(id);
            var userRoleToDelete = _context.UserRole.Where(u => u.Userid == userGuid).ToList();
            _context.UserRole.RemoveRange(userRoleToDelete);
            _context.SaveChanges();

        }


        //public async Task<List<UserCompany>> GetUsersByCompanyId(Guid companyId)
        //{
        //        var users = await _context.UserCompany
        //            .Where(u => u.CompanyId == companyId)
        //            .ToListAsync();

        //    return users;

        //        //return new Exception($"Error getting users: {Exception.}")
        //    }
        //}
    }
}
