using conifs.rms.data.entities;

namespace conifs.rms.data.repositories.Company
{
    public interface ICompanyRepository
    {

        Task<IEnumerable<entities.Company>> GetAllCompanies()
        {
            throw new NotImplementedException();
        }

        Task<entities.Company> GetCompanyById(string companyID)
        {
            throw new NotImplementedException();
        }

    //    bool IfExistCompany(string companyID)
    //    {
    //        throw new NotImplementedException();
    //}

    Task<entities.Company> AddCompany(entities.Company newCompany)
        {
            throw new NotImplementedException();
        }

        Task<entities.Company> UpdateCompany(entities.Company company)
        {
            throw new NotImplementedException();
        }

        Task DeleteCompany(string companyID)
        {
            throw new NotImplementedException();
        }
    }
}