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
        public async Task<ActionResult<List<CurrencyDto>>> GetAllCurrencies()
        {
            var currencies = await _currencyManager.GetAllCurrenciesAsync();
            return Ok(currencies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CurrencyDto>> GetCurrencyById(int id)
        {
            var currency = await _currencyManager.GetCurrencyByIdAsync(id);
            if (currency == null)
            {
                return NotFound();
            }
            return Ok(currency);
        }

        [HttpPost]
        public async Task<IActionResult> AddCurrency(CurrencyDto currencyDto)
        {
            await _currencyManager.AddCurrencyAsync(currencyDto);
            return CreatedAtAction(nameof(GetCurrencyById), new { id = currencyDto.CurrencyID }, currencyDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCurrency(int id, CurrencyDto currencyDto)
        {
            if (id != currencyDto.CurrencyID)
            {
                return BadRequest();
            }
            await _currencyManager.UpdateCurrencyAsync(currencyDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurrency(int id)
        {
            await _currencyManager.DeleteCurrencyAsync(id);
            return NoContent();
        }
    }
}
