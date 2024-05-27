using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
      
        public DateTime ValidTill { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
        public string Password { get; set; }

    }
}
