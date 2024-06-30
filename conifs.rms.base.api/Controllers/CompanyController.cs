using AutoMapper;
using conifs.rms.business.managers;
using conifs.rms.data.entities;
using conifs.rms.dto.Company;
using Microsoft.AspNetCore.Mvc;


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
    //_mapper = mapper;
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
        public async Task<IActionResult> AddCompany([FromBody] CompanyDto newCompanyDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var addedCompany = await _companyManager.AddCompany(newCompanyDto);
                // If AddCompany provides the ID, you can use CreatedAtAction
                return CreatedAtAction(nameof(GetCompanyById), new { id = addedCompany.CompanyID }, addedCompany);
            }
            catch (Exception ex)
            {
                // Consider logging the error here
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompany(string id, [FromBody] CompanyDto updatedCompanyDto)
        {
            try
            {
                if (id != updatedCompanyDto.CompanyID.ToString())
                {
                    return BadRequest("Company ID mismatch");
                }

                var updatedCompany = await _companyManager.UpdateCompany(updatedCompanyDto);
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
        //public async Task<IActionResult> DeleteCompany(string id)
        //{
        //    try
        //    {
        //        await _companyManager.DeleteCompany(id);
        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}


        public async Task<IActionResult> DeleteCompany(string id)
        {
            try
            {
                await _companyManager.DeleteCompany(id);
                return NoContent();
            }
            catch (InvalidOperationException ex) when (ex.Message == "Cannot delete company with associated users.")
            {
                return BadRequest("Cannot delete company with associated users.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
