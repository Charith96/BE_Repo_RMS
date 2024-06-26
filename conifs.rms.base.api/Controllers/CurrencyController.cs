using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using conifs.rms.business.managers;
using conifs.rms.dto.Company;

namespace conifs.rms.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyManager _currencyManager;

        public CurrencyController(ICurrencyManager currencyManager)
        {
            _currencyManager = currencyManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCurrencies()
        {
            try
            {
                var currencies = await _currencyManager.GetAllCurrencies();
                return Ok(currencies);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCurrencyById(Guid id)
        {
            try
            {
                var currency = await _currencyManager.GetCurrencyById(id);
                if (currency == null)
                {
                    return NotFound();
                }
                return Ok(currency);
            }
            catch (Exception ex)
            {
                // _logger.LogError(ex, "Error fetching company by ID.");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddCurrency([FromBody] CurrencyDto newCurrencyDto)
        {
            try
            {
                var addedCurrency = await _currencyManager.AddCurrency(newCurrencyDto);
                return Ok(addedCurrency);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCurrency(Guid id, [FromBody] CurrencyDto updatedCurrencyDto)
        {
            try
            {
                if (id != updatedCurrencyDto.CurrencyID)
                {
                    return BadRequest("Currency ID mismatch");
                }
                var updatedCurrency = await _currencyManager.UpdateCurrency(updatedCurrencyDto);
                if(updatedCurrency == null)
                {
                    return NotFound();
                }
                return Ok(updatedCurrency);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurrency(Guid id)
        {
            try
            {
                await _currencyManager.DeleteCurrency(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }
    }
}
