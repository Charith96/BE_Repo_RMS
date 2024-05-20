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

        Task<Company> GetCompanyById(string companyID)
        {
            throw new NotImplementedException();
        }

        //bool IfExistCompany(string companyID)
        //{
        //    throw new NotImplementedException();
        //}

        Task<Company> AddCompany(Company newCompany)
        {
            throw new NotImplementedException();
        }

        Task<Company> UpdateCompany(Company company)
        {
            throw new NotImplementedException();
        }

        Task DeleteCompany(string companyID)
        {
            throw new NotImplementedException();
        }
    }
}