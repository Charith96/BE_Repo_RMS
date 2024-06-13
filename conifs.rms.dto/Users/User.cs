
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace conifs.rms.dto
{
    public class CreateUserDto
    {
        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string DefaultCompany { get; set; }


        public string Designation { get; set; }


        public string PrimaryRole { get; set; }


        public string Email { get; set; }


        public DateTime ValidFrom { get; set; }



        public DateTime ValidTill { get; set; }

        public string Password { get; set; }

    }

    public class CreateUserCompanyDto
    {


        public Guid id { get; set; }



        public Guid CompanyId { get; set; }
    }
    public class CreateUserRoleDto
    {


        public Guid id { get; set; }




        public Guid RoleId { get; set; }

    }
    public class GetUserDto
    {

        public Guid id { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string DefaultCompany { get; set; }


        public string Designation { get; set; }


        public string PrimaryRole { get; set; }


        public string Email { get; set; }


        public DateTime ValidFrom { get; set; }


        public DateTime ValidTill { get; set; }
        public List<String> Companies { get; set; } = new List<string>();

        public List<String> Roles { get; set; } = new List<string>();



    }
    public class GetUserDtoList
    {

        public Guid id { get; set; }


        public string FirstName { get; set; }


        public string LastName { get; set; }


        public string DefaultCompany { get; set; }

        public string Designation { get; set; }


        public string PrimaryRole { get; set; }


        public string Email { get; set; }


        public DateTime ValidFrom { get; set; }



        public DateTime ValidTill { get; set; }




    }



    public class PutUserDto
    {

        [Key]

        public Guid Userid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DefaultCompany { get; set; }


        public string Designation { get; set; }


        public string PrimaryRole { get; set; }

        public string Email { get; set; }


        public DateTime ValidFrom { get; set; }



        public DateTime ValidTill { get; set; }


        public string Password { get; set; }
        public List<String> Companies { get; set; }

        public List<String> Roles { get; set; }
    }
}
 
   