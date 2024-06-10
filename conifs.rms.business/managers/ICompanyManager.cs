using conifs.rms.data.entities;
using conifs.rms.dto.Company;
using System.Threading.Tasks;

namespace conifs.rms.business.managers
{
    public interface ICompanyManager
    {

        Task<IEnumerable<CompanyDto>> GetAllCompanies()
        {
            throw new NotImplementedException();
        }

        Task<CompanyDto> GetCompanyById(string companyID)
        {
            throw new NotImplementedException();
        }

        Task<CompanyDto> AddCompany(CompanyDto newCompanyDto)
        {
            throw new NotImplementedException();
        }

        Task<CompanyDto> UpdateCompany(CompanyDto updatedCompanyDto)
        {
            throw new NotImplementedException();
        }

        Task DeleteCompany(string companyID)
        {
            throw new NotImplementedException();
        }

    }
}