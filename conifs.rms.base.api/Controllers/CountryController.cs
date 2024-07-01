using conifs.rms.business.managers;
using conifs.rms.dto.Company;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace conifs.rms.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryManager _countryManager;

        public CountryController(ICountryManager countryManager)
        {
            _countryManager = countryManager;
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            try
            {
                var countries = await _countryManager.GetAllCountries();
                return Ok(countries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("{countryId}")]
        public async Task<IActionResult> GetCountryById(Guid countryId)
        {
            try
            {
                var country = await _countryManager.GetCountryById(countryId);
                if (country == null)
                {
                    return NotFound();
                }
                return Ok(country);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPost]
        public async Task<IActionResult> AddCountry([FromBody] CountryDto newCountryDto)
        {
            try
            {
                var addedCountry = await _countryManager.AddCountry(newCountryDto);
                return Ok(addedCountry);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
            
           // return CreatedAtAction(nameof(GetCountryById), new { id = countryDto.CountryID }, countryDto);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCountry(Guid id, [FromBody] CountryDto updatedCountryDto)
        {
            try
            {
                if (id != updatedCountryDto.CountryID)
                {
                    return BadRequest("Country ID mismatch");
                }
               var updatedCountry = await _countryManager.UpdateCountry(updatedCountryDto);
                if(updatedCountry != null)
                {
                    return NotFound();
                }
                return Ok(updatedCountry);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
           
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("{countryId}")]
        public async Task<IActionResult> DeleteCountry(Guid countryId)
        {
            try
            {
                await _countryManager.DeleteCountry(countryId);
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
            
        }
    }
}
