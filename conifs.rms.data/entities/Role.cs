
using System.ComponentModel.DataAnnotations;


namespace conifs.rms.data.entities
{
    public class Role

    // columns of the role table
    {
        [Key]
        
        [Required]
        [StringLength(8)]
        public string RoleID { get; set; }

        [Required]
        [StringLength(20)]
        public string RoleName { get; set; } = "";




        // Navigation property to RolePrivilege
        // public ICollection<RolePrivilege> RolePrivileges { get; set; }
    }
}
