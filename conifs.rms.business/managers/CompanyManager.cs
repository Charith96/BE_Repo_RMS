using AutoMapper;
using conifs.rms.business.validators;
using conifs.rms.data.entities;
using conifs.rms.data.repositories.Company;
using FluentValidation;
using conifs.rms.dto.Company;
using Microsoft.EntityFrameworkCore;
using conifs.rms.data;

namespace conifs.rms.business.managers
{
    public class CompanyManager : ICompanyManager
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;
        private readonly CompanyDataContext _context;

        public CompanyManager(ICompanyRepository companyRepository, IMapper mapper, CompanyDataContext context)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<CompanyDto>> GetAllCompanies()
        {

            var company = await _companyRepository.GetAllCompanies();

            return _mapper.Map<List<CompanyDto>>(company);

        }

        public async Task<CompanyDto> GetCompanyById(string companyID)
        {
            var company = await _companyRepository.GetCompanyById(companyID);

                return _mapper.Map<CompanyDto>(company) ?? new CompanyDto(); 
        }

        public async Task<CompanyDto> AddCompany(CompanyDto newCompanyDto)
        {
            Company newCompany = _mapper.Map<Company>(newCompanyDto);

            var validator = new CompanyValidator(_context, isNew: true);

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
            var validator = new CompanyValidator(_context, isNew: false);

            //validator.RuleFor(c => c.CompanyCode)
            //    .MustAsync(async (code, cancellation) =>
            //    {
            //        return !await _context.Companies
            //        .Where(c => c.CompanyID != updatedCompany.CompanyID)
            //        .AnyAsync(c => c.CompanyCode == code, cancellation);
            //    }).WithMessage("Company Code must be unique.");

            var validationResult = await validator.ValidateAsync(updatedCompany);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            existingCompany.CompanyCode = updatedCompany.CompanyCode;
            existingCompany.CompanyName = updatedCompany.CompanyName;
            existingCompany.Description = updatedCompany.Description;
            existingCompany.CountryID = updatedCompany.CountryID;
            existingCompany.CurrencyID = updatedCompany.CurrencyID;
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

