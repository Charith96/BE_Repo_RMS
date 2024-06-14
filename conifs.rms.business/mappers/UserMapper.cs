using conifs.rms.data.entities;
using conifs.rms.dto.Users;


namespace conifs.rms.business.mappers
{
    public class UserMapper
    {
        public UserTable Map(CreateUserDto input)
        {
            if (string.IsNullOrWhiteSpace(input?.FirstName))
            {
                throw new ArgumentException("FirstName cannot be null or empty");
            }

            if (string.IsNullOrWhiteSpace(input?.LastName))
            {
                throw new ArgumentException("LastName cannot be null or empty");
            }

            if (string.IsNullOrWhiteSpace(input?.Email))
            {
                throw new ArgumentException("Email cannot be null or empty");
            }

            if (string.IsNullOrWhiteSpace(input?.PrimaryRole))
            {
                throw new ArgumentException("PrimaryRole cannot be null or empty");
            }

            if (string.IsNullOrWhiteSpace(input?.DefaultCompany))
            {
                throw new ArgumentException("DefaultCompany cannot be null or empty");
            }
            if (string.IsNullOrWhiteSpace(input?.Password))
            {
                throw new ArgumentException("password cannot be null or empty");
            }
          
            return new UserTable()
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Email = input.Email,
                PrimaryRole = input.PrimaryRole,
                DefaultCompany = input.DefaultCompany,
                Password = input.Password,
                ValidFrom = input.ValidFrom,
                ValidTill = input.ValidTill,

            };
        }

    
       
 
     
        public UserTable Map(PutUserDto input)
        {
            return new UserTable()
            {

                FirstName = input?.FirstName,
                LastName = input?.LastName,
                Email = input?.Email,
                PrimaryRole = input?.PrimaryRole,
                Designation = input?.Designation,
             


            };


        }
        public GetUserDto Map(UserTable input)
        {
            return new GetUserDto()
            {

                FirstName = input?.FirstName,
                LastName = input?.LastName,
                Email = input?.Email,
                PrimaryRole = input?.PrimaryRole,
                Designation = input?.Designation,



            };


        }
    }
}
