using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conifs.rms.data.entities
{
    public class Admin
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "FirstName is required.")]
        [StringLength(20, ErrorMessage = "FirstName can only be a maximum of 20 characters.")]
        public string FirstName { get; set; }

        [StringLength(20, ErrorMessage = "FirstName can only be a maximum of 20 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [StringLength(50, ErrorMessage = "Email can only be a maximum of 50 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; }

        public string Role { get; set; } = "Admin";
        
    }
}
