using conifs.rms.data.entities;
using conifs.rms.data.repositories.Company;
using conifs.rms.business.validators;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentValidation;

namespace conifs.rms.business.managers
{
    public class CompanyManager : ICompanyManager
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyManager(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await _companyRepository.GetAllCompanies();
        }

        public async Task<Company> GetCompanyById(string companyID)
        {
            return await _companyRepository.GetCompanyById(companyID);
        }

        public async Task<Company> AddCompany(Company newCompany)
        {
            // Create an instance of the CompanyValidator
            var validator = new CompanyValidator();

            // Validate the new company object
            var validationResult = await validator.ValidateAsync(newCompany);

            if (!validationResult.IsValid)
            {
                // Handle validation errors
                throw new ValidationException(validationResult.Errors);
            }

            // If validation passes, add the new company
            return await _companyRepository.AddCompany(newCompany);
        }

        public async Task<Company> UpdateCompany(Company updatedCompany)
        {
            var existingCompany = await _companyRepository.GetCompanyById(updatedCompany.CompanyID.ToString());

            if (existingCompany == null)
            {
                throw new Exception($"Company with ID {updatedCompany.CompanyID} not found.");
            }

            // Create an instance of the CompanyValidator
            var validator = new CompanyValidator();

            // Validate the updated company object
            var validationResult = await validator.ValidateAsync(updatedCompany);

            if (!validationResult.IsValid)
            {
                // Handle validation errors
                throw new ValidationException(validationResult.Errors);
            }

            existingCompany.CompanyCode = updatedCompany.CompanyCode;
            existingCompany.CompanyName = updatedCompany.CompanyName;
            existingCompany.Description = updatedCompany.Description;
            existingCompany.Country = updatedCompany.Country;
            existingCompany.Currency = updatedCompany.Currency;
            existingCompany.Address01 = updatedCompany.Address01;
            existingCompany.Address02 = updatedCompany.Address02;
            existingCompany.DefaultCompany = updatedCompany.DefaultCompany;

            await _companyRepository.UpdateCompany(existingCompany);

            return existingCompany;
        }

        public async Task DeleteCompany(string companyID)
        {
            await _companyRepository.DeleteCompany(companyID);
        }
    }
}
