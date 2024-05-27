using System.ComponentModel.DataAnnotations;
using conifs.rms.data.entities;

namespace conifs.rms.data.entities
{
    public class GetUserDto
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

      

    }
}
