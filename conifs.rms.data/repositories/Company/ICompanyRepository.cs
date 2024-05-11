using conifs.rms.data.entities;

namespace conifs.rms.data.repositories.Company
{
    public interface ICompanyRepository
    {

        //public ICollection<entities.Company> GetAllCompanies();

        //public entities.Company GetCompanyById(Guid companyId);

        //void AddCompany(entities.Company company);

        //void UpdateCompany(entities.Company company);

        //void DeleteCompany(Guid companyId);

        Task<IEnumerable<entities.Company>> GetAllCompanies()
        {
            throw new NotImplementedException();
        }

        Task<entities.Company> GetCompanyById(Guid companyID)
        {
            throw new NotImplementedException();
        }

        Task<entities.Company> AddCompany(entities.Company newCompany)
        {
            throw new NotImplementedException();
        }

        Task<entities.Company> UpdateCompany(entities.Company company)
        {
            throw new NotImplementedException();
        }

        Task DeleteCompany(Guid companyID)
        {
            throw new NotImplementedException();
        }

        //Task<IEnumerable<entities.Company>> GetCompany();
        // Task<entities.Company> GetCompanyById(Guid companyId);
        // Task<entities.Company> AddCompany(entities.Company company);
        // Task<entities.Company> UpdateCompany(entities.Company company);
        // Task DeleteCompany(Guid companyId);

        //public Task<IEnumerable<entities.Company>> GetCompany();
        //public Task<entities.Company> GetCompanyById(Guid companyId);
        //public Task<entities.Company> AddCompany(entities.Company company);
        //public Task<entities.Company> UpdateCompany(entities.Company company);
        //public Task DeleteCompany(Guid companyId);
    }
}