using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using conifs.rms.business;
using conifs.rms.business.managers;
using conifs.rms.dto.Company;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryDto>>> GetAllCountries()
        {
            var countries = await _countryManager.GetAllCountriesAsync();
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountryById(int id)
        {
            var country = await _countryManager.GetCountryByIdAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

        [HttpPost]
        public async Task<ActionResult> AddCountry([FromBody] CountryDto countryDto)
        {
            await _countryManager.AddCountryAsync(countryDto);
            return CreatedAtAction(nameof(GetCountryById), new { id = countryDto.CountryID }, countryDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCountry(int id, [FromBody] CountryDto countryDto)
        {
            if (id != countryDto.CountryID)
            {
                return BadRequest();
            }
            await _countryManager.UpdateCountryAsync(countryDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCountry(int id)
        {
            await _countryManager.DeleteCountryAsync(id);
            return NoContent();
        }
    }
}
