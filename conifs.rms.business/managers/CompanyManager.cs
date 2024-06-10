using AutoMapper;
using conifs.rms.business.validators;
using conifs.rms.data.entities;
using conifs.rms.data.repositories.Company;
using FluentValidation;
using conifs.rms.dto.Company;
using Microsoft.EntityFrameworkCore;

namespace conifs.rms.business.managers
{
    public class CompanyManager : ICompanyManager
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyManager(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CompanyDto>> GetAllCompanies()
        {

            var company = await _companyRepository.GetAllCompanies();

            return _mapper.Map<List<CompanyDto>>(company);

        }

        public async Task<CompanyDto> GetCompanyById(string companyID)
        {
            var company = await _companyRepository.GetCompanyById(companyID);

                return _mapper.Map<CompanyDto>(company) ?? new CompanyDto(); ;
        }

        public async Task<CompanyDto> AddCompany(CompanyDto newCompanyDto)
        {
            Company newCompany = _mapper.Map<Company>(newCompanyDto);

            var validator = new CompanyValidator();

            var validationResult = await validator.ValidateAsync(newCompany);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var addedCompany = await _companyRepository.AddCompany(newCompany);

            newCompanyDto.CompanyID = addedCompany.CompanyID;

            return newCompanyDto;

        }

        public async Task<CompanyDto> UpdateCompany(CompanyDto updatedCompanyDto)
        {
            var existingCompany = await _companyRepository.GetCompanyById(updatedCompanyDto.CompanyID.ToString());

            if (existingCompany == null)
            {
                throw new Exception($"Company with ID {updatedCompanyDto.CompanyID} not found.");
            }

            var updatedCompany = _mapper.Map<Company>(updatedCompanyDto);
            var validator = new CompanyValidator();
            var validationResult = await validator.ValidateAsync(updatedCompany);

            if (!validationResult.IsValid)
            {
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

            // Update the existing company with the new values
            var updatedCompanyEntity = await _companyRepository.UpdateCompany(existingCompany);

            // Map the updated entity back to a DTO and return it
            return _mapper.Map<CompanyDto>(updatedCompanyEntity);
        }

        public async Task DeleteCompany(string companyID)
        {
             await _companyRepository.DeleteCompany(companyID);

        }
    }
}

