using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace conifs.rms.dto.Users
{
    public class CreateUserCompanyDto
    {

        


        [ForeignKey("User")]
        public Guid Userid { get; set; }
    

        [ForeignKey("Company")]
        public Guid CompanyId { get; set; }
    


       
    
}
}
