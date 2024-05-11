//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using conifs.rms.data.entities;
//using conifs.rms.data.repositories.Company;
//using Microsoft.EntityFrameworkCore;


//namespace conifs.rms.data.repositories.Company
//{
//    public class CompanyRepository : ICompanyRepository
//    {
//        //AddCompany();
//        //_context.Companies.Add(companies);

//        private readonly CompanyDataContext _context;

//        public CompanyRepository(CompanyDataContext context) 
//        {  
//            _context = context; 
//        }

//        public IEnumerable<entities.Company> GetAllCompanies()
//        {
//            return _context.Companies.ToList();
//        }
//        //public async Task<IEnumerable<entities.Company>> GetAllCompanies()
//        //{
//        //    return await _context.Companies.ToListAsync();
//        //}

//        public entities.Company GetCompanyById(Guid companyID) 
//        {
//            var company = _context.Companies.Find(companyID);
//            return company ?? throw new Exception($"Company with ID {companyID} not found.");
//        }

//        //public async Task<entities.Company> GetCompanyById(Guid companyId)
//        //{
//        //    var company = await _context.Companies.FindAsync(companyId);
//        //    return company ?? throw new Exception($"Company with ID {companyId} not found.");
//        //}



//        //public async Task<entities.Company> AddCompany(entities.Company newCompany)
//        //{
//        //    _context.Companies.Add(newCompany);
//        //    await _context.SaveChangesAsync();
//        //    return newCompany;
//        //}

//        public void AddCompany(entities.Company newCompany)
//        {
//            _context.Companies.Add(newCompany);
//            _context.SaveChanges();
//        }

//        public void UpdateCompany(entities.Company company)
//        {
//            _context.Companies.Update(company);
//            _context.SaveChanges();
//        }

//        public void DeleteCompany(Guid companyID)
//        {
//            var company =  _context.Companies.Find(companyID);
//            if (company != null)
//            {
//                _context.Companies.Remove(company);
//                 _context.SaveChanges();
//            }
//        }



//        //public async Task<entities.Company> UpdateCompany(entities.Company company)
//        //{
//        //    _context.Entry(company).State = EntityState.Modified;
//        //    await _context.SaveChangesAsync();
//        //    return company;
//        //}

//        //public async Task DeleteCompany(Guid companyId)
//        //{
//        //    var company = await _context.Companies.FindAsync(companyId);
//        //    if (company != null)
//        //    {
//        //        _context.Companies.Remove(company);
//        //        await _context.SaveChangesAsync();
//        //    }



//    }
//}


using System;
using System.Collections.Generic;
using System.Linq;
using conifs.rms.data.entities;
using Microsoft.EntityFrameworkCore;

namespace conifs.rms.data.repositories.Company
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CompanyDataContext _context;

        public CompanyRepository(CompanyDataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<entities.Company>> GetAllCompanies()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<entities.Company> GetCompanyById(Guid companyID)
        {
            var company = await _context.Companies.FindAsync(companyID);
            return company ?? throw new Exception($"Company with ID {companyID} not found.");
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

        public async Task DeleteCompany(Guid companyID)
        {
            var company = await _context.Companies.FindAsync(companyID);
            if (company != null)
            {
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();
            }
        }
    }
}
