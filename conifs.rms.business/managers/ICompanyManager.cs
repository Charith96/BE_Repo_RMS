using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using conifs.rms.data.entities;

namespace conifs.rms.business.managers
{
    public interface ICompanyManager
    {

        Task<IEnumerable<Company>> GetAllCompanies()
        {
            throw new NotImplementedException();
        }

        Task<Company> GetCompanyById(Guid companyID)
        {
            throw new NotImplementedException();
        }

        Task<Company> AddCompany(Company newCompany)
        {
            throw new NotImplementedException();
        }

        Task<Company> UpdateCompany(Company company)
        {
            throw new NotImplementedException();
        }

        Task DeleteCompany(Guid companyID)
        {
            throw new NotImplementedException();
        }
        //Task<IEnumerable<Company>> GetAllCompanies();
        //Task<Company> GetCompanyById(Guid companyId);
        //Task<Company> AddCompany(Company company);
        //Task<Company> UpdateCompany(Company company);
        //Task DeleteCompany(Guid companyId);
    }
}