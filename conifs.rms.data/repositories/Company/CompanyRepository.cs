using System;
using System.Collections.Generic;
using System.Linq;
using conifs.rms.data.entities;
using Microsoft.EntityFrameworkCore;

namespace conifs.rms.data.repositories.Company
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<entities.Company>> GetAllCompanies()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<entities.Company> GetCompanyById(string id)
        {


            var company = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyID.ToString() == id);

            return company ?? new entities.Company();
        }


        public async Task<entities.Company> AddCompany(entities.Company newCompany)
        {

            _context.Companies.Add(newCompany);
            await _context.SaveChangesAsync();
            return newCompany;
        }

        public async Task<entities.Company> UpdateCompany(entities.Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
            return company;
        }

        public async Task DeleteCompany(string id)
        {
            var company = await _context.Companies.FirstOrDefaultAsync(c => c.CompanyID.ToString() == id);
            if (company != null)
            {
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> CompanyHasUsers(string companyID)
        {
            return await _context.UserCompany.AnyAsync(uc => uc.CompanyId.ToString() == companyID);
        }
    }
}