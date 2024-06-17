using System;
using System.ComponentModel.DataAnnotations;

namespace conifs.rms.data.entities
{
    public class Privilege
    {
        [Key]
        public Guid PrivilegeCode { get; set; }
        public string PrivilegeName { get; set; }
    }
}