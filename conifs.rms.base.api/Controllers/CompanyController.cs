using conifs.rms.business.managers;
using conifs.rms.data.entities;
using Microsoft.AspNetCore.Mvc;
using conifs.rms.data;
using conifs.rms.data.repositories.Company;
using Microsoft.Extensions.Logging;


namespace conifs.rms.@base.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private readonly ICompanyManager _companyManager;
        //  private readonly ILogger<CompanyController> _logger;

        //public CompanyController(ICompanyManager companyManager, ILogger<CompanyController> logger)
        //{
        //    _companyManager = companyManager;
        //    _logger = logger;

        //}

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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyById(string id)
        {
            try
            {
                //if (!Guid.TryParse(id, out var guid))
                //{
                //    return BadRequest("Invalid GUID format.");
                //}

                var company = await _companyManager.GetCompanyById(id);
                if (company == null)
                {
                    return NotFound();
                }

                return Ok(company);
            }
            catch (Exception ex)
            {
               // _logger.LogError(ex, "Error fetching company by ID.");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    [HttpPost]
        public async Task<IActionResult> AddCompany([FromBody] Company newCompany)
        {
            try
            {
                var addedCompany = await _companyManager.AddCompany(newCompany);
               // return CreatedAtAction(nameof(GetCompanyById), new { id = addedCompany.CompanyID }, addedCompany);
                return CreatedAtAction(nameof(GetCompanyById), new { id = newCompany.CompanyID }, newCompany);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(string id, [FromBody] Company company)
        {
            try
            {
                if (id != company.CompanyID.ToString())
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(string id)
        {
            try
            {
                await _companyManager.DeleteCompany(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
