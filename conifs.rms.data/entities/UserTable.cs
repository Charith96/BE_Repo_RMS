using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.ComponentModel.DataAnnotations;
using System.Data;
using conifs.rms.dto.Users;
namespace conifs.rms.data.entities
{
   
   public class UserTable
    {
        [Key]
      
        public Guid Userid { get; set; }

      

        [Required(ErrorMessage = "First name is required")]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Default Company is required")]
        [StringLength(50)]
        public string DefaultCompany { get; set; } 

        [Required(ErrorMessage = "Designation is required")]
        [StringLength(40)]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Primary Role is required")]
        [StringLength(20)]
        public string PrimaryRole { get; set; } 

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Valid from date is required")]
        [DataType(DataType.Date)]
        public DateTime ValidFrom { get; set; }

        [Required(ErrorMessage = "Valid till date is required")]
        [DataType(DataType.Date)]
        [DateGreaterThan("ValidFrom", ErrorMessage = "Valid till date must be greater than valid from date")]
        public DateTime ValidTill { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; }

        public ICollection<UserCompany>? UserCompanies { get; set; }

        public ICollection<UserRoles>? UserRoles { get; set; }
        public string ImageData { get; set; } = "default_image";
        public UserTable()
        {
       
            Userid = Guid.NewGuid();
        }
    }

   
}