//using conifs.rms.business.managers;
//using conifs.rms.data.entities;
//using Microsoft.AspNetCore.Mvc;
//using conifs.rms.data;
//using conifs.rms.data.repositories.Company;


//namespace conifs.rms.@base.api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CompanyController : ControllerBase
//    {

//        private readonly CompanyManager _companyManager;

//        public CompanyController(CompanyManager companyManager)
//        {
//            _companyManager = companyManager;

//        }


//        [HttpGet]
//        public async Task<IActionResult> GetAllCompanies()
//        {
//            try
//            {
//                var companies = await _companyManager.GetAllCompanies();
//                return Ok(companies);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Internal server error: {ex.Message}");
//            }
//        }

//        [HttpGet("{CompanyID}")]
//        public async Task<IActionResult> GetCompanyById(Guid CompanyID)
//        {
//            try
//            {
//                var company = await _companyManager.GetCompanyById(CompanyID); // Specify which overload to call
//                if (company == null)
//                {
//                    return NotFound();
//                }

//                return Ok(company);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Internal server error: {ex.Message}");
//            }
//        }

//        [HttpPost]
//        public async Task<IActionResult> AddCompany([FromBody] Company newCompany)
//        {
//            try
//            {
//                var addedCompany = await _companyManager.AddCompany(newCompany);
//                return CreatedAtAction(nameof(GetCompanyById), new { CompanyID = addedCompany.CompanyID }, addedCompany);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Internal server error: {ex.Message}");
//            }
//        }

//        [HttpPut("{CompanyID}")]
//        public async Task<IActionResult> UpdateCompany(Guid CompanyID, [FromBody] Company company)
//        {
//            try
//            {
//                if (CompanyID != company.CompanyID)
//                {
//                    return BadRequest("Company ID mismatch");
//                }

//                var updatedCompany = await _companyManager.UpdateCompany(company);
//                if (updatedCompany == null)
//                {
//                    return NotFound();
//                }

//                return Ok(updatedCompany);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Internal server error: {ex.Message}");
//            }
//        }

//        [HttpDelete("{CompanyID}")]
//        public async Task<IActionResult> DeleteCompany(Guid CompanyID)
//        {
//            try
//            {
//                await _companyManager.DeleteCompany(CompanyID);
//                return NoContent();
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Internal server error: {ex.Message}");
//            }
//        }
//    //[HttpPut]
//    //    public IActionResult UpdateCompany(Company company)
//    //    {
//    //        var updatedCompany =  _companyService.UpdateCompany(company);
//    //        if (updatedCompany == null)
//    //            return NotFound("Company not found.");


//    //        //dbcompanies.CompanyName = updatedCompanies.CompanyName;
//    //        //dbcompanies.Description = updatedCompanies.Description;
//    //        //dbcompanies.Country = updatedCompanies.Country;
//    //        //dbcompanies.Currency = updatedCompanies.Currency;
//    //        //dbcompanies.Address01 = updatedCompanies.Address01;
//    //        //dbcompanies.Address02 = updatedCompanies.Address02;
//    //        //dbcompanies.DefaultCompany = updatedCompanies.DefaultCompany;

//    //        return Ok(updatedCompany);
//    //    }
//    }
//}  


using conifs.rms.business.managers;
using conifs.rms.data.entities;
using Microsoft.AspNetCore.Mvc;
using conifs.rms.data;
using conifs.rms.data.repositories.Company;


namespace conifs.rms.@base.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private readonly ICompanyManager _companyManager;

        public CompanyController(ICompanyManager companyManager)
        {
            _companyManager = companyManager;

        }


        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            try
            {
                var companies = await _companyManager.GetAllCompanies();
                return Ok(companies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{CompanyID}")]
        public async Task<IActionResult> GetCompanyById(Guid CompanyID)
        {
            try
            {
                var companyID = Guid.Parse("your-guid-here"); // Convert string to Guid
                var company = await _companyManager.GetCompanyById(CompanyID); // Specify which overload to call
                if (company == null)
                {
                    return NotFound();
                }

                return Ok(company);
            }
            catch (FormatException)
            {
                return BadRequest("Invalid company ID format.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany([FromBody] Company newCompany)
        {
            try
            {
                var addedCompany = await _companyManager.AddCompany(newCompany);
                return CreatedAtAction(nameof(GetCompanyById), new { CompanyID = addedCompany.CompanyID }, addedCompany);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{CompanyID}")]
        public async Task<IActionResult> UpdateCompany(Guid CompanyID, [FromBody] Company company)
        {
            try
            {
                if (CompanyID != company.CompanyID)
                {
                    return BadRequest("Company ID mismatch");
                }

                var updatedCompany = await _companyManager.UpdateCompany(company);
                if (updatedCompany == null)
                {
                    return NotFound();
                }

                return Ok(updatedCompany);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{CompanyID}")]
        public async Task<IActionResult> DeleteCompany(Guid CompanyID)
        {
            try
            {
                await _companyManager.DeleteCompany(CompanyID);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        //[HttpPut]
        //    public IActionResult UpdateCompany(Company company)
        //    {
        //        var updatedCompany =  _companyService.UpdateCompany(company);
        //        if (updatedCompany == null)
        //            return NotFound("Company not found.");


        //        //dbcompanies.CompanyName = updatedCompanies.CompanyName;
        //        //dbcompanies.Description = updatedCompanies.Description;
        //        //dbcompanies.Country = updatedCompanies.Country;
        //        //dbcompanies.Currency = updatedCompanies.Currency;
        //        //dbcompanies.Address01 = updatedCompanies.Address01;
        //        //dbcompanies.Address02 = updatedCompanies.Address02;
        //        //dbcompanies.DefaultCompany = updatedCompanies.DefaultCompany;

        //        return Ok(updatedCompany);
        //    }
    }
}

