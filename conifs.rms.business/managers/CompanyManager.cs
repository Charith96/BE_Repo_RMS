using conifs.rms.data.entities;
using conifs.rms.data.repositories.Company;

namespace conifs.rms.business.managers
{
    public class CompanyManager : ICompanyManager
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyManager(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        //public IEnumerable<Company> GetAllCompanies() 
        //{ 
        //    return _companyRepository.GetAllCompanies().Result; //Result added because the error
        //}

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await _companyRepository.GetAllCompanies();
        }

        public async Task<Company> GetCompanyById(Guid companyID) // Renamed from CompanyID to companyId
        {
            return await _companyRepository.GetCompanyById(companyID);
        }

        //public void AddCompany(Company newCompany) 
        //{
        // _companyRepository.AddCompany(newCompany);
        //}

        public async Task<Company> AddCompany(Company newCompany)
        {
            return await _companyRepository.AddCompany(newCompany);
        }

        //public void UpdateCompany(Company Company) 
        //{
        //    _companyRepository.UpdateCompany(Company);
        //}

        //public async Task<Company> UpdateCompany(Company company)
        //{
        //    return await _companyRepository.UpdateCompany(company);
        //}

        public async Task<Company> UpdateCompany(Company updatedCompany)
        {
            // Check if the CompanyID is null
            if (updatedCompany.CompanyID == null)
            {
                throw new ArgumentException("CompanyID cannot be null");
            }

            // Retrieve the existing company from the database
            var existingCompany = await _companyRepository.GetCompanyById(updatedCompany.CompanyID.Value);

            // If the company does not exist, throw an exception
            if (existingCompany == null)
            {
                throw new Exception($"Company with ID {updatedCompany.CompanyID} not found.");
            }

            // Update the properties of the existing company with values from the updatedCompany
            existingCompany.CompanyName = updatedCompany.CompanyName;
            existingCompany.Description = updatedCompany.Description;
            existingCompany.Country = updatedCompany.Country;
            existingCompany.Currency = updatedCompany.Currency;
            existingCompany.Address01 = updatedCompany.Address01;
            existingCompany.Address02 = updatedCompany.Address02;
            existingCompany.DefaultCompany = updatedCompany.DefaultCompany;

            // Save the changes to the database
            await _companyRepository.UpdateCompany(existingCompany);

            // Return the updated company
            return existingCompany;
        }




        //public void DeleteCompany(Guid companyID) 
        //{
        //    _companyRepository.DeleteCompany(companyID);
        //}

        public async Task DeleteCompany(Guid companyID)
        {
            await _companyRepository.DeleteCompany(companyID);
        }
    }
}
