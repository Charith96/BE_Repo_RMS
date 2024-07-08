using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conifs.rms.dto.Users
{
    public class PutUserDto
    {

        [Key]

        public Guid Userid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DefaultCompany { get; set; }

        public string ImageData { get; set; }
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
