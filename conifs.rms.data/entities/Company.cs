
using conifs.rms.data.repositories;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace conifs.rms.data.entities;
using System.Collections.Generic;
public class Company
{
    [Key]
    public Guid CompanyId { get; set; }
    public string CompanyName { get; set; }

    public ICollection<UserCompany> UserCompanies { get; set; }
}