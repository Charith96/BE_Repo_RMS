
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace conifs.rms.dto
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "First name is required")]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(20)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Default Company is required")]
        [StringLength(50)]
        public string DefaultCompany { get; set; }

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
        
    }

    public class CreateUserCompanyDto
    {

        [ForeignKey("User")]
        public Guid id { get; set; }


        [ForeignKey("Company")]
        public Guid CompanyId { get; set; }
    }
    public class CreateUserRoleDto
    {

        [ForeignKey("User")]

        public Guid id { get; set; }



        [ForeignKey("Role")]
        public Guid RoleId { get; set; }

    }
    public class GetUserDto
    {

        public Guid id { get; set; }

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
        public List<String> Companies { get; set; } = new List<string>();

        public List<String> Roles { get; set; } = new List<string>();



    }
    public class GetUserDtoList
    {

        public Guid id { get; set; }

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




    }



    public class PutUserDto
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
    }
    public class UserResponseDto
    {
        public Guid id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DefaultCompany { get; set; }
        public string Designation { get; set; }
        public string PrimaryRole { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTill { get; set; }
        public string Password { get; set; }
        public string ImageData { get; set; }

      


    }
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _startDatePropertyName;

        public DateGreaterThanAttribute(string startDatePropertyName)
        {
            _startDatePropertyName = startDatePropertyName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var startDateProperty = validationContext.ObjectType.GetProperty(_startDatePropertyName);

            if (startDateProperty == null)
            {
                return new ValidationResult($"Unknown property {_startDatePropertyName}");
            }

            var startDateValue = (DateTime?)startDateProperty.GetValue(validationContext.ObjectInstance);
            var endDateValue = (DateTime?)value;

            if (startDateValue.HasValue && endDateValue.HasValue && endDateValue <= startDateValue)
            {
                return new ValidationResult(ErrorMessage ?? $"{validationContext.DisplayName} must be greater than {_startDatePropertyName}");
            }

            return ValidationResult.Success;
        }
    }
}
